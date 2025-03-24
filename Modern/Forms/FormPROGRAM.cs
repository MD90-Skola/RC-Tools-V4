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

   

        private void button2_Click(object sender, EventArgs e)
        {
            FunctionsPortableTools.RunRidNacs();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FunctionsPortableTools.Openhardwaremonitor();
        }
    }


}
