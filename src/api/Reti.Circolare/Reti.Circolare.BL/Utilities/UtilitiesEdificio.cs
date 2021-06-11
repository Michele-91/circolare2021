using Reti.Circolare.BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reti.Circolare.BL.Utilities
{
    public static class UtilitiesEdificio
    {
        public static DTOEdificio Edificio_ConvertiDTOCreaInDTO(DTOEdificio_Crea dtoEdificioCrea)
        {
            DTOEdificio dtoEdificio = new DTOEdificio()
            {
                Nome = dtoEdificioCrea.Nome,
                Indirizzo = dtoEdificioCrea.Indirizzo,
                Disponibile = dtoEdificioCrea.Disponibile
            };

            return dtoEdificio;
        }
    }
}
