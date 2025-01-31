using Microsoft.Win32;
using System.IO;
using System;

public static class PrivacyCleaner
{
    // Feature 29: Recent Documents
    public static void ClearRecentDocuments()
    {
        string recentPath = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
        Directory.GetFiles(recentPath).ToList().ForEach(File.Delete);
    }

    // Feature 30: Run Dialog History
    public static void ClearRunHistory()
    {
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\RunMRU", true))
        {
            key?.DeleteValue("MRUList");
            foreach (string value in key?.GetValueNames() ?? Array.Empty<string>())
                key.DeleteValue(value);
        }
    }
}