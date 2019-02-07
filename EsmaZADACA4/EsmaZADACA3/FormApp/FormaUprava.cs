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
using FormApp;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Security;

namespace FormaApp
{
    public partial class FormaUprava : Form
    {
        BindingList<Zaposleni> spisakZaposlenih;
        BindingList<Aparat> spisakAparata;
        BindingList<Doktor> spisakDoktora;
        Zaposleni zap;
        Aparat ap;
        Doktor doc;
        List<Izuzetak> listaIzuzetaka;
        public FormaUprava()
        {
            spisakZaposlenih = new BindingList<Zaposleni>();
            spisakAparata = new BindingList<Aparat>();
            spisakDoktora = new BindingList<Doktor>();
            listaIzuzetaka = new List<Izuzetak>();
            InitializeComponent();
            listBox1.DataSource = spisakZaposlenih;
            listBox1.DisplayMember = "imeIprezime";
            listBox2.DataSource = spisakAparata;
            listBox2.DisplayMember = "tip";
            listBox3.DataSource = spisakDoktora;
            listBox3.DisplayMember = "imeIprezime";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            List<Doktor> lista = FormaMain.klinika17736.listaDoktora;
            if (lista.Count() != 0)
            {
                Doktor max = lista[0];
                double suma = 0;
                foreach (Doktor d in lista)
                {
                    suma += d.brojPacijenataUkupno;
                    if (d.brojPacijenataUkupno > max.brojPacijenataUkupno)
                    {
                        max = d;
                    }
                }
                label4.Text = max.imeIprezime;
                List<int> postotci = new List<int>();
                int suma2 = 0;
                foreach(Doktor d in lista)
                {
                    if (d.brojPacijenataUkupno == 0) continue;
                    double z = (d.brojPacijenataUkupno / suma) * 100;
                    postotci.Add(Convert.ToInt32(z));
                    suma2 += Convert.ToInt32(z);
                }
                if (suma2 != 100)
                {
                    postotci[0] += 100 - suma2;
                }
                FormaStatistika x = new FormaStatistika(postotci);
                x.ShowDialog();
            }
            else
            {
                label4.Text = "Nema doktora u klinici!";
                label4.ForeColor = Color.Red;
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

            FormaMain.baza.otvoriKonekciju();
            FormaMain.baza.ucitajKartone();
            FormaMain.baza.ucitajPacijente();
            FormaMain.baza.zatvoriKonekciju();
            List<Karton> lista = FormaMain.baza.kartoni;
            
            if (lista.Count() != 0)
            {
                Karton max = lista[0];
                foreach(Karton p in lista)
                {
                    if (p.brojPosjeta > max.brojPosjeta)
                    {

                        max = p;
                    }
                }
                HitniPacijent pac= FormaMain.baza.pacijenti.FirstOrDefault(pa => pa.ID ==max.pacijentID);
                label5.Text = pac.imeIprezime;
            }
            else
            {
                label5.Text = "Nema pacijenata u klinici!";
                label5.ForeColor = Color.Red;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            List<Aparat> lista = FormaMain.klinika17736.listaAparata;
            if (lista.Count() != 0)
            {
                Aparat max = lista[0];
                foreach (Aparat p in lista)
                {
                    if (p.putaUKvaru > max.putaUKvaru)
                    {
                        max = p;
                    }
                }
                label5.Text = max.tip;
            }
            else
            {
                label5.Text = "Nema aparata u klinici!";
                label5.ForeColor = Color.Red;
            }
        }

        private int provjeriZaZaposlenika()// 0-greska, 1-doktor, 2-zaposleni
        {
            if (textBox1.Text == "")
            {
                toolStripStatusLabel1.Text = "Unesite ime i prezime uposlenika";
                toolStripStatusLabel1.ForeColor = Color.Red;
                return 0;
            }
            else
            {
                if (comboBox1.SelectedItem.ToString() == "Doktor")
                {
                    DateTime d = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                    Decimal plata;
                    Decimal.TryParse(textBox2.Text, out plata);
                    string pass = FormaMain.CreateMD5(textBox4.Text);
                    doc =new Doktor(textBox1.Text, d, plata, textBox3.Text, pass);
                    return 1;
                    
                }
                else if (comboBox1.SelectedItem.ToString() == "Medicinski tehnicar")
                {
                    DateTime d = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                    Decimal plata;
                    string pass = FormaMain.CreateMD5(textBox4.Text);
                    Decimal.TryParse(textBox2.Text, out plata);
                    zap= new Zaposleni(textBox1.Text, d, plata, Posao.MedTehnicar, textBox3.Text, pass);
                }
                else if (comboBox1.SelectedItem.ToString() == "Cistaci")
                {
                    DateTime d = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                    Decimal plata;
                    string pass = FormaMain.CreateMD5(textBox4.Text);
                    Decimal.TryParse(textBox2.Text, out plata);
                    zap=new Zaposleni(textBox1.Text, d, plata, Posao.Cistaci, textBox3.Text, pass);
                }
                else if (comboBox1.SelectedItem.ToString() == "Tehnicko osoblje")
                {
                    DateTime d = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                    Decimal plata;
                    string pass = FormaMain.CreateMD5(textBox4.Text);
                    Decimal.TryParse(textBox2.Text, out plata);
                    zap = new Zaposleni(textBox1.Text, d, plata, Posao.TehAdmin, textBox3.Text, pass);
                }
                else if (comboBox1.SelectedItem.ToString() == "Uprava")
                {
                    DateTime d = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                    Decimal plata;
                    string pass = FormaMain.CreateMD5(textBox4.Text);
                    Decimal.TryParse(textBox2.Text, out plata);
                    zap=new Zaposleni(textBox1.Text, d, plata, Posao.Uprava, textBox3.Text, pass);
                }
                else
                {
                    toolStripStatusLabel1.Text = "Odaberite tip uposlenika!";
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    return 0;
                }
                comboBox1.Text = null;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                toolStripStatusLabel1.Text = "";
                return 2;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                toolStripStatusLabel1.Text = "Unesite ime i prezime uposlenika";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
            else
            {
                if (comboBox1.SelectedItem.ToString() == "Doktor")
                {
                    DateTime d = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                    Decimal plata;
                    Decimal.TryParse(textBox2.Text, out plata);
                    string pass = FormaMain.CreateMD5(textBox4.Text);
                    FormaMain.klinika17736.listaDoktora.Add(new Doktor(textBox1.Text, d, plata, textBox3.Text, pass));
                }
                else if (comboBox1.SelectedItem.ToString() == "Medicinski tehnicar")
                {
                    DateTime d = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                    Decimal plata;
                    string pass = FormaMain.CreateMD5(textBox4.Text);
                    Decimal.TryParse(textBox2.Text, out plata);
                    FormaMain.klinika17736.listaOsoblja.Add(new Zaposleni(textBox1.Text, d, plata, Posao.MedTehnicar, textBox3.Text, pass));
                }
                else if (comboBox1.SelectedItem.ToString() == "Cistaci")
                {
                    DateTime d = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                    Decimal plata;
                    string pass = FormaMain.CreateMD5(textBox4.Text);
                    Decimal.TryParse(textBox2.Text, out plata);
                    FormaMain.klinika17736.listaOsoblja.Add(new Zaposleni(textBox1.Text, d, plata, Posao.Cistaci, textBox3.Text, pass));
                }
                else if (comboBox1.SelectedItem.ToString() == "Tehnicko osoblje")
                {
                    DateTime d = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                    Decimal plata;
                    string pass = FormaMain.CreateMD5(textBox4.Text);
                    Decimal.TryParse(textBox2.Text, out plata);
                    FormaMain.klinika17736.listaOsoblja.Add(new Zaposleni(textBox1.Text, d, plata, Posao.TehAdmin, textBox3.Text, pass));
                }
                else if (comboBox1.SelectedItem.ToString() == "Uprava")
                {
                    DateTime d = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
                    Decimal plata;
                    string pass = FormaMain.CreateMD5(textBox4.Text);
                    Decimal.TryParse(textBox2.Text, out plata);
                    FormaMain.klinika17736.listaOsoblja.Add(new Zaposleni(textBox1.Text, d, plata, Posao.Uprava, textBox3.Text, pass));
                }
                else
                {
                    toolStripStatusLabel1.Text = "Odaberite tip uposlenika!";
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    return;
                }
                comboBox1.Text =null;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                toolStripStatusLabel1.Text = "";
            
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text != textBox4.Text)
            {
                errorProvider1.SetError(textBox6, "Sifre se ne slazu!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (textBox4.Text.Count() < 6)
            {
                errorProvider1.SetError(textBox4, "Sifra mora imati minimalno 6 karaktera!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private bool provjeriZaAparat()
        {
            if (textBox5.Text == "" || (!radioButton1.Checked && !radioButton2.Checked) || (!radioButton3.Checked && !radioButton4.Checked) || (!radioButton5.Checked && !radioButton6.Checked))
            {
                return false;
            }
            ap = new Aparat(textBox5.Text, (radioButton1.Checked || radioButton4.Checked), radioButton1.Checked, radioButton5.Checked);
            textBox5.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            return true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox5.Text=="" || (!radioButton1.Checked && !radioButton2.Checked) || (!radioButton3.Checked && !radioButton4.Checked) || (!radioButton5.Checked && !radioButton6.Checked))
            {
                return;
            }
            FormaMain.klinika17736.listaAparata.Add(new Aparat(textBox5.Text, (radioButton1.Checked || radioButton4.Checked), radioButton1.Checked, radioButton5.Checked));
            textBox5.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (provjeriZaAparat())
            {
                spisakAparata.Add(ap);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ( provjeriZaZaposlenika() == 2)
            {
                spisakZaposlenih.Add(zap);
            }
            else if (provjeriZaZaposlenika() == 1)
            {
                spisakDoktora.Add(doc);
            }
        }

        private async Task<bool> SnimiZaposlenogXml()
        {
            if (provjeriZaZaposlenika() == 1)
            {

                XmlSerializer xs = new XmlSerializer(typeof(Doktor));
                SaveFileDialog sfd = new SaveFileDialog() { FileName = "doktor.xml", AddExtension = true, DefaultExt = "xml", };
                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.EndsWith(".xml"))
                {
                    using (Stream s = File.Create(sfd.FileName))
                        xs.Serialize(s, doc);
                }
            }
            else if (provjeriZaZaposlenika() == 2)
            {
                XmlSerializer xs = new XmlSerializer(typeof(Zaposleni));
                SaveFileDialog sfd = new SaveFileDialog() { FileName = "zaposleni.xml", AddExtension = true, DefaultExt = "xml", };
                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.EndsWith(".xml"))
                {
                    using (Stream s = File.Create(sfd.FileName))
                        xs.Serialize(s, zap);
                }
            }
            return true;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            bool x = await SnimiZaposlenogXml();
        }

        private async Task<bool> SnimiListuZaposl()
        {
            if (provjeriZaZaposlenika() == 1)
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Doktor>));
                SaveFileDialog sfd = new SaveFileDialog() { FileName = "doktori.xml", AddExtension = true, DefaultExt = "xml", };
                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.EndsWith(".xml"))
                {
                    using (Stream s = File.Create(sfd.FileName))
                        xs.Serialize(s, spisakDoktora.ToList<Doktor>());
                }
            }
            else if (provjeriZaZaposlenika() == 2)
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Zaposleni>));
                SaveFileDialog sfd = new SaveFileDialog() { FileName = "zaposleni.xml", AddExtension = true, DefaultExt = "xml", };
                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.EndsWith(".xml"))
                {
                    using (Stream s = File.Create(sfd.FileName))
                        xs.Serialize(s, spisakZaposlenih.ToList<Zaposleni>());
                }
            }
            return true;
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            bool x =await SnimiListuZaposl();
        }

        private async Task<bool> UcitajIzXMLZaposlenika()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, CheckFileExists = true };
                if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.EndsWith(".xml"))
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        XmlReader reader = XmlReader.Create(fs);
                        XmlSerializer xs = new XmlSerializer(typeof(List<Zaposleni>));
                        List<Zaposleni> tmp = xs.Deserialize(reader) as List<Zaposleni>;
                        if (tmp != null)
                        {
                            spisakZaposlenih = new BindingList<Zaposleni>(tmp);
                            listBox1.DataSource = null;
                            listBox1.DataSource = spisakZaposlenih;
                            listBox1.DisplayMember = "imeIprezime";
                        }
                    }

                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (SecurityException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }

            try
            {
                OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, CheckFileExists = true };
                if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.EndsWith(".xml"))
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        XmlReader reader = XmlReader.Create(fs);
                        XmlSerializer xs = new XmlSerializer(typeof(List<Doktor>));
                        List<Doktor> tmp = xs.Deserialize(reader) as List<Doktor>;
                        if (tmp != null)
                        {
                            spisakDoktora = new BindingList<Doktor>(tmp);
                            listBox3.DataSource = null;
                            listBox3.DataSource = spisakDoktora;
                            listBox3.DisplayMember = "imeIprezime";
                        }
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (SecurityException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            return true;
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            bool x = await UcitajIzXMLZaposlenika();
        }

        private async Task<bool> UcitajListuZaposlenika()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, CheckFileExists = true };
                if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.EndsWith(".xml"))
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        XmlReader reader = XmlReader.Create(fs);
                        XmlSerializer xs = new XmlSerializer(typeof(List<Zaposleni>));
                        List<Zaposleni> tmp = xs.Deserialize(reader) as List<Zaposleni>;
                        if (tmp != null)
                        {
                            spisakZaposlenih = new BindingList<Zaposleni>(tmp);
                            listBox1.DataSource = null;
                            listBox1.DataSource = spisakZaposlenih;
                            listBox1.DisplayMember = "imeIprezime";
                        }
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (SecurityException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }

            try
            {
                OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, CheckFileExists = true };
                if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.EndsWith(".xml"))
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        XmlReader reader = XmlReader.Create(fs);
                        XmlSerializer xs = new XmlSerializer(typeof(List<Doktor>));
                        List<Doktor> tmp = xs.Deserialize(reader) as List<Doktor>;
                        if (tmp != null)
                        {
                            spisakDoktora = new BindingList<Doktor>(tmp);
                            listBox1.DataSource = null;
                            listBox1.DataSource = spisakDoktora;
                            listBox1.DisplayMember = "imeIprezime";
                        }
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (SecurityException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            return true;
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            bool x = await UcitajListuZaposlenika();
        }

        private async Task<bool> BazaZap(int x)
        {
            if (x == 1)
            {
                try
                {
                    FormaMain.baza.otvoriKonekciju();
                    if (FormaMain.baza.spasiDoktora(doc) != 1) throw new Exception("Doktor nije unesen!");
                    FormaMain.baza.zatvoriKonekciju();
                    MessageBox.Show("Uspjesno unesen doktor");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                    listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.baza));
                }
            }
            else
            {
                try
                {
                    FormaMain.baza.otvoriKonekciju();
                    if (FormaMain.baza.spasiZaposlenika(zap) != 1) throw new Exception("Zaposlenik nije unesen!");
                    FormaMain.baza.zatvoriKonekciju();
                    MessageBox.Show("Uspjesno unesen zaposlenik");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                    listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.baza));
                }
            }
            return true;
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            if (provjeriZaZaposlenika() == 1)
            {
                bool x = await BazaZap(1);
            }
            else if (provjeriZaZaposlenika() == 2)
            {
                bool x = await BazaZap(2);
            }
        }

        private async Task<bool> SnimiAparat()
        {
            if (provjeriZaAparat())
            {
                XmlSerializer xs = new XmlSerializer(typeof(Aparat));
                SaveFileDialog sfd = new SaveFileDialog() { FileName = "aparat.xml", AddExtension = true, DefaultExt = "xml", };
                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.EndsWith(".xml"))
                {
                    using (Stream s = File.Create(sfd.FileName))
                        xs.Serialize(s, ap);
                }
            }
            return true;
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            bool x = await SnimiAparat();
        
        }

        private async Task<bool> SnimiListuAparata()
        {
            
                XmlSerializer xs = new XmlSerializer(typeof(List<Aparat>));
                SaveFileDialog sfd = new SaveFileDialog() { FileName = "aparati.xml", AddExtension = true, DefaultExt = "xml", };
                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.EndsWith(".xml"))
                {
                    using (Stream s = File.Create(sfd.FileName))
                        xs.Serialize(s, spisakAparata.ToList<Aparat>());
                }
            return true;
            
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            bool x = await SnimiListuAparata();
        }
        
        private async Task<bool> UcitajAparat()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, CheckFileExists = true };
                if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.EndsWith(".xml"))
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        XmlReader reader = XmlReader.Create(fs);
                        XmlSerializer xs = new XmlSerializer(typeof(List<Aparat>));
                        List<Aparat> tmp = xs.Deserialize(reader) as List<Aparat>;
                        if (tmp != null)
                        {
                            spisakAparata = new BindingList<Aparat>(tmp);
                            listBox2.DataSource = null;
                            listBox2.DataSource = spisakAparata;
                            listBox2.DisplayMember = "tip";
                        }
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (SecurityException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            return true;
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            bool x = await UcitajAparat();
        }

        private async Task<bool> UcitajListuAparata()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, CheckFileExists = true };
                if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.EndsWith(".xml"))
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        XmlReader reader = XmlReader.Create(fs);
                        XmlSerializer xs = new XmlSerializer(typeof(List<Aparat>));
                        List<Aparat> tmp = xs.Deserialize(reader) as List<Aparat>;
                        if (tmp != null)
                        {
                            spisakAparata = new BindingList<Aparat>(tmp);
                            listBox2.DataSource = null;
                            listBox2.DataSource = spisakAparata;
                            listBox2.DisplayMember = "tip";
                        }
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));

            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (SecurityException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.XML));
            }
            return true;
        }

        private async void button13_Click(object sender, EventArgs e)
        {
            bool x = await UcitajListuAparata();
        }

        private async Task<bool> BazaAparat()
        {
            try
            {
                FormaMain.baza.otvoriKonekciju();
                if (FormaMain.baza.spasiAparat(ap) != 1) throw new Exception("Aparat nije unesen!");
                FormaMain.baza.zatvoriKonekciju();
                MessageBox.Show("Uspjesno unesen aparat");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.baza));
            }
            return true;
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            if (provjeriZaAparat())
            {
                bool x = await BazaAparat();
            }
        }

        private void FormaUprava_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Izuzetak>));

            using (Stream s = File.Open(FormaMain.fileName, FileMode.OpenOrCreate))
                xs.Serialize(s, listaIzuzetaka.ToList<Izuzetak>());
        }
        public static bool Between(DateTime date1, DateTime date2, DateTime input)
        {
            return (input > date1 && input < date2);
        }


        private void TabOutput(int number)
        {
            for (short i = 0; i < number; i++)
                richTextBox1.Text += "\t";
        }

       


        private void button1_Click_1(object sender, EventArgs e)
        {
            List<Izuzetak> l1 = new List<Izuzetak>();
            using (FileStream fs = new FileStream(FormaMain.fileName, FileMode.Open))
            {
                
                XmlReader reader = XmlReader.Create(fs);
                XmlSerializer xs = new XmlSerializer(typeof(List<Izuzetak>));
                List<Izuzetak> tmp = xs.Deserialize(reader) as List<Izuzetak>;
                if (tmp != null)
                {
                    l1 = new List<Izuzetak>(tmp);
                }
            }
            string x = comboBox1.Text;
            DateTime x1 = dateTimePicker2.Value, x2=dateTimePicker3.Value;
            List<Izuzetak> lista= new List<Izuzetak>();
            if (x != "")
            {
                lista = l1.FindAll(p => p.tip.ToString() == x);
            }
            else lista = l1;
            List<Izuzetak> fin = new List<Izuzetak>();
            if ((x1 - x2).Minutes != 0) fin = lista;
            else
            {
                fin = lista.FindAll(l => Between(x1, x2, l.vrijeme));
            }
            foreach(Izuzetak i in fin)
            {
                richTextBox1.Text += i.opis + " " + i.tip.ToString() + " " + i.vrijeme.ToString()+ "\n";
            }
        }
    }
}
