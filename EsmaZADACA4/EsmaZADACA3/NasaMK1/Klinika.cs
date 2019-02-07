using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NasaMK1
{
    public class Klinika
    {
        public List<HitniPacijent> listaPacijenata;
        public List<Ordinacija> listaOrdinacija;
        public List<Karton> listaKartona;
        public List<Doktor> listaDoktora;
        public List<Aparat> listaAparata;
        public List<Zaposleni> listaOsoblja;
        public List<Pregled> listaPregleda;

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public Klinika()
        {
        
            listaPregleda = new List<Pregled>();
            listaPacijenata = new List<HitniPacijent>();
            listaPacijenata.Add(new HitniPacijent("Ime", DateTime.Now, 1234567890123, Spol.muski, true, "alala", DateTime.Now, null, ""));
            listaOrdinacija = new List<Ordinacija>();
            listaKartona = new List<Karton>();
            listaDoktora = new List<Doktor>();
            listaAparata = new List<Aparat>();
            listaOsoblja = new List<Zaposleni>();
            Karton k = new Karton(listaPacijenata[0], "", "", "", "", CreateMD5("123"));
            k.username = "caocao";
            
            listaKartona.Add(k);
            listaOsoblja.Add(new Zaposleni("Budi Dobra", DateTime.Now, 100, Posao.Uprava, "Uprava", CreateMD5("upravajezakon")));
            listaOsoblja.Add(new Zaposleni("Kako Si", DateTime.Now, 100, Posao.MedTehnicar, "Osoblje", CreateMD5("osobljejezakon")));
            listaDoktora.Add(new Doktor("Bosanko Horozic", new DateTime(1960, 11, 1), 2000,"Bosanko",CreateMD5("123")));
            listaDoktora.Add(new Doktor("Suad Djumisic", new DateTime(1960, 11, 1), 2000, "Suad", CreateMD5("1234")));
            listaDoktora.Add(new Doktor("Amira Horozic", new DateTime(1960, 11, 1), 2000, "Amira", CreateMD5("12345")));
            listaDoktora.Add(new Doktor("Gena Djumisic", new DateTime(1960, 11, 1), 2000, "", ""));
            listaDoktora.Add(new Doktor("Adnan Galijatovic", new DateTime(1960, 11, 1), 2000, "", ""));
            listaDoktora.Add(new Doktor("Maida Galijatovic", new DateTime(1960, 11, 1), 2000, "", ""));
            listaDoktora.Add(new Doktor("Dzan Horozic", new DateTime(1960, 11, 1), 2000, "", ""));
            listaDoktora.Add(new Doktor("Lajla Galijatovic", new DateTime(1960, 11, 1), 2000, "", ""));
            listaDoktora.Add(new Doktor("Amir Karup", new DateTime(1960, 11, 1), 2000, "", ""));
            listaDoktora.Add(new Doktor("Aida Karup", new DateTime(1960, 11, 1), 2000, "", ""));
            listaAparata.Add(new Aparat("Ultrazvuk", true, false, false));
            listaAparata.Add(new Aparat("EKG", false, false, true));
            listaAparata[1].periodGasenja = new DateTime(2018, 2, 1, 14, 30, 0);
            listaAparata.Add(new Aparat("Dermatoloski aparat", false, false, false));
            listaAparata.Add(new Aparat("Stomatoloski aparat", false, false, false));
            listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.OpstaMedicina, listaDoktora[0], false));
            listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.Oftamoloska, listaDoktora[1], false));
            listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.Kardioloska, listaDoktora[2], true));
            listaOrdinacija[2].aparat = listaAparata[1];
            listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.Ortopedska, listaDoktora[3], false));
            listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.Otorinolaringoloska, listaDoktora[5], false));
            listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.Internisticka, listaDoktora[4], true));
            listaOrdinacija[5].aparat = listaAparata[0];
            listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.Laboratorijska, listaDoktora[6], false));
            listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.HitnaSluzba, listaDoktora[7], false));
            listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.Stomatoloska, listaDoktora[8], true));
            listaOrdinacija.Add(new Ordinacija(true, TipOrdinacija.Dermatoloska, listaDoktora[9], true));
            listaOrdinacija[9].aparat = listaAparata[2];
            listaOrdinacija[8].aparat = listaAparata[3];
        }
        public void ObrisiPacijenta(Int64 jmb)
        {
            Pacijent p = listaPacijenata.FirstOrDefault(pac => pac.jmbg == jmb);
            Karton k = listaKartona.FirstOrDefault(kar => kar.pacijent == p);
           
            listaKartona.Remove(k);
        }

        public void ObrisiDoktora(string ime)
        {
            Doktor d = listaDoktora.FirstOrDefault(doc => doc.imeIprezime == ime);
            listaDoktora.Remove(d);
        }
        public void DodajOrdinaciju(Ordinacija o)
        {
            listaOrdinacija.Add(o);
        }
        public void ObrisiOrdinaciju(Ordinacija o)
        {
            listaOrdinacija.Remove(o);
        }
        public void DodajAparat(Aparat a)
        {
            listaAparata.Add(a);
        }
        public void ObrisiAparat(Aparat a)
        {
            listaAparata.Remove(a);
        }
        public void NedostupanDoktor(Doktor d)
        {
            Doktor x = listaDoktora.FirstOrDefault(doc => doc.imeIprezime == d.imeIprezime);
            x.dostupan = false;
        }

    }
}
