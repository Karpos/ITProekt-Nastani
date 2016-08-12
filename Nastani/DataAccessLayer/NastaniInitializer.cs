using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Nastani.Models;

namespace Nastani.DataAccessLayer
{
    public class NastaniInitializer : DropCreateDatabaseIfModelChanges<NastaniDBContext>
    {
        protected override void Seed(NastaniDBContext context)
        {
            var korisnici = new List<Korisnik> {
                new Korisnik {
                    Email = "martin.avramoski@gmail.com",
                    Ime = "Martin",
                    Prezime = "Avramoski",
                    Lozinka = "lozinka",
                    KorisnickoIme = "Karposh",
                    EAdmin = true,
                    EAktiven = true
                },
                new Korisnik {
                    Email = "marko.paloski@gmail.com",
                    Ime = "Marko",
                    Prezime = "Paloski",
                    Lozinka = "lozinka",
                    KorisnickoIme = "Palce",
                    EAdmin = true,
                    EAktiven = true
                },
                new Korisnik {
                    Email = "eldridz.dekica@gmail.com",
                    Ime = "Dekica",
                    Prezime = "Eldridzovski",
                    Lozinka = "lozinka",
                    KorisnickoIme = "Eldridz",
                    EAdmin = false,
                    EAktiven = true
                },
                new Korisnik {
                    Email = "sampleuser@gmail.com",
                    Ime = "Sample",
                    Prezime = "Sample",
                    Lozinka = "lozinka",
                    KorisnickoIme = "Sample",
                    EAdmin = false,
                    EAktiven = true
                },
                new Korisnik {
                    Email = "dolce.fica@gmail.com",
                    Ime = "Dolce",
                    Prezime = "Fica",
                    Lozinka = "lozinka",
                    KorisnickoIme = "DolceFica",
                    EAdmin = false,
                    EAktiven = true
                },
                new Korisnik {
                    Email = "dolce.vica@gmail.com",
                    Ime = "Dolcee",
                    Prezime = "Vica",
                    Lozinka = "lozinka",
                    KorisnickoIme = "Dolce",
                    EAdmin = false,
                    EAktiven = true
                }
            };
            korisnici.ForEach(s => context.Korisnici.Add(s));
            context.SaveChanges();
            var nastani = new List<Nastan>{
                new Nastan {
                    
                    Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque non lorem vel dolor posuere congue. Sed venenatis imperdiet ipsum, a convallis lacus consequat sit amet. Donec nisl justo, hendrerit vitae tortor ac, tempus tincidunt arcu. ",
                    Datum = DateTime.Now,
                    Ime = "Kode Pu",
                    BrPosetenost = 32,
                    VkupnaOcena = 4,
                    Email = "marko.paloski@gmail.com"
            },
                new Nastan {
                    
                    Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque non lorem vel dolor posuere congue. Sed venenatis imperdiet ipsum, a convallis lacus consequat sit amet. Donec nisl justo, hendrerit vitae tortor ac, tempus tincidunt arcu. ",
                    Datum = DateTime.Now,
                    Ime = "MojNastan",
                    BrPosetenost = 32,
                    VkupnaOcena = 4,
                    Email = "marko.paloski@gmail.com"
            },
                new Nastan {
                    
                    Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque non lorem vel dolor posuere congue. Sed venenatis imperdiet ipsum, a convallis lacus consequat sit amet. Donec nisl justo, hendrerit vitae tortor ac, tempus tincidunt arcu. ",
                    Datum = DateTime.Now,
                    Ime = "INastan",
                    BrPosetenost = 32,
                    VkupnaOcena = 4,
                    Email = "martin.avramoski@gmail.com"
        }

    };
            nastani.ForEach(s => context.Nastani.Add(s));
            context.SaveChanges();
            var sliki = new List<Slika>{
                new Slika {
                    SlikaID  = 1,
                    SlikaPateka = "https://www.google.com/search?q=code+fu&source=lnms&tbm=isch&sa=X&ved=0ahUKEwiB3YbroYzOAhWEthoKHak6BeIQ_AUICSgC&biw=1396&bih=723&dpr=0.9#imgdii=SFfcPuwep0TeMM%3A%3BSFfcPuwep0TeMM%3A%3Bi0VeSNfqRnpFnM%3A&imgrc=SFfcPuwep0TeMM%3A",
                    NastanID = 1
                },
                new Slika {
                    SlikaID  = 2,
                    SlikaPateka = "https://www.google.com/search?q=code+fu&source=lnms&tbm=isch&sa=X&ved=0ahUKEwiB3YbroYzOAhWEthoKHak6BeIQ_AUICSgC&biw=1396&bih=723&dpr=0.9#imgrc=_",
                    NastanID = 1
                },
                new Slika {
                    SlikaID  = 3,
                    SlikaPateka = "https://www.google.com/search?q=nastan&biw=1396&bih=723&tbm=isch&source=lnms&sa=X&ved=0ahUKEwjy6OzJoozOAhVCMBoKHe7hAXUQ_AUICCgD&dpr=0.9#tbm=isch&q=it+event&imgrc=GdlmLlIIhLKoTM%3A",
                    NastanID = 1
                }
            };
            sliki.ForEach(s => context.Sliki.Add(s));
            context.SaveChanges();
            var tipovi = new List<Tip> {
                new Tip {
                    TipID = 1,
                    TipIme = "IT"
                },                
            };
            tipovi.ForEach(s => context.Tipovi.Add(s));
            context.SaveChanges();
            var komentari = new List<Komentira> {
                new Komentira {
                    Email = "dolce.vica@gmail.com",
                    NastanID = 1,
                    KomentarID = 0,
                    Data = DateTime.Now,
                    Tekst = "Lorem ipsum dolor sit amet"
                },
                new Komentira {
                    Email = "dolce.vica@gmail.com",
                    NastanID = 1,
                    KomentarID = 1,
                    Data = DateTime.Now,
                    Tekst = "jas sum majko sin ti sajzer"
                },
                new Komentira {
                    Email = "dolce.fica@gmail.com",
                    NastanID = 2,
                    KomentarID = 2,
                    Data = DateTime.Now,
                    Tekst = "dobar nastan"
                },
                new Komentira {
                    Email = "eldridz.dekica@gmail.com",
                    NastanID = 2,
                    KomentarID = 3,
                    Data = DateTime.Now,
                    Tekst = "Lorem ipsum dolor sit amet"
                }
            };
            komentari.ForEach(s => context.Komentari.Add(s));
            context.SaveChanges();
            var ocenki = new List<Ocenuva> {
                new Ocenuva {
                    Email = "eldridz.dekica@gmail.com",
                    NastanID = 2,
                    Ocena = 3,                    
                },
                new Ocenuva {
                    Email = "dolce.fica@gmail.com",
                    NastanID = 2,
                    Ocena = 5,
                },
                new Ocenuva {
                    Email = "dolce.fica@gmail.com",
                    NastanID = 3,
                    Ocena = 4,
                }
            };
            ocenki.ForEach(s => context.Oceni.Add(s));
            context.SaveChanges(); 
        }
    }
}