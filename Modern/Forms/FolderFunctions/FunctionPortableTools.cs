using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

public class FunctionPortableTools
{
    public static void StartPortableTool(string zipFileName, string exeName)
    {
        string basePath = Application.StartupPath;
        string zipPath = Path.Combine(basePath, @"Resources\Program", zipFileName);
        string extractFolder = Path.GetFileNameWithoutExtension(zipFileName); // t.ex. "openhardwaremonitor-v0.9.6"
        string extractPath = Path.Combine(basePath, @"Resources\Program", extractFolder);
        string exePath = Path.Combine(extractPath, exeName);

        try
        {
            // Extrahera om inte redan gjort
            if (!Directory.Exists(extractPath))
            {
                if (File.Exists(zipPath))
                {
                    ZipFile.ExtractToDirectory(zipPath, extractPath);
                }
                else
                {
                    MessageBox.Show("Zip-filen saknas:\n" + zipPath, "Fel");
                    return;
                }
            }

            // Starta exe
            if (File.Exists(exePath))
            {
                Process.Start(exePath);
            }
            else
            {
                MessageBox.Show("EXE-filen hittades inte:\n" + exePath, "Fel");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fel vid uppstart:\n" + ex.Message, "Fel");
        }
    }
}
