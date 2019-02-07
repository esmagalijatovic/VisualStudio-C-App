using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp
{
    public enum TipIzuzetka { XML, baza, UI};
    public class Izuzetak
    {
        public DateTime vrijeme { get; set; }
        public string opis { get; set; }
        public TipIzuzetka tip { get; set; }
        public Izuzetak() { }
        public Izuzetak(DateTime vrijeme, string opis, TipIzuzetka tip)
        {
            this.vrijeme = vrijeme;
            this.opis = opis;
            this.tip = tip;
        }
    }
}
