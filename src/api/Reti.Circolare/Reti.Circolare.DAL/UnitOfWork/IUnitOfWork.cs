using Reti.Circolare.DAL.Entities;
using Reti.Circolare.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reti.Circolare.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        //IRepository<TBW_Contact> ContactRepository { get; }
        IRepository<TBW_Risorsa> RisorsaRepository { get; }
        IRepository<TBW_Edificio> EdificioRepository { get; }
        IRepository<TBW_Prenotazione> PrenotazioneRepository { get; }
        IRepository<TBW_Sala> SalaRepository { get; }
        void Commit();
        void RollBack();

    }
}
