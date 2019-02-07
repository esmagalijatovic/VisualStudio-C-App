using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMK1
{
    public partial class Karton
    {
        public Pacijent pacijent;
        public int ID { get; set; }
        public List<KeyValuePair<Ordinacija, int>> listaPregleda { get; set; }
        public DateTime termin { get; set; }
        public List<Ordinacija> obavljeniPregledi;
        public Terapija trenutnaTerapija;
        public string alergije { get; set; }
        public string bolesti { get; set; }
        public string prethodneAlergije { get; set; }
        public string prethodneBolesti { get; set; }
        public bool otvoren { get; set; }
        public string username { get; set; }
        public string Pass { get => pass; set => pass = value; }
        public bool aktivan { get; set; }
        public bool placanjeNaRate { get; set; }
        public Decimal dug { get; set; }
        public int brojPosjeta { get; set; }


        private string pass;
        public int pacijentID ;

        public Karton() {
            aktivan = true;
            placanjeNaRate = false;
            dug = 0;
        }
        public Karton(Pacijent p, string alergy, string bolesti, string prethodneBolesti, string prethodneAlergije, string passw)
        {
            username = p.imeIprezime + (p.jmbg % 1000).ToString();
            Pass = passw;
            listaPregleda = new List<KeyValuePair<Ordinacija, int>>();
            obavljeniPregledi = new List<Ordinacija>();
            pacijent = p;
            alergije = alergy;
            this.bolesti = bolesti;
            this.prethodneAlergije = prethodneAlergije;
            this.prethodneBolesti = prethodneBolesti;
            otvoren = true;
            aktivan = true;
            placanjeNaRate = false;
            dug = 0;
            
        }
        public Karton(int idp,  string alergy, string bolesti, string prethodneBolesti, string prethodneAlergije, string passw, string user)
        {
            username = user;
            Pass = passw;
            listaPregleda = new List<KeyValuePair<Ordinacija, int>>();
            obavljeniPregledi = new List<Ordinacija>();
            alergije = alergy;
            pacijentID = idp;
            this.bolesti = bolesti;
            this.prethodneAlergije = prethodneAlergije;
            this.prethodneBolesti = prethodneBolesti;
            otvoren = true;
            aktivan = true;
            placanjeNaRate = false;
            dug = 0;
        }
        public bool Redovni() => brojPosjeta > 3;
        public void SmanjiRedCekanja(int i)
        {
            listaPregleda[i] = new KeyValuePair<Ordinacija, int>(listaPregleda[i].Key, listaPregleda[i].Value - 1);
        }

    }
}
