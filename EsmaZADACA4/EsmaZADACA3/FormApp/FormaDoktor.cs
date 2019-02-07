using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NasaMK1;

namespace FormaApp
{
    public partial class FormaDoktor : Form
    {
        
        Ordinacija ord;
        Doktor doc;
        public FormaDoktor(Doktor doc)
        {
            this.doc = doc;
            InitializeComponent();
            this.ord = FormaMain.klinika17736.listaOrdinacija.FirstOrDefault(o => o.doktor.imeIprezime == this.doc.imeIprezime);
            this.toolStripLabel1.Text = doc.imeIprezime;
            

            
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            Int64 jmb;
            Int64.TryParse(textBox1.Text, out jmb);
            int numOfDigits = textBox1.Text.Count(char.IsDigit);
            if (numOfDigits != 13)
            {
                errorProvider1.SetError(textBox1, "Pogresan JMBG");
                toolStripStatusLabel1.Text = "Unesite ispravan JMBG!";
                toolStripStatusLabel1.ForeColor = Color.Red;
                return;
            }
            else if (FormaMain.klinika17736.listaPacijenata.Count(p => p.jmbg == jmb) == 0)
            {
                errorProvider1.SetError(textBox1, "Ne postoji pacijent sa tim JMBG");
                toolStripStatusLabel1.Text = "Unesite ispravan JMBG!";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
            else
            {
                errorProvider1.Clear();
                toolStripStatusLabel1.Text = "";
            }
        }


        private void prikazPacijentaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Text != "")
            {
                toolStripStatusLabel1.Text = "Unesite ispravan JMBG!";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
            else
            {
                
                Int64 jmbg;
                Int64.TryParse(textBox1.Text, out jmbg);
                Pacijent p = FormaMain.klinika17736.listaPacijenata.FirstOrDefault(pac => pac.jmbg == jmbg);
                PrikazPodataka x = new PrikazPodataka(p);
                x.ShowDialog();
                toolStripStatusLabel1.Text = "";
            }
        }

        private void prikazKartonaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (errorProvider1.GetError(textBox1) == "")
            {
                Int64 jmbg;
                Int64.TryParse(textBox1.Text, out jmbg);
                Karton karton = FormaMain.klinika17736.listaKartona.FirstOrDefault(k => k.pacijent.jmbg == jmbg);
                Pacijent p = FormaMain.klinika17736.listaPacijenata.FirstOrDefault(pac => pac.jmbg == jmbg);
                PrikazKartona x = new PrikazKartona(karton);
                x.ShowDialog();
                toolStripStatusLabel1.Text = "";
            }
            else
            {
                toolStripStatusLabel1.Text = "Unesite ispravan JMBG!";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
        }

        private void prikazListeCekanjaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string pacijenti="";
            Ordinacija ord = FormaMain.klinika17736.listaOrdinacija.FirstOrDefault(o => o.doktor.imeIprezime == doc.imeIprezime);
            foreach(Pacijent p in ord.redCekanja)
            {
                pacijenti += p.imeIprezime + "\n";
            }
            MessageBox.Show(pacijenti, "Red cekanja");

        }

        private void dostupanToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            doc.dostupan = true;
        }

        private void nedostupanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doc.dostupan=false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (errorProvider1.GetError(textBox1) == "")
            {
                Int64 jmbg;
                Int64.TryParse(textBox1.Text, out jmbg);
                doc.brojPacijenataDan++;
                doc.brojPacijenataUkupno++;
                Karton karton = FormaMain.klinika17736.listaKartona.FirstOrDefault(k => k.pacijent.jmbg == jmbg);
                if (ord.redCekanja.Count(y => y.jmbg == karton.pacijent.jmbg) == 0)
                {
                    toolStripStatusLabel1.Text = "Pacijent nije zakazan u ovoj ordinaciji!";
                    return;
                }
                else
                {
                    toolStripStatusLabel1.Text = "";
                }
                TipTerapije tip;
                if (radioButton1.Checked) tip = TipTerapije.Dugorocna;
                else tip = TipTerapije.Kratkorocna;
                karton.trenutnaTerapija = new Terapija(tip, textBox2.Text, this.doc, DateTime.Now);
                textBox2.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                toolStripStatusLabel1.Text = "";
                karton.obavljeniPregledi.Add(ord);
                KeyValuePair<Ordinacija, int> x = karton.listaPregleda.FirstOrDefault(c => c.Key.poljeMedicine == ord.poljeMedicine);
                karton.listaPregleda.Remove(x);
                Pacijent p = ord.redCekanja.FirstOrDefault(pac => pac.jmbg == karton.pacijent.jmbg);
                ord.redCekanja.Remove(p);
                int j = FormaMain.klinika17736.listaOrdinacija.FindIndex(o => o.poljeMedicine == ord.poljeMedicine);
                FormaMain.klinika17736.listaOrdinacija[j] = ord;
                int i = FormaMain.klinika17736.listaKartona.FindIndex(k => k.pacijent.jmbg == jmbg);
                FormaMain.klinika17736.listaKartona[i] = karton;
            }
            else
            {
                toolStripStatusLabel1.Text = "Unesite ispravan JMBG!";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (errorProvider1.GetError(textBox1) == "")
            {
                Int64 jmbg;
                Int64.TryParse(textBox1.Text, out jmbg);
                Karton karton = FormaMain.klinika17736.listaKartona.FirstOrDefault(k => k.pacijent.jmbg == jmbg);
                karton.trenutnaTerapija.greska = textBox3.Text;
                textBox3.Text = "";
                toolStripStatusLabel1.Text = "";
                int i = FormaMain.klinika17736.listaKartona.FindIndex(k => k.pacijent.jmbg == jmbg);
                FormaMain.klinika17736.listaKartona[i] = karton;
            }
            else
            {
                toolStripStatusLabel1.Text = "Unesite ispravan JMBG!";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (errorProvider1.GetError(textBox1) == "")
            {
                Int64 jmbg;
                Int64.TryParse(textBox1.Text, out jmbg);
                Karton karton = FormaMain.klinika17736.listaKartona.FirstOrDefault(k => k.pacijent.jmbg == jmbg);
                List<TipOrdinacija> tipovi= new List<TipOrdinacija>();
                if (checkBox1.Checked) tipovi.Add(TipOrdinacija.OpstaMedicina);
                if (checkBox2.Checked) tipovi.Add(TipOrdinacija.Oftamoloska);
                if (checkBox3.Checked) tipovi.Add(TipOrdinacija.Ortopedska);
                if (checkBox4.Checked) tipovi.Add(TipOrdinacija.Dermatoloska);
                if (checkBox5.Checked) tipovi.Add(TipOrdinacija.Stomatoloska);
                if (checkBox6.Checked) tipovi.Add(TipOrdinacija.Otorinolaringoloska);
                if (checkBox7.Checked) tipovi.Add(TipOrdinacija.Laboratorijska);
                if (checkBox8.Checked) tipovi.Add(TipOrdinacija.Internisticka);
                if (checkBox9.Checked) tipovi.Add(TipOrdinacija.Kardioloska);
                foreach(TipOrdinacija t in tipovi)
                {
                    int i = FormaMain.klinika17736.listaOrdinacija.FindIndex(o => o.poljeMedicine == t);
                    FormaMain.klinika17736.listaOrdinacija[i].redCekanja.Add(karton.pacijent);
                    int redniBroj = FormaMain.klinika17736.listaOrdinacija[i].redCekanja.IndexOf(karton.pacijent) + 1;
                    karton.listaPregleda.Add(new KeyValuePair<Ordinacija, int>(FormaMain.klinika17736.listaOrdinacija[i], redniBroj));
                    
                }
                if (tipovi.Count() == 0)
                {
                    toolStripLabel1.Text = "Molimo oznacite jedan od pregleda!";
                    toolStripStatusLabel1.ForeColor = Color.Red;
                }
                else
                {
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                    checkBox5.Checked = false;
                    checkBox6.Checked = false;
                    checkBox7.Checked = false;
                    checkBox8.Checked = false;
                    checkBox9.Checked = false;
                    toolStripLabel1.Text = "";
                }
                int i1= FormaMain.klinika17736.listaKartona.FindIndex(k => k.pacijent.jmbg == jmbg);
                FormaMain.klinika17736.listaKartona[i1] = karton;
            }
            else
            {
                toolStripStatusLabel1.Text = "Unesite ispravan JMBG!";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
        }
    }
}
