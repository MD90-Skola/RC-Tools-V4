using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Modern.Forms // <-- Viktigt att det är samma namespace!
{
    public static class FunctionsPortableTools
    {
        public static void RunProgramFromZip(string zipFilePath, string exeName)
        {
            string extractPath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(zipFilePath));

            if (!Directory.Exists(extractPath))
            {
                ZipFile.ExtractToDirectory(zipFilePath, extractPath);
            }

            // Leta efter EXE-filen i alla undermappar
            string exeFullPath = Directory.GetFiles(extractPath, exeName, SearchOption.AllDirectories).FirstOrDefault();

            if (exeFullPath != null)
            {
                Process.Start(exeFullPath);
            }
            else
            {
                MessageBox.Show($"Kunde inte hitta filen {exeName} i zip-arkivet.", "Filen hittades ej", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        public static void RunRidNacs()
        {
            RunProgramFromZip(@"C:\Users\Michel\Desktop\RC-Tools-RaccoonTools-Framewoork-complete\Modern\Resources\Program\RidNacs-3.0.zip", "RidNacs.exe");
        }


        public static void Openhardwaremonitor()
        {
            RunProgramFromZip(@"C:\Users\Michel\Desktop\RC-Tools-RaccoonTools-Framewoork-complete\Modern\Resources\Program\openhardwaremonitor-v0.9.6.zip", "OpenHardwareMonitor.exe");
        }
















    }
}
