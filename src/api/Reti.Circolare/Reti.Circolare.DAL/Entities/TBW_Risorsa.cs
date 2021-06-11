using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Reti.Circolare.DAL.Entities
{
    public class TBW_Risorsa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string UserName { get; set; }
        public string EmailReti { get; set; }
        public string EmailPersonale { get; set; }
        public bool Abilitato { get; set; }
        public ICollection<TBW_Prenotazione> Prenotazioni { get; set; }
    }
}
