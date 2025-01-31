using System.Diagnostics;

public static class AdvancedCleaner
{
    // Feature 105: Driver Store Cleanup
    public static void CleanDriverStore()
    {
        Process.Start(new ProcessStartInfo("cmd.exe", "/c pnputil.exe /delete-driver oem*.inf")
        {
            WindowStyle = ProcessWindowStyle.Hidden
        })?.WaitForExit();
    }

    // Feature 106: Windows Component Cleanup
    public static void CleanWindowsComponents()
    {
        Process.Start(new ProcessStartInfo("cmd.exe", "/c DISM /Online /Cleanup-Image /StartComponentCleanup")
        {
            WindowStyle = ProcessWindowStyle.Hidden
        })?.WaitForExit();
    }
}