using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nastani.Models;
using Nastani.DataAccessLayer;
using Nastani.ViewModels;
using Nastani.Repositories;

namespace Nastani.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            PocetnaViewModel model = new PocetnaViewModel();
            model.TriNajpopularni = new NastanRepository().ZemiTriNajpopularni().ToList();                    
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
        public ActionResult Events(){
            PocetnaViewModel model = new PocetnaViewModel();
            model.SiteNatani = new NastanRepository().ZemiGiSite().ToList();
            return View(model);
        }
        public ActionResult Event(int? id) {
            if (id != null)
            {
                PocetnaViewModel model = new PocetnaViewModel();
                model.SelektiranNastan = new NastanRepository().ZemiPoID(Convert.ToInt32(id));
                return View(model);
            }
            return RedirectToAction("Index", "Home");            
        }
    }
}