using Nastani.DataAccessLayer;
using Nastani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nastani.Repository
{
    public class KorisnikRepository
    {
        public ICollection<Korisnik> getAll() {
            NastaniDBContext nastaniDBContext = new NastaniDBContext();
            List<Korisnik> korisnici =  nastaniDBContext.Korisnici.Include("OdiNaNastani").Include("KreiraNastani").Include("OcenuvaNastan").Include("KometiraNastan").ToList();
            return korisnici;
        }
        public Korisnik getById(string Email) {
            List<Korisnik> korisnici = getAll().ToList();
            Korisnik korisnik = korisnici.Where(t => t.Email == Email).FirstOrDefault();            
            return korisnik;
        }
        public Korisnik getNastaniForKorisnik(string Email) {                        
            return new NastaniDBContext().Korisnici.Include("OdiNaNastani").Where(t => t.Email == Email).FirstOrDefault();
        } 
    }
}