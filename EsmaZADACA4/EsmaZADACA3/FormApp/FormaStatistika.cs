using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp
{
    public partial class FormaStatistika : Form
    {
        List<int> lista;
        public FormaStatistika(List<int> l)
        {
            lista = l;
            InitializeComponent();
            
        }
        public void DrawPieChartOnForm()
        {
            int[] myPiePercent = lista.ToArray();
            
            List<Color> n= new List<Color>();
            Color[] myPieColors1 = { Color.Red, Color.Black, Color.Blue, Color.Green, Color.Maroon, Color.Purple, Color.Orange, Color.Yellow };
            for (int i=0; i<lista.Count(); i++)
            {
                n.Add(myPieColors1[i]);
            }
            Color[] myPieColors =n.ToArray() ;

            using (Graphics myPieGraphic = this.CreateGraphics())
            {
                Point myPieLocation = new Point(10, 10);
                
                Size myPieSize = new Size(150, 150);
                
                DrawPieChart(myPiePercent, myPieColors, myPieGraphic, myPieLocation, myPieSize);
            }
        }

        
        public void DrawPieChart(int[] myPiePerecents, Color[] myPieColors, Graphics myPieGraphic, Point myPieLocation, Size myPieSize)
        {
            
            int PiePercentTotal = 0;
            for (int PiePercents = 0; PiePercents < myPiePerecents.Length; PiePercents++)
            {
                using (SolidBrush brush = new SolidBrush(myPieColors[PiePercents]))
                {
                    myPieGraphic.FillPie(brush, new Rectangle(new Point(10, 10), myPieSize), Convert.ToSingle(PiePercentTotal * 360 / 100), Convert.ToSingle(myPiePerecents[PiePercents] * 360 / 100));
                }

                PiePercentTotal += myPiePerecents[PiePercents];
            }
            return;
        }

        private void FormaStatistika_Paint(object sender, PaintEventArgs e)
        {
            DrawPieChartOnForm();
        }
    }
}

