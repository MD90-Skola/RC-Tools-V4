using System;
using System.Windows.Forms;
using Modern.Forms.Functions;
using Modern.Forms.FolderFunctions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;


namespace Modern.Forms
{
    public partial class FormHOME : Form
    {
        private Timer klockaTimer;

        public FormHOME()
        {
            InitializeComponent();
        }

        private void FormHOME_Load(object sender, EventArgs e)
        {
            StartKlockaActive();
            VisaDatorSpec();
            VisaAvanceradSpec();






        }

        private void VisaAvanceradSpec()
        {
            textBox5.Text = FunctionsDatorSpecs.HämtaModerkort();
            textBox6.Text = FunctionsDatorSpecs.HämtaDisk();
            textBox7.Text = FunctionsDatorSpecs.HämtaCputemp();

            var nätverkskort = FunctionsDatorSpecs.HämtaNätverkskort();
            textBox8.Text = nätverkskort.Length > 0 ? nätverkskort[0] : "Inget kort aktivt";
        }




        private void VisaDatorSpec()
        {
            textBox1.Text = FunctionsDatorSpecs.HämtaCPU();

            var gpuLista = FunctionsDatorSpecs.HämtaGPUer();
            textBox2.Text = gpuLista.Length > 0 ? gpuLista[0] : "Ingen GPU";
            textBox3.Text = gpuLista.Length > 1 ? gpuLista[1] : "Ingen extra GPU";

            textBox4.Text = FunctionsDatorSpecs.HämtaRAM();
        }


        ///////////////////////////////////////////////////
        ///                                         ///// 
        ///         Test Zone                       /// 
        ///                                       ///   
        ///                                     ///             
        /////////////////////////////////////////
















        ///////////////////////////////////////////////////
        ///                                         ///// 
        ///         Klocka                          /// 
        ///                                       ///   
        ///                                     ///             
        /////////////////////////////////////////


        private void StartKlockaActive()
        {
            klockaTimer = new Timer();
            klockaTimer.Interval = 1000;
            klockaTimer.Tick += (s, e) =>
            {
                label1.Text = FunctionsKlocka.HämtaDatum();     // YYYY-MM-DD
                label2.Text = FunctionsKlocka.HämtaTid();       // TT:MM:SS
                label3.Text = FunctionsKlocka.HämtaManad();     // MMMM månad
                label4.Text = FunctionsKlocka.HämtaVecka();     // Vecka: 00
            };
            klockaTimer.Start();
        }













        ///////////////////////////////////////////////////
        ///                                         ///// 
        ///         övrigt                         /// 
        ///                                       ///   
        ///                                     ///             
        /////////////////////////////////////////
























        // Eventhandlers (om du behöver dem för andra klick)
        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FunctionPortableTools.StartPortableTool("RidNacs-3.0.zip", "RidNacs.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FunctionPortableTools.StartPortableTool("openhardwaremonitor.zip", "OpenHardwareMonitor.exe");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FunctionPortableTools.StartPortableTool("Autoruns.zip", "Autoruns.exe");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FunctionPortableTools.StartPortableTool("CrystalDiskInfo.zip", "DiskInfo64A.exe");
        }
    }
}
