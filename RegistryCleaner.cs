using Microsoft.Win32;

public static class RegistryCleaner
{
    // Feature 61: Invalid Uninstallers
    public static void RemoveInvalidUninstallers()
    {
        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", true))
        {
            foreach (string subkey in key.GetSubKeyNames())
            {
                using (RegistryKey sub = key.OpenSubKey(subkey))
                {
                    if (sub.GetValue("UninstallString") == null)
                        key.DeleteSubKeyTree(subkey);
                }
            }
        }
    }
}