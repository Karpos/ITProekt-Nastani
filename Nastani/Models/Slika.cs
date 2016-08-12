using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nastani.Models
{
    public class Slika
    {
        public int SlikaID { get; set; }
        public string SlikaPateka { get; set; }
        public int NastanID { get; set; }
        [ForeignKey("NastanID")]
        public virtual Nastan ENaNastan { get; set; }
    }
}