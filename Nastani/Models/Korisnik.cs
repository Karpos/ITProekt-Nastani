using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nastani.Models
{
    public class Korisnik
    {
        [Key]
        public string Email { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Lozinka { get; set; }
        public string KorisnickoIme { get; set; }
        public bool EAktiven { get; set; }
        public bool EAdmin { get; set; }
        public virtual ICollection<Nastan> OdiNaNastani { get; set; }
        public virtual ICollection<Nastan> KreiraNastani { get; set; }
        public virtual ICollection<Ocenuva> OcenuvaNastan { get; set; }
        public virtual ICollection<Komentira> KometiraNastan { get; set; }
    }
}