using System;
using System.Collections.Generic;
using System.Text;

namespace Reti.Circolare.BL.DTO
{
    public class DTOPrenotazione
    {
        //public int ID { get; set; }
        public string Descrizione { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public Guid RisorsaId { get; set; }
        public int SalaId { get; set; }
    }

    public class DTOPrenotazione_Crea
    {
        public string Descrizione { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public Guid RisorsaId { get; set; }
        public int SalaId { get; set; }
    }

    public class DTOPrenotazione_Mostra
    {
        public int ID { get; set; }
        public string Descrizione { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public Guid RisorsaId { get; set; }
        public int SalaId { get; set; }
    }
}
