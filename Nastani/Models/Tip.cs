using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nastani.Models
{
    public class Tip
    {
        public int TipID { get; set; }
        public string TipIme { get; set; }
        public ICollection<Nastan> ENaNastan { get; set;}
    }
}