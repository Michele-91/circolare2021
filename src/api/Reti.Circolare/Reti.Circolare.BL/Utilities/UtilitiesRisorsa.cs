using Reti.Circolare.BL.DTO;
using Reti.Circolare.DAL;
using Reti.Circolare.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reti.Circolare.BL.Utilities
{
    public static class UtilitiesRisorsa
    {
        public static DTORisorsa Risorsa_ConvertiDTOCreaInDTO(DTORisorsa_Crea dtoRisorsaCrea)
        {
            DTORisorsa dtoRisorsa = new DTORisorsa()
            {
                Nome = dtoRisorsaCrea.Nome,
                Cognome = dtoRisorsaCrea.Cognome,
                EmailPersonale = dtoRisorsaCrea.EmailPersonale,
                Abilitato = dtoRisorsaCrea.Abilitato
            };

            return dtoRisorsa;
        }

        // Genera UserName dell'utente a partire da nome e cognome
        internal static string Risorsa_GeneraUsername(string nome, string cognome)
        {
            string username = cognome.Substring(0, 5) + nome.Substring(0, 2);
            return username;
        }

        // Aggiunge cifra finale a username, addizionando di una cifra il suffisso più alto presente tra gli utenti già esistenti
        internal static int Risorsa_AggiungiCifraDiSuffissoPerUsername(IEnumerable<TBW_Risorsa> utenzeSimili)
        {
            int maxCifra = 0;
            foreach (var utente in utenzeSimili)
            {
                int cifra = Int32.Parse(utente.UserName[utente.UserName.Length - 1].ToString());
                if (cifra > maxCifra)
                {
                    maxCifra = cifra;
                }
            }
            int cifraNuovoUtente = maxCifra + 1;
            return cifraNuovoUtente;
        }
    }
}
