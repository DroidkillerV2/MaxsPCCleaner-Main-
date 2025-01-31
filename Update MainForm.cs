using System.Windows.Forms;
using System;

private void SubmenuButton_Click(object sender, EventArgs e)
{
    Button btn = (Button)sender;
    Form subForm = null;

    switch (btn.Tag.ToString())
    {
        case "System Junk Cleaning": subForm = new SystemJunkForm(); break;
        case "Browser Cleaning": subForm = new BrowserCleaningForm(); break;
        case "Privacy & Security": subForm = new PrivacySecurityForm(); break;
        case "Application-Specific Cleanup": subForm = new AppCleanupForm(); break;
        case "Disk & Storage Optimization": subForm = new DiskOptimizationForm(); break;
        case "Registry Cleaning": subForm = new RegistryCleaningForm(); break;
        case "System Performance": subForm = new SystemPerformanceForm(); break;
        case "SSD Optimization": subForm = new SSDOptimizationForm(); break;
        case "Network Cleaning": subForm = new NetworkCleaningForm(); break;
        case "Advanced System Tools": subForm = new AdvancedToolsForm(); break;
    }

    if (subForm != null)
    {
        subForm.Show();
        this.Hide();
    }
}