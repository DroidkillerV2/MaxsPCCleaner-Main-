using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaxsPCCleaner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CreateHomeScreen();
        }

        private void CreateHomeScreen()
        {
            // Form setup
            this.Text = "Max's PC Cleaner";
            this.Size = new Size(900, 700);
            this.BackColor = Color.FromArgb(30, 30, 30); // Dark background
            this.ForeColor = Color.White; // White text
            this.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Bold font
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Title Label
            Label titleLabel = new Label
            {
                Text = "Made by Max The Goat",
                Font = new Font("Segoe UI", 24, FontStyle.Bold), // Bold font
                AutoSize = true,
                Location = new Point(250, 50),
                ForeColor = Color.FromArgb(0, 120, 215) // Blue text
            };
            this.Controls.Add(titleLabel);

            // Submenu Buttons
            string[] subMenus = {
                "System Junk Cleaning", "Browser Cleaning", "Privacy & Security",
                "Application-Specific Cleanup", "Disk & Storage Optimization",
                "Registry Cleaning", "System Performance", "SSD Optimization",
                "Network Cleaning", "Advanced System Tools"
            };

            int yPos = 150;
            foreach (string menu in subMenus)
            {
                Button btn = new Button
                {
                    Text = menu,
                    Location = new Point(50, yPos),
                    Size = new Size(800, 50),
                    Tag = menu,
                    BackColor = Color.FromArgb(0, 120, 215), // Blue background
                    ForeColor = Color.White, // White text
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold) // Bold font
                };
                btn.Click += SubmenuButton_Click;
                this.Controls.Add(btn);
                yPos += 60;
            }
        }

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
    }
}