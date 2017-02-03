using Nastani.Models;
using Nastani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nastani.ViewModels;
namespace Nastani.Controllers
{
    public class SampleController : Controller
    {
        // GET: Sample
        public ActionResult Index()
        {
            SiteKorisniciModel sk = new SiteKorisniciModel();
            //sk.siteKorisnici = new KorisnikRepository().getAll().ToList();

            return View(sk);
        }
    }
}