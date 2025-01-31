using MaxsPCCleaner;
using System.ComponentModel;

public partial class RegistryCleaningForm : BaseCleanerForm
{
    public RegistryCleaningForm()
    {
        checklist.Items.AddRange(new string[]
        {
            "Invalid Uninstallers", "Orphaned Software Keys", "Broken File Associations",
            "Invalid Startup Entries", "Missing DLL References", "Obsolete Font Entries",
            "Windows Explorer MRUs", "Outdated Driver Entries", "Invalid Shared DLLs",
            "UserAssist History"
        });
        this.Text = "Registry Cleaning";
    }

    protected override void CleanItems(object sender, DoWorkEventArgs e)
    {
        foreach (string item in checklist.CheckedItems)
        {
            switch (item)
            {
                case "Invalid Uninstallers":
                    RegistryCleaner.RemoveInvalidUninstallers();
                    break;
                case "Orphaned Software Keys":
                    RegistryCleaner.RemoveOrphanedKeys();
                    break;
                    // Add cases for all 10 items
            }
        }
    }
}