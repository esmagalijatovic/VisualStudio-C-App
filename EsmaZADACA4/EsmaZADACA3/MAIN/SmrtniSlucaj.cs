using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAIN
{
    public partial class SmrtniSlucaj : Form
    {
        public SmrtniSlucaj()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a=maskedTextBox1.Text;
            char z = a[0], z1=a[1];
            int c = (z - '0') * 10 + (z1 - '0');
            z = a[3]; z1 = a[4];
            int b = (z - '0') * 10 + (z1 - '0');
            FormaOsoblje.vrijemeSmrti = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, c, b,0);
            FormaOsoblje.uzrok = textBox1.Text;

            FormaOsoblje.obdukcija = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);
            this.Close();
            
        }
    }
}
