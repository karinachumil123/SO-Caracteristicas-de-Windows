using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diseño
{
    public partial class Perfmon : Form
    {
        public Perfmon()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float cpu = CPU.NextValue();
            float ram = RAM.NextValue();

            progressBar1.Value = (int)cpu;
            progressBar2.Value = (int)ram;

            label3.Text = string.Format("{0:0.00}%", cpu);
            label5.Text = string.Format("{0:0.00}%", ram);

            chart1.Series["CPU"].Points.AddY(cpu);
            chart1.Series["RAM"].Points.AddY(ram);
        }

        private void Perfmon_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
