using Reti.Circolare.BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reti.Circolare.BL.Utilities
{
    public static class UtilitiesPrenotazione
    {
        public static DTOPrenotazione Prenotazione_ConvertiDTOCreaInDTO(DTOPrenotazione_Crea dtoPrenotazioneCrea)
        {
            DTOPrenotazione dtoPrenotazione = new DTOPrenotazione()
            {
                Descrizione = dtoPrenotazioneCrea.Descrizione,
                RisorsaId = dtoPrenotazioneCrea.RisorsaId,
                SalaId = dtoPrenotazioneCrea.SalaId,
                Inizio = dtoPrenotazioneCrea.Inizio,
                Fine = dtoPrenotazioneCrea.Fine
            };

            return dtoPrenotazione;
        }
    }
}
