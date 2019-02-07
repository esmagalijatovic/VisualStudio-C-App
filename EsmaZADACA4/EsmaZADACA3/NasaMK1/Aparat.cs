using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMK1
{
    public sealed class Aparat
    {
        public string tip { get; set; }
        public bool zauzet { get; set; }
        public bool uKvaru { get; set; }
        public bool trebaGasiti { get; set; }
        public DateTime periodGasenja { get; set; }
        public DateTime proraditCe { get; set; }
        public int putaUKvaru { get; set; }
        public int ID { get; set; }
        public Aparat() { }
        public Aparat(string tip, bool nijedostupan, bool pokvaren, bool trebaGasiti, int id=0)
        {
            ID = id;
            this.tip = tip;
            zauzet = nijedostupan;
            uKvaru = pokvaren;
            this.trebaGasiti = trebaGasiti;
        }
        public void Ugasi()
        {
            if (DateTime.Now > periodGasenja) zauzet = true;
        }
    }
}
