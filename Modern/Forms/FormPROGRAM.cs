using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;






namespace Modern.Forms
{
    public partial class FormPROGRAM : Form
    {
        public FormPROGRAM()
        {
            InitializeComponent();
        }

        private void FormPROGRAM_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FunctionPortableTools.StartPortableTool("openhardwaremonitor-v0.9.6.zip", "OpenHardwareMonitor.exe");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string zipFilePath = @"C:\Users\Michel\Desktop\RC-Tools-RaccoonTools-Framewoork-complete\Modern\Resources\Program\RidNacs-3.0.zip";

            // Temporär plats där zip-filen packas upp
            string extractPath = Path.Combine(Path.GetTempPath(), "RidNacs");

            // Packa upp zip-filen om den inte redan är uppackad
            if (!Directory.Exists(extractPath))
            {
                ZipFile.ExtractToDirectory(zipFilePath, extractPath);
            }

            // Sökväg till RidNacs.exe efter uppackning
            string ridnacsExePath = Path.Combine(extractPath, "RidNacs.exe");

            // Starta RidNacs-programmet
            Process.Start(ridnacsExePath);

        }


        

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }


}
