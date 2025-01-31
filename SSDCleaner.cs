using System.Diagnostics;

public static class SSDCleaner
{
    // Feature 81: Enable TRIM
    public static void EnableTRIM()
    {
        Process.Start(new ProcessStartInfo("cmd.exe", "/c fsutil behavior set DisableDeleteNotify 0")
        {
            WindowStyle = ProcessWindowStyle.Hidden
        })?.WaitForExit();
    }

    // Feature 83: Disable Hibernation
    public static void DisableHibernation()
    {
        Process.Start(new ProcessStartInfo("cmd.exe", "/c powercfg /h off")
        {
            WindowStyle = ProcessWindowStyle.Hidden
        })?.WaitForExit();
    }
}