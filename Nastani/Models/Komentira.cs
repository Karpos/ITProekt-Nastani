using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nastani.Models
{
    public class Komentira
    {
        [Key, Column(Order = 0)]
        public string  Email { get; set; }
        [Key, Column(Order = 1)]
        public int NastanID { get; set; }
        [Key, Column(Order = 2)]
        public int KomentarID { get; set; }        
        public string Tekst { get; set; }
        public DateTime Data { get; set; }
        [ForeignKey("Email")]
        public virtual Korisnik Korisnik { get; set; }
        [ForeignKey("NastanID")]
        public virtual Nastan Nastan { get; set; }
    }
}
