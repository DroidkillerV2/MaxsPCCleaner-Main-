using MaxsPCCleaner;
using System.ComponentModel;

public partial class NetworkCleaningForm : BaseCleanerForm
{
    public NetworkCleaningForm()
    {
        checklist.Items.AddRange(new string[]
        {
            "DNS Cache Flush", "ARP Cache Clear", "Windows Sockets Reset",
            "Network Adapter Reset", "Browser Network Cache", "Hosts File Cleanup",
            "VPN Residual Files", "Wi-Fi Profiles", "Proxy Settings Reset",
            "Network Diagnostics Logs", "TCP/IP Stack Reset", "Cached Credentials",
            "Windows Update Network Cache", "Firewall Rules Cleanup"
        });
        this.Text = "Network Cleaning";
    }

    protected override void CleanItems(object sender, DoWorkEventArgs e)
    {
        foreach (string item in checklist.CheckedItems)
        {
            switch (item)
            {
                case "DNS Cache Flush":
                    NetworkCleaner.FlushDNSCache();
                    break;
                case "Hosts File Cleanup":
                    NetworkCleaner.CleanHostsFile();
                    break;
                    // Add cases for all 14 items
            }
        }
    }
}