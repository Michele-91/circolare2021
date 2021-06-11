using Reti.Circolare.BL.DTO;
using Reti.Circolare.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reti.Circolare.BL.Mappers
{
    public class MapperPrenotazione
    {
        public static TBW_Prenotazione Prenotazione_ConvertiDTOInEntity(DTOPrenotazione dtoPrenotazione)
        {
            TBW_Prenotazione entityPrenotazione = new TBW_Prenotazione()
            {
                Descrizione = dtoPrenotazione.Descrizione,
                RisorsaId = dtoPrenotazione.RisorsaId,
                SalaId = dtoPrenotazione.SalaId,
                Inizio = dtoPrenotazione.Inizio,
                Fine = dtoPrenotazione.Fine,
            };

            return entityPrenotazione;
        }

        public static DTOPrenotazione Prenotazione_ConvertiEntityInDTO(TBW_Prenotazione entityPrenotazione)
        {
            DTOPrenotazione dtoPrenotazione = new DTOPrenotazione()
            {
                Descrizione = entityPrenotazione.Descrizione,
                RisorsaId = entityPrenotazione.RisorsaId,
                SalaId = entityPrenotazione.SalaId,
                Inizio = entityPrenotazione.Inizio,
                Fine = entityPrenotazione.Fine
            };

            return dtoPrenotazione;
        }

        public static DTOPrenotazione_Mostra Prenotazione_ConvertiEntityInDTOMostra(TBW_Prenotazione entityPrenotazione)
        {
            DTOPrenotazione_Mostra dtoPrenotazioneMostra = new DTOPrenotazione_Mostra()
            {
                ID = entityPrenotazione.ID,
                Descrizione = entityPrenotazione.Descrizione,
                RisorsaId = entityPrenotazione.RisorsaId,
                SalaId = entityPrenotazione.SalaId,
                Inizio = entityPrenotazione.Inizio,
                Fine = entityPrenotazione.Fine,
            };

            return dtoPrenotazioneMostra;
        }
    }
}
