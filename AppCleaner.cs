using System.IO;
using System;

public static class AppCleaner
{
    // Feature 41: Microsoft Office Cache
    public static void CleanOfficeCache()
    {
        string officeCache = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            @"Microsoft\Office\16.0\Wef"
        );
        Directory.Delete(officeCache, true);
    }
}