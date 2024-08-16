using Microsoft.VisualBasic.Devices;
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
    public partial class Winver : Form
    {
        public Winver()
        {
            InitializeComponent();
        }

        private void Winver_Load(object sender, EventArgs e)
        {
            Obtener_registroWin32("Win32_OperatingSystem");
            // USANDO COMPUTER Y ENVIRONMENT
            label1.Text = System.Environment.OSVersion.ToString();
			Computer pc = new Computer();
			label2.Text = pc.Info.OSFullName.ToString();
			//
			// USANDO REGISTRO DE WINDOWS
			string Clave1 = @"SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion";
			string Clave2 = @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment";
			//
			Microsoft.Win32.RegistryKey principal = Microsoft.Win32.Registry.LocalMachine; //rama LocalMachine
			Microsoft.Win32.RegistryKey subclave1 = principal.OpenSubKey(Clave1); //clave SOFTWARE ... CurrentVersion
			Microsoft.Win32.RegistryKey subclave2 = principal.OpenSubKey(Clave2); //clave SYSTEM ...  Environment
																				  //
			string nombre = subclave1.GetValue("ProductName").ToString();
			string compilacion = subclave1.GetValue("CurrentBuild").ToString();
			string release = subclave1.GetValue("ReleaseId").ToString();
			string arquitectura = subclave2.GetValue("PROCESSOR_ARCHITECTURE").ToString();
			if (arquitectura.Equals("AMD64"))
				arquitectura = "64 bits";
			else
				arquitectura = "32 bits";
			//
			label3.Text = nombre;
			label9.Text = compilacion;
			label12.Text = arquitectura;
			label13.Text = release;

		}

        private void Obtener_registroWin32(string clave)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + clave);
            listView1.Items.Clear();
            ListViewGroup lstvg;
            try
            {
                foreach (ManagementObject objeto in searcher.Get())
                {
                    try
                    {
                        lstvg = listView1.Groups.Add(objeto["Name"].ToString(), objeto["Name"].ToString());
                    }
                    catch
                    {

                        lstvg = listView1.Groups.Add(objeto["Name"].ToString(), objeto["Name"].ToString());

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
                            listView1.Items.Add(listViewItem1);
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (groupBox2.Visible == false){
                groupBox2.Visible = true;
                groupBox1.Location = new Point(74, 101);
                iconButton1.Text = "Ocultar Detalles..";
            }
            else
            {
                iconButton1.Text = "Ver Detalles..";
                groupBox2.Visible = false;
                groupBox1.Location = new Point(285, 101);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
