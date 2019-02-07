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
    public partial class PrikazKartona : Form
    {
        public Karton k = new Karton();
        public PrikazKartona(Karton karton)
        {
            k = karton;
            InitializeComponent();
            this.label10.Text = k.prethodneBolesti;
            this.label9.Text = k.prethodneAlergije;
            label8.Text = k.pacijent.imeIprezime;
            label13.Text = k.trenutnaTerapija.Ispisi();
            label12.Text = k.alergije;
            label11.Text = k.bolesti;
        }
    }
}
