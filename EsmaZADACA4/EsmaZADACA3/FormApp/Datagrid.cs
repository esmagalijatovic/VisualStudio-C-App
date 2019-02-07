using NasaMK1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FormApp
{
    public partial class Datagrid : Form
    {
        BindingList<HitniPacijent> spisakPac;
        string xmlFileName;
        bool loaded = false;
        public Datagrid(BindingList<HitniPacijent> spisakPac, string fname) 
        {
            InitializeComponent();
            this.spisakPac = spisakPac;
            this.xmlFileName=fname;
            dataGridView1.DataSource = spisakPac;
            loaded = true;
        }
        private void updateXMLFile()
        {
            if (loaded)
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<HitniPacijent>));
                using (Stream s = File.Create(xmlFileName))
                    xs.Serialize(s, spisakPac.ToList<HitniPacijent>());
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            updateXMLFile();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            updateXMLFile();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            updateXMLFile();
        }
    }
}
