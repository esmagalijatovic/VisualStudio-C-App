using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMK1
{
    public enum Posao { MedTehnicar, Uprava, Cistaci, TehAdmin, Doktor }
    public class Zaposleni : Osoba
    {
        public Decimal plata { get; set; }
        public Posao tipPosla { get; set; }
        public string username { get; set; }
        public string Md5pass { get => md5pass; set => md5pass = value; }

        private string md5pass;
        
        public bool DaLiSuIsti(string pass)
        {
            if (pass == Md5pass) return true;
            return false;
        }


        public Zaposleni() { }
        public Zaposleni(string imeIprezime, DateTime datum, Decimal plata, Posao tip, string user, string pass, int id=0) :
            base(imeIprezime, datum)
        {
            ID = id;
            username = user;
            Md5pass = pass;
            this.plata=plata;
            tipPosla = tip;
        }
    }
}
