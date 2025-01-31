using MaxsPCCleaner;
using System.ComponentModel;

public partial class DiskOptimizationForm : BaseCleanerForm
{
    public DiskOptimizationForm()
    {
        checklist.Items.AddRange(new string[]
        {
            "Duplicate Files", "Empty Folders", "Large Files",
            "Temporary Downloads", "Old Backups", "Orphaned Installers",
            "Logs from Uninstalled Apps", "Windows Component Store",
            "System Restore Points", "NTFS Compression"
        });
        this.Text = "Disk & Storage Optimization";
    }

    protected override void CleanItems(object sender, DoWorkEventArgs e)
    {
        foreach (string item in checklist.CheckedItems)
        {
            switch (item)
            {
                case "Duplicate Files":
                    DiskCleaner.DeleteDuplicates(@"C:\Users");
                    break;
                case "Empty Folders":
                    DiskCleaner.DeleteEmptyFolders(@"C:\");
                    break;
                    // Add cases for all 10 items
            }
        }
    }
}