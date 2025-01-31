using MaxsPCCleaner;
using System.ComponentModel;

public partial class AppCleanupForm : BaseCleanerForm
{
    public AppCleanupForm()
    {
        checklist.Items.AddRange(new string[]
        {
            "Microsoft Office Cache", "Adobe Temp Files", "Steam/Epic Games Cache",
            "Spotify Cache", "Discord Cache", "Zoom Cache", "Java Cache",
            "Python Cache", "Docker Images", "Visual Studio Cache"
        });
        this.Text = "Application-Specific Cleanup";
    }

    protected override void CleanItems(object sender, DoWorkEventArgs e)
    {
        foreach (string item in checklist.CheckedItems)
        {
            switch (item)
            {
                case "Microsoft Office Cache":
                    AppCleaner.CleanOfficeCache();
                    break;
                case "Adobe Temp Files":
                    AppCleaner.CleanAdobeTemp();
                    break;
                    // Add cases for all 10 items
            }
        }
    }
}