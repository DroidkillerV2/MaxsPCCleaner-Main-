using MaxsPCCleaner;
using System.ComponentModel;

public partial class BrowserCleaningForm : BaseCleanerForm
{
    public BrowserCleaningForm()
    {
        checklist.Items.AddRange(new string[]
        {
            "Browser Cache",
            "Cookies",
            "Browsing History",
            "Download History",
            "Form Data",
            "Passwords",
            "Extensions Cache",
            "Web Databases",
            "Service Workers",
            "SuperCookies",
            "Browser Sessions",
            "Search Bar History",
            "Browser Crash Reports"
        });
        this.Text = "Browser Cleaning";
    }

    protected override void CleanItems(object sender, DoWorkEventArgs e)
    {
        foreach (string item in checklist.CheckedItems)
        {
            switch (item)
            {
                case "Browser Cache":
                    BrowserCleaner.ClearBrowserCache(BrowserType.Chrome);
                    BrowserCleaner.ClearBrowserCache(BrowserType.Firefox);
                    // Add other browsers
                    break;
                case "Cookies":
                    BrowserCleaner.ClearCookies(BrowserType.Chrome);
                    // Add other browsers
                    break;
                    // Add cases for all 13 items
            }
        }
    }
}