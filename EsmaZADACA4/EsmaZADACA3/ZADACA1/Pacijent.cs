using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NasaMK1
{
    public class Pacijent : Osoba
    {
        public DateTime datumPrijema { get; set; }
        public DateTime vrijemeSmrti { get; set; }
        public string razlogSmrti { get; set; }
        public DateTime terminObdukcije { get; set; }
        
        public Int64 jmbg { get; set; }
        public Spol spol { get; set; }
        public bool uBraku { get; set; }
        public string adresa { get; set; }
        public Image slika { get; set; }
        

        public Pacijent() { }
        public Pacijent(string imeIprezime, DateTime datum, Int64 maticni, Spol spol, bool uBraku, string stanovanje, DateTime datumPrijema, Image foto, int id=0) :
            base(imeIprezime, datum)
        {
            ID = id;
            slika = foto;
            jmbg = maticni;
            this.spol = spol;
            this.uBraku = uBraku;
            adresa = stanovanje;
            
        }
        public void SmrtniSlucaj(DateTime vrijeme, string uzrok, DateTime obdukcija = default(DateTime))
        {
            vrijemeSmrti = vrijeme;
            razlogSmrti = uzrok;
            this.terminObdukcije = obdukcija;
        
        }
    }
}
