using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nastani.Models
{
    public class Nastan
    {
        public int NastanID { get; set; }
        public string Opis { get; set; }
        public String Datum { get; set; }
        public string Ime { get; set; }
        public int BrPosetenost { get; set; }
        public float VkupnaOcena { get; set; }
        public string Email { get; set; }
        [ForeignKey("Email")]
        public virtual Korisnik EKreiranOdKorisnik { get; set; }
        public virtual ICollection<Korisnik> PosetuvanOdKorisnici { get; set; }
        public virtual ICollection<Tip> EOdTip { get; set; }
        public virtual ICollection<Slika> SodrziSliki { get; set; }
        public virtual ICollection<Video> SodrziVidea { get; set; }
        public virtual ICollection<Ocenuva> OcenuvaKorisnik{ get; set; }
        public virtual ICollection<Komentira> KomentiraKorisnik { get; set; }

    }
}