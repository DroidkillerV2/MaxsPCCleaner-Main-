using MaxsPCCleaner;
using System.ComponentModel;

public partial class SystemJunkForm : BaseCleanerForm
{
    public SystemJunkForm()
    {
        checklist.Items.AddRange(new string[]
        {
            "Windows Temporary Files",
            "Windows Update Cache",
            "Recycle Bin",
            "Thumbnail Cache",
            "Memory Dump Files",
            "Error Reporting Logs",
            "Delivery Optimization Files",
            "Windows Logs",
            "Old Windows Installations",
            "Microsoft Defender Quarantine",
            "Windows Upgrade Residuals",
            "Clipboard History",
            "Font Cache",
            "Windows Spotlight Cache",
            "Windows Error Reports"
        });
        this.Text = "System Junk Cleaning";
    }

    protected override void CleanItems(object sender, DoWorkEventArgs e)
    {
        foreach (string item in checklist.CheckedItems)
        {
            switch (item)
            {
                case "Windows Temporary Files":
                    SystemJunkCleaner.CleanTempFiles();
                    break;
                case "Windows Update Cache":
                    SystemJunkCleaner.CleanUpdateCache();
                    break;
                    // Add cases for all 15 items
            }
        }
    }
}