using System.IO;
using System;

public static class SystemJunkCleaner
{
    // Feature 1: Clean Windows Temporary Files
    public static void CleanTempFiles()
    {
        string[] tempPaths =
        {
            Path.GetTempPath(),
            @"C:\Windows\Temp",
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Temp"
        };

        foreach (string path in tempPaths)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                Directory.CreateDirectory(path);
            }
        }
    }

    // Feature 2: Clean Windows Update Cache
    public static void CleanUpdateCache()
    {
        string updatePath = @"C:\Windows\SoftwareDistribution\Download";
        if (Directory.Exists(updatePath))
        {
            Directory.Delete(updatePath, true);
            Directory.CreateDirectory(updatePath);
        }
    }

    // Add methods for all 15 features...
}