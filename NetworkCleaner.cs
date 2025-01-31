using System.Diagnostics;
using System.IO;
using System;

public static class NetworkCleaner
{
    // Feature 91: Flush DNS Cache
    public static void FlushDNSCache()
    {
        Process.Start(new ProcessStartInfo("cmd.exe", "/c ipconfig /flushdns")
        {
            WindowStyle = ProcessWindowStyle.Hidden
        })?.WaitForExit();
    }

    // Feature 96: Clean Hosts File
    public static void CleanHostsFile()
    {
        string hostsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts");
        File.WriteAllText(hostsPath, "# Cleaned by Max's PC Cleaner");
    }
}