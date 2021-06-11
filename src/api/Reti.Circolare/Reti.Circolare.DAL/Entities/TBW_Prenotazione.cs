using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Reti.Circolare.DAL.Entities
{
    public class TBW_Prenotazione
    {
        [Key]
        public int ID { get; set; }
        public string Descrizione { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public Guid RisorsaId { get; set; }
        public virtual TBW_Risorsa Risorsa { get; set; }
        public int SalaId { get; set; }
        public virtual TBW_Sala Sala { get; set; }
    }
}
