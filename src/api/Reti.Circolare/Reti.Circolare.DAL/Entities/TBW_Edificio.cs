using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Reti.Circolare.DAL.Entities
{
    public class TBW_Edificio
    {
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public bool Disponibile { get; set; }
        public virtual ICollection<TBW_Sala> Sale { get; set; }
    }
}
