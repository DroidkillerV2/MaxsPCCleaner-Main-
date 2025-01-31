using MaxsPCCleaner;
using System.ComponentModel;

public partial class PrivacySecurityForm : BaseCleanerForm
{
    public PrivacySecurityForm()
    {
        checklist.Items.AddRange(new string[]
        {
            "Recent Documents", "Run Dialog History", "Windows Search Index",
            "Prefetch Files", "Jump Lists", "Telemetry Data", "Cortana Logs",
            "Windows Timeline", "Location Traces", "Network Sharing History",
            "Windows Defender Scans", "RDP Connections"
        });
        this.Text = "Privacy & Security";
    }

    protected override void CleanItems(object sender, DoWorkEventArgs e)
    {
        foreach (string item in checklist.CheckedItems)
        {
            switch (item)
            {
                case "Recent Documents":
                    PrivacyCleaner.ClearRecentDocuments();
                    break;
                case "Run Dialog History":
                    PrivacyCleaner.ClearRunHistory();
                    break;
                    // Add cases for all 12 items
            }
        }
    }
}