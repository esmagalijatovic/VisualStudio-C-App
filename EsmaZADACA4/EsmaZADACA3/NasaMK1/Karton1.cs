using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NasaMK1
{
    public partial class Karton
    {
        public void NapraviListuPregleda()
        {
            listaPregleda.Sort((x, y) => x.Value.CompareTo(y.Value));
        }
        public bool DaLiSuIsti(string md5pass)
        {
            if (Pass == md5pass) return true;
            return false;
        }
        public string IspisiAnamnezu()
        {
            return "Alergije: " + alergije + "\nBolesti: " + bolesti + "\nPrijasnje alergije: " + prethodneAlergije +
            "\nPrijasnje bolesti: " + prethodneBolesti + "\n";
        }
        public string Ispisi()
        {
            string vrati;
            vrati = pacijent.Ispisi() + "Pregledi: \n";
            foreach (KeyValuePair<Ordinacija, int> pregled in listaPregleda)
            {
                vrati += pregled.Key.Ispisi();
            }
            vrati += trenutnaTerapija.Ispisi();
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
            if (termin != null) vrati += termin.ToString() + "\n";
            vrati += IspisiAnamnezu();
            return vrati;
        }
    }
}
