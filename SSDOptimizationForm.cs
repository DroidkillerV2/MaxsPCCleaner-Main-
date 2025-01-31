using MaxsPCCleaner;
using System.ComponentModel;

public partial class SSDOptimizationForm : BaseCleanerForm
{
    public SSDOptimizationForm()
    {
        checklist.Items.AddRange(new string[]
        {
            "TRIM Optimization", "Defragmentation Disable", "Hibernation File Cleanup",
            "SSD Over-Provisioning", "Write Cache Buffer Flushing", "Superfetch/Prefetch Disable",
            "Indexing Reduction", "Temp File Relocation", "System Restore Adjustments",
            "Volume Shadow Copy Cleanup"
        });
        this.Text = "SSD Optimization";
    }

    protected override void CleanItems(object sender, DoWorkEventArgs e)
    {
        foreach (string item in checklist.CheckedItems)
        {
            switch (item)
            {
                case "TRIM Optimization":
                    SSDCleaner.EnableTRIM();
                    break;
                case "Hibernation File Cleanup":
                    SSDCleaner.DisableHibernation();
                    break;
                    // Add cases for all 10 items
            }
        }
    }
}