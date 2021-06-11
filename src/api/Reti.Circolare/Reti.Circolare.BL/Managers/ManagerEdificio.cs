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
    public class ManagerEdificio
    {
        private IUnitOfWork unitOfWork;
        public ManagerEdificio(IUnitOfWork iUnitOfWork)
        {
            this.unitOfWork = iUnitOfWork;
        }
        public int Add(DTOEdificio_Crea dtoEdificioCrea)
        {
            try
            {
                DTOEdificio dtoEdificio = UtilitiesEdificio.Edificio_ConvertiDTOCreaInDTO(dtoEdificioCrea);
                //int cifraEdificio = unitOfWork.EdificioRepository.GetAll().ToList().Count + 1;
                //dtoEdificio.ID = cifraEdificio;

                TBW_Edificio edificio = MapperEdificio.Edificio_ConvertiDTOInEntity(dtoEdificio);
                unitOfWork.EdificioRepository.Add(edificio);
                unitOfWork.Commit();
                return edificio.ID;
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                throw new Exception(ex.Message);
            }

        }

        public List<DTOEdificio_Mostra> GetAll()
        {
            try
            {
                List<TBW_Edificio> listaEdifici;
                List<DTOEdificio_Mostra> listaEdificiDTOMostra = new List<DTOEdificio_Mostra>();
                listaEdifici = unitOfWork.EdificioRepository.GetAll().ToList();

                foreach (TBW_Edificio edificio in listaEdifici)
                {
                    listaEdificiDTOMostra.Add(MapperEdificio.Edificio_ConvertiEntityInDTOMostra(edificio));
                }

                return listaEdificiDTOMostra;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
