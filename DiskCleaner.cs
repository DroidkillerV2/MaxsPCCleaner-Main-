using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System;

public static class DiskCleaner
{
    // Feature 51: Duplicate Files
    public static void DeleteDuplicates(string path)
    {
        var hashes = new Dictionary<string, string>();
        foreach (string file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
        {
            string hash = BitConverter.ToString(SHA256.Create().ComputeHash(File.ReadAllBytes(file)));
            if (hashes.ContainsKey(hash)) File.Delete(file);
            else hashes.Add(hash, file);
        }
    }
}