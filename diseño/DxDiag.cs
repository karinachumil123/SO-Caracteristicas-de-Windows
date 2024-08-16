using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diseño
{
    public partial class DxDiag : Form
    {
        public DxDiag()
        {
            InitializeComponent();
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }
        private void iconButton4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }
        private void iconButton5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);
        }
        private void iconButton6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(5);
        }
        private void iconButton7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(6);
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void DxDiag_Load(object sender, EventArgs e)
        {
            //Procesador
            MuestraInformacion("Win32_Processor", listView1);
            MuestraInformacion("Win32_DiskDrive", listView2);
            MuestraInformacion("Win32_PhysicalMemory", listView3);
            MuestraInformacion("Win32_VideoController", listView4);
            MuestraInformacion("Win32_NetworkAdapter", listView5);
            MuestraInformacion("Win32_SoundDevice", listView6);
            MuestraInformacion("Win32_BaseBoard", listView7);
            MuestraInformacion("Win32_Battery", listView8);
        }

        private void MuestraInformacion(string clave, ListView vista)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + clave);
            vista.Items.Clear();
            ListViewGroup lstvg;
            try
            {
                foreach (ManagementObject objeto in searcher.Get())
                {
                    try
                    {
                        lstvg = vista.Groups.Add(objeto["Name"].ToString(), objeto["Name"].ToString());
                    }
                    catch
                    {
                        lstvg = vista.Groups.Add(objeto["Name"].ToString(), objeto["Name"].ToString());

                    }
                    if (objeto.Properties.Count <= 0)
                    {
                        MessageBox.Show("La Información No Está Disponible", "No Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    foreach (PropertyData PropiedadObjeto in objeto.Properties)
                    {
                        ListViewItem listViewItem1 = new ListViewItem(lstvg);
                        listViewItem1.Text = PropiedadObjeto.Name;

                        if (PropiedadObjeto.Value != null && PropiedadObjeto.Value.ToString() != "")
                        {
                            listViewItem1.SubItems.Add(PropiedadObjeto.Value.ToString());
                            vista.Items.Add(listViewItem1);
                        }
                        else
                        {
                            // Informacion nula
                        }

                    }
                }
            }

            catch (Exception exp)
            {
                MessageBox.Show("No se pueden obtener datos \n" + exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(7);
        }
    }
}