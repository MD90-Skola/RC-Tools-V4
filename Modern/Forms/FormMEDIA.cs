using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic; // Behövs för InputBox
using Microsoft.Web.WebView2.WinForms;





namespace Modern.Forms
{
    public partial class FormMEDIA : Form
    {
        public FormMEDIA()
        {
            InitializeComponent();
            this.Load += FormMEDIA_Load;
        }

        private void FormMEDIA_Load(object sender, EventArgs e)
        {















            // Gör buttonRund helt rund
            GraphicsPath rundPath = new GraphicsPath();
            rundPath.AddEllipse(0, 0, buttonRund.Width, buttonRund.Height);
            buttonRund.Region = new Region(rundPath);

            // Gör buttonHalvRund med avrundade hörn
            GraphicsPath halvPath = new GraphicsPath();
            int radius = 30;
            halvPath.AddArc(0, 0, radius, radius, 180, 90);
            halvPath.AddArc(buttonHalvRund.Width - radius, 0, radius, radius, 270, 90);
            halvPath.AddArc(buttonHalvRund.Width - radius, buttonHalvRund.Height - radius, radius, radius, 0, 90);
            halvPath.AddArc(0, buttonHalvRund.Height - radius, radius, radius, 90, 90);
            halvPath.CloseAllFigures();
            buttonHalvRund.Region = new Region(halvPath);
        }

        private void buttonRund_Click(object sender, EventArgs e)
        {
            Process.Start("https://crop-circle.imageonline.co/");
        }

        private void buttonHalvRund_Click(object sender, EventArgs e)
        {
            Process.Start("https://round-corner.imageonline.co/");
        }

        private void button3_Click(object sender, EventArgs e)
        {





            // Ange det korrekta lösenordet "Rly hard pass"  gj <3 
            string correctPassword = "1";

            // Visa en inmatningsruta för att fråga användaren efter lösenord
            string inputPassword = Interaction.InputBox("Ange lösenord:", "Lösenord", "");

            // Kontrollera om lösenordet stämmer
            if (inputPassword == correctPassword)
            {
                MessageBox.Show("Arise");
                Process.Start("https://www.mediafire.com/file/eaolcve6cytq1qz/101010123123123ps.rar");
            }
            else
            {
                MessageBox.Show("Not for you");
                string filePath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Resources", "Arise2.wav");

                if (System.IO.File.Exists(filePath))
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(filePath);
                    player.Play();
                }
              



















            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
             Process.Start("https://www.canva.com");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.blackmagicdesign.com/products/davinciresolve");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCrop_Click(object sender, EventArgs e)
        {
            Process.Start("https://imageresizer.com/crop-image");
        }

        private void FormMEDIA_Load_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
