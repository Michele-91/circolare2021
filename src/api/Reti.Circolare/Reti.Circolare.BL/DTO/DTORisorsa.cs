using System;
using System.Collections.Generic;
using System.Text;

namespace Reti.Circolare.BL.DTO
{
    public class DTORisorsa
    {
        //public int ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string UserName { get; set; }
        public string EmailReti { get; set; }
        public string EmailPersonale { get; set; }
        public bool Abilitato { get; set; }
    }

    public class DTORisorsa_Crea
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string EmailPersonale { get; set; }
        public bool Abilitato { get; set; }
    }

    public class DTORisorsa_Mostra
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string UserName { get; set; }
        public string EmailReti { get; set; }
        public string EmailPersonale { get; set; }
        public bool Abilitato { get; set; }
    }
}
