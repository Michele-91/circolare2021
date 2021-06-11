using Reti.Circolare.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reti.Circolare.BL.DTO
{
    public class DTOEdificio
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public bool Disponibile { get; set; }
        //public ICollection<TBW_Sala> Sale { get; set; }
    }

    public class DTOEdificio_Crea
    {
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public bool Disponibile { get; set; }
    }

    public class DTOEdificio_Mostra
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public bool Disponibile { get; set; }
        public ICollection<TBW_Sala> Sale { get; set; }
    }
}
