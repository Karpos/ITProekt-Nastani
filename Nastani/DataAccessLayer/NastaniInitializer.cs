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
                    Datum = DateTime.Now.ToString(),
                    Ime = "Kode Pu",
                    BrPosetenost = 32,
                    VkupnaOcena = 4,
                    Email = "marko.paloski@gmail.com",
                    SodrziSliki = new List<Slika> {
                        new Slika {
                            SlikaID=1,
                            SlikaPateka="http://codefu.mk/files/poster/2009/CodeFu2009.jpg"
                        }
                    }
                    
            },
                new Nastan {
                    
                    Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque non lorem vel dolor posuere congue. Sed venenatis imperdiet ipsum, a convallis lacus consequat sit amet. Donec nisl justo, hendrerit vitae tortor ac, tempus tincidunt arcu. ",
                    Datum = DateTime.Now.ToString(),
                    Ime = "MojNastan",
                    BrPosetenost = 32,
                    VkupnaOcena = 4,
                    Email = "marko.paloski@gmail.com",
                    SodrziSliki = new List<Slika> {
                        new Slika {
                            SlikaID=2,
                            SlikaPateka = "http://www.happiestminds.com/blogs/wp-content/uploads/2015/11/IMG-20151106-WA0013.jpg",
                        }
                    }
            },
                new Nastan {
                    
                    Opis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque non lorem vel dolor posuere congue. Sed venenatis imperdiet ipsum, a convallis lacus consequat sit amet. Donec nisl justo, hendrerit vitae tortor ac, tempus tincidunt arcu. ",
                    Datum = DateTime.Now.ToString(),
                    Ime = "INastan",
                    BrPosetenost = 32,
                    VkupnaOcena = 4,
                    Email = "martin.avramoski@gmail.com",
                    SodrziSliki = new List<Slika> {
                        new Slika {
                            SlikaID=3,
                            SlikaPateka = "http://www.revelryeventdesigners.com/wp-content/uploads/2011/05/revelry-event-designers-homepage-slideshow-38.jpeg",
                        }
                    }
        }

    };
            nastani.ForEach(s => context.Nastani.Add(s));
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