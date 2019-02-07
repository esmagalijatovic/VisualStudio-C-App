using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMK1
{
    public class Pregled
    {
        public int ID { get; set; }
        public string opisPregleda { get; set; }
        public int doktorID { get; set; }
        public int pacijentID { get; set; }
        public int ordinacijaID { get; set; }
        public bool hitan { get; set; }
        public bool obavljen { get; set; }
        public decimal cijena { get; set; }
        public DateTime termin { get; set; }
        public int redCekanja { get; set; }
        public Pregled() { }
        public Pregled(string opisPregleda, int doktorID, int pacijentID, int ordinacijaID, bool hitan, bool obavljen, DateTime termin, int cekanje)
        {
            redCekanja = cekanje;
            this.opisPregleda = opisPregleda;
            this.doktorID = doktorID;
            this.pacijentID = pacijentID;
            this.ordinacijaID = ordinacijaID;
            this.hitan = hitan;
            this.obavljen = obavljen;
            this.termin = termin;
        }
    }
}
