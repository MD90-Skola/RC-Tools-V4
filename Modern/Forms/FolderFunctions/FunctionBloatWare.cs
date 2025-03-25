using System.Collections.Generic;
using System.Diagnostics;

public static class FunctionBloatWare
{
    public static List<string> GetBloatwareList()
    {
        return new List<string>
        {
            "Microsoft.3DBuilder",
            "Microsoft.XboxApp",
            "Microsoft.ZuneMusic",
            "Microsoft.ZuneVideo",
            "Microsoft.BingNews",
            "Microsoft.MicrosoftSolitaireCollection",
            "Microsoft.SkypeApp",
            "Microsoft.People",
            "Microsoft.MicrosoftOfficeHub",
            "Microsoft.OneConnect",
            "Microsoft.GetHelp",
            "Microsoft.Getstarted",
            "Microsoft.Microsoft3DViewer",
            "Microsoft.MicrosoftStickyNotes",
            "Microsoft.MixedReality.Portal",
            "Microsoft.XboxGameOverlay",
            "Microsoft.XboxGamingOverlay",
            "Microsoft.XboxSpeechToTextOverlay",
            "Microsoft.YourPhone"
        };
    }

    public static void RemoveBloatware(List<string> selectedApps)
    {
        foreach (string app in selectedApps)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = $"-Command \"Get-AppxPackage -Name '{app}' | Remove-AppxPackage -ErrorAction SilentlyContinue; Get-AppxProvisionedPackage -Online | Where-Object {{$_.DisplayName -eq '{app}'}} | Remove-AppxProvisionedPackage -Online -ErrorAction SilentlyContinue\"",
                Verb = "runas", // Kör som admin
                UseShellExecute = true
            });
        }
    }
}
