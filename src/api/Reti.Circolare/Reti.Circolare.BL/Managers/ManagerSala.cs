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
    public class ManagerSala
    {
        private IUnitOfWork unitOfWork;
        public ManagerSala(IUnitOfWork iUnitOfWork)
        {
            this.unitOfWork = iUnitOfWork;
        }
        public int Add(DTOSala_Crea dtoSalaCrea)
        {
            try
            {
                DTOSala dtoSala = UtilitiesSala.Edificio_ConvertiDTOCreaInDTO(dtoSalaCrea);

                TBW_Sala sala = MapperSala.Sala_ConvertiDTOInEntity(dtoSala);
                unitOfWork.SalaRepository.Add(sala);
                unitOfWork.Commit();
                return sala.ID;
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message);
            }

        }

        public List<DTOSala_Mostra> GetAll()
        {
            try
            {
                List<TBW_Sala> listaSale;
                List<DTOSala_Mostra> listaSaleDTOMostra = new List<DTOSala_Mostra>();
                listaSale = unitOfWork.SalaRepository.GetAll().ToList();

                foreach (TBW_Sala sala in listaSale)
                {
                    listaSaleDTOMostra.Add(MapperSala.Sala_ConvertiEntityInDTOMostra(sala));
                }
                return listaSaleDTOMostra;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
