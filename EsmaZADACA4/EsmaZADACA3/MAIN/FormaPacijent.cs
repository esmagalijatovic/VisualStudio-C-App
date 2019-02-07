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
    public partial class FormaPacijent : Form
    {
        public Karton kar;
        public FormaPacijent(Karton p)
        {
            kar = p;
            InitializeComponent();
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            List<List<TreeNode>> djeca= new List<List<TreeNode>>();
            foreach(KeyValuePair<Ordinacija, int> o in kar.listaPregleda)
            {
                List<TreeNode> dj= new List<TreeNode>();
                dj.Add(new TreeNode("Red cekanja: " + o.Value.ToString()));
                djeca.Add(dj);
            }
            int i = 0; 
            foreach(KeyValuePair<Ordinacija, int> o in kar.listaPregleda)
            {
                treeView1.Nodes.Add(new TreeNode(o.Key.poljeMedicine.ToString(), djeca[i].ToArray()));
                i++;
            }
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            foreach (Ordinacija o17736 in kar.obavljeniPregledi)
            {
                int cijena = 0;
                string ordinac = "";
                if (o17736.poljeMedicine == TipOrdinacija.OpstaMedicina)
                {
                    cijena = 30;
                    ordinac = "Opsta medicina";
                }
                else if (o17736.poljeMedicine == TipOrdinacija.Ortopedska)
                {
                    cijena = 40;
                    ordinac = "Ortopedska ordinacija";
                }
                else if (o17736.poljeMedicine == TipOrdinacija.Kardioloska)
                {
                    cijena = 60;
                    ordinac = "Kardioloska ordinacija";
                }
                else if (o17736.poljeMedicine == TipOrdinacija.Dermatoloska)
                {
                    cijena = 50;
                    ordinac = "Dermatoloska ordinacija";
                }
                else if (o17736.poljeMedicine == TipOrdinacija.Internisticka)
                {
                    cijena = 70;
                    ordinac = "Internisticka ordinacija";
                }
                else if (o17736.poljeMedicine == TipOrdinacija.Otorinolaringoloska)
                {
                    cijena = 40;
                    ordinac = "Otorinolaringoloska ordinacija";
                }
                else if (o17736.poljeMedicine == TipOrdinacija.Oftamoloska)
                {
                    cijena = 30;
                    ordinac = "Oftalmoloska ordinacija";
                }
                else if (o17736.poljeMedicine == TipOrdinacija.Laboratorijska)
                {
                    cijena = 50;
                    ordinac = "Laboratorija";
                }
                else if (o17736.poljeMedicine == TipOrdinacija.Stomatoloska)
                {
                    cijena = 60;
                    ordinac = "Opsta medicina";
                }
                else if (o17736.poljeMedicine == TipOrdinacija.HitnaSluzba)
                {
                    cijena = 30;
                    ordinac = "Hitna sluzba";
                }
                List<TreeNode> dj = new List<TreeNode>();
                dj.Add(new TreeNode("Cijena: " + cijena.ToString() + " KM"));
                treeView2.Nodes.Add(new TreeNode(ordinac, dj.ToArray()));
            }
        }

        private void profilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrikazPodataka x = new PrikazPodataka(kar.pacijent);
            x.ShowDialog();
        }

        private void kartonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrikazKartona x = new PrikazKartona(kar);
            x.ShowDialog();
        }
    }
}
