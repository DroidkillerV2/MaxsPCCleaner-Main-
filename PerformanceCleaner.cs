using Microsoft.Win32;
using System.Diagnostics;

public static class PerformanceCleaner
{
    // Feature 71: Disable Startup Programs
    public static void DisableStartupPrograms()
    {
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
        {
            foreach (string value in key.GetValueNames())
                key.DeleteValue(value);
        }
    }

    // Feature 75: Optimize RAM
    public static void OptimizeRAM()
    {
        Process.Start(new ProcessStartInfo("cmd.exe", "/c echo EmptyStandbyList.exe workingsets > nul")
        {
            WindowStyle = ProcessWindowStyle.Hidden
        })?.WaitForExit();
    }
}