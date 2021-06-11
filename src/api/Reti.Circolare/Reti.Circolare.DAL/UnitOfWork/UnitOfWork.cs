using Microsoft.EntityFrameworkCore;
using Reti.Circolare.DAL.Entities;
using Reti.Circolare.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reti.Circolare.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private CircolareContext dbContext;
        //private IRepository<TBW_Contact> contactRepository;
        private IRepository<TBW_Risorsa> risorsaRepository;
        private IRepository<TBW_Edificio> edificioRepository;
        private IRepository<TBW_Prenotazione> prenotazioneRepository;
        private IRepository<TBW_Sala> salaRepository;

        public IRepository<TBW_Risorsa> RisorsaRepository => risorsaRepository = risorsaRepository ?? new Repository<TBW_Risorsa>(dbContext);
        public IRepository<TBW_Edificio> EdificioRepository => edificioRepository = edificioRepository ?? new Repository<TBW_Edificio>(dbContext);
        public IRepository<TBW_Prenotazione> PrenotazioneRepository => prenotazioneRepository = prenotazioneRepository ?? new Repository<TBW_Prenotazione>(dbContext);
        public IRepository<TBW_Sala> SalaRepository => salaRepository = salaRepository ?? new Repository<TBW_Sala>(dbContext);


        public UnitOfWork(CircolareContext circolareContext)
        {
            dbContext = circolareContext;
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void RollBack()
        {
            dbContext.Dispose();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
