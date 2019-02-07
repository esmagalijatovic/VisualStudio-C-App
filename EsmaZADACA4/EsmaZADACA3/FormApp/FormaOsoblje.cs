using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using FormApp;
using NasaMK1;

namespace FormaApp
{
    public partial class FormaOsoblje : Form
    {
        private BindingList<HitniPacijent> spisakPacijenata;
        private HitniPacijent hp;
        private BindingList<Karton> spisakKartona;
        private Karton kar;
        private BindingList<Aparat> spisakAparata;
        private Aparat ap;
        List<Izuzetak> listaIzuzetaka;
        public FormaOsoblje()
        {
            spisakPacijenata = new BindingList<HitniPacijent>();
            spisakKartona = new BindingList<Karton>();
            spisakAparata = new BindingList<Aparat>();
            InitializeComponent();
            listBox1.DataSource = spisakPacijenata;
            listBox1.DisplayMember = "imeIprezime";
            listBox2.DataSource = spisakKartona;
            listBox2.DisplayMember = "username";
            listaIzuzetaka = new List<Izuzetak>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            System.Windows.Forms.TreeNode[] lopsta = new System.Windows.Forms.TreeNode[100];
            System.Windows.Forms.TreeNode[] loft = new System.Windows.Forms.TreeNode[100];
            System.Windows.Forms.TreeNode[] lkard = new System.Windows.Forms.TreeNode[100];
            System.Windows.Forms.TreeNode[] lstom = new System.Windows.Forms.TreeNode[100];
            System.Windows.Forms.TreeNode[] lort = new System.Windows.Forms.TreeNode[100];
            System.Windows.Forms.TreeNode[] lderm = new System.Windows.Forms.TreeNode[100];
            System.Windows.Forms.TreeNode[] loto = new System.Windows.Forms.TreeNode[100];
            System.Windows.Forms.TreeNode[] llab = new System.Windows.Forms.TreeNode[100];
            System.Windows.Forms.TreeNode[] linter = new System.Windows.Forms.TreeNode[100];
            System.Windows.Forms.TreeNode[] lhitn = new System.Windows.Forms.TreeNode[100];
            foreach (Ordinacija o in FormaMain.klinika17736.listaOrdinacija)
            {
                if (o.poljeMedicine == TipOrdinacija.OpstaMedicina)
                {
                    lopsta = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    lopsta[i] = new System.Windows.Forms.TreeNode();
                    lopsta[i].Text = o.redniBroj.ToString();
                }
                else if (o.poljeMedicine == TipOrdinacija.Oftamoloska)
                {
                    loft = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    loft[i] = new System.Windows.Forms.TreeNode();
                    loft[i].Text = o.redniBroj.ToString();
                }
                else if (o.poljeMedicine == TipOrdinacija.Kardioloska)
                {
                    lkard = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    lkard[i] = new System.Windows.Forms.TreeNode();
                    lkard[i].Text = o.redniBroj.ToString();
                }
                else if (o.poljeMedicine == TipOrdinacija.Stomatoloska)
                {
                    lstom = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    lstom[i] = new System.Windows.Forms.TreeNode();
                    lstom[i].Text = o.redniBroj.ToString();
                }
                else if (o.poljeMedicine == TipOrdinacija.Ortopedska)
                {
                    lort = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    lort[i] = new System.Windows.Forms.TreeNode();
                    lort[i].Text = o.redniBroj.ToString();
                }
                else if (o.poljeMedicine == TipOrdinacija.Dermatoloska)
                {
                    lderm = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    lderm[i] = new System.Windows.Forms.TreeNode();
                    lderm[i].Text = o.redniBroj.ToString();
                }
                else if (o.poljeMedicine == TipOrdinacija.Otorinolaringoloska)
                {
                    loto = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;

                    loto[i] = new System.Windows.Forms.TreeNode();
                    loto[i].Text = o.redniBroj.ToString();
                }
                else if (o.poljeMedicine == TipOrdinacija.Laboratorijska)
                {
                    llab = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    llab[i] = new System.Windows.Forms.TreeNode();
                    llab[i].Text = o.redniBroj.ToString();
                }
                else if (o.poljeMedicine == TipOrdinacija.Internisticka)
                {
                    linter = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    linter[i] = new System.Windows.Forms.TreeNode();
                    linter[i].Text = o.redniBroj.ToString();
                }
                else if (o.poljeMedicine == TipOrdinacija.HitnaSluzba)
                {
                    lhitn = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    lhitn[i] = new System.Windows.Forms.TreeNode();
                    lhitn[i].Text = o.redniBroj.ToString();
                }
            }
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Opsta medicina", lopsta);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Oftamoloska ordinacija", loft);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Kardioloska ordinacija", lkard);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Stomatoloska ordinacija", lstom);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Ortopedska ordinacija", lort);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Dermatoloska ordinacija", lderm);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Otorinolaringoloska ordinacija", loto);
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Laboratorija", llab);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Internisticka ordinacija", linter);
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Hitna služba", lhitn);
            this.treeView1.LineColor = System.Drawing.Color.DimGray;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Opsta medicina";
            treeNode3.Name = "Node1";
            treeNode3.Text = "Oftamoloska ordinacija";
            treeNode4.Name = "Node2";
            treeNode4.Text = "Kardioloska ordinacija";
            treeNode5.Name = "Node3";
            treeNode5.Text = "Stomatoloska ordinacija";
            treeNode6.Name = "Node4";
            treeNode6.Text = "Ortopedska ordinacija";
            treeNode7.Name = "Node5";
            treeNode7.Text = "Dermatoloska ordinacija";
            treeNode8.Name = "Node6";
            treeNode8.Text = "Otorinolaringoloska ordinacija";
            treeNode9.Name = "Node7";
            treeNode9.Text = "Laboratorija";
            treeNode10.Name = "Node8";
            treeNode10.Text = "Internisticka ordinacija";
            treeNode11.Name = "Node9";
            treeNode11.Text = "Hitna služba";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            this.treeView1.Size = new System.Drawing.Size(407, 283);
            this.treeView1.TabIndex = 0;
        }

        bool provjeriSve()
        {
            Int64 jmbg;
            Int64.TryParse(textBox3.Text, out jmbg);
            Spol sp;
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                errorProvider4.SetError(groupBox1, "Oznacite jednu od ponuđenih vrijednosti!");
                toolStripStatusLabel1.Text = "Oznacite spol!";
                toolStripStatusLabel1.ForeColor = Color.Red;
                return false;
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox5.Text == "" || textBox3.Text == "")
            {
                toolStripStatusLabel1.Text = "Molimo unesite sve podatke!";
                toolStripStatusLabel1.ForeColor = Color.Red;
                return false;
            }
            if (radioButton1.Checked) sp = Spol.zenski;
            else sp = Spol.muski;
            if (checkBox1.Checked == true)
            {
                hp = new HitniPacijent(textBox1.Text + " " + textBox5.Text, new DateTime(dateTimePicker1.Value.Date.Year, dateTimePicker1.Value.Date.Month, dateTimePicker1.Value.Date.Day), jmbg, sp, radioButton3.Checked, textBox2.Text, DateTime.Now, korisnickaKontrola1.pictureBox1.Image, tb.Text);
                hp.terminObdukcije = obdukcija;
                hp.razlogSmrti = uzrok;
                hp.vrijemeSmrti = vrijemeSmrti;
                pocistiPage3();
                return true;
            }
            else
            {
                hp = new HitniPacijent(textBox1.Text + " " + textBox5.Text, new DateTime(dateTimePicker1.Value.Date.Year, dateTimePicker1.Value.Date.Month, dateTimePicker1.Value.Date.Day), jmbg, sp, radioButton3.Checked, textBox2.Text, DateTime.Now, korisnickaKontrola1.pictureBox1.Image, "");
                pocistiPage3();
                return true;
            }

        }

        private void pocistiPage3()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            //korisnickaKontrola1 = null;
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            errorProvider5.Clear();
            toolStripStatusLabel1.Text = "";
            tb.Text = "";
            tb.Size = new Size(0, 0);
            cb.Checked = false;
            tabPage3.Controls.Remove(cb);
            checkBox1.Checked = false;
           // korisnickaKontrola1.pictureBox1 = null;
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            Int64 jmbg;
            Int64.TryParse(textBox3.Text, out jmbg);
            Spol sp;
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                errorProvider4.SetError(groupBox1, "Oznacite jednu od ponuđenih vrijednosti!");
                toolStripStatusLabel1.Text = "Oznacite spol!";
                toolStripStatusLabel1.ForeColor = Color.Red;
                return;
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox5.Text == "" || textBox3.Text == "")
            {
                toolStripStatusLabel1.Text = "Molimo unesite sve podatke!";
                toolStripStatusLabel1.ForeColor = Color.Red;
                return;
            }
            if (radioButton1.Checked) sp = Spol.zenski;
            else sp = Spol.muski;
            if (checkBox1.Checked == true)
            {
                FormaMain.klinika17736.listaPacijenata.Add(new HitniPacijent(textBox1.Text + " " + textBox5.Text, new DateTime(dateTimePicker1.Value.Date.Year, dateTimePicker1.Value.Date.Month, dateTimePicker1.Value.Date.Day), jmbg, sp, radioButton3.Checked, textBox2.Text, DateTime.Now, korisnickaKontrola1.pictureBox1.Image, tb.Text));
                int i = FormaMain.klinika17736.listaPacijenata.Count();
                FormaMain.klinika17736.listaPacijenata[i - 1].terminObdukcije = obdukcija;
                FormaMain.klinika17736.listaPacijenata[i - 1].razlogSmrti = uzrok;
                FormaMain.klinika17736.listaPacijenata[i - 1].vrijemeSmrti = vrijemeSmrti;
            }
            else FormaMain.klinika17736.listaPacijenata.Add(new HitniPacijent(textBox1.Text + " " + textBox5.Text, new DateTime(dateTimePicker1.Value.Date.Year, dateTimePicker1.Value.Date.Month, dateTimePicker1.Value.Date.Day), jmbg, sp, radioButton3.Checked, textBox2.Text, DateTime.Now, korisnickaKontrola1.pictureBox1.Image, ""));
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            korisnickaKontrola1 = null;
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            errorProvider5.Clear();
            toolStripStatusLabel1.Text = "";
            tb.Text = "";
            tb.Size = new Size(0, 0);
            cb.Checked = false;
            tabPage3.Controls.Remove(cb);
            checkBox1.Checked = false;
            korisnickaKontrola1.pictureBox1 = null;
        }*/

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            int numOfDigits = textBox3.Text.Count(char.IsDigit);
            Int64 jmb;

            Int64.TryParse(textBox3.Text, out jmb);
            if (numOfDigits != 13 || textBox3.Text.Count() != 13)
            {
                toolStripStatusLabel1.Text = "Pogresan JMBG";
                toolStripStatusLabel1.ForeColor = Color.Red;
                errorProvider1.SetError(textBox3, "Pogresan JMBG");
                textBox3.Text = "";
            }

            else
            {
                toolStripStatusLabel1.Text = "";
                errorProvider1.Clear();
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == "")
            {
                toolStripStatusLabel1.Text = "Unesite trazene informacije!";
                toolStripStatusLabel1.ForeColor = Color.Red;
                errorProvider2.SetError(textBox1, "Nije uneseno ime!");
            }
            else
            {
                toolStripStatusLabel1.Text = "";
                errorProvider2.Clear();
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (textBox5.Text == "")
            {
                toolStripStatusLabel1.Text = "Unesite trazene informacije!";
                toolStripStatusLabel1.ForeColor = Color.Red;
                errorProvider3.SetError(textBox5, "Nije uneseno prezime!");
            }
            else
            {
                toolStripStatusLabel1.Text = "";
                errorProvider3.Clear();
            }
        }

        private void groupBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                errorProvider4.SetError(groupBox1, "Oznacite spol!");
                toolStripStatusLabel1.Text = "Unesite trazene informacije!";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
            else
            {
                toolStripStatusLabel1.Text = "";
                errorProvider4.Clear();
            }
        }

        private void groupBox2_Validating(object sender, CancelEventArgs e)
        {
            if (!radioButton3.Checked && !radioButton4.Checked)
            {
                errorProvider5.SetError(groupBox2, "Oznacite bracno stanje!");
                toolStripStatusLabel1.Text = "Unesite trazene informacije!";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
            else
            {
                toolStripStatusLabel1.Text = "";
                errorProvider5.Clear();
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            Int64 jmb;
            Int64.TryParse(textBox4.Text, out jmb);
            int numOfDigits = textBox4.Text.Count(char.IsDigit);
            if (numOfDigits != 13 || textBox4.Text.Count() != 13)
            {
                toolStripStatusLabel1.Text = "Pogresan JMBG";
                toolStripStatusLabel1.ForeColor = Color.Red;
                errorProvider6.SetError(textBox4, "Pogresan JMBG");
                return;
            }

            else
            {
                toolStripStatusLabel1.Text = "";
                errorProvider6.Clear();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                tb.Location = new System.Drawing.Point(112, 155);
                tb.Size = new System.Drawing.Size(152, 20);
                tb.TabIndex = 17;
                this.tabPage3.Controls.Add(this.tb);
                tb.Text = "Upisite obavljenu prvu pomoc";
                tb.ForeColor = Color.Gray;
                cb.Location = new System.Drawing.Point(283, 158);
                cb.Text = "Desio se smrtni slucaj";
                this.tabPage3.Controls.Add(this.cb);
            }
        }

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            if (cb.Checked == true)
            {
                SmrtniSlucaj x = new SmrtniSlucaj();
                x.ShowDialog();

            }
        }

        private void tb_Enter(object sender, EventArgs e)
        {
            tb.Text = "";
            tb.ForeColor = Color.Black;
        }

        /* private void button3_Click(object sender, EventArgs e)
        {
            if (errorProvider6.GetError(textBox4) != "" || errorProvider6.GetError(textBox4) != "" || textBox4.Text == "" || textBox13.Text == "")
            {
                toolStripStatusLabel1.Text = "Unesite ispravne podatke!";
                return;
            }
            else
            {
                toolStripStatusLabel1.Text = "";
            }
            MessageBox.Show("Korisnicko ime je 'Ime PrezimeXXX gdje XXX predstavljaju zadnje 3 cifre JMBG", "Registrovanje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Int64 jmb;
            Int64.TryParse(textBox4.Text, out jmb);
            Pacijent i = FormaMain.klinika17736.listaPacijenata.FirstOrDefault(p => p.jmbg == jmb);
            string pass = FormaMain.CreateMD5(textBox13.Text);
            FormaMain.klinika17736.listaKartona.Add(new Karton(i, textBox7.Text, textBox6.Text, textBox8.Text, textBox9.Text, pass));
            textBox7.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox13.Text = "";
            errorProvider6.Clear();
            errorProvider14.Clear();
            textBox4.Text = "";

        }*/

        private void textBox10_Validating(object sender, CancelEventArgs e)
        {
            Int64 jmb;
            Int64.TryParse(textBox10.Text, out jmb);
            int numOfDigits = textBox10.Text.Count(char.IsDigit);
            if (numOfDigits != 13)
            {
                toolStripStatusLabel1.Text = "Pogresan JMBG";
                toolStripStatusLabel1.ForeColor = Color.Red;
                errorProvider7.SetError(textBox10, "Pogresan JMBG");
                textBox10.Text = "";
                return;
            }
            else if (FormaMain.klinika17736.listaPacijenata.Count(p => p.jmbg == jmb) == 0)
            {
                toolStripStatusLabel1.Text = "Nije nađen pacijent sa navedenim JMBG";
                toolStripStatusLabel1.ForeColor = Color.Red;
                errorProvider7.SetError(textBox10, "Pogresan JMBG");
                textBox10.Text = "";
                return;

            }
            else if (FormaMain.klinika17736.listaKartona.Count(p => p.pacijent.jmbg == jmb) == 0)
            {
                toolStripStatusLabel1.Text = "Prvo kreirajte karton!";
                toolStripStatusLabel1.ForeColor = Color.Red;
                textBox10.Text = "";
            }
            else
            {
                toolStripStatusLabel1.Text = "";
                errorProvider7.Clear();
            }

        }

        private void zakazi(TipOrdinacija tip, Karton ka)
        {
            FormaMain.baza.otvoriKonekciju();
            Ordinacija o = FormaMain.baza.ordinacije.FirstOrDefault(or => or.poljeMedicine == tip);
            int i = FormaMain.baza.ordinacije.FindIndex(or => or.poljeMedicine == tip);
            Doktor d = FormaMain.baza.doktori.FirstOrDefault(doc => doc.ID == o.doktorId);
            Aparat a = new Aparat();
            if (o.aparatId != 0) a = FormaMain.baza.aparati.FirstOrDefault(apa => apa.ID == o.aparatId);
            if (d.dostupan == false)
            {
                MessageBox.Show("Doktor u ordinaciji nije dostupan!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (o.aparatId != 0 && (a.zauzet == true || a.uKvaru == true))
            {
                MessageBox.Show("Aparat u ordinaciji nije dostupan", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FormaMain.baza.pregledi.Add(new Pregled("", d.ID, ka.pacijentID, o.ID, false, false, DateTime.Now, o.redniBroj + 1));

            }
            o.redniBroj++;
            FormaMain.baza.editOrdinacija(i, o);
            FormaMain.baza.zatvoriKonekciju();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (errorProvider7.GetError(textBox10) == "")
            {
                TipOrdinacija tip;
                Int64 jmb;
                if (textBox10.Text == "")
                {
                    toolStripStatusLabel1.Text = "Prvo unesite JMBG!";
                    toolStripStatusLabel1.ForeColor = Color.Red;
                    return;
                }
                else
                {
                    toolStripStatusLabel1.Text = "";
                }

                Int64.TryParse(textBox10.Text, out jmb);
                FormaMain.baza.otvoriKonekciju();
                FormaMain.baza.ucitajKartone();
                Karton ka = FormaMain.baza.kartoni.FirstOrDefault(k => k.pacijent.jmbg == jmb);
                int j= FormaMain.baza.kartoni.FindIndex(k => k.pacijent.jmbg == jmb);
                ka.brojPosjeta++;
                FormaMain.baza.editKartona(j, ka);
                FormaMain.baza.ucitajOrdinacije();
                FormaMain.baza.ucitajAparate();
                FormaMain.baza.ucitajZaposlenikeIDoktore();
                if (checkBox1.Checked == false)
                {
                    if (checkBox3.Checked)
                    {
                        tip = TipOrdinacija.OpstaMedicina;
                        zakazi(tip, ka);
                    }
                    if (checkBox10.Checked)
                    {
                        tip = TipOrdinacija.Ortopedska;
                        zakazi(tip, ka);
                    }
                    if (checkBox9.Checked)
                    {
                        tip = TipOrdinacija.Kardioloska;
                        zakazi(tip, ka);
                    }
                    if (checkBox4.Checked)
                    {
                        tip = TipOrdinacija.Dermatoloska;
                        zakazi(tip, ka);
                    }
                    if (checkBox5.Checked)
                    {
                        tip = TipOrdinacija.Internisticka;
                        zakazi(tip, ka);
                    }
                    if (checkBox7.Checked)
                    {
                        tip = TipOrdinacija.Otorinolaringoloska;
                        zakazi(tip, ka);
                    }
                    if (checkBox11.Checked)
                    {
                        tip = TipOrdinacija.Oftamoloska;
                        zakazi(tip, ka);
                    }
                    if (checkBox6.Checked)
                    {
                        tip = TipOrdinacija.Laboratorijska;
                        zakazi(tip, ka);
                    }
                    if (checkBox8.Checked)
                    {
                        tip = TipOrdinacija.Stomatoloska;
                        zakazi(tip, ka);
                    }
                }
                else
                {
                    tip = TipOrdinacija.OpstaMedicina;
                    zakazi(tip, ka);
                    tip = TipOrdinacija.Oftamoloska;
                    zakazi(tip, ka);
                    tip = TipOrdinacija.Internisticka;
                    zakazi(tip, ka);
                }
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                textBox10.Text = "";
                errorProvider7.Clear();
                toolStripStatusLabel1.Text = "";
                FormaMain.baza.zatvoriKonekciju();
            }
        }

        private void textBox11_Validating(object sender, CancelEventArgs e)
        {
            Int64 jmb;
            Int64.TryParse(textBox11.Text, out jmb);
            int numOfDigits = textBox11.Text.Count(char.IsDigit);
            if (numOfDigits != 13)
            {
                toolStripStatusLabel1.Text = "Pogresan JMBG";
                toolStripStatusLabel1.ForeColor = Color.Red;
                errorProvider8.SetError(textBox11, "Pogresan JMBG");
                textBox11.Text = "";
                return;
            }
            else if (FormaMain.klinika17736.listaPacijenata.Count(p => p.jmbg == jmb) == 0)
            {
                toolStripStatusLabel1.Text = "Nije nađen pacijent sa navedenim JMBG";
                toolStripStatusLabel1.ForeColor = Color.Red;
                errorProvider8.SetError(textBox11, "Pogresan JMBG");
                textBox11.Text = "";
                return;

            }
            else
            {
                errorProvider8.Clear();
                toolStripStatusLabel1.Text = "";
            }
        }

        private void groupBox3_Validating(object sender, CancelEventArgs e)
        {
            if (checkBox13.Checked && checkBox12.Checked == false)
            {
                toolStripStatusLabel1.Text = "Nije moguce obrisati pacijenta, a ostaviti njegov karton!";
                toolStripStatusLabel1.ForeColor = Color.Red;
                errorProvider9.SetError(groupBox1, "Pogresno oznacavanje!");
            }
            else
            {
                toolStripStatusLabel1.Text = "";
                errorProvider9.Clear();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Int64 jmb;
            Int64.TryParse(textBox11.Text, out jmb);
            if (textBox11.Text == "")
            {
                toolStripStatusLabel1.Text = "Molimo unesite JMBG!";
                toolStripStatusLabel1.ForeColor = Color.Red;
                errorProvider8.SetError(textBox11, "Nije unesen JMBG!");
                return;
            }
            if (!checkBox12.Checked && checkBox13.Checked) return;
            else if (checkBox12.Checked)
            {
                FormaMain.baza.otvoriKonekciju();
                FormaMain.baza.ucitajKartone();
                int k = FormaMain.baza.kartoni.FindIndex(p => p.pacijent.jmbg == jmb);
                FormaMain.baza.brisiKarton(k);
                if (checkBox13.Checked)
                {
                    FormaMain.baza.ucitajPacijente();
                    int p = FormaMain.baza.pacijenti.FindIndex(x => x.jmbg == jmb);
                    FormaMain.baza.brisiPacijenta(p);
                }
                FormaMain.baza.zatvoriKonekciju();
                textBox11.Text = "";
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                toolStripStatusLabel1.Text = "";
                errorProvider9.Clear();
                errorProvider8.Clear();
            }

        }

        private void textBox12_Validating(object sender, CancelEventArgs e)
        {
            if (textBox12.Text == "")
            {
                errorProvider10.SetError(textBox12, "Unesite tip aparata!");
                toolStripStatusLabel1.Text = "Molimo unesite tip aparata!";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
            else if (FormaMain.klinika17736.listaAparata.Count(a => a.tip == textBox12.Text) == 0)
            {
                errorProvider10.SetError(textBox12, "Neispravan tip aparata!");
                toolStripStatusLabel1.Text = "Nije nađen aparat tog tipa!";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
            else
            {
                toolStripStatusLabel1.Text = "";
                errorProvider10.Clear();
            }
        }

        private bool provjeriZaAparat()
        {
            if (checkBox14.Checked || checkBox15.Checked || checkBox16.Checked || checkBox18.Checked || checkBox17.Checked || checkBox19.Checked)
            {
                FormaMain.baza.otvoriKonekciju();
                FormaMain.baza.ucitajAparate();
                FormaMain.baza.zatvoriKonekciju();
                ap = FormaMain.baza.aparati.FirstOrDefault(a => a.tip == textBox12.Text);
                if (checkBox14.Checked) ap.zauzet = true;
                if (checkBox15.Checked)ap.Ugasi();
                if (checkBox16.Checked)
                {
                    ap.uKvaru = true;
                    ap.putaUKvaru++;
                }
                if (checkBox17.Checked || checkBox19.Checked) ap.zauzet = false;
                if (checkBox18.Checked) ap.uKvaru = false;
                ap.proraditCe = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day);
                textBox12.Text = "";
                toolStripStatusLabel1.Text = "";
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
                return true;
            }
            else
            {
                toolStripStatusLabel1.Text = "Odaberite jednu od opcija!";
                toolStripStatusLabel1.ForeColor = Color.Red;
                return false;
            }
        }
        /*
        private void button7_Click(object sender, EventArgs e)
        {
            if (checkBox14.Checked || checkBox15.Checked || checkBox16.Checked || checkBox18.Checked || checkBox17.Checked || checkBox19.Checked)
            {
                int i = FormaMain.klinika17736.listaAparata.FindIndex(a => a.tip == textBox12.Text);
                if (checkBox14.Checked) FormaMain.klinika17736.listaAparata[i].zauzet = true;
                if (checkBox15.Checked) FormaMain.klinika17736.listaAparata[i].Ugasi();
                if (checkBox16.Checked)
                {
                    FormaMain.klinika17736.listaAparata[i].uKvaru = true;
                    FormaMain.klinika17736.listaAparata[i].putaUKvaru++;
                }
                if (checkBox17.Checked || checkBox19.Checked) FormaMain.klinika17736.listaAparata[i].zauzet = false;
                if (checkBox18.Checked) FormaMain.klinika17736.listaAparata[i].uKvaru = false;
                FormaMain.klinika17736.listaAparata[i].proraditCe = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day);
                textBox12.Text = "";
                toolStripStatusLabel1.Text = "";
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
            else
            {
                toolStripStatusLabel1.Text = "Odaberite jednu od opcija!";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
        }
        */
        private void button8_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Text == "" && errorProvider11.GetError(maskedTextBox1) == "" && (radioButton5.Checked || radioButton6.Checked || radioButton7.Checked))
            {
                Int64 ID;
                Int64.TryParse(maskedTextBox1.Text, out ID);
                FormaMain.baza.otvoriKonekciju();
                FormaMain.baza.ucitajPreglede();
                FormaMain.baza.ucitajKartone();
                FormaMain.baza.ucitajOrdinacije();
                FormaMain.baza.zatvoriKonekciju();
                List<Pregled> obavljeniPregledi = FormaMain.baza.pregledi.FindAll(k => k.pacijentID == ID);
                Karton kart = FormaMain.baza.kartoni.FirstOrDefault(k => k.pacijentID == ID);
                int ukupno = 0;
                foreach (Pregled p in obavljeniPregledi)
                {
                    int cijena = 0;
                    Ordinacija o17736 = FormaMain.baza.ordinacije.FirstOrDefault(o => o.ID == p.ordinacijaID);
                    string ordinac = "";
                    if (o17736.poljeMedicine == TipOrdinacija.OpstaMedicina)
                    {
                        cijena = 30;
                        ukupno += 30;
                        ordinac = "Opsta medicina";
                    }
                    else if (o17736.poljeMedicine == TipOrdinacija.Ortopedska)
                    {
                        cijena = 40;
                        ukupno += 40;
                        ordinac = "Ortopedska ordinacija";
                    }
                    else if (o17736.poljeMedicine == TipOrdinacija.Kardioloska)
                    {
                        cijena = 60;
                        ukupno += 60;
                        ordinac = "Kardioloska ordinacija";
                    }
                    else if (o17736.poljeMedicine == TipOrdinacija.Dermatoloska)
                    {
                        cijena = 50;
                        ukupno += 50;
                        ordinac = "Dermatoloska ordinacija";
                    }
                    else if (o17736.poljeMedicine == TipOrdinacija.Internisticka)
                    {
                        ukupno += 70;
                        cijena = 70;
                        ordinac = "Internisticka ordinacija";
                    }
                    else if (o17736.poljeMedicine == TipOrdinacija.Otorinolaringoloska)
                    {
                        ukupno += 40;
                        cijena = 40;
                        ordinac = "Otorinolaringoloska ordinacija";
                    }
                    else if (o17736.poljeMedicine == TipOrdinacija.Oftamoloska)
                    {
                        ukupno += 30;
                        cijena = 30;
                        ordinac = "Oftalmoloska ordinacija";
                    }
                    else if (o17736.poljeMedicine == TipOrdinacija.Laboratorijska)
                    {
                        ukupno += 50;
                        cijena = 50;
                        ordinac = "Laboratorija";
                    }
                    else if (o17736.poljeMedicine == TipOrdinacija.Stomatoloska)
                    {
                        ukupno += 60;
                        cijena = 60;
                        ordinac = "Opsta medicina";
                    }
                    else if (o17736.poljeMedicine == TipOrdinacija.HitnaSluzba)
                    {
                        ukupno += 30;
                        cijena = 30;
                        ordinac = "Hitna sluzba";
                    }
                    List<TreeNode> dj = new List<TreeNode>();
                    dj.Add(new TreeNode("Cijena: " + cijena.ToString() + " KM"));
                    treeView2.Nodes.Clear();
                    treeView2.Nodes.Add(new TreeNode(ordinac, dj.ToArray()));

                }


                if (kart.Redovni() && radioButton5.Checked)
                {
                    label19.Text = "Popust: 10%   Ukupno: " + (ukupno * 0.9).ToString();
                }
                else if ((kart.Redovni() && radioButton6.Checked) || (radioButton5.Checked))
                {
                    label19.Text = "Ukupno: " + ukupno.ToString() + " KM";

                    if (kart.Redovni() && radioButton6.Checked)
                    {
                        kart.dug += ukupno;
                        label20.Text = "Uplaceno:";
                        textBox14.Size = new Size(70, 20);
                        button9.Size = new Size(75, 23);
                    }
                }
                else if (radioButton6.Checked)
                {
                    label19.Text = "Povecanje cijene: 15%  Ukupno: " + (ukupno * 1.15).ToString();
                    kart.dug += Convert.ToDecimal(ukupno * 1.15);
                    label20.Text = "Uplaceno:";
                    textBox14.Size = new Size(70, 20);
                    button9.Size = new Size(75, 23);
                    
                }
                else if (radioButton7.Checked)
                {
                    label19.Text = "Dug iznosi: " + kart.dug.ToString();
                    label20.Text = "Uplaceno:";
                    textBox14.Size = new Size(70, 20);
                    button9.Size = new Size(75, 23);
                }
                FormaMain.baza.otvoriKonekciju();
                FormaMain.baza.ucitajPreglede();
                foreach(Pregled p in obavljeniPregledi)
                {
                    int j = FormaMain.baza.pregledi.FindIndex(pr => pr.ID == p.ID);
                    FormaMain.baza.brisiPregled(j);

                }
                
                int c = FormaMain.baza.kartoni.FindIndex(k => k.ID == kart.ID);
                FormaMain.baza.editKartona(c,kart);
                FormaMain.baza.zatvoriKonekciju();
            }
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            Int64 jmbg;
            Int64.TryParse(maskedTextBox1.Text, out jmbg);
            if (maskedTextBox1.Text.Count() < 13)
            {
                errorProvider11.SetError(maskedTextBox1, "Pogresan JMBG");

            }
            else if (FormaMain.klinika17736.listaKartona.Count(k => k.pacijent.jmbg == jmbg) == 0)
            {
                toolStripStatusLabel1.Text = "Nije pronađen pacijent sa navedenim JMBG!";
                toolStripStatusLabel1.ForeColor = Color.Red;
                errorProvider11.SetError(maskedTextBox1, "Pogresan JMBG");
            }
            else
            {
                errorProvider11.Clear();
                toolStripStatusLabel1.Text = "";
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Int64 ID;
            Int64.TryParse(maskedTextBox1.Text, out ID);
            FormaMain.baza.otvoriKonekciju();
            FormaMain.baza.ucitajKartone();
            FormaMain.baza.ucitajPacijente();
            Karton kart = FormaMain.baza.kartoni.FirstOrDefault(k => k.pacijentID == ID);
            int a = FormaMain.baza.kartoni.FindIndex(k => k.pacijentID == ID);
            if (radioButton6.Checked) kar.placanjeNaRate = true;
            int uplaceno;
            Int32.TryParse(textBox14.Text, out uplaceno);
            kar.dug -= uplaceno;
            if (kar.dug == 0) kar.placanjeNaRate = false;
            maskedTextBox1.Text = "";
            treeView2.Nodes.Clear();
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            textBox14.Size = new Size(0, 0);
            button9.Size = new Size(0, 0);
            label19.Text = "";
            label20.Text = "";
            FormaMain.baza.editKartona(a, kart);
            FormaMain.baza.zatvoriKonekciju();
        }

        private void groupBox6_Validating(object sender, CancelEventArgs e)
        {
            if (!radioButton5.Checked && !radioButton6.Checked && !radioButton7.Checked)
            {
                errorProvider12.SetError(groupBox6, "Odaberite jednu od opcija!");
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "Odaberite nacin placanja!";
            }
        }



        public static int GetMonthsBetween(DateTime from, DateTime to)
        {
            if (from > to) return GetMonthsBetween(to, from);

            var monthDiff = Math.Abs((to.Year * 12 + (to.Month - 1)) - (from.Year * 12 + (from.Month - 1)));

            if (from.AddMonths(monthDiff) > to || to.Day < from.Day)
            {
                return monthDiff - 1;
            }
            else
            {
                return monthDiff;
            }
        }

        private void korisnickaKontrola1_Validating(object sender, CancelEventArgs e)
        {
            DateTime d = new DateTime(korisnickaKontrola1.dateTimePicker1.Value.Year, korisnickaKontrola1.dateTimePicker1.Value.Month, korisnickaKontrola1.dateTimePicker1.Value.Day);
            if (GetMonthsBetween(d, DateTime.Now) > 6)
            {
                errorProvider13.SetError(korisnickaKontrola1, "Slika je starija od 6 mjeseci!");
                toolStripStatusLabel1.Text = "Odaberite sliku koja nije starija od 6 mjeseci!";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }
            else
            {
                errorProvider13.Clear();
                toolStripStatusLabel1.Text = "";
            }
        }

        private void textBox13_Validating(object sender, CancelEventArgs e)
        {
            if (textBox13.Text.Count() < 6)
            {
                errorProvider14.SetError(textBox4, "Lozinka mora imati najmanje 6 karaktera!");
                textBox13.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (provjeriSve())
            {
                spisakPacijenata.Add(hp);
                pocistiPage3();
            }
        }

        private async Task<bool> XMLasyncSnimiPac()
        {
            XmlSerializer xs = new XmlSerializer(typeof(HitniPacijent));
                SaveFileDialog sfd = new SaveFileDialog() { FileName = "pacijent.xml", AddExtension = true, DefaultExt = "xml", };
                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.EndsWith(".xml"))
                {
                    using (Stream s = File.Create(sfd.FileName))
                        xs.Serialize(s, hp);
                
            }
            return true;
        }

        private async void button11_Click(object sender, EventArgs e)

        {
            if (provjeriSve())
            {
                bool x = await XMLasyncSnimiPac();
            }
            pocistiPage3();
        }

        private async Task<bool> XMLasyncSnimiListuPac()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<HitniPacijent>));
            SaveFileDialog sfd = new SaveFileDialog() { FileName = "pacijenti.xml", AddExtension = true, DefaultExt = "xml", };
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.EndsWith(".xml"))
            {
                using (Stream s = File.Create(sfd.FileName))
                    xs.Serialize(s, spisakPacijenata.ToList<HitniPacijent>());
            }
            
            return true;
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            bool x = await XMLasyncSnimiListuPac();
            pocistiPage3();

        }

        private async Task<bool> BazaPac()
        {
            
                try
                {
                    FormaMain.baza.otvoriKonekciju();
                    if (FormaMain.baza.spasiPacijenta(hp) != 1) throw new Exception("Pacijent nije unesen!");
                    FormaMain.baza.zatvoriKonekciju();
                    MessageBox.Show("Uspjesno unesen pacijent");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                    listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.baza));
                }
                
                spisakPacijenata.Clear();
            
            return true;
        }

        private async void button13_Click(object sender, EventArgs e)
        {
            if (provjeriSve())
            {
                bool x = await BazaPac();
                pocistiPage3();
            }
        }

        private async Task<bool> XMLasyncUcitajListuPac()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, CheckFileExists = true };
                if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.EndsWith(".xml"))
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        XmlReader reader = XmlReader.Create(fs);
                        XmlSerializer xs = new XmlSerializer(typeof(List<HitniPacijent>));
                        List<HitniPacijent> tmp = xs.Deserialize(reader) as List<HitniPacijent>;
                        if (tmp != null)
                        {
                            spisakPacijenata = new BindingList<HitniPacijent>(tmp);
                            listBox1.DataSource = null;
                            listBox1.DataSource = spisakPacijenata;
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

        private async void button2_Click_1(object sender, EventArgs e)
        {
            bool x = await XMLasyncUcitajListuPac();
            
        }

        private async Task<bool> XMLasyncUcitajPacijenta()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, CheckFileExists = true };
                if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.EndsWith(".xml"))
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        XmlReader reader = XmlReader.Create(fs);
                        XmlSerializer xs = new XmlSerializer(typeof(List<HitniPacijent>));
                        List<HitniPacijent> tmp = xs.Deserialize(reader) as List<HitniPacijent>;
                        if (tmp != null)
                        {
                            spisakPacijenata = new BindingList<HitniPacijent>(tmp);
                            listBox1.DataSource = null;
                            listBox1.DataSource = spisakPacijenata;
                            listBox1.DisplayMember = "imeIprezime";
                        }
                    }
                    Datagrid forma = new Datagrid(spisakPacijenata, ofd.FileName);
                    forma.ShowDialog();
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

        private async void button14_Click(object sender, EventArgs e)
        {
            bool x= await XMLasyncUcitajPacijenta();
        }

        private async Task<bool> SnimiListuKartonaAsync()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Karton>));
            SaveFileDialog sfd = new SaveFileDialog() { FileName = "kartoni.xml", AddExtension = true, DefaultExt = "xml", };
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.EndsWith(".xml"))
            {
                using (Stream s = File.Create(sfd.FileName))
                    xs.Serialize(s, spisakKartona.ToList<Karton>());
            }
            return true;
        }

        private async void button17_Click(object sender, EventArgs e)
        {
            bool x = await SnimiListuKartonaAsync();
        }


        private bool provjeriZaKarton()
        {
            if (errorProvider6.GetError(textBox4) != "" || errorProvider6.GetError(textBox4) != "" || textBox4.Text == "" || textBox13.Text == "")
            {
                toolStripStatusLabel1.Text = "Unesite ispravne podatke!";
                return false;
            }
            else
            {
                toolStripStatusLabel1.Text = "";

               // MessageBox.Show("Korisnicko ime je 'Ime PrezimeXXX gdje XXX predstavljaju zadnje 3 cifre JMBG", "Registrovanje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Int64 jmb;
                Int64.TryParse(textBox4.Text, out jmb);
                FormaMain.baza.otvoriKonekciju();
                FormaMain.baza.ucitajPacijente();
                FormaMain.baza.zatvoriKonekciju();
                HitniPacijent pac = FormaMain.baza.pacijenti.FirstOrDefault(p => p.jmbg == jmb);
                string pass = FormaMain.CreateMD5(textBox13.Text);

                kar = new Karton(pac.ID, textBox7.Text, textBox6.Text, textBox8.Text, textBox9.Text, pass, textBox15.Text);
                textBox7.Text = "";
                textBox6.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox13.Text = "";
                errorProvider6.Clear();
                errorProvider14.Clear();
                textBox4.Text = "";
                return true;
            }

        }


        private void button15_Click(object sender, EventArgs e)
        {
            if (provjeriZaKarton())
            {
                spisakKartona.Add(kar);
            }
        }

        private async Task<bool> SnimiKartonAsync()
        {
            
                XmlSerializer xs = new XmlSerializer(typeof(Karton));
                SaveFileDialog sfd = new SaveFileDialog() { FileName = "karton.xml", AddExtension = true, DefaultExt = "xml", };
                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.EndsWith(".xml"))
                {
                    using (Stream s = File.Create(sfd.FileName))
                        xs.Serialize(s, kar);
                }
            
            return true;
        }

        private async void button16_Click(object sender, EventArgs e)
        {
            if (provjeriZaKarton())
            {
                bool x = await SnimiKartonAsync();
            }
        }

        private async Task<bool> UcitajKartonIzXMLAsync()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, CheckFileExists = true };
                if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.EndsWith(".xml"))
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        XmlReader reader = XmlReader.Create(fs);
                        XmlSerializer xs = new XmlSerializer(typeof(List<Karton>));
                        List<Karton> tmp = xs.Deserialize(reader) as List<Karton>;
                        if (tmp != null)
                        {
                            spisakKartona = new BindingList<Karton>(tmp);
                            listBox2.DataSource = null;
                            listBox2.DataSource = spisakKartona;
                            listBox2.DisplayMember = "username";
                        }
                    }
                    Datagrid forma = new Datagrid(spisakPacijenata, ofd.FileName);
                    forma.ShowDialog();
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

        private async void button18_Click(object sender, EventArgs e)
        {
            bool x = await UcitajKartonIzXMLAsync();
        }

        private async Task<bool> UcitajListuKartonaAsync()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, CheckFileExists = true };
                if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.EndsWith(".xml"))
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        XmlReader reader = XmlReader.Create(fs);
                        XmlSerializer xs = new XmlSerializer(typeof(List<Karton>));
                        List<Karton> tmp = xs.Deserialize(reader) as List<Karton>;
                        if (tmp != null)
                        {
                            spisakKartona = new BindingList<Karton>(tmp);
                            listBox1.DataSource = null;
                            listBox1.DataSource = spisakKartona;
                            listBox1.DisplayMember = "username";
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

        private async void button19_Click(object sender, EventArgs e)
        {
            bool x = await UcitajListuKartonaAsync();
        }

        private async Task<bool> BazaKarton()
        {
            try
            {
                FormaMain.baza.otvoriKonekciju();
                if (FormaMain.baza.spasiKarton(kar) != 1) throw new Exception("Karton nije unesen!");
                FormaMain.baza.zatvoriKonekciju();
                MessageBox.Show("Uspjesno unesen karton");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                listaIzuzetaka.Add(new Izuzetak(DateTime.Now, ex.Message, TipIzuzetka.baza));
            }
            spisakKartona.Clear();
            return true;
        }

        private async void button20_Click(object sender, EventArgs e)
        {
            if (provjeriZaKarton())
            {
                bool x = await BazaKarton();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (provjeriZaAparat())
            {
                FormaMain.baza.otvoriKonekciju();
                FormaMain.baza.ucitajAparate();
                int i = FormaMain.baza.aparati.FindIndex(ap1 => ap1.ID == ap.ID);
                FormaMain.baza.editAparata(i, ap);
                FormaMain.baza.zatvoriKonekciju();
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_Validated(object sender, EventArgs e)
        {
            if (textBox15.Text.Count() != 5)
            {
                errorProvider15.SetError(textBox15, "Korisnicko ime mora imati vise od 5 karaktera!");
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "Unesite pravilne podatke!";
            }
            else
            {
                errorProvider15.Clear();
                toolStripStatusLabel1.Text = "";

            }
        }

        private void FormaOsoblje_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Izuzetak>));

            using (Stream s = File.Open(FormaMain.fileName, FileMode.OpenOrCreate)) 
                xs.Serialize(s, listaIzuzetaka.ToList<Izuzetak>());   
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
