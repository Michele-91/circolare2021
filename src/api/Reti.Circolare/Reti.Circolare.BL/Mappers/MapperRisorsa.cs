using Reti.Circolare.BL.DTO;
using Reti.Circolare.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reti.Circolare.BL.Mappers
{
    public class MapperRisorsa
    {
        public static TBW_Risorsa Risorsa_ConvertiDTOInEntity(DTORisorsa dtoRisorsa)
        {
            TBW_Risorsa entityRisorsa = new TBW_Risorsa()
            {
                Nome = dtoRisorsa.Nome,
                Cognome = dtoRisorsa.Cognome,
                UserName = dtoRisorsa.UserName,
                EmailPersonale = dtoRisorsa.EmailPersonale,
                EmailReti = dtoRisorsa.EmailReti,
                Abilitato = dtoRisorsa.Abilitato
            };

            return entityRisorsa;
        }

        public static DTORisorsa Risorsa_ConvertiEntityInDTO(TBW_Risorsa entityRisorsa)
        {
            DTORisorsa dtoRisorsa = new DTORisorsa()
            {
                //ID = entityRisorsa.ID,
                Nome = entityRisorsa.Nome,
                Cognome = entityRisorsa.Cognome,
                UserName = entityRisorsa.UserName,
                EmailPersonale = entityRisorsa.EmailPersonale,
                EmailReti = entityRisorsa.EmailReti,
                Abilitato = entityRisorsa.Abilitato
            };

            return dtoRisorsa;
        }

        public static DTORisorsa_Mostra Risorsa_ConvertiEntityInDTOMostra(TBW_Risorsa entityRisorsa)
        {
            DTORisorsa_Mostra dtoRisorsa = new DTORisorsa_Mostra()
            {
                ID = entityRisorsa.ID,
                Nome = entityRisorsa.Nome,
                Cognome = entityRisorsa.Cognome,
                UserName = entityRisorsa.UserName,
                EmailPersonale = entityRisorsa.EmailPersonale,
                EmailReti = entityRisorsa.EmailReti,
                Abilitato = entityRisorsa.Abilitato
            };

            return dtoRisorsa;
        }
    }
}
