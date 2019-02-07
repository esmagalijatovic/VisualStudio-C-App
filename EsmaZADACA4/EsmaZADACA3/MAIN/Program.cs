using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NasaMK1;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace MAIN
{
    class Program
    {
        static Klinika klinika17736 = new Klinika();

        static void Main(string[] args)
        {
            klinika17736.listaDoktora.Add(new Doktor("Bosanko Horozic", new DateTime(1960, 11, 1), 2000));
            klinika17736.listaDoktora.Add(new Doktor("Suad Djumisic", new DateTime(1960, 11, 1), 2000));
            klinika17736.listaDoktora.Add(new Doktor("Amira Horozic", new DateTime(1960, 11, 1), 2000));
            klinika17736.listaDoktora.Add(new Doktor("Gena Djumisic", new DateTime(1960, 11, 1), 2000));
            klinika17736.listaDoktora.Add(new Doktor("Adnan Galijatovic", new DateTime(1960, 11, 1), 2000));
            klinika17736.listaDoktora.Add(new Doktor("Maida Galijatovic", new DateTime(1960, 11, 1), 2000));
            klinika17736.listaDoktora.Add(new Doktor("Dzan Horozic", new DateTime(1960, 11, 1), 2000));
            klinika17736.listaDoktora.Add(new Doktor("Lajla Galijatovic", new DateTime(1960, 11, 1), 2000));
            klinika17736.listaDoktora.Add(new Doktor("Amir Karup", new DateTime(1960, 11, 1), 2000));
            klinika17736.listaDoktora.Add(new Doktor("Aida Karup", new DateTime(1960, 11, 1), 2000));
            klinika17736.listaAparata.Add(new Aparat("Ultrazvuk", true, false, false));
            klinika17736.listaAparata.Add(new Aparat("EKG", true, false, true));
            klinika17736.listaAparata[1].periodGasenja = new DateTime(2018, 2, 1, 14, 30, 0);
            klinika17736.listaAparata.Add(new Aparat("Dermatoloski aparat", true, false, false));
            klinika17736.listaAparata.Add(new Aparat("Stomatoloski aparat", true, false, false));
            klinika17736.listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.OpstaMedicina, klinika17736.listaDoktora[0], false));
            klinika17736.listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.Oftamoloska, klinika17736.listaDoktora[1], false));
            klinika17736.listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.Kardioloska, klinika17736.listaDoktora[2], true));
            klinika17736.listaOrdinacija[2].aparat = klinika17736.listaAparata[1];
            klinika17736.listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.Ortopedska, klinika17736.listaDoktora[3], false));
            klinika17736.listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.Otorinolaringoloska, klinika17736.listaDoktora[5], false));
            klinika17736.listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.Internisticka, klinika17736.listaDoktora[4], true));
            klinika17736.listaOrdinacija[5].aparat = klinika17736.listaAparata[0];
            klinika17736.listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.Laboratorijska, klinika17736.listaDoktora[6], false));
            klinika17736.listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.HitnaSluzba, klinika17736.listaDoktora[7], false));
            klinika17736.listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.Stomatoloska, klinika17736.listaDoktora[8], true));
            klinika17736.listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.Dermatoloska, klinika17736.listaDoktora[9], true));
            klinika17736.listaOrdinacija[9].aparat = klinika17736.listaAparata[2];
            klinika17736.listaOrdinacija[8].aparat = klinika17736.listaAparata[3];

            int x = new Int32();
            while (x != 8)
            {
                Console.WriteLine("Dobro došli! Odaberite jednu od opcija:\n" +
                    "1.Registruj / Briši pacijenta\n" +
                    "2.Prikaži raspored pregleda pacijenta\n" +
                    "3.Kreiranje kartona pacijenta\n" +
                    "4.Pretraga kartona pacijenta\n" +
                    "5.Registruj novi pregled\n" +
                    "6.Analiza sadržaja\n" +
                    "7.Naplata\n" +
                    "8. Zavrsi dan\n" +
                    "9. Oznaci doktora da je zauzet/ aparat da je u kvaru" +
                    "10.Izlaz");
                string ulaz = Console.ReadLine();
                Int32.TryParse(ulaz, out x);
                if (x == 1)
                {
                    Console.WriteLine("1.Registruj pacijenta\n" +
                                      "2.Brisi pacijenta");
                    int x1;
                    ulaz = Console.ReadLine();
                    Int32.TryParse(ulaz, out x1);
                    if (x1 == 1) //Registrovanje pacijenta (NORMALNI SLUCAJ)
                    {
                        int x2;
                        Console.WriteLine("1. Registruj novog pacijenta\n" +
                            "2. Zakazi preglede postojeceg pacijenta");
                        ulaz = Console.ReadLine();
                        int x4;
                        Int32.TryParse(ulaz, out x4);
                        if (x4 == 1)
                        {
                            Console.WriteLine("1. Normalan slučaj\n" +
                                              "2. Hitan slučaj");
                            ulaz = Console.ReadLine();
                            Int32.TryParse(ulaz, out x2);
                            if (x2 == 1) //NORMALAN SLUCAJ
                            {
                                klinika17736.listaPacijenata.Add(RegistrujPacijentaNormalniSlucaj());
                            }
                            else if (x2 == 2) // HITAN SLICAJ
                            {
                                int f;
                                Console.WriteLine("1. Pošaji pacijenta u ordinaciju hitne službe\n" +
                                    "2. Regisruj pacijenta koji je bio hitan slučaj");
                                ulaz = Console.ReadLine();
                                Int32.TryParse(ulaz, out f);
                                if (f == 1)  // HITNIC PACIJENT U ORDINACIJU HITNE SLUZBE
                                {
                                    Ordinacija o17736 = klinika17736.listaOrdinacija.FirstOrDefault(p => p.poljeMedicine == TipOrdinacija.HitnaSluzba);
                                    int i = klinika17736.listaOrdinacija.FindIndex(p => p.poljeMedicine == TipOrdinacija.HitnaSluzba);
                                    o17736.redCekanja.Add(new HitniPacijent());
                                    klinika17736.listaOrdinacija[i] = o17736;
                                }
                                else if (f == 2) // REGISTRACIJA PACIJETNA
                                {
                                    Pacijent p = RegistrujPacijentaNormalniSlucaj();
                                    Console.WriteLine("Opisite pruzenu prvu pomoc: ");
                                    ulaz = Console.ReadLine();
                                    int x7 = klinika17736.listaPacijenata.FindIndex(e => e == null);
                                    klinika17736.listaPacijenata[x7] = new HitniPacijent(p.imeIprezime, p.datumRodjenja, p.jmbg, p.spol, p.uBraku, p.adresa, p.datumPrijema, ulaz);
                                    klinika17736.listaPacijenata[x7].brojPosjeta++;
                                    Console.WriteLine("Da li se desio smrtni slucaj?\n" +
                                        "1. DA\n" +
                                        "2. NE ");
                                    int x3;
                                    ulaz = Console.ReadLine();
                                    Int32.TryParse(ulaz, out x3);
                                    if (x3 == 1)
                                    {
                                        Console.WriteLine("Unesite vrijeme smrti (d.m.g.h.min)");
                                        ulaz = Console.ReadLine();
                                        string[] datumi = ulaz.Split('.');
                                        int a, b, c, d, e;
                                        Int32.TryParse(datumi[0], out a);
                                        Int32.TryParse(datumi[1], out b);
                                        Int32.TryParse(datumi[2], out c);
                                        Int32.TryParse(datumi[3], out d);
                                        Int32.TryParse(datumi[4], out e);
                                        klinika17736.listaPacijenata[x7].vrijemeSmrti = new DateTime(c, b, a, d, e, 0);
                                        Console.WriteLine("Unesite preliminarni uzrok smrti: ");
                                        klinika17736.listaPacijenata[x7].razlogSmrti = Console.ReadLine();
                                        Console.WriteLine("Unesite datum obdukcije: ");
                                        ulaz = Console.ReadLine();
                                        datumi = ulaz.Split('.');
                                        Int32.TryParse(datumi[0], out a);
                                        Int32.TryParse(datumi[1], out b);
                                        Int32.TryParse(datumi[2], out c);
                                        klinika17736.listaPacijenata[x7].terminObdukcije = new DateTime(a, b, c);
                                        klinika17736.listaPacijenata[x7].aktivan = false;
                                    }
                                }
                            }
                        }
                        else if (x4 == 2) // ZAKAZI PREGLEDE POSTOJECEG PACIJENTA
                        {
                            Int64 jmbg = UnosJMBG();
                            if (klinika17736.listaPacijenata.Count(p => p.jmbg == jmbg) == 0)
                            {
                                Console.WriteLine("Ne postoji pacijent sa tim jmbg!\n");
                                continue;
                            }
                            if (klinika17736.listaKartona.Count(p => p.pacijent.jmbg == jmbg) == 0)
                            {
                                Console.WriteLine("Prvo kreirajte karton!");
                                continue;
                            }
                            Karton k17736;
                            int v = klinika17736.listaPacijenata.FindIndex(p => p.jmbg == jmbg);
                            klinika17736.listaPacijenata[v].brojPosjeta++;
                            try
                            {
                                k17736 = klinika17736.listaKartona.FirstOrDefault(p => p.pacijent.jmbg == jmbg);
                                k17736.pacijent.brojPosjeta++;
                                k17736 = ZakaziPregede(k17736);
                                int i = klinika17736.listaKartona.FindIndex(p => p.pacijent.jmbg == jmbg);
                                klinika17736.listaKartona[i] = k17736;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Prvo kreirajte karton!");
                                continue;
                            }
                        }

                    }
                    else if (x1 == 2) //Brisanje Pacijenta
                    {
                        Int64 jmb = UnosJMBG();
                        klinika17736.ObrisiPacijenta(jmb);
                        int i = klinika17736.listaPacijenata.FindIndex(p => p.jmbg == jmb);
                        klinika17736.listaPacijenata[i].aktivan = false;
                    }
                }
                else if (x == 2) // RASPORED PREGLEDA PACIJENTA
                {
                    Int64 jmbg = UnosJMBG();
                    Karton k17736 = klinika17736.listaKartona.FirstOrDefault(n => n.pacijent.jmbg == jmbg);
                    IzlistajPreglede(k17736);
                }
                else if (x == 3) //Kreiranje kartona pacijenta
                {
                    Int64 jmbg = KreirajKarton();
                    Karton k17736 = klinika17736.listaKartona.FirstOrDefault(p => p.pacijent.jmbg == jmbg);
                    k17736 = ZakaziPregede(k17736);
                    int i = klinika17736.listaKartona.FindIndex(p => p.pacijent.jmbg == jmbg);
                    klinika17736.listaKartona[i] = k17736;
                }
                else if (x == 4) //Pretraga kartona pacijenta
                {
                    Int64 jmbg = UnosJMBG();
                    Karton k17736 = klinika17736.listaKartona.FirstOrDefault(kar => kar.pacijent.jmbg == jmbg);
                    Console.WriteLine("1.Pretraga kartona\n" +
                                      "2.Prikaz kartona");
                    int n;
                    ulaz = Console.ReadLine();
                    Int32.TryParse(ulaz, out n);
                    if (n == 1)
                    {
                        PretragaKartona(k17736);
                    }
                    else if (n == 2) Console.WriteLine("{0}", k17736.Ispisi());
                }
                else if (x == 5) //Registruj novi pregled
                {
                    Int64 jmbg = UnosJMBG();
                    Karton k17736 = klinika17736.listaKartona.FirstOrDefault(p => p.pacijent.jmbg == jmbg);
                    int i = klinika17736.listaKartona.FindIndex(p => p.pacijent.jmbg == jmbg);
                    Console.WriteLine("Odaberite ordinaciju: \n" +
                         "1. Opsta medicina\n" +
                        "2. Ortopedski\n" +
                        "3. Kardioloski\n" +
                        "4. Dermatoloski\n" +
                        "5. Internisticki\n" +
                        "6. Otorinolaringoloski\n" +
                        "7. Oftamoloski\n" +
                        "8. Laboratorijski\n" +
                        "9. Stomatoloski\n" +
                        "10. Kraj ");
                    int x1;
                    ulaz = Console.ReadLine();
                    Int32.TryParse(ulaz, out x1);
                    TipOrdinacija tip = new TipOrdinacija();
                    if (x1 == 10) break;
                    else if (x1 == 1) tip = TipOrdinacija.OpstaMedicina;
                    else if (x1 == 2) tip = TipOrdinacija.Ortopedska;
                    else if (x1 == 3) tip = TipOrdinacija.Kardioloska;
                    else if (x1 == 4) tip = TipOrdinacija.Dermatoloska;
                    else if (x1 == 5) tip = TipOrdinacija.Internisticka;
                    else if (x1 == 6) tip = TipOrdinacija.Otorinolaringoloska;
                    else if (x1 == 7) tip = TipOrdinacija.Oftamoloska;
                    else if (x1 == 8) tip = TipOrdinacija.Laboratorijska;
                    else if (x1 == 9) tip = TipOrdinacija.Stomatoloska;
                    else
                    {
                        Console.WriteLine("Pogresan unos.");
                    }
                    Ordinacija o17736 = klinika17736.listaOrdinacija.FirstOrDefault(p => p.poljeMedicine == tip);
                    int i1 = klinika17736.listaOrdinacija.FindIndex(p => p.poljeMedicine == tip);
                    o17736.redCekanja.Remove(k17736.pacijent);
                    o17736.doktor.dodajPacijenta();
                    int v = klinika17736.listaDoktora.FindIndex(d => d == o17736.doktor);
                    klinika17736.listaDoktora[v].dodajPacijenta();
                    KeyValuePair<Ordinacija, int> n = k17736.listaPregleda.FirstOrDefault(p => p.Key.poljeMedicine == tip);
                    k17736.obavljeniPregledi.Add(o17736);
                    for (int i2 = 0; i2 < klinika17736.listaKartona.Count(); i2++)
                    {
                        for (int j = 0; j < klinika17736.listaKartona[i2].listaPregleda.Count(); j++)
                        {
                            if (klinika17736.listaKartona[i2].listaPregleda[j].Key.poljeMedicine == tip)
                            {
                                klinika17736.listaKartona[i2].SmanjiRedCekanja(j);
                            }
                        }
                    }
                    k17736.listaPregleda.Remove(n);
                    Console.WriteLine("Odaberite opciju: \n" +
                        "1. Promijeni terapiju\n" +
                        "2. Napisi primjedbu za postojecu terapiju\n" +
                        "3. Zakazi dodatne preglede ");
                    ulaz = Console.ReadLine();
                    int x6;
                    Int32.TryParse(ulaz, out x6);
                    if (x6 == 1) //Promijeni terapiju
                    {
                        while (true)
                        {
                            Console.WriteLine("Odaberite tip terapije: \n" +
                                "1. Dugorocna\n" +
                                "2. Kratkorocna");
                            int x2;
                            ulaz = Console.ReadLine();
                            Int32.TryParse(ulaz, out x2);
                            TipTerapije tip1;
                            if (x2 == 1) tip1 = TipTerapije.Dugorocna;
                            else if (x2 == 2) tip1 = TipTerapije.Kratkorocna;
                            else
                            {
                                Console.WriteLine("Pogresan unos. Ponovite!");
                                continue;
                            }
                            Console.WriteLine("Opisite terapiju: ");
                            ulaz = Console.ReadLine();
                            k17736.trenutnaTerapija = new Terapija(tip1, ulaz, o17736.doktor, DateTime.Now);
                            break;
                        }


                    }
                    else if (x6 == 2) // Napisi primjedbu za postojecu terapiju
                    {
                        k17736.trenutnaTerapija.blokirana = true;
                        Console.WriteLine("Opisite gresku u trenutnoj terapiji: ");
                        k17736.trenutnaTerapija.greska = Console.ReadLine();
                    }
                    else if (x6 == 3) //Zakazivanje pregleda
                    {
                        ZakaziPregede(k17736);
                    }

                    klinika17736.listaKartona[i] = k17736;
                    klinika17736.listaOrdinacija[i1] = o17736;
                }
                else if (x == 6) //ANALIZA SADRŽAJA
                {
                    Console.WriteLine("Odaberite:\n" +
                        "1. Prikaz najposjecenijeg doktora\n" +
                        "2. Prikaz pacijenta koji je u klinici bio najvise puta\n" +
                        "3. Prikaz aparata koji je najvise puta bio u kvaru");
                    int a;
                    ulaz = Console.ReadLine();
                    Int32.TryParse(ulaz, out a);
                    if (a == 1)
                    {
                        Doktor d17736 = klinika17736.listaDoktora[0];
                        foreach (Doktor d in klinika17736.listaDoktora)
                        {
                            if (d17736.brojPacijenataUkupno < d.brojPacijenataUkupno)
                            {
                                d17736 = d;
                            }
                        }
                        Console.WriteLine(d17736.imeIprezime);
                    }
                    else if (a == 2)
                    {
                        Pacijent p17736 = klinika17736.listaPacijenata[0];
                        foreach (Pacijent d in klinika17736.listaPacijenata)
                        {
                            if (p17736.brojPosjeta < d.brojPosjeta)
                            {
                                p17736 = d;
                            }
                        }
                        Console.WriteLine(p17736.imeIprezime);
                    }
                    else if (a == 3)
                    {
                        Aparat a17736 = klinika17736.listaAparata[0];
                        foreach (Aparat d in klinika17736.listaAparata)
                        {
                            if (a17736.putaUKvaru < d.putaUKvaru)
                            {
                                a17736 = d;
                            }
                        }
                        Console.WriteLine(a17736.tip);
                    }

                }
                else if (x == 7) //NAPLATA
                {
                    Int64 jmbg = UnosJMBG();
                    Karton k17736 = klinika17736.listaKartona.FirstOrDefault(p => p.pacijent.jmbg == jmbg);
                    int i = klinika17736.listaKartona.FindIndex(p => p.pacijent.jmbg == jmbg);
                    int cijena;
                    cijena = 0;
                    cijena = Cjenovnik(k17736.obavljeniPregledi);

                    Console.WriteLine("Odaberite nacin placanja: \n" +
                        "1. Gotovinsko\n" +
                        "2. Na rate\n" +
                        "3. Uplata rate");
                    int x1;
                    ulaz = Console.ReadLine();
                    Int32.TryParse(ulaz, out x1);

                    if (x1 == 3)
                    {
                        Console.WriteLine("DUG: {0}", k17736.pacijent.dug);
                        Console.WriteLine("Uplaceno: ");
                        ulaz = Console.ReadLine();
                        Decimal uplaceno;
                        Decimal.TryParse(ulaz, out uplaceno);
                        k17736.pacijent.dug = cijena - uplaceno;
                        if (k17736.pacijent.dug == 0)
                        {
                            k17736.pacijent.placanjeNaRate = false;
                        }
                        continue;
                    }
                    else if (x1 == 2) k17736.pacijent.placanjeNaRate = true;
                    if (k17736.pacijent.Redovni())
                    {
                        if (k17736.pacijent.placanjeNaRate)
                        {
                            Console.WriteLine("UKUPNO: {0}", cijena);
                            Console.WriteLine("Uplaceno: ");
                            ulaz = Console.ReadLine();
                            Decimal uplaceno;
                            Decimal.TryParse(ulaz, out uplaceno);
                            k17736.pacijent.dug = cijena - uplaceno;
                        }
                        else Console.WriteLine("POPUST: 10%\n" +
                                "UKUPNO: {0}", cijena * 0.9);
                    }

                    else
                    {
                        if (k17736.pacijent.placanjeNaRate)
                        {
                            Console.WriteLine("POVECANJE CIJENE: 15%\n" +
                             "UKUPNO: {0}", cijena * 1.15);
                            Console.WriteLine("Uplaceno: ");
                            ulaz = Console.ReadLine();
                            Decimal uplaceno;
                            Decimal.TryParse(ulaz, out uplaceno);
                            k17736.pacijent.dug = cijena - uplaceno;
                        }
                        else Console.WriteLine("UKUPNO: {0}", cijena);
                    }
                    k17736.obavljeniPregledi.Clear();
                    klinika17736.listaKartona[i] = k17736;
                }
                else if (x == 8)
                {
                    foreach (Doktor d17736 in klinika17736.listaDoktora)
                    {
                        d17736.brojPacijenataDan = 0;
                    }
                }
                else if (x == 9)
                {
                    Console.WriteLine(" 1. Doktor nedostupan\n" +
                        "2. Doktor dostupan\n" +
                        "3. Aparat u kvaru\n" +
                        "4. Aparat popravljen");
                    int x1;
                    ulaz = Console.ReadLine();
                    Int32.TryParse(ulaz, out x1);
                    if (x1 == 1)
                    {
                        Console.WriteLine("Unesite ime doktora: ");
                        string ime = Console.ReadLine();
                        int i = klinika17736.listaDoktora.FindIndex(d => d.imeIprezime == ime);
                        klinika17736.listaDoktora[i].dostupan = false;
                        int i1 = klinika17736.listaOrdinacija.FindIndex(o => o.doktor.imeIprezime == ime);
                        klinika17736.listaOrdinacija[i1].doktor = klinika17736.listaDoktora[i];
                    }
                    else if (x1 == 2)
                    {
                        Console.WriteLine("Unesite ime doktora: ");
                        string ime = Console.ReadLine();
                        int i = klinika17736.listaDoktora.FindIndex(d => d.imeIprezime == ime);
                        klinika17736.listaDoktora[i].dostupan = true;
                        int i1 = klinika17736.listaOrdinacija.FindIndex(o => o.doktor.imeIprezime == ime);
                        klinika17736.listaOrdinacija[i1].doktor = klinika17736.listaDoktora[i];
                    }
                    else if (x1 == 3)
                    {
                        Console.WriteLine("Unesite tip aparata: ");
                        string tip = Console.ReadLine();
                        int i = klinika17736.listaAparata.FindIndex(d => d.tip == tip);
                        klinika17736.listaAparata[i].uKvaru = true;
                        klinika17736.listaAparata[i].putaUKvaru++;
                        int i1 = klinika17736.listaOrdinacija.FindIndex(o => o.aparat.tip == tip);
                        klinika17736.listaOrdinacija[i1].aparat = klinika17736.listaAparata[i];
                    }
                    else if (x1 == 4)
                    {
                        Console.WriteLine("Unesite tip aparata: ");
                        string tip = Console.ReadLine();
                        int i = klinika17736.listaAparata.FindIndex(d => d.tip == tip);
                        klinika17736.listaAparata[i].uKvaru = false;
                        int i1 = klinika17736.listaOrdinacija.FindIndex(o => o.aparat.tip == tip);
                        klinika17736.listaOrdinacija[i1].aparat = klinika17736.listaAparata[i];
                    }
                }
                else if (x == 10)
                {
                    Console.WriteLine("Doviđenja!");
                    foreach (Doktor d in klinika17736.listaDoktora)
                    {
                        d.brojPacijenataDan = 0;
                    }
                }
                else
                {
                    Console.WriteLine("Pogresan unos!");
                }
            }
        }

        static Pacijent RegistrujPacijentaNormalniSlucaj()
        {
            string ulaz;
            while (true)
            { //Unosi se sve dok se ne unesu ispravni podaci

                string ime;
                DateTime datum;
                Int64 jmbg;
                Spol pol;
                bool ubraku;
                string adresa;

                //UNOS IMENA I PREZIMENA
                Console.WriteLine("Unesite ime i prezime pacijenta: ");
                ime = Console.ReadLine();

                //UNOS DATUMA RODJENJA
                Console.WriteLine("Unesite datum rođenja (dan.mjesec.godina)");
                ulaz = Console.ReadLine();
                string[] datumi = ulaz.Split('.');
                int a, b, c;
                Int32.TryParse(datumi[0], out a);
                Int32.TryParse(datumi[1], out b);
                Int32.TryParse(datumi[2], out c);
                try
                {
                    datum = new DateTime(c, b, a);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Pogresan unos");
                    continue;
                }

                // UNOS ZA JMBG 
                jmbg = UnosJMBG();

                //UNOS SPOLA
                Console.WriteLine("Spol:\n" +
                    "1. Muski\n" +
                    "2. Zenski ");
                ulaz = Console.ReadLine();
                Int32.TryParse(ulaz, out a);
                if (a == 1) pol = Spol.muski;
                else if (a == 2) pol = Spol.zenski;
                else
                {
                    Console.WriteLine("Pogresan unos");
                    continue;
                }

                //UNOS BRACNOG STATUSA
                Console.WriteLine("U braku:\n" +
                    "1. DA\n" +
                    "2. NE\n");
                ulaz = Console.ReadLine();
                Int32.TryParse(ulaz, out a);
                if (a == 1) ubraku = true;
                else if (a == 2) ubraku = false;
                else
                {
                    Console.WriteLine("Pogresan unos");
                    continue;
                }

                //UNOS ADRESE
                Console.WriteLine("Unesite adresu stanovanja: ");
                adresa = Console.ReadLine();

                //DATUM PRIJEMA - DateTime.Now
                Pacijent p17736 = new Pacijent(ime, datum, jmbg, pol, ubraku, adresa, DateTime.Now);
                p17736.brojPosjeta++;
                return p17736;

            }
        }

        static void IzlistajPreglede(Karton k17736)
        {
            int i = 1;
            foreach (KeyValuePair<Ordinacija, int> pregled in k17736.listaPregleda)
            {
                Console.Write("{0}. ", i);
                i++;
                Console.WriteLine("{0} - {1}", pregled.Key.Ispisi(), pregled.Value);

            }
        }

        static Int64 KreirajKarton()
        {
            Int64 ispravan;
            while (true)
            {
                Int64 jmbg = UnosJMBG();
                try
                {
                    Pacijent p17736 = klinika17736.listaPacijenata.FirstOrDefault(pac => pac.jmbg == jmbg);
                    Console.WriteLine("Da li pacijent trenutno posjeduje alergije?");
                    string alergy = Console.ReadLine();
                    Console.WriteLine("Da li pacijent trenutno boluje od necega?");
                    string bolest = Console.ReadLine();
                    Console.WriteLine("Da li je pacijent prije posjedovao neke alergije?");
                    string prijeAlerg = Console.ReadLine();
                    Console.WriteLine("Da li je pacijent prije bolovao od necega?");
                    string prijeBolest = Console.ReadLine();
                    klinika17736.listaKartona.Add(new Karton(p17736, alergy, bolest, prijeAlerg, prijeBolest));
                    ispravan = jmbg;
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ne postoji pacijent sa navedenim JMBG!");
                    continue;
                }
            }
            return ispravan;
        }

        static Int64 UnosJMBG()
        {
            string ulaz;
            Int64 jm;
            while (true)
            {
                Console.WriteLine("Unesite JMBG pacijenta: ");
                ulaz = Console.ReadLine();
                int numOfDigits = ulaz.Count(char.IsDigit);
                if (numOfDigits != 13)
                {
                    Console.WriteLine("Pogresan unos");
                    continue;
                }
                Int64.TryParse(ulaz, out jm);
                break;
            }
            return jm;
        }

        static void PretragaKartona(Karton k17736)
        {
            string ulaz;
            Console.WriteLine("Odaberite opciju:\n" +
                            "1. Pacijent\n" +
                            "2. Raspored pregleda\n" +
                            "3. Trenutna terapija\n" +
                            "4. Termin zakazanog pregleda\n" +
                            "5. Anamneza");
            ulaz = Console.ReadLine();
            int n1;
            Int32.TryParse(ulaz, out n1);
            if (n1 == 1) Console.WriteLine("{0}ˇ", k17736.pacijent.Ispisi());
            else if (n1 == 2)
            {
                Console.WriteLine("Pregledi: ");
                IzlistajPreglede(k17736);
            }
            else if (n1 == 3) Console.WriteLine("{0}", k17736.trenutnaTerapija.Ispisi());
            else if (n1 == 4)
            {
                CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
                Console.WriteLine(k17736.termin.ToString());
            }
            else if (n1 == 5) Console.WriteLine("{0}", k17736.IspisiAnamnezu());
        }
        static Karton ZakaziPregede(Karton kar17736)
        {
            Console.WriteLine("Vrsta pregleda:\n" +
                "1. Zdravstveno uvjerenje\n" +
                "2. Ostalo");
            string citaj = Console.ReadLine();
            int x5;
            Int32.TryParse(citaj, out x5);
            if (x5 == 1)
            {
                TipOrdinacija tip = TipOrdinacija.OpstaMedicina;
                for (int i = 0; i < 3; i++)
                {
                    if (i == 1) tip = TipOrdinacija.Oftamoloska;
                    else if (i == 2) tip = TipOrdinacija.Internisticka;
                    Ordinacija o = klinika17736.listaOrdinacija.FirstOrDefault(p => p.poljeMedicine == tip);
                    o.redCekanja.Add(kar17736.pacijent);
                    int redniBroj = o.redCekanja.IndexOf(kar17736.pacijent) + 1;
                    kar17736.listaPregleda.Add(new KeyValuePair<Ordinacija, int>(o, redniBroj));
                }
                kar17736.NapraviListuPregleda();
            }
            else if (x5 == 2)
            {
                while (true)
                {
                    Console.WriteLine("Odaberite pregled:\n" +
                        "1. Opsta medicina\n" +
                        "2. Ortopedski\n" +
                        "3. Kardioloski\n" +
                        "4. Dermatoloski\n" +
                        "5. Internisticki\n" +
                        "6. Otorinolaringoloski\n" +
                        "7. Oftamoloski\n" +
                        "8. Laboratorijski\n" +
                        "9. Stomatoloski\n" +
                        "10. Kraj ");
                    int x1;
                    string ulaz = Console.ReadLine();
                    Int32.TryParse(ulaz, out x1);
                    TipOrdinacija tip = new TipOrdinacija();
                    if (x1 == 10) break;
                    else if (x1 == 1) tip = TipOrdinacija.OpstaMedicina;
                    else if (x1 == 2) tip = TipOrdinacija.Ortopedska;
                    else if (x1 == 3) tip = TipOrdinacija.Kardioloska;
                    else if (x1 == 4) tip = TipOrdinacija.Dermatoloska;
                    else if (x1 == 5) tip = TipOrdinacija.Internisticka;
                    else if (x1 == 6) tip = TipOrdinacija.Otorinolaringoloska;
                    else if (x1 == 7) tip = TipOrdinacija.Oftamoloska;
                    else if (x1 == 8) tip = TipOrdinacija.Laboratorijska;
                    else if (x1 == 9) tip = TipOrdinacija.Stomatoloska;
                    else
                    {
                        Console.WriteLine("Pogresan unos.");
                    }
                    Ordinacija o17736 = klinika17736.listaOrdinacija.FirstOrDefault(p => p.poljeMedicine == tip);
                    if (kar17736.listaPregleda.Count(p => p.Key.poljeMedicine == tip) > 0)
                    {
                        Console.WriteLine("Vec ste unijeli taj pregled!");
                        continue;
                    }
                    if (o17736.imaAparat && (o17736.aparat.uKvaru == true || (o17736.aparat.trebaGasiti && DateTime.Now > o17736.aparat.periodGasenja)))
                    {
                        Console.WriteLine("Aparat ordinacije nije dostupan! Bit ce dostupan {0}\n" +
                            "Da li zelite zakazati termin?\n" +
                            "1. Da\n" +
                            "2. Ne", o17736.aparat.proraditCe);
                        int x;
                        ulaz = Console.ReadLine();
                        Int32.TryParse(ulaz, out x);
                        if (x == 1)
                        {
                            kar17736.termin = ZakaziTermin();
                        }
                        continue;
                    }
                    else if (o17736.doktor.dostupan == false)
                    {
                        Console.WriteLine("Doktor nije dostupan!");
                        continue;
                    }
                    o17736.redCekanja.Add(kar17736.pacijent);
                    int redniBroj = o17736.redCekanja.IndexOf(kar17736.pacijent) + 1;
                    kar17736.listaPregleda.Add(new KeyValuePair<Ordinacija, int>(o17736, redniBroj));

                }
                kar17736.NapraviListuPregleda();

            }
            return kar17736;
        }
        static DateTime ZakaziTermin()
        {
            DateTime datum;
            string ulaz;
            while (true)
            {
                Console.WriteLine("Unesite datum dodatnih pregleda (d.m.g): ");
                ulaz = Console.ReadLine();
                string[] datumi = ulaz.Split('.');
                int a, b, c;
                Int32.TryParse(datumi[0], out a);
                Int32.TryParse(datumi[1], out b);
                Int32.TryParse(datumi[2], out c);
                try
                {
                    datum = new DateTime(c, b, a);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Pogresan unos");
                    continue;
                }
                break;
            }
            return datum;
        }
        static int Cjenovnik(List<Ordinacija> l)
        {
            Int32 cijena = new int();
            cijena = 0;
            foreach (Ordinacija o17736 in l)
            {
                if (o17736.poljeMedicine == TipOrdinacija.OpstaMedicina)
                {
                    cijena += 30;
                    Console.WriteLine("Pregled u ordinaciji opste medicine:\n" +
                        "30KM ");
                }
                else if (o17736.poljeMedicine == TipOrdinacija.Ortopedska)
                {
                    cijena += 40;
                    Console.WriteLine("Ortopedski pregled:\n" +
                        "40KM ");
                }
                else if (o17736.poljeMedicine == TipOrdinacija.Kardioloska)
                {
                    cijena += 60;
                    Console.WriteLine("Kardioloski pregled\n" +
                        "60KM");
                }
                else if (o17736.poljeMedicine == TipOrdinacija.Dermatoloska)
                {
                    Console.WriteLine("Dermatoloski pregled:\n" +
                        "50KM ");
                    cijena += 50;
                }
                else if (o17736.poljeMedicine == TipOrdinacija.Internisticka)
                {
                    Console.WriteLine("Internisticki pregled:\n" +
                        "70KM ");
                    cijena += 70;
                }
                else if (o17736.poljeMedicine == TipOrdinacija.Otorinolaringoloska)
                {
                    cijena += 40;
                    Console.WriteLine("Otorinolaringoloski pregled:\n" +
                        "40KM ");
                }
                else if (o17736.poljeMedicine == TipOrdinacija.Oftamoloska)
                {
                    Console.WriteLine("Oftamoloski pregled:\n" +
                        "30KM ");
                    cijena += 30;
                }
                else if (o17736.poljeMedicine == TipOrdinacija.Laboratorijska)
                {
                    Console.WriteLine("Laboratorijski pregled:\n" +
                        "50KM ");
                    cijena += 50;
                }
                else if (o17736.poljeMedicine == TipOrdinacija.Stomatoloska)
                {
                    cijena += 60;
                    Console.WriteLine("Stomatoloski pregled:\n" +
                        "60KM ");
                }
                else if (o17736.poljeMedicine == TipOrdinacija.HitnaSluzba)
                {
                    cijena += 30;
                    Console.WriteLine("Hitna sluzba:\n" +
                        "30KM ");
                }
            }
            return cijena;
        }
    }
}
