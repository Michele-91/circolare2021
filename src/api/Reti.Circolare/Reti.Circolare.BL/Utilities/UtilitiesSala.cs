using Reti.Circolare.BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reti.Circolare.BL.Utilities
{
    public static class UtilitiesSala
    {
        public static DTOSala Edificio_ConvertiDTOCreaInDTO(DTOSala_Crea dtoSalaCrea)
        {
            DTOSala dtoSala = new DTOSala()
            {
                Nome = dtoSalaCrea.Nome,
                EdificioId = dtoSalaCrea.EdificioId
            };

            return dtoSala;
        }
    }
}
