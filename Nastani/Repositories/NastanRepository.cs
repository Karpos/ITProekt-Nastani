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
        public IEnumerable<Nastan> ZemiGiSite() {
            NastaniDBContext nastaniDBContext = new NastaniDBContext();
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
    }
}