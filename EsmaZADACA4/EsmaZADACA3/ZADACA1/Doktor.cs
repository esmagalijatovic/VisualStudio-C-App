using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMK1
{
    public delegate Decimal Bonus(Decimal x, Decimal y, int i);
    public class Doktor : Zaposleni, IDoktor
    {
        public int brojPacijenataDan { get; set; }
        public int brojPacijenataUkupno { get; set; }
        private Decimal bonus = 0.02m;
        public bool dostupan { get; set; }
        public DateTime vracaSe { get; set; }
        public decimal Bonus { get => bonus; set => bonus = value; }
        public Doktor() { }
        public Doktor(string imeIprezime, DateTime datum, Decimal plata, string user, string pass, int id=0) :
             base(imeIprezime, datum, plata, Posao.Doktor, user, pass, id)
        {
            brojPacijenataDan = brojPacijenataUkupno = 0;
            ID = id;
            dostupan = true;
        }
        public Decimal IzracunajBonus()// => plata * bonus * brojPacijenataDan;
        {
            Bonus z = (x, y, i) => x * y * i;
            return z(plata, Bonus, brojPacijenataDan);
        }
        public void dodajPacijenta()
        {
            brojPacijenataDan++;
            brojPacijenataUkupno++;
        }
    }
}
