using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nastani.Models
{
    public class Ocenuva
    {
        [Key, Column(Order = 0)]
        public string Email { get; set; }
        [Key, Column(Order = 1)]
        public int NastanID { get; set; }        
        public int Ocena { get; set; }
        [ForeignKey("Email")]
        public virtual Korisnik Korisnik { get; set; }
        [ForeignKey("NastanID")]
        public virtual Nastan Nastan { get; set; }
    }
}