using MaxsPCCleaner;
using System.ComponentModel;

public partial class SystemPerformanceForm : BaseCleanerForm
{
    public SystemPerformanceForm()
    {
        checklist.Items.AddRange(new string[]
        {
            "Startup Programs", "Background Services", "Context Menu Cleanup",
            "Scheduled Tasks", "RAM Optimization", "Power Throttling",
            "Visual Effects", "Windows Search Indexing", "Driver Updates",
            "Page File Optimization"
        });
        this.Text = "System Performance";
    }

    protected override void CleanItems(object sender, DoWorkEventArgs e)
    {
        foreach (string item in checklist.CheckedItems)
        {
            switch (item)
            {
                case "Startup Programs":
                    PerformanceCleaner.DisableStartupPrograms();
                    break;
                case "RAM Optimization":
                    PerformanceCleaner.OptimizeRAM();
                    break;
                    // Add cases for all 10 items
            }
        }
    }
}