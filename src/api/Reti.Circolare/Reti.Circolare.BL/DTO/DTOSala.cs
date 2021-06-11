using Reti.Circolare.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reti.Circolare.BL.DTO
{
    public class DTOSala
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int EdificioId { get; set; }
        //public virtual TBW_Edificio Edificio { get; set; }
    }

    public class DTOSala_Crea
    {
        //public int ID { get; set; }
        public string Nome { get; set; }
        public int EdificioId { get; set; }
        //public virtual TBW_Edificio Edificio { get; set; }
    }

    public class DTOSala_Mostra
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int EdificioId { get; set; }
        //public virtual TBW_Edificio Edificio { get; set; }
    }
}
