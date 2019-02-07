using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using FormApp;
using NasaMK1;


namespace FormaApp
{
    
    public partial class FormaMain : Form
    {
        public static Klinika klinika17736 = new Klinika();
        public static Baza baza;
        public static string fileName;
        List<Izuzetak> listaIzuzetaka;
        
        public FormaMain()
        {
           
            InitializeComponent();
            baza = new Baza();
            SaveFileDialog sfd = new SaveFileDialog() { FileName = "logg.xml", AddExtension = true, DefaultExt = "xml", };
            fileName = sfd.FileName;
            listaIzuzetaka = new List<Izuzetak>();
           /* try
            {
                baza.otvoriKonekciju();
                baza.kreirajPocetneTabele();
                baza.zatvoriKonekciju();
                IzKlinikeUBazu(); // ---pocetne vrijednosti 
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e.Message);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, e.Message, TipIzuzetka.baza));
                return;
            }*/

            
        }

        public void IzKlinikeUBazu()
        {
            baza.otvoriKonekciju();
            foreach(Doktor d in klinika17736.listaDoktora)
            {
                baza.spasiDoktora(d);
            }
            foreach (Zaposleni d in klinika17736.listaOsoblja)
            {
                baza.spasiZaposlenika(d);
            }
            foreach (HitniPacijent d in klinika17736.listaPacijenata)
            {
                baza.spasiPacijenta(d);
            }
            foreach (Karton d in klinika17736.listaKartona)
            {
                baza.spasiKarton(d);
            }
            foreach (Pregled d in klinika17736.listaPregleda)
            {
                baza.spasiPregled(d);
            }
            foreach (Ordinacija d in klinika17736.listaOrdinacija)
            {
                baza.spasiOrdinacijiu(d);
            }
            foreach (Aparat d in klinika17736.listaAparata)
            {
                baza.spasiAparat(d);
            }
        }

        public void izjednaciListeAparata()
        {
            baza.ucitajAparate();
            klinika17736.listaAparata = baza.aparati;
        }

        public void izjednaciListePregleda()
        {
            baza.ucitajPreglede();
            klinika17736.listaPregleda = baza.pregledi;
        }

        public void izjednaciListeDoktora()
        {
            baza.ucitajZaposlenikeIDoktore();
            klinika17736.listaDoktora = baza.doktori;
        }

        public void izjednaciListeZaposlenih()
        {
            baza.ucitajZaposlenikeIDoktore();
            klinika17736.listaOsoblja = baza.zaposlenici;
        }

        public void izjednaciListePacijenata()
        {
            baza.ucitajPacijente();
            klinika17736.listaPacijenata = baza.pacijenti;
        }

        public void izjednaciListeOrdinacija()
        {
            baza.ucitajOrdinacije();
            klinika17736.listaOrdinacija = baza.ordinacije;
        }

        public void izjednaciListeKartona()
        {
            baza.ucitajKartone();
            klinika17736.listaKartona = baza.kartoni;
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (x == 0 || textBox2.Text=="" || textBox1.Text=="")
            {
                toolStripStatusLabel1.Text = "Unesite sve podatke!";
                return;
            }
            else
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Izuzetak>));

                using (Stream s = File.Open(FormaMain.fileName, FileMode.OpenOrCreate))
                    xs.Serialize(s, listaIzuzetaka.ToList<Izuzetak>());
                if (x == 1)//uprava ili osoblje
                {

                    FormaUprava formaupr = new FormaUprava();
                    formaupr.ShowDialog();
                }
                else if(x==2) //doktor
                {
                    Doktor d = klinika17736.listaDoktora.FirstOrDefault(p => p.username == textBox1.Text);
                    FormaDoktor doc = new FormaDoktor(d);
                    doc.ShowDialog();
                }
                else if (x == 3)
                {
                    FormaOsoblje osob = new FormaOsoblje();
                    osob.ShowDialog();
                }
                else if (x == 4)
                {
                    Karton p = klinika17736.listaKartona.FirstOrDefault(k => k.username == textBox1.Text);
                    FormaPacijent pac = new FormaPacijent(p);
                    pac.ShowDialog();
                }
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                errorProvider1.Clear();
                errorProvider2.Clear();
                errorProvider3.Clear();
                toolStripStatusLabel1.Text = "";
            }
        }

        public int x = 0;

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (x == 0)
            {
                errorProvider1.SetError(comboBox1, "Prvo unesite tip korisnika!");
                textBox1.Text = "";
            }
            else if (x == 1)
            {
                errorProvider1.Clear();
                int i = baza.zaposlenici.Count(p => p.username == textBox1.Text);
                if (i == 0)
                {
                    errorProvider2.SetError(textBox1, "Nije nađen ni jedan zaposlenik uprave sa tim korisnickim imenom!");
                    textBox1.Text = "";
                }

            }
            else if (x == 2)
            {
                errorProvider1.Clear();
                int i = baza.doktori.Count(p => p.username == textBox1.Text);
                if (i == 0)
                {
                    errorProvider2.SetError(textBox1, "Nije nađen ni jedan doktor sa tim korisnickim imenom!");
                    textBox1.Text = "";
                }
            }
            else if (x == 3)
            {
                errorProvider1.Clear();
                int i = baza.zaposlenici.Count(p => p.username == textBox1.Text);
                if (i == 0)
                {
                    errorProvider2.SetError(textBox1, "Nije nađen ni jedan zaposlenik sa tim korisnickim imenom!");
                    textBox1.Text = "";
                }
            }
            else if (x == 4)
            {
                errorProvider1.Clear();
                int i = baza.kartoni.Count(p => p.username == textBox1.Text);
                if (i == 0)
                {
                    errorProvider2.SetError(textBox1, "Nije nađen ni jedan pacijent sa tim korisnickim imenom!");
                    textBox1.Text = "";
                }
            }
        }

        

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider3.SetError(textBox2, "Prvo unesite korisnicko ime!");
                textBox2.Text = "";
            }
            else if (textBox2.Text == "")
            {
                errorProvider3.SetError(textBox2, "Unesite lozinku!");
                textBox2.Text = "";
            }
            else
            {
                errorProvider3.Clear();
                if (x == 1)
                {
                    int i = baza.zaposlenici.FindIndex(p => p.username == textBox1.Text);
                    if (!baza.zaposlenici[i].DaLiSuIsti(CreateMD5(textBox2.Text)))
                    {
                        toolStripStatusLabel1.Text = "Korisnicko ime i lozinka se ne podudaraju!";
                        toolStripStatusLabel1.ForeColor = Color.Red;
                        textBox2.Text = "";
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "";
                    }
                }
                else if (x == 2)
                {
                    errorProvider1.Clear();
                    int i = baza.doktori.FindIndex(p => p.username == textBox1.Text);
                    if (!baza.doktori[i].DaLiSuIsti(CreateMD5(textBox2.Text)))
                    {
                        toolStripStatusLabel1.Text = "Korisnicko ime i lozinka se ne podudaraju!";
                        toolStripStatusLabel1.ForeColor = Color.Red;
                        textBox2.Text = "";
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "";
                    }
                }
                else if (x == 3)
                {
                    errorProvider1.Clear();
                    int i = baza.zaposlenici.FindIndex(p => p.username == textBox1.Text);
                    if (!baza.zaposlenici[i].DaLiSuIsti(CreateMD5(textBox2.Text)))
                    {
                        toolStripStatusLabel1.Text = "Korisnicko ime i lozinka se ne podudaraju!";
                        toolStripStatusLabel1.ForeColor = Color.Red;
                        textBox2.Text = "";
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "";
                    }
                }
                else if (x == 4)
                {
                    errorProvider1.Clear();
                    int i = baza.kartoni.FindIndex(p => p.username == textBox1.Text);
                    if (!baza.kartoni[i].DaLiSuIsti(CreateMD5(textBox2.Text)))
                    {
                        toolStripStatusLabel1.Text = "Korisnicko ime i lozinka se ne podudaraju!";
                        toolStripStatusLabel1.ForeColor = Color.Red;
                        textBox2.Text = "";
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "";
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Uprava") x = 1;
            else if (comboBox1.Text == "Doktor") x = 2;
            else if (comboBox1.Text == "Osoblje") x = 3;
            else if (comboBox1.Text == "Pacijent") x = 4;
        }
        private Thread nasa;
        private Thread mala;
        private Thread klinika;
        private async Task<bool> nacrtaj1(PaintEventArgs e)
        {
            Font f1 = new Font("Times New Roman", 12, FontStyle.Bold | FontStyle.Italic);
            e.Graphics.DrawString("NAŠA", f1, new SolidBrush(ForeColor), 70, 20);
          //  await Task.Delay(3000);
            return true;
        }
        private async Task<bool> nacrtaj2(PaintEventArgs e)
        {
            Font f1 = new Font("Times New Roman", 12, FontStyle.Bold | FontStyle.Italic);
            e.Graphics.DrawString("MALA", f1, new SolidBrush(ForeColor), 172, 20);
           // await Task.Delay(3000);
            return true;
        }
        private async Task<bool> nacrtaj3(PaintEventArgs e)
        {
            Font f1 = new Font("Times New Roman", 12, FontStyle.Bold | FontStyle.Italic);
            e.Graphics.DrawString("KLINIKA", f1, new SolidBrush(ForeColor), 113, 78+31+6);
            //await Task.Delay(3000);
            return true;
        }


        private async void FormaMain_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics mojGrafickiObjekat;
            mojGrafickiObjekat = this.CreateGraphics();
            Pen mojPen = new Pen(System.Drawing.Color.Red, 5);
            Pen mojPen1 = new Pen(System.Drawing.Color.White, 3);
            SolidBrush mojBrush = new SolidBrush(System.Drawing.Color.Red);
            Point[] polygonTacke = new Point[12];
            polygonTacke[0] = new Point(132, 12);
            polygonTacke[1] = new Point(167, 12);
            polygonTacke[2] = new Point(167, 43);
            polygonTacke[3] = new Point(167 + 35, 43);
            polygonTacke[4] = new Point(167 + 35, 43 + 35);//ovdje + 35
            polygonTacke[5] = new Point(167, 78);
            polygonTacke[6] = new Point(167, 78 + 31);
            polygonTacke[7] = new Point(132, 78 + 31);
            polygonTacke[8] = new Point(132, 78);
            polygonTacke[9] = new Point(132 - 35, 78);
            polygonTacke[10] = new Point(132 - 35, 43);
            polygonTacke[11] = new Point(132, 43);
            Point[] polygonTacke1 = new Point[11];
            polygonTacke1[0] = new Point(100 + 10, 103);
            polygonTacke1[1] = new Point(113 + 10, 35);
            polygonTacke1[2] = new Point(118 + 10, 83);
            polygonTacke1[3] = new Point(126 + 10, 49);
            polygonTacke1[4] = new Point(132 + 10, 90);
            polygonTacke1[5] = new Point(139 + 10, 35);

            polygonTacke1[6] = new Point(143 + 10, 80);
            polygonTacke1[7] = new Point(148 + 10, 49);
            polygonTacke1[8] = new Point(151 + 10, 73);
            polygonTacke1[9] = new Point(156 + 10, 61);
            polygonTacke1[10] = new Point(210 + 10, 61);
            Font f1 = new Font("Times New Roman", 12, FontStyle.Bold | FontStyle.Italic);
            // e.Graphics.DrawString("NAŠA", f1, new SolidBrush(ForeColor), 70,20);

            nasa = new Thread(() => nacrtaj1(e));
            mala = new Thread(() => nacrtaj2(e));
            klinika = new Thread(() => nacrtaj3(e));
  
            
            nacrtaj1(e);
            Thread.Sleep(500);
            nacrtaj2(e);
            Thread.Sleep(500);
            nacrtaj3(e);
            Thread.Sleep(500);
            mojGrafickiObjekat.DrawPolygon(mojPen, polygonTacke); // Crtanje poligona
            mojGrafickiObjekat.FillPolygon(mojBrush, polygonTacke);
            // rastezanje
            Thread.Sleep(300);
            polygonTacke[3] = new Point(167 + 70, 43);
            polygonTacke[4] = new Point(167 + 70, 43 + 35);
            polygonTacke[9] = new Point(132 - 70, 78);
            polygonTacke[10] = new Point(132 - 70, 43);
            
            mojGrafickiObjekat.DrawPolygon(mojPen, polygonTacke); // Crtanje poligona
            mojGrafickiObjekat.FillPolygon(mojBrush, polygonTacke);
            Thread.Sleep(1000);
            polygonTacke[3] = new Point(167 + 35, 43);
            polygonTacke[4] = new Point(167 + 35, 43 + 35);
            polygonTacke[9] = new Point(132 - 35, 78);
            polygonTacke[10] = new Point(132 - 35, 43);

            mojGrafickiObjekat.DrawPolygon(mojPen, polygonTacke); // Crtanje poligona
            mojGrafickiObjekat.FillPolygon(mojBrush, polygonTacke);
            System.Drawing.Graphics mojGrafickiObjekat1;
            mojGrafickiObjekat1 = this.CreateGraphics();
            mojGrafickiObjekat.DrawLines(mojPen1, polygonTacke1); // Crtanje poligona
        }

        private void FormaMain_FormClosed(object sender, FormClosedEventArgs e)
        {
           /* try
            {
                baza.otvoriKonekciju();
                baza.obrisiTabele();
                baza.zatvoriKonekciju();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.baza));
            }*/
        }
    }
}
