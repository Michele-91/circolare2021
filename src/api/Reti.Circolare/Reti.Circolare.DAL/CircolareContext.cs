using Microsoft.EntityFrameworkCore;
using Reti.Circolare.DAL.Entities;
using System.Collections.Generic;

namespace Reti.Circolare.DAL
{
    public class CircolareContext : DbContext
    {
        //public DbSet<TBW_Contact> TBW_Contacts { get; set; }
        public DbSet<TBW_Risorsa> TBW_Risorse { get; set; }
        public DbSet<TBW_Edificio> TBW_Edifici { get; set; }
        public DbSet<TBW_Prenotazione> TBW_Prenotazioni { get; set; }
        public DbSet<TBW_Sala> TBW_Sale { get; set; }
        public CircolareContext(DbContextOptions<CircolareContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<TBW_Prenotazione>()
           //.Property(et => et.ID)
           //.ValueGeneratedNever();
            modelBuilder.Entity<TBW_Prenotazione>().HasIndex(p => p.ID).IsUnique();

            modelBuilder.Entity<TBW_Sala>()
            .HasOne<TBW_Edificio>(s => s.Edificio)
            .WithMany(e => e.Sale)
            .HasForeignKey(s => s.EdificioId);

            modelBuilder.Entity<TBW_Sala>()
            .HasMany<TBW_Prenotazione>(s => s.Prenotazioni)
            .WithOne(p => p.Sala)
            .HasForeignKey(s => s.SalaId);

            modelBuilder.Entity<TBW_Prenotazione>()
            .HasOne<TBW_Risorsa>(s => s.Risorsa)
            .WithMany(r => r.Prenotazioni)
            .HasForeignKey(s => s.RisorsaId);

        }
    }
}
