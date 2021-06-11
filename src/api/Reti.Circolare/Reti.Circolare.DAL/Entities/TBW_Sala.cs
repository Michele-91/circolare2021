using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Reti.Circolare.DAL.Entities
{
    public class TBW_Sala
    {
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public int EdificioId { get; set; }
        public virtual TBW_Edificio Edificio { get; set; }
        public virtual ICollection<TBW_Prenotazione> Prenotazioni { get; set; }
    }
}
