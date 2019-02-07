using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaApp
{
    public partial class KorisnickaKontrola : UserControl
    {
        public KorisnickaKontrola()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog2.Filter = "Slike|*.jpg;*.png;*.bmp";
            if (openFileDialog2.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog2.FileName))
            {
                pictureBox1.Image = Image.FromFile(openFileDialog2.FileName);
                pictureBox1.ImageLocation = openFileDialog2.FileName;
            }
            else
            {
                MessageBox.Show("Profilna slika nije pravilno izabrana ili nije u ispravnom formatu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
