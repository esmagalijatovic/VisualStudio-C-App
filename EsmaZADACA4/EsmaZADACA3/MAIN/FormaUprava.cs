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

namespace MAIN
{
    public partial class FormaUprava : Form
    {
        public FormaUprava()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            List<Doktor> lista = FormaMain.klinika17736.listaDoktora;
            if (lista.Count() != 0)
            {
                Doktor max = lista[0];
                foreach (Doktor d in lista)
                {
                    if (d.brojPacijenataUkupno > max.brojPacijenataUkupno)
                    {
                        max = d;
                    }
                }
                label4.Text = max.imeIprezime;
            }
            else
            {
                label4.Text = "Nema doktora u klinici!";
                label4.ForeColor = Color.Red;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            List<Pacijent> lista = FormaMain.klinika17736.listaPacijenata;
            if (lista.Count() != 0)
            {
                Pacijent max = lista[0];
                foreach(Pacijent p in lista)
                {
                    if (p.brojPosjeta > max.brojPosjeta)
                    {
                        max = p;
                    }
                }
                label5.Text = max.imeIprezime;
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
                    // DODATI U KONSTRUKTOR SIFRU I USER!!!!!!!!
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
    }
}
