using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NasaMK1
{
    public class HitniPacijent : Pacijent
    {
        public string prvaPomoc { get; set; }
        public HitniPacijent() { }
        public HitniPacijent(string imeIprezime, DateTime datum, Int64 maticni, Spol spol, bool uBraku, string stanovanje, DateTime datumprijema, Image foto, string pp, int id=0) :
            base(imeIprezime, datum, maticni, spol, uBraku, stanovanje, datumprijema, foto, id)
        {
            prvaPomoc = pp;
        }

        public void Unesipodatke(Pacijent p, string pp)
        {
            this.imeIprezime = p.imeIprezime;
            this.datumRodjenja = p.datumRodjenja;
            this.jmbg = p.jmbg;
            this.spol = p.spol;
            this.uBraku = p.uBraku;
            this.adresa = p.adresa;
            this.datumPrijema = p.datumPrijema;
            prvaPomoc = pp;

        }
        new public string Ispisi()
        {
            Pacijent p = new Pacijent(imeIprezime, datumRodjenja, jmbg, spol, uBraku, adresa, datumPrijema, slika);
            return p.Ispisi() + prvaPomoc;
        }
    }
}
