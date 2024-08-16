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
    public partial class Tasklist : Form
    {
        public Tasklist()
        {
            InitializeComponent();
            UpdateProcessList();
            timer1.Enabled = true;
        }
        private void UpdateProcessList()
        {
            listView1.Items.Clear();
            int id = 1;

            foreach (Process p in Process.GetProcesses())
            {
                ListViewItem item = new ListViewItem();
                item = listView1.Items.Add(p.ProcessName);
                item.SubItems.Add(p.Id.ToString());
                item.SubItems.Add(p.WorkingSet64.ToString());
                item.SubItems.Add(p.VirtualMemorySize64.ToString());
                item.SubItems.Add(p.SessionId.ToString());


                id = id + 1;
            }
            tslProcessCount.Text = "Procesos Actuales: " + listView1.Items.Count.ToString();    //  cant de procesos   
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            UpdateProcessList();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Process p in Process.GetProcesses())
                {
                    string arr = listView1.SelectedItems[0].SubItems[0].Text; 

                    if (p.ProcessName == arr)
                    {
                        p.Kill();
                    }

                }
            }
            catch (Exception x)
            {
                MessageBox.Show("No se seleccionó ningún proceso. ", "Error al Eliminar", MessageBoxButtons.OK);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Tasklist_Load(object sender, EventArgs e)
        {

        }
    }
}
