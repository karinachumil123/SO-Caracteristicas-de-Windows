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
    public partial class Netstat : Form
    {
        public Netstat()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void proceso()
        {
            executeCommand("netstat");
        }
        private void executeCommand(String commandR)
        {
            try
            {
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        Arguments = "/c " + commandR,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    updateStatusExecution(line);
                }
            }
            catch (Exception e)
            {
               updateStatusExecution("***Error durante la ejecución '" + commandR + "'");
               updateStatusExecution("***Excepción: '" + e.ToString());
               updateStatusExecution("***Stack Trace: '" + e.StackTrace.ToString());
            }
        }
        private void updateStatusExecution(String textR)
        {
            listBox1.Items.Add(textR);
        }

        private async void Netstat_Load(object sender, EventArgs e)
        {
            label2.Visible = true; pictureBox2.Visible = true;
            Task ejecutar = new Task(proceso);
            ejecutar.Start();
            await ejecutar;
            label2.Visible = false; pictureBox2.Visible = false;
        }
    }
}
