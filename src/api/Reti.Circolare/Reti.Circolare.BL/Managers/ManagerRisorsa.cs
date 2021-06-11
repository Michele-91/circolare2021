using Reti.Circolare.BL.DTO;
using Reti.Circolare.BL.Mappers;
using Reti.Circolare.BL.Utilities;
using Reti.Circolare.DAL.Entities;
using Reti.Circolare.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reti.Circolare.BL.Managers
{
    public class ManagerRisorsa
    {
        private IUnitOfWork unitOfWork;
        public ManagerRisorsa(IUnitOfWork iUnitOfWork)
        {
            this.unitOfWork = iUnitOfWork;
        }

        public Guid Add(DTORisorsa_Crea dtoRisorsaCrea)
        {
            try
            {
                DTORisorsa dtoRisorsa = UtilitiesRisorsa.Risorsa_ConvertiDTOCreaInDTO(dtoRisorsaCrea);
                // genera username di base
                dtoRisorsa.UserName = UtilitiesRisorsa.Risorsa_GeneraUsername(dtoRisorsa.Nome, dtoRisorsa.Cognome).ToLower();
                var utenzeSimili = unitOfWork.RisorsaRepository.GetAll()
                                                   .Where(u => u.Nome.ToLower() == dtoRisorsa.Nome.ToLower() && u.Cognome.ToLower() == dtoRisorsa.Cognome.ToLower());
                // completa username con suffisso
                int cifraUtente = UtilitiesRisorsa.Risorsa_AggiungiCifraDiSuffissoPerUsername(utenzeSimili);
                dtoRisorsa.UserName += cifraUtente;
                // genera email reti utilizzando nome, cognome, suffisso dello username
                dtoRisorsa.EmailReti = $"{dtoRisorsa.Nome.ToLower()}.{dtoRisorsa.Cognome.ToLower()}{cifraUtente}@reti.it";

                TBW_Risorsa risorsa = MapperRisorsa.Risorsa_ConvertiDTOInEntity(dtoRisorsa);

                unitOfWork.RisorsaRepository.Add(risorsa);
                unitOfWork.Commit();
                return risorsa.ID;
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message);
            }

        }

        public Guid CambiaAbilitazioneRisorsa(Guid dtoRisorsaId)
        {
            try
            {
                var risorsa = unitOfWork.RisorsaRepository.GetAll().Where(r => r.ID == dtoRisorsaId).SingleOrDefault();
                risorsa.Abilitato = !risorsa.Abilitato;
                unitOfWork.RisorsaRepository.Update(risorsa);
                unitOfWork.Commit();
                return risorsa.ID;
            } 
            catch(Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message);
            }
        }

        public List<DTORisorsa_Mostra> GetAll()
        {
            //List<TBW_Risorsa> listaRisorse;
            //List<DTORisorsa> listaRisorseDTO = new List<DTORisorsa>();
            //listaRisorse = unitOfWork.RisorsaRepository.GetAll().ToList();

            //foreach (TBW_Risorsa risorsa in listaRisorse)
            //{
            //    listaRisorseDTO.Add(MapperRisorsa.Risorsa_ConvertiEntityInDTO(risorsa));
            //}
            try
            {
                List<TBW_Risorsa> listaRisorse;
                List<DTORisorsa_Mostra> listaRisorseDTOMostra = new List<DTORisorsa_Mostra>();
                listaRisorse = unitOfWork.RisorsaRepository.GetAll().ToList();

                foreach (TBW_Risorsa risorsa in listaRisorse)
                {
                    listaRisorseDTOMostra.Add(MapperRisorsa.Risorsa_ConvertiEntityInDTOMostra(risorsa));
                }

                return listaRisorseDTOMostra;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
