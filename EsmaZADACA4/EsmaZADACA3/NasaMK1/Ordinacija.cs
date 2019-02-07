using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMK1
{
    public enum TipOrdinacija
    {
        OpstaMedicina, HitnaSluzba, Ortopedska, Kardioloska, Dermatoloska, Internisticka, Otorinolaringoloska,
        Oftamoloska, Laboratorijska, Stomatoloska
    };

    public class Ordinacija
    {
        public Ordinacija() { }
        public int ID { get; set; }
        public bool dostupna { get; set; }
        public TipOrdinacija poljeMedicine { get; set; }
        public List<Pacijent> redCekanja;
        public Doktor doktor;
        public int doktorId { get; set; }
        public int aparatId { get; set; }
        public bool imaAparat { get; set; }
        public Aparat aparat;
        public int redniBroj { get; set; }

        public Ordinacija(int iD, bool dostupna, TipOrdinacija poljeMedicine, int doktorId, int aparatId, bool imaAparat)
        {
            ID = iD;
            this.dostupna = dostupna;
            this.poljeMedicine = poljeMedicine;
            this.doktorId = doktorId;
            this.aparatId = aparatId;
            this.imaAparat = imaAparat;
            
        }



        
        public Ordinacija(bool slobodna, TipOrdinacija tip, Doktor doktor, bool ima)
        {
            dostupna = slobodna;
            poljeMedicine = tip;
            this.doktor = doktor;
            imaAparat = ima;
            redCekanja = new List<Pacijent>();
        }
        
        public void DodajAparat(Aparat a)
        {
            aparat = a;
        }
        public void DodajUredCekanja(Pacijent p)
        {
            redCekanja.Add(p);
        }
        public string Ispisi()
        {
            return poljeMedicine.ToString() + "\n";
        }
    }
}
