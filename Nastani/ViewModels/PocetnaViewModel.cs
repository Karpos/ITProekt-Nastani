using Nastani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nastani.ViewModels
{
    public class PocetnaViewModel
    {
        public IEnumerable<Nastan> SiteNatani { get; set; }
        public IEnumerable<Nastan> TriNajpopularni{ get; set; }
        public Nastan SelektiranNastan { get; set; }

        public Boolean KorisnikEAdmin { get; set; }
    }
}