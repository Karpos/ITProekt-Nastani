using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Nastani.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Nastani.DataAccessLayer
{
    public class NastaniDBContext : DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Nastan> Nastani { get; set; }
        public DbSet<Slika> Sliki { get; set; }
        public DbSet<Tip> Tipovi { get; set; }
        public DbSet<Video> Videa { get; set; }
        public DbSet<Komentira> Komentari { get; set; }
        public DbSet<Ocenuva> Oceni{ get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>()
                .HasMany(t => t.OdiNaNastani)
                .WithMany(t => t.PosetuvanOdKorisnici)
                .Map(m =>
                {
                    m.ToTable("KorisnikOdiNaNastan");
                    m.MapLeftKey("Email");
                    m.MapRightKey("NastnanID");
                });
            modelBuilder.Entity<Nastan>()
                .HasMany(t => t.EOdTip)
                .WithMany(t => t.ENaNastan)
                .Map(m => {
                    m.ToTable("NastanEOdTip");
                    m.MapLeftKey("NastanID");
                    m.MapRightKey("TipID");
            });
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);            
        }

    }
}