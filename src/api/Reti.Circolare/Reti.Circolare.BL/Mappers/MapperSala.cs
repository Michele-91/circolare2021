using Reti.Circolare.BL.DTO;
using Reti.Circolare.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reti.Circolare.BL.Mappers
{
    public class MapperSala
    {
        public static TBW_Sala Sala_ConvertiDTOInEntity(DTOSala dtoSala)
        {
            TBW_Sala entitySala = new TBW_Sala()
            {
                ID = dtoSala.ID,
                Nome = dtoSala.Nome,
                EdificioId = dtoSala.EdificioId
            };

            return entitySala;
        }

        public static DTOSala Sala_ConvertiEntityInDTO(TBW_Sala entitySala)
        {
            DTOSala dtoEdificio = new DTOSala()
            {
                ID = entitySala.ID,
                Nome = entitySala.Nome,
                EdificioId = entitySala.EdificioId
            };

            return dtoEdificio;
        }

        public static DTOSala_Mostra Sala_ConvertiEntityInDTOMostra(TBW_Sala entitySala)
        {
            DTOSala_Mostra dtoSalaMostra = new DTOSala_Mostra()
            {
                ID = entitySala.ID,
                Nome = entitySala.Nome,
                EdificioId = entitySala.EdificioId
            };

            return dtoSalaMostra;
        }
    }
}
