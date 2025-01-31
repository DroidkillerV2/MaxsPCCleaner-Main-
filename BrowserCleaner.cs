using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MaxsPCCleaner
{
    public partial class BaseCleanerForm : Form
    {
        protected CheckedListBox checklist;
        protected Button btnCheckAll, btnCleanSelected, btnBack;
        protected ProgressBar progressBar;
        protected Label lblProgress, lblETA;

        public BaseCleanerForm()
        {
            InitializeBaseComponents();
        }

        private void InitializeBaseComponents()
        {
            // Form setup
            this.Size = new Size(900, 700);
            this.BackColor = Color.FromArgb(30, 30, 30); // Dark background
            this.ForeColor = Color.White; // White text
            this.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Bold font
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Checklist
            checklist = new CheckedListBox
            {
                Location = new Point(50, 50),
                Size = new Size(800, 400),
                CheckOnClick = true,
                BackColor = Color.FromArgb(50, 50, 50), // Darker background
                ForeColor = Color.White, // White text
                Font = new Font("Segoe UI", 10, FontStyle.Bold) // Bold font
            };

            // Buttons
            btnCheckAll = new Button
            {
                Text = "Check All",
                Location = new Point(50, 470),
                Size = new Size(120, 40),
                BackColor = Color.FromArgb(0, 120, 215), // Blue background
                ForeColor = Color.White, // White text
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold) // Bold font
            };
            btnCheckAll.Click += (s, e) => CheckAllItems(true);

            btnCleanSelected = new Button
            {
                Text = "Clean Selected",
                Location = new Point(180, 470),
                Size = new Size(150, 40),
                BackColor = Color.FromArgb(0, 120, 215), // Blue background
                ForeColor = Color.White, // White text
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold) // Bold font
            };
            btnCleanSelected.Click += BtnCleanSelected_Click;

            btnBack = new Button
            {
                Text = "Back",
                Location = new Point(730, 470),
                Size = new Size(120, 40),
                BackColor = Color.FromArgb(0, 120, 215), // Blue background
                ForeColor = Color.White, // White text
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold) // Bold font
            };
            btnBack.Click += (s, e) => { this.Close(); };

            // Progress Bar
            progressBar = new ProgressBar
            {
                Location = new Point(50, 530),
                Size = new Size(800, 20),
                Style = ProgressBarStyle.Continuous,
                ForeColor = Color.FromArgb(0, 120, 215) // Blue progress bar
            };

            // Labels
            lblProgress = new Label
            {
                Location = new Point(50, 560),
                Size = new Size(200, 30),
                Text = "0% Complete",
                Font = new Font("Segoe UI", 10, FontStyle.Bold) // Bold font
            };

            lblETA = new Label
            {
                Location = new Point(250, 560),
                Size = new Size(300, 30),
                Text = "ETA: Calculating...",
                Font = new Font("Segoe UI", 10, FontStyle.Bold) // Bold font
            };

            this.Controls.AddRange(new Control[] {
                checklist, btnCheckAll, btnCleanSelected, btnBack,
                progressBar, lblProgress, lblETA
            });
        }

        protected virtual void CheckAllItems(bool check)
        {
            for (int i = 0; i < checklist.Items.Count; i++)
                checklist.SetItemChecked(i, check);
        }

        protected virtual void BtnCleanSelected_Click(object sender, EventArgs e)
        {
            if (checklist.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BackgroundWorker worker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };

            worker.DoWork += CleanItems;
            worker.ProgressChanged += (s, ev) =>
            {
                progressBar.Value = ev.ProgressPercentage;
                lblProgress.Text = $"{ev.ProgressPercentage}% Complete";
                lblETA.Text = $"ETA: {ev.UserState}";
            };

            worker.RunWorkerCompleted += (s, ev) =>
            {
                MessageBox.Show("Cleaning complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressBar.Value = 0;
                lblProgress.Text = "0% Complete";
                lblETA.Text = "ETA: Calculating...";
            };

            worker.RunWorkerAsync();
        }

        protected virtual void CleanItems(object sender, DoWorkEventArgs e)
        {
            // To be overridden in child forms
        }
    }
}