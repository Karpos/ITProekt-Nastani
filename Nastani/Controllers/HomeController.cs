using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nastani.Models;
using Nastani.DataAccessLayer;
using Nastani.ViewModels;
using Nastani.Repositories;
using Nastani.Repository;

namespace Nastani.Controllers
{
    public class HomeController : Controller
    {

        NastaniDBContext nastaniDBContext = new NastaniDBContext();
        public ActionResult Index()
        {
            PocetnaViewModel model = new PocetnaViewModel();
            model.TriNajpopularni = new NastanRepository(nastaniDBContext).ZemiTriNajpopularni().ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Events()
        {
            PocetnaViewModel model = new PocetnaViewModel();
            model.SiteNatani = new NastanRepository(nastaniDBContext).ZemiGiSite().ToList();
            Korisnik k = null;
            if (User.Identity.IsAuthenticated)
            {
                k = new KorisnikRepository(nastaniDBContext).getById(User.Identity.Name);
                if (k.EAdmin)
                {
                    model.KorisnikEAdmin = true;
                }
                else model.KorisnikEAdmin = false;
            }
            else model.KorisnikEAdmin = false;

            return View(model);
        }
        public ActionResult Event(int id)
        {
            
            if (id != null)
            {
                new NastanRepository(nastaniDBContext).dodajGledanost(id);
                PocetnaViewModel model = new PocetnaViewModel();
                model.SelektiranNastan = new NastanRepository(nastaniDBContext).ZemiPoID(Convert.ToInt32(id));
                Korisnik k = null;
                if (User.Identity.IsAuthenticated)
                {
                    k = new KorisnikRepository(nastaniDBContext).getById(User.Identity.Name);
                    model.KorisnikEAdmin = k.EAdmin;
                }
                else
                    model.KorisnikEAdmin = false;
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult AddEvent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEvent(String naslov, String koga, String kade, String tekst, List<String> sliki)
        {
            Korisnik k = null;
            if (User.Identity.IsAuthenticated)
            {
                k = new KorisnikRepository(nastaniDBContext).getById(User.Identity.Name);

            }
            else
            {
                return Json("User Not Logged");
            }
            List<Slika> slikiObj = new List<Slika>(); ;
            if (sliki != null)
            {
                foreach (String s in sliki)
                {
                    slikiObj.Add(new Slika { SlikaPateka = s });
                }
            }

            new NastanRepository(nastaniDBContext).ZacuvajNastan(new Nastan { Ime = naslov, Opis = tekst, Datum = koga, BrPosetenost = 0, VkupnaOcena = 0, EKreiranOdKorisnik = k, SodrziSliki = slikiObj });
            return Json("Success");
        }
        public ActionResult deleteEvent(int id)
        {
            new NastanRepository(nastaniDBContext).izbrisiNastan(id);
            return RedirectToAction("/Events");
        }
        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            PocetnaViewModel model = new PocetnaViewModel();
            model.SelektiranNastan = new NastanRepository(nastaniDBContext).ZemiPoID(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditEvent(String naslov, String koga, String kade, String tekst, List<String> sliki, int id)
        {
            Korisnik k = null;
            if (User.Identity.IsAuthenticated)
            {
                k = new KorisnikRepository(nastaniDBContext).getById(User.Identity.Name);

            }
            else
            {
                return Json("User Not Logged");
            }
            List<Slika> slikiObj = new List<Slika>(); ;
            if (sliki != null)
            {
                foreach (String s in sliki)
                {
                    slikiObj.Add(new Slika { SlikaPateka = s });
                }
            }

            new NastanRepository(nastaniDBContext).izmeniNastan(new Nastan {NastanID = id, Ime = naslov, Opis = tekst, Datum = koga, BrPosetenost = 0, VkupnaOcena = 0, EKreiranOdKorisnik = k, SodrziSliki = slikiObj });
            return Json("Success");
        }
        public ActionResult AddGoing(int id) {
            Korisnik k = null;
            if (User.Identity.IsAuthenticated)
            {
                k = new KorisnikRepository(nastaniDBContext).getById(User.Identity.Name);

                return Json(new NastanRepository(nastaniDBContext).dodajPosetuvanja(id, k));
            }
            else
            {
                return Json("User Not Logged");
            }                        
        }
        [HttpGet]
        public ActionResult AllUsers() {
            SiteKorisniciModel model = new SiteKorisniciModel();
            model.siteKorisnici = new KorisnikRepository(nastaniDBContext).getAll().ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult AllUsers(List<String> lista) {

             foreach (String item in lista) {
                Korisnik k = new KorisnikRepository(nastaniDBContext).getById(item.Split(':')[0]);
                k.EAdmin = item.Split(':')[1] == "true" ? true : false;
                nastaniDBContext.SaveChanges();
              }

            SiteKorisniciModel model = new SiteKorisniciModel();
            model.siteKorisnici = new KorisnikRepository(nastaniDBContext).getAll().ToList();
            return Json("success");
        }
    }
    
}