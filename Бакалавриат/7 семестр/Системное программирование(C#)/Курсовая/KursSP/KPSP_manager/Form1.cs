using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.ServiceProcess;

namespace KPSP_manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Text = serviceController.Status.ToString();
        }
        ServiceController serviceController = new ServiceController("KursSP");
        private void exec_button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceController.Status.ToString() == "Stopped")
                {
                    serviceController.Start();
                    serviceController.WaitForStatus(ServiceControllerStatus.Running);
                    label2.Text = serviceController.Status.ToString();
                }
                else MessageBox.Show("Служба уже запущена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void stop_button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceController.Status.ToString() == "Running")
                {
                    serviceController.Stop();
                    serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                    label2.Text = serviceController.Status.ToString();
                }
                else MessageBox.Show("Служба уже остановлена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void log_button3_Click(object sender, EventArgs e)
        {
            File.Copy("C:\\DebugKPSP\\KPSP.log", "C:\\DebugKPSP\\KPSP-copy.log", true);
            StreamReader r = new StreamReader("C:\\DebugKPSP\\KPSP-copy.log");
            richTextBox1.Text = r.ReadToEnd().ToString();
            r.Close();
            File.Delete("C:\\DebugKPSP\\KPSP-copy.log");
        }
    }
}
