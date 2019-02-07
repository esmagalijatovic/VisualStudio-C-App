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
    public partial class FormaOsoblje : Form
    {
        public FormaOsoblje()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // FormaMain.klinika17736.listaPacijenata.Add(new Pacijent("ime", DateTime.Now, 1234567890123, Spol.muski, true, "adresa", DateTime.Now));
            // FormaMain.klinika17736.listaOrdinacija[0].redCekanja.Add(FormaMain.klinika17736.listaPacijenata[0]);
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
                    foreach (Pacijent p in o.redCekanja)
                    {
                        lopsta[i] = new System.Windows.Forms.TreeNode();
                        lopsta[i].Text = p.imeIprezime;
                        i++;
                    }
                }
                else if (o.poljeMedicine == TipOrdinacija.Oftamoloska)
                {
                    loft = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    foreach (Pacijent p in o.redCekanja)
                    {
                        loft[i] = new System.Windows.Forms.TreeNode();
                        loft[i].Text = p.imeIprezime;
                        i++;
                    }
                }
                else if (o.poljeMedicine == TipOrdinacija.Kardioloska)
                {
                    lkard = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    foreach (Pacijent p in o.redCekanja)
                    {
                        lkard[i] = new System.Windows.Forms.TreeNode();
                        lkard[i].Text = p.imeIprezime;
                        i++;
                    }
                }
                else if (o.poljeMedicine == TipOrdinacija.Stomatoloska)
                {
                    lstom = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    foreach (Pacijent p in o.redCekanja)
                    {
                        lstom[i] = new System.Windows.Forms.TreeNode();
                        lstom[i].Text = p.imeIprezime;
                        i++;
                    }
                }
                else if (o.poljeMedicine == TipOrdinacija.Ortopedska)
                {
                    lort = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    foreach (Pacijent p in o.redCekanja)
                    {
                        lort[i] = new System.Windows.Forms.TreeNode();
                        lort[i].Text = p.imeIprezime;
                        i++;
                    }
                }
                else if (o.poljeMedicine == TipOrdinacija.Dermatoloska)
                {
                    lderm = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    foreach (Pacijent p in o.redCekanja)
                    {
                        lderm[i] = new System.Windows.Forms.TreeNode();
                        lderm[i].Text = p.imeIprezime;
                        i++;
                    }
                }
                else if (o.poljeMedicine == TipOrdinacija.Otorinolaringoloska)
                {
                    loto = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    foreach (Pacijent p in o.redCekanja)
                    {
                        loto[i] = new System.Windows.Forms.TreeNode();
                        loto[i].Text = p.imeIprezime;
                        i++;
                    }
                }
                else if (o.poljeMedicine == TipOrdinacija.Laboratorijska)
                {
                    llab = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    foreach (Pacijent p in o.redCekanja)
                    {
                        llab[i] = new System.Windows.Forms.TreeNode();
                        llab[i].Text = p.imeIprezime;
                        i++;
                    }
                }
                else if (o.poljeMedicine == TipOrdinacija.Internisticka)
                {
                    linter = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    foreach (Pacijent p in o.redCekanja)
                    {
                        linter[i] = new System.Windows.Forms.TreeNode();
                        linter[i].Text = p.imeIprezime;
                        i++;
                    }
                }
                else if (o.poljeMedicine == TipOrdinacija.HitnaSluzba)
                {
                    lhitn = new System.Windows.Forms.TreeNode[o.redCekanja.Count];
                    int i = 0;
                    foreach (Pacijent p in o.redCekanja)
                    {
                        lhitn[i] = new System.Windows.Forms.TreeNode();
                        lhitn[i].Text = p.imeIprezime;
                        i++;
                    }
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

        private void button2_Click(object sender, EventArgs e)
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
            if (korisnickaKontrola1.pictureBox1 == null)
            {
                toolStripStatusLabel1.Text = "Molimo odaberite sliku!";
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
            else FormaMain.klinika17736.listaPacijenata.Add(new Pacijent(textBox1.Text + " " + textBox5.Text, new DateTime(dateTimePicker1.Value.Date.Year, dateTimePicker1.Value.Date.Month, dateTimePicker1.Value.Date.Day), jmbg, sp, radioButton3.Checked, textBox2.Text, DateTime.Now, korisnickaKontrola1.pictureBox1.Image));
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
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            int numOfDigits = textBox3.Text.Count(char.IsDigit);
            Int64 jmb;
            Int64.TryParse(textBox3.Text, out jmb);
            if (numOfDigits != 13)
            {
                toolStripStatusLabel1.Text = "Pogresan JMBG";
                toolStripStatusLabel1.ForeColor = Color.Red;
                errorProvider1.SetError(textBox3, "Pogresan JMBG");
                textBox3.Text = "";
            }
            else if (FormaMain.klinika17736.listaPacijenata.Count(p => p.jmbg == jmb) != 0) {
                toolStripStatusLabel1.Text = "Vec postoji pacijent sa tim JMBG!";
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
            if (!radioButton1.Checked && !radioButton2.Checked) {
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
            if (numOfDigits != 13)
            {
                toolStripStatusLabel1.Text = "Pogresan JMBG";
                toolStripStatusLabel1.ForeColor = Color.Red;
                errorProvider6.SetError(textBox4, "Pogresan JMBG");
                return;
            }
            else if (FormaMain.klinika17736.listaPacijenata.Count(p => p.jmbg == jmb) == 0)
            {
                toolStripStatusLabel1.Text = "Nije nađen pacijent sa navedenim JMBG";
                toolStripStatusLabel1.ForeColor = Color.Red;
                errorProvider6.SetError(textBox4, "Pogresan JMBG");
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (errorProvider6.GetError(textBox4) != "" || errorProvider6.GetError(textBox4) != "" || textBox4.Text=="" || textBox13.Text=="" )
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

        }

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
                int j = FormaMain.klinika17736.listaKartona.FindIndex(k => k.pacijent.jmbg == jmb);
                int a = FormaMain.klinika17736.listaPacijenata.FindIndex(x => x.jmbg == jmb);
                FormaMain.klinika17736.listaPacijenata[a].brojPosjeta++;
                FormaMain.klinika17736.listaKartona[j].pacijent = FormaMain.klinika17736.listaPacijenata[a];
                if (checkBox1.Checked == false)
                {
                    if (checkBox3.Checked)
                    {
                        tip = TipOrdinacija.OpstaMedicina;
                        int i = FormaMain.klinika17736.listaOrdinacija.FindIndex(o => o.poljeMedicine == tip);
                        if (FormaMain.klinika17736.listaOrdinacija[i].doktor.dostupan == false)
                        {
                            MessageBox.Show("Doktor u ordinaciji opste medicine nije dostupan!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else if(FormaMain.klinika17736.listaOrdinacija[i].aparat!=null && (FormaMain.klinika17736.listaOrdinacija[i].aparat.zauzet==true || FormaMain.klinika17736.listaOrdinacija[i].aparat.uKvaru == true)){
                            MessageBox.Show("Aparat u ordinaciji opste medicine nije dostupan", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            FormaMain.klinika17736.listaOrdinacija[i].redCekanja.Add(FormaMain.klinika17736.listaKartona[j].pacijent);
                            int redniBroj = FormaMain.klinika17736.listaOrdinacija[i].redCekanja.IndexOf(FormaMain.klinika17736.listaKartona[j].pacijent) + 1;
                            FormaMain.klinika17736.listaKartona[j].listaPregleda.Add(new KeyValuePair<Ordinacija, int>(FormaMain.klinika17736.listaOrdinacija[i], redniBroj));
                        }
                    }
                    if (checkBox10.Checked)
                    {
                        tip = TipOrdinacija.Ortopedska;
                        int i = FormaMain.klinika17736.listaOrdinacija.FindIndex(o => o.poljeMedicine == tip);
                        if (FormaMain.klinika17736.listaOrdinacija[i].doktor.dostupan == false)
                        {
                            MessageBox.Show("Doktor u ortopedskoj ordinaciji nije dostupan!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else if (FormaMain.klinika17736.listaOrdinacija[i].aparat != null && (FormaMain.klinika17736.listaOrdinacija[i].aparat.zauzet == true || FormaMain.klinika17736.listaOrdinacija[i].aparat.uKvaru == true))
                        {
                            MessageBox.Show("Aparat u ortopedskij ordinaciji  nije dostupan", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            FormaMain.klinika17736.listaOrdinacija[i].redCekanja.Add(FormaMain.klinika17736.listaKartona[j].pacijent);
                            int redniBroj = FormaMain.klinika17736.listaOrdinacija[i].redCekanja.IndexOf(FormaMain.klinika17736.listaKartona[j].pacijent) + 1;
                            FormaMain.klinika17736.listaKartona[j].listaPregleda.Add(new KeyValuePair<Ordinacija, int>(FormaMain.klinika17736.listaOrdinacija[i], redniBroj));
                        }
                    }
                    if (checkBox9.Checked)
                    {
                        tip = TipOrdinacija.Kardioloska;
                        int i = FormaMain.klinika17736.listaOrdinacija.FindIndex(o => o.poljeMedicine == tip);
                        if (FormaMain.klinika17736.listaOrdinacija[i].doktor.dostupan == false)
                        {
                            MessageBox.Show("Doktor u kardioloskoj ordinaciji nije dostupan!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else if (FormaMain.klinika17736.listaOrdinacija[i].aparat != null && (FormaMain.klinika17736.listaOrdinacija[i].aparat.zauzet == true || FormaMain.klinika17736.listaOrdinacija[i].aparat.uKvaru == true))
                        {
                            MessageBox.Show("Aparat u kardioloskoj ordinaciji  nije dostupan", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            FormaMain.klinika17736.listaOrdinacija[i].redCekanja.Add(FormaMain.klinika17736.listaKartona[j].pacijent);
                            int redniBroj = FormaMain.klinika17736.listaOrdinacija[i].redCekanja.IndexOf(FormaMain.klinika17736.listaKartona[j].pacijent) + 1;
                            FormaMain.klinika17736.listaKartona[j].listaPregleda.Add(new KeyValuePair<Ordinacija, int>(FormaMain.klinika17736.listaOrdinacija[i], redniBroj));
                        }
                    }
                    if (checkBox4.Checked)
                    {
                        tip = TipOrdinacija.Dermatoloska;
                        int i = FormaMain.klinika17736.listaOrdinacija.FindIndex(o => o.poljeMedicine == tip);
                        if (FormaMain.klinika17736.listaOrdinacija[i].doktor.dostupan == false)
                        {
                            MessageBox.Show("Doktor u dermatoloskoj ordinaciji nije dostupan!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else if (FormaMain.klinika17736.listaOrdinacija[i].aparat != null && (FormaMain.klinika17736.listaOrdinacija[i].aparat.zauzet == true || FormaMain.klinika17736.listaOrdinacija[i].aparat.uKvaru == true))
                        {
                            MessageBox.Show("Aparat u dermatoloskoj ordinaciji  nije dostupan", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            FormaMain.klinika17736.listaOrdinacija[i].redCekanja.Add(FormaMain.klinika17736.listaKartona[j].pacijent);
                            int redniBroj = FormaMain.klinika17736.listaOrdinacija[i].redCekanja.IndexOf(FormaMain.klinika17736.listaKartona[j].pacijent) + 1;
                            FormaMain.klinika17736.listaKartona[j].listaPregleda.Add(new KeyValuePair<Ordinacija, int>(FormaMain.klinika17736.listaOrdinacija[i], redniBroj));
                        }
                    }
                    if (checkBox5.Checked)
                    {
                        tip = TipOrdinacija.Internisticka;
                        int i = FormaMain.klinika17736.listaOrdinacija.FindIndex(o => o.poljeMedicine == tip);
                        if (FormaMain.klinika17736.listaOrdinacija[i].doktor.dostupan == false)
                        {
                            MessageBox.Show("Doktor u internistickoj ordinaciji nije dostupan!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            FormaMain.klinika17736.listaOrdinacija[i].redCekanja.Add(FormaMain.klinika17736.listaKartona[j].pacijent);
                            int redniBroj = FormaMain.klinika17736.listaOrdinacija[i].redCekanja.IndexOf(FormaMain.klinika17736.listaKartona[j].pacijent) + 1;
                            FormaMain.klinika17736.listaKartona[j].listaPregleda.Add(new KeyValuePair<Ordinacija, int>(FormaMain.klinika17736.listaOrdinacija[i], redniBroj));
                        }
                    }
                    if (checkBox7.Checked)
                    {
                        tip = TipOrdinacija.Otorinolaringoloska;
                        int i = FormaMain.klinika17736.listaOrdinacija.FindIndex(o => o.poljeMedicine == tip);
                        if (FormaMain.klinika17736.listaOrdinacija[i].doktor.dostupan == false)
                        {
                            MessageBox.Show("Doktor u otorinolaringoloskoj ordinaciji nije dostupan!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (FormaMain.klinika17736.listaOrdinacija[i].aparat != null && (FormaMain.klinika17736.listaOrdinacija[i].aparat.zauzet == true || FormaMain.klinika17736.listaOrdinacija[i].aparat.uKvaru == true))
                        {
                            MessageBox.Show("Aparat u otorinolaringoloskoj ordinaciji  nije dostupan", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            FormaMain.klinika17736.listaOrdinacija[i].redCekanja.Add(FormaMain.klinika17736.listaKartona[j].pacijent);
                            int redniBroj = FormaMain.klinika17736.listaOrdinacija[i].redCekanja.IndexOf(FormaMain.klinika17736.listaKartona[j].pacijent) + 1;
                            FormaMain.klinika17736.listaKartona[j].listaPregleda.Add(new KeyValuePair<Ordinacija, int>(FormaMain.klinika17736.listaOrdinacija[i], redniBroj));
                        }
                    }
                    if (checkBox11.Checked)
                    {
                        tip = TipOrdinacija.Oftamoloska;
                        int i = FormaMain.klinika17736.listaOrdinacija.FindIndex(o => o.poljeMedicine == tip);
                        if (FormaMain.klinika17736.listaOrdinacija[i].doktor.dostupan == false)
                        {
                            MessageBox.Show("Doktor u oftalmoloskoj ordinaciji nije dostupan!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (FormaMain.klinika17736.listaOrdinacija[i].aparat != null && (FormaMain.klinika17736.listaOrdinacija[i].aparat.zauzet == true || FormaMain.klinika17736.listaOrdinacija[i].aparat.uKvaru == true))
                        {
                            MessageBox.Show("Aparat u oftalmoloskoj ordinaciji  nije dostupan", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            FormaMain.klinika17736.listaOrdinacija[i].redCekanja.Add(FormaMain.klinika17736.listaKartona[j].pacijent);
                            int redniBroj = FormaMain.klinika17736.listaOrdinacija[i].redCekanja.IndexOf(FormaMain.klinika17736.listaKartona[j].pacijent) + 1;
                            FormaMain.klinika17736.listaKartona[j].listaPregleda.Add(new KeyValuePair<Ordinacija, int>(FormaMain.klinika17736.listaOrdinacija[i], redniBroj));
                        }
                    }
                    if (checkBox6.Checked)
                    {
                        tip = TipOrdinacija.Laboratorijska;
                        int i = FormaMain.klinika17736.listaOrdinacija.FindIndex(o => o.poljeMedicine == tip);
                        if (FormaMain.klinika17736.listaOrdinacija[i].doktor.dostupan == false)
                        {
                            MessageBox.Show("Doktor u laboratoriji nije dostupan!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (FormaMain.klinika17736.listaOrdinacija[i].aparat != null && (FormaMain.klinika17736.listaOrdinacija[i].aparat.zauzet == true || FormaMain.klinika17736.listaOrdinacija[i].aparat.uKvaru == true))
                        {
                            MessageBox.Show("Aparat u laboratoriji  nije dostupan", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            FormaMain.klinika17736.listaOrdinacija[i].redCekanja.Add(FormaMain.klinika17736.listaKartona[j].pacijent);
                            int redniBroj = FormaMain.klinika17736.listaOrdinacija[i].redCekanja.IndexOf(FormaMain.klinika17736.listaKartona[j].pacijent) + 1;
                            FormaMain.klinika17736.listaKartona[j].listaPregleda.Add(new KeyValuePair<Ordinacija, int>(FormaMain.klinika17736.listaOrdinacija[i], redniBroj));
                        }
                    }
                    if (checkBox8.Checked)
                    {
                        tip = TipOrdinacija.Stomatoloska;
                        int i = FormaMain.klinika17736.listaOrdinacija.FindIndex(o => o.poljeMedicine == tip);
                        if (FormaMain.klinika17736.listaOrdinacija[i].doktor.dostupan == false)
                        {
                            MessageBox.Show("Doktor u stomatoloskoj ordinaciji nije dostupan!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (FormaMain.klinika17736.listaOrdinacija[i].aparat != null && (FormaMain.klinika17736.listaOrdinacija[i].aparat.zauzet == true || FormaMain.klinika17736.listaOrdinacija[i].aparat.uKvaru == true))
                        {
                            MessageBox.Show("Aparat u stomatoloskoj ordinaciji  nije dostupan", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            FormaMain.klinika17736.listaOrdinacija[i].redCekanja.Add(FormaMain.klinika17736.listaKartona[j].pacijent);
                            int redniBroj = FormaMain.klinika17736.listaOrdinacija[i].redCekanja.IndexOf(FormaMain.klinika17736.listaKartona[j].pacijent) + 1;
                            FormaMain.klinika17736.listaKartona[j].listaPregleda.Add(new KeyValuePair<Ordinacija, int>(FormaMain.klinika17736.listaOrdinacija[i], redniBroj));
                        }
                        FormaMain.klinika17736.listaKartona[j].NapraviListuPregleda();
                    }
                }
                else
                {
                    tip = TipOrdinacija.OpstaMedicina;
                    int i = FormaMain.klinika17736.listaOrdinacija.FindIndex(o => o.poljeMedicine == tip);
                    FormaMain.klinika17736.listaOrdinacija[i].redCekanja.Add(FormaMain.klinika17736.listaKartona[j].pacijent);
                    int redniBroj = FormaMain.klinika17736.listaOrdinacija[i].redCekanja.IndexOf(FormaMain.klinika17736.listaKartona[j].pacijent) + 1;
                    FormaMain.klinika17736.listaKartona[j].listaPregleda.Add(new KeyValuePair<Ordinacija, int>(FormaMain.klinika17736.listaOrdinacija[i], redniBroj));
                    tip = TipOrdinacija.Oftamoloska;
                    FormaMain.klinika17736.listaOrdinacija[i].redCekanja.Add(FormaMain.klinika17736.listaKartona[j].pacijent);
                    redniBroj = FormaMain.klinika17736.listaOrdinacija[i].redCekanja.IndexOf(FormaMain.klinika17736.listaKartona[j].pacijent) + 1;
                    FormaMain.klinika17736.listaKartona[j].listaPregleda.Add(new KeyValuePair<Ordinacija, int>(FormaMain.klinika17736.listaOrdinacija[i], redniBroj));
                    tip = TipOrdinacija.Internisticka;
                    FormaMain.klinika17736.listaOrdinacija[i].redCekanja.Add(FormaMain.klinika17736.listaKartona[j].pacijent);
                    redniBroj = FormaMain.klinika17736.listaOrdinacija[i].redCekanja.IndexOf(FormaMain.klinika17736.listaKartona[j].pacijent) + 1;
                    FormaMain.klinika17736.listaKartona[j].listaPregleda.Add(new KeyValuePair<Ordinacija, int>(FormaMain.klinika17736.listaOrdinacija[i], redniBroj));
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
                Karton k = FormaMain.klinika17736.listaKartona.FirstOrDefault(p => p.pacijent.jmbg == jmb);
                FormaMain.klinika17736.listaKartona.Remove(k);
                if (checkBox13.Checked)
                {
                    Pacijent p = FormaMain.klinika17736.listaPacijenata.FirstOrDefault(x => x.jmbg == jmb);
                    FormaMain.klinika17736.listaPacijenata.Remove(p);
                }
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

        private void button8_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Text == "" && errorProvider11.GetError(maskedTextBox1) == "" && (radioButton5.Checked || radioButton6.Checked || radioButton7.Checked)) {
                Int64 jmbg;
                Int64.TryParse(maskedTextBox1.Text, out jmbg);
                Karton kar = FormaMain.klinika17736.listaKartona.FirstOrDefault(k => k.pacijent.jmbg == jmbg);
                int ukupno = 0;
                foreach (Ordinacija o17736 in kar.obavljeniPregledi)
                {
                    int cijena = 0;
                    string ordinac="";
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
                    dj.Add(new TreeNode("Cijena: " + cijena.ToString()+ " KM"));
                    treeView2.Nodes.Clear();
                    treeView2.Nodes.Add(new TreeNode(ordinac, dj.ToArray()));

                }
                

                if (kar.pacijent.Redovni() && radioButton5.Checked)
                {
                    label19.Text = "Popust: 10%   Ukupno: " + (ukupno * 0.9).ToString();
                }
                else if ((kar.pacijent.Redovni() && radioButton6.Checked) || ( radioButton5.Checked))
                {
                    label19.Text = "Ukupno: " + ukupno.ToString()+" KM";
                    
                    if (kar.pacijent.Redovni() && radioButton6.Checked)
                    {
                        kar.pacijent.dug += ukupno;
                        label20.Text = "Uplaceno:";
                        textBox14.Size = new Size(70, 20);
                        button9.Size = new Size(75, 23);
                    }
                }
                else if (radioButton6.Checked)
                {
                    label19.Text = "Povecanje cijene: 15%  Ukupno: " + (ukupno * 1.15).ToString();
                    kar.pacijent.dug += Convert.ToDecimal(ukupno * 1.15);
                    label20.Text = "Uplaceno:";
                    textBox14.Size = new Size(70, 20);
                    button9.Size = new Size(75, 23);

                }
                else if (radioButton7.Checked)
                {
                    label19.Text = "Dug iznosi: " + kar.pacijent.dug.ToString();
                    label20.Text = "Uplaceno:";
                    textBox14.Size = new Size(70, 20);
                    button9.Size = new Size(75, 23);
                }
                int i = FormaMain.klinika17736.listaPacijenata.FindIndex(p => p.jmbg == jmbg);
                kar.obavljeniPregledi.Clear();
                FormaMain.klinika17736.listaPacijenata[i] = kar.pacijent;
               
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
            Int64 jmbg;
            Int64.TryParse(maskedTextBox1.Text, out jmbg);
            Karton kar = FormaMain.klinika17736.listaKartona.FirstOrDefault(k => k.pacijent.jmbg == jmbg);
            int i = FormaMain.klinika17736.listaPacijenata.FindIndex(p => p.jmbg == jmbg);
            if (radioButton6.Checked) kar.pacijent.placanjeNaRate = true;
            int uplaceno;
            Int32.TryParse(textBox14.Text, out uplaceno);
            kar.pacijent.dug -= uplaceno;
            if (kar.pacijent.dug == 0) kar.pacijent.placanjeNaRate = false;
            FormaMain.klinika17736.listaPacijenata[i] = kar.pacijent;
            maskedTextBox1.Text = "";
            treeView2.Nodes.Clear();
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            textBox14.Size = new Size(0, 0);
            button9.Size = new Size(0, 0);
            label19.Text = "";
            label20.Text = "";
        }

        private void groupBox6_Validating(object sender, CancelEventArgs e)
        {
            if(!radioButton5.Checked && !radioButton6.Checked && !radioButton7.Checked)
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
            if(GetMonthsBetween(d, DateTime.Now) > 6)
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
            if(textBox13.Text.Count() < 6)
            {
                errorProvider14.SetError(textBox4, "Lozinka mora imati najmanje 6 karaktera!");
                textBox13.Text = "";
            }
        }
    }
}
