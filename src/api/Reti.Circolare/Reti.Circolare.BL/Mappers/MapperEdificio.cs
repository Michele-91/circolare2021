using Reti.Circolare.BL.DTO;
using Reti.Circolare.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reti.Circolare.BL.Mappers
{
    public class MapperEdificio
    {
        public static TBW_Edificio Edificio_ConvertiDTOInEntity(DTOEdificio dtoEdificio)
        {
            TBW_Edificio entityEdificio = new TBW_Edificio()
            {
                ID = dtoEdificio.ID,
                Nome = dtoEdificio.Nome,
                Indirizzo = dtoEdificio.Indirizzo,
                Disponibile = dtoEdificio.Disponibile,
            };

            return entityEdificio;
        }

        public static DTOEdificio Edificio_ConvertiEntityInDTO(TBW_Edificio entityEdificio)
        {
            DTOEdificio dtoEdificio = new DTOEdificio()
            {
                ID = entityEdificio.ID,
                Nome = entityEdificio.Nome,
                Indirizzo = entityEdificio.Indirizzo,
                Disponibile = entityEdificio.Disponibile,
            };

            return dtoEdificio;
        }

        public static DTOEdificio_Mostra Edificio_ConvertiEntityInDTOMostra(TBW_Edificio entityEdificio)
        {
            DTOEdificio_Mostra dtoEdificioMostra = new DTOEdificio_Mostra()
            {
                ID = entityEdificio.ID,
                Nome = entityEdificio.Nome,
                Indirizzo = entityEdificio.Indirizzo,
                Disponibile = entityEdificio.Disponibile
            };

            return dtoEdificioMostra;
        }
    }
}
