using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Management;

namespace KursSP
{
    public partial class KursSP : ServiceBase
    {
        public KursSP()
        {
            InitializeComponent();
        }
        private StreamWriter file;
        protected override void OnStart(string[] args)
        {
            file = new StreamWriter(new FileStream("C:\\DebugKPSP\\KPSP.log",
                                         System.IO.FileMode.Append));
            this.file.WriteLine("-----------------------------------------------------------------------------------");
            this.file.WriteLine("Служба запущена " + System.DateTime.Now);
            this.file.WriteLine("-----------------------------------------------------------------------------------");
            this.file.Flush();
            backgroundWorker1.RunWorkerAsync();
        }

        protected override void OnStop()
        {
            this.file.WriteLine("-----------------------------------------------------------------------------------");
            this.file.WriteLine("Служба остановлена " + DateTime.Now);
            this.file.WriteLine("-----------------------------------------------------------------------------------");
            this.file.Flush();
            this.file.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");

            ManagementEventWatcher insertWatcher = new ManagementEventWatcher(insertQuery);
            insertWatcher.EventArrived += new EventArrivedEventHandler(DeviceInsertedEvent);
            insertWatcher.Start();

            WqlEventQuery removeQuery = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
            ManagementEventWatcher removeWatcher = new ManagementEventWatcher(removeQuery);
            removeWatcher.EventArrived += new EventArrivedEventHandler(DeviceRemovedEvent);
            removeWatcher.Start();

            // Do something while waiting for events
            System.Threading.Thread.Sleep(20000000);
        }
        private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            foreach (var property in instance.Properties)
            {
                if (property.Name == "Caption")
                    this.file.WriteLineAsync("Устройство: " + property.Value + " подключено " + DateTime.Now);
            }
            this.file.Flush();
        }

        private void DeviceRemovedEvent(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            foreach (var property in instance.Properties)
            {
                if (property.Name == "Caption")
                    this.file.WriteLineAsync("Устройство: " + property.Value + " отключено " + DateTime.Now);
            }
            this.file.Flush();
        }

    }
}
