using MaxsPCCleaner;
using System.ComponentModel;

public partial class AdvancedToolsForm : BaseCleanerForm
{
    public AdvancedToolsForm()
    {
        checklist.Items.AddRange(new string[]
        {
            "Driver Store Cleanup", "Windows Component Cleanup", "User Profile Cleanup",
            "Windows Store Cache", "Group Policy Cache", "Windows License Residuals"
        });
        this.Text = "Advanced System Tools";
    }

    protected override void CleanItems(object sender, DoWorkEventArgs e)
    {
        foreach (string item in checklist.CheckedItems)
        {
            switch (item)
            {
                case "Driver Store Cleanup":
                    AdvancedCleaner.CleanDriverStore();
                    break;
                case "Windows Component Cleanup":
                    AdvancedCleaner.CleanWindowsComponents();
                    break;
                    // Add cases for all 6 items
            }
        }
    }
}