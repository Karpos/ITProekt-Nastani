using Nastani.DataAccessLayer;
using Nastani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nastani.Repositories
{
    public class NastanRepository
    {
        NastaniDBContext nastaniDBContext;
        public NastanRepository(NastaniDBContext nastaniDBContext) {
            this.nastaniDBContext = nastaniDBContext;
        }
        public IEnumerable<Nastan> ZemiGiSite() {
            
            List<Nastan> nastani = nastaniDBContext.Nastani
                .Include("PosetuvanOdKorisnici")
                .Include("EOdTip")
                .Include("SodrziSliki")
                .Include("SodrziVidea")
                .Include("OcenuvaKorisnik")
                .Include("KomentiraKorisnik")
                .ToList();
            return nastani;
        }
        public IEnumerable<Nastan> ZemiTriNajpopularni() {
            List<Nastan> najpopularni = new List<Nastan>();
            List<Nastan> nastani = ZemiGiSite().ToList();
            for (int i = 0; i < 3; i++)
            {
                float najgolemaOcena = nastani.Select(p => p.VkupnaOcena).Max();
                Nastan nastan = nastani.Where(o => o.VkupnaOcena == najgolemaOcena).FirstOrDefault();
                najpopularni.Add(nastan);
                nastani.Remove(nastan);
            }
            return najpopularni;
        }
        public Nastan ZemiPoID(int id) {

            List<Nastan> nastani = ZemiGiSite().ToList();
            Nastan nastan = nastani.Where(n => n.NastanID == id).FirstOrDefault();
            return nastan;
        }
        public void ZacuvajNastan(Nastan nastan) {            
            nastaniDBContext.Nastani.Add(nastan);
            nastaniDBContext.SaveChanges();
        }
        public void izbrisiNastan(int id) {
            nastaniDBContext.Nastani.Remove(ZemiPoID(id));
            nastaniDBContext.SaveChanges();
        }
        public void izmeniNastan(Nastan nastan) {
            Nastan nn = nastaniDBContext.Nastani.SingleOrDefault(n => n.NastanID == nastan.NastanID);            
            nn.Ime = nastan.Ime;
            nn.Datum = nastan.Datum;
            nn.Opis = nastan.Opis;
            nn.SodrziSliki = nastan.SodrziSliki;
            nastaniDBContext.SaveChanges();
        }
        public void dodajGledanost(int id) {
            nastaniDBContext.Nastani.SingleOrDefault(n => n.NastanID == id).BrPosetenost++;
            nastaniDBContext.SaveChanges();
        }
        public int dodajPosetuvanja(int id,Korisnik k) {
            Nastan nastan = ZemiPoID(id);
            if (nastan.PosetuvanOdKorisnici == null)
            {
                ICollection<Korisnik> posetuvaatNastan = new List<Korisnik>();
                posetuvaatNastan.Add(k);
                nastan.PosetuvanOdKorisnici = posetuvaatNastan;
                nastaniDBContext.SaveChanges();
                return 1;
            }
            else
            {
                if (nastan.PosetuvanOdKorisnici.FirstOrDefault(ko => ko.Email.Equals(k.Email)) == null)
                {
                    nastan.PosetuvanOdKorisnici.Add(k);
                    nastaniDBContext.SaveChanges();
                }
            }
            return nastan.PosetuvanOdKorisnici.Count;
        }
    }
}