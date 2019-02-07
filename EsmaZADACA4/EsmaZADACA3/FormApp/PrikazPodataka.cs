using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NasaMK1;
using System.Windows.Forms;
using FormApp;

namespace FormaApp
{
    public partial class PrikazPodataka : Form
    {
        Pacijent p;
        public PrikazPodataka(Pacijent pac)
        {
            p = pac;
            pacijent = new Pacijent(pac.imeIprezime, pac.datumRodjenja, pac.jmbg, pac.spol, pac.uBraku, pac.adresa, pac.datumPrijema, pac.slika);
            InitializeComponent();
            this.label11.Text = pac.adresa;
            this.label8.Text = pac.imeIprezime;
            this.label12.Text = System.Convert.ToString(pac.spol);
            this.label10.Text = System.Convert.ToString(pac.datumRodjenja.Day) + "/" +
                                System.Convert.ToString(pac.datumRodjenja.Month) + "/" +
                                System.Convert.ToString(pac.datumRodjenja.Year);
            
            this.pictureBox1.Image = pac.slika;
            this.label9.Text = System.Convert.ToString(pac.jmbg);
            if (pac.uBraku == true)
                this.label13.Text = "U braku";
            else this.label13.Text = "Nije u braku";
        }

        private void promijeniSlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormaSlika x = new FormaSlika();
            x.ShowDialog();
            pictureBox1.Image = pacijent.slika;
            p.slika = pacijent.slika;
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show();
        }
    }
}
