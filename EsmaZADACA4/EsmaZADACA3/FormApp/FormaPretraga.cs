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

namespace FormApp
{
    public partial class FormaPretraga : Form
    {
        private List<string> dostupniFileovi;
        private BindingList<string> file;
        public FormaPretraga()
        {
            InitializeComponent();
            dostupniFileovi = new List<string>();
            file = new BindingList<string>();
            listBox1.DataSource = file;
        }
        
        private void DirectorySearch(string dir)
        {
           
            string error = null;
            try
            {
                dostupniFileovi.AddRange(Directory.GetFiles(dir));
                dostupniFileovi.AddRange(Directory.GetDirectories(dir));                    
            }
            catch (ArgumentNullException ex)
            {
                error = ex.Message;
            }
            catch (UnauthorizedAccessException ex)
            {
                error = ex.Message;
            }
            catch (PathTooLongException ex)
            {
                error = ex.Message;
            }
            catch (DirectoryNotFoundException ex)
            {
                error = ex.Message;
            }
            catch (IOException ex)
            {
                error = ex.Message;
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                if (!String.IsNullOrWhiteSpace(error))
                {

                    toolStripLabel1.ForeColor = Color.Red;
                    toolStripLabel1.Text = error;
                }
            }
        }
      
    
        private async Task<bool> IzlistajFileove()
        {
            dostupniFileovi.Sort();
            foreach(string s in dostupniFileovi)
            {
                file.Add(s);
                await Task.Delay(500);
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                dostupniFileovi = new List<string>();
              
                DirectorySearch(fbd.SelectedPath);
                
                    
                    
                
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            bool x = await IzlistajFileove();

        }
    }
}
