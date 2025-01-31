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
            this.Size = new Size(800, 600);
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Checklist
            checklist = new CheckedListBox
            {
                Location = new Point(50, 50),
                Size = new Size(700, 400),
                CheckOnClick = true,
                Font = new Font("Arial", 10)
            };

            // Buttons
            btnCheckAll = new Button
            {
                Text = "Check All",
                Location = new Point(50, 460),
                Size = new Size(100, 30),
                Font = new Font("Arial", 9)
            };
            btnCheckAll.Click += (s, e) => CheckAllItems(true);

            btnCleanSelected = new Button
            {
                Text = "Clean Selected",
                Location = new Point(160, 460),
                Size = new Size(120, 30),
                Font = new Font("Arial", 9)
            };
            btnCleanSelected.Click += BtnCleanSelected_Click;

            btnBack = new Button
            {
                Text = "Back",
                Location = new Point(670, 460),
                Size = new Size(100, 30),
                Font = new Font("Arial", 9)
            };
            btnBack.Click += (s, e) => { this.Close(); };

            // Progress elements
            progressBar = new ProgressBar
            {
                Location = new Point(50, 500),
                Size = new Size(700, 20)
            };

            lblProgress = new Label
            {
                Location = new Point(50, 530),
                Size = new Size(200, 20),
                Text = "0% Complete"
            };

            lblETA = new Label
            {
                Location = new Point(250, 530),
                Size = new Size(300, 20),
                Text = "ETA: Calculating..."
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
                MessageBox.Show("Please select at least one item!");
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
                MessageBox.Show("Cleaning complete!");
                progressBar.Value = 0;
                lblProgress.Text = "0% Complete";
                lblETA.Text = "ETA: Calculating...";
            };

            worker.RunWorkerAsync();
        }

        protected virtual void CleanItems(object sender, DoWorkEventArgs e)
        {
            // To be implemented in child forms
        }
    }
} 