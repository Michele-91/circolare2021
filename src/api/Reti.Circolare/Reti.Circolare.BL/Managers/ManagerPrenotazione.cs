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
    public class ManagerPrenotazione
    {
        private IUnitOfWork unitOfWork;
        public ManagerPrenotazione(IUnitOfWork iUnitOfWork)
        {
            this.unitOfWork = iUnitOfWork;
        }
        public int Add(DTOPrenotazione_Crea dtoPrenotazioneCrea)
        {
            try
            {
                DTOPrenotazione dtoPrenotazione = UtilitiesPrenotazione.Prenotazione_ConvertiDTOCreaInDTO(dtoPrenotazioneCrea);

                TBW_Prenotazione nuovaPrenotazione = MapperPrenotazione.Prenotazione_ConvertiDTOInEntity(dtoPrenotazione);

                var listaPrenotazioniEsistenti = unitOfWork.PrenotazioneRepository.GetAll().ToList();
                foreach (TBW_Prenotazione prenotazioneEsistente in listaPrenotazioniEsistenti)
                {
                    if ((prenotazioneEsistente.Inizio > nuovaPrenotazione.Inizio && prenotazioneEsistente.Inizio < nuovaPrenotazione.Fine) ||
                        (prenotazioneEsistente.Fine < nuovaPrenotazione.Fine && prenotazioneEsistente.Fine > nuovaPrenotazione.Inizio))
                    {
                        unitOfWork.RollBack();
                        throw new Exception("La seguente prenotazione non può essere creata perché entra in conflitto con prenotazioni già esistenti");
                    }
                }
                unitOfWork.PrenotazioneRepository.Add(nuovaPrenotazione);
                unitOfWork.Commit();
                return nuovaPrenotazione.ID;
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message);
            }

        }

        public int Delete(int dtoPrenotazioneId)
        {
            TBW_Prenotazione prenotazione = unitOfWork.PrenotazioneRepository.Where(p => p.ID == dtoPrenotazioneId).SingleOrDefault();

            unitOfWork.PrenotazioneRepository.Delete(prenotazione);
            unitOfWork.Commit();
            return prenotazione.ID;
        }

        public List<DTOPrenotazione_Mostra> GetAll()
        {
            try
            {
                List<TBW_Prenotazione> listaPrenotazioni;
                List<DTOPrenotazione_Mostra> listaPrenotazioniDTOMostra = new List<DTOPrenotazione_Mostra>();
                listaPrenotazioni = unitOfWork.PrenotazioneRepository.GetAll().ToList();

                foreach (TBW_Prenotazione prenotazione in listaPrenotazioni)
                {
                    listaPrenotazioniDTOMostra.Add(MapperPrenotazione.Prenotazione_ConvertiEntityInDTOMostra(prenotazione));
                }

                return listaPrenotazioniDTOMostra;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<DTOPrenotazione_Mostra> Filter(string testoInput)
        {
            try
            {
                List<TBW_Prenotazione> listaPrenotazioni;
                if (String.IsNullOrWhiteSpace(testoInput))
                {
                    listaPrenotazioni = unitOfWork.PrenotazioneRepository.GetAll().ToList();

                } 
                else
                {
                    listaPrenotazioni = unitOfWork.PrenotazioneRepository.GetAll().Where(p => p.Descrizione.Contains(testoInput)).ToList();
                }

                List<DTOPrenotazione_Mostra> listaPrenotazioniDTOMostra = new List<DTOPrenotazione_Mostra>();
                foreach (TBW_Prenotazione prenotazione in listaPrenotazioni)
                {
                    listaPrenotazioniDTOMostra.Add(MapperPrenotazione.Prenotazione_ConvertiEntityInDTOMostra(prenotazione));
                }
                return listaPrenotazioniDTOMostra;
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message);
            }

        }
    }
}
