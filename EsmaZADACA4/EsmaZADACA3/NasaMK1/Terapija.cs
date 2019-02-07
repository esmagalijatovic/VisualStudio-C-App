using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMK1
{
    public enum TipTerapije { Dugorocna, Kratkorocna }
    public class Terapija
    {
        public TipTerapije tip { get; set; }
        public string terapija { get; set; }
        public Doktor doktor;
        public DateTime datumPropisivanja { get; set; }
        public bool blokirana { get; set; }
        public string greska { get; set; }


        public Terapija() { }
        public Terapija(TipTerapije tip, string terapija, Doktor d, DateTime datum)
        {
            this.terapija = terapija;
            this.tip = tip;
            doktor = d;
            datumPropisivanja = datum;
            blokirana = false;
        }
        public string Ispisi()
        {
            return "Terapija: " + terapija + "\nDoktor: " + doktor.imeIprezime + "\nDatum propisivanja: " + datumPropisivanja.ToString("d") + "\n";
        }
    }
}
