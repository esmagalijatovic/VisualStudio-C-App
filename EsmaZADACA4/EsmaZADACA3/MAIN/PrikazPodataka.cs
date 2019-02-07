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

namespace MAIN
{
    public partial class PrikazPodataka : Form
    {
        public PrikazPodataka(Pacijent pac)
        {
            this.pacijent = pac;
            InitializeComponent();
            this.label11.Text = pacijent.adresa;
            this.label8.Text = pacijent.imeIprezime;
            this.label12.Text = System.Convert.ToString(pacijent.spol);
            this.label10.Text = System.Convert.ToString(pacijent.datumRodjenja.Day) + "/" +
                                System.Convert.ToString(pacijent.datumRodjenja.Month) + "/" +
                                System.Convert.ToString(pacijent.datumRodjenja.Year);
            this.label14.Text = System.Convert.ToString(pacijent.brojPosjeta);
            this.pictureBox1.Image = pacijent.slika;
            this.label9.Text = System.Convert.ToString(pacijent.jmbg);
            if (pacijent.uBraku == true)
                this.label13.Text = "U braku";
            else this.label13.Text = "Nije u braku";
        }

        
    }
}
