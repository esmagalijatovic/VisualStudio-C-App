using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMK1
{
    public enum Spol { muski, zenski };
    public abstract class Osoba
    {
        public string imeIprezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public int ID { get; set; }

        public Osoba() { }
        public Osoba(string imeIprezime, DateTime datum)
        {
            this.imeIprezime = imeIprezime;
            datumRodjenja = datum;

        }
        public string Ispisi()
        {
            return "Ime i prezime: " + imeIprezime + "\n" + "Datum rođenja: " + datumRodjenja.ToString("d") + "\n";
        }
    }
}
