using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diseño
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string namepc = Environment.MachineName;

        private void OcultarPanel()
        {
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
        }
        private void MostrarPanel(Panel Panel_SubMenu)
        {
            if (Panel_SubMenu.Visible == false)
            {
                OcultarPanel();
                Panel_SubMenu.Visible = true;
            }
            else
                Panel_SubMenu.Visible = false;
        }
        private void FormularioNuevo(Object formulario_contenido)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fa = formulario_contenido as Form;
            fa.TopLevel = false;
            fa.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fa);
            this.panelContenedor.Tag = fa;
            fa.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            iconButton10.Text = namepc;
            FormularioNuevo(new Inicio());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            MostrarPanel(panel7);
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            MostrarPanel(panel9);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            MostrarPanel(panel4);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            MostrarPanel(panel5);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            MostrarPanel(panel6);
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            MostrarPanel(panel8);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormularioNuevo(new Winver());
        }


        private void button4_Click(object sender, EventArgs e)
        {
            FormularioNuevo(new DxDiag());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FormularioNuevo(new Tasklist());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FormularioNuevo(new Netstat());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FormularioNuevo(new Perfmon());
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            FormularioNuevo(new Inicio());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormularioNuevo(new Appwiz());
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            FormularioNuevo(new Interbloqueo());
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            FormularioNuevo(new Concurrencia());
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
