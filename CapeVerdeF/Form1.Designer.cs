using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapeVerdeF
{
    partial class Form1
    {
        // Control declarations
        private TableLayoutPanel mainLayoutPanel;
        private PictureBox headerBanner;
        private Label lblTitle;
        private TextBox txtName;
        private ComboBox cmbCategory;
        private TextBox txtContact;
        private Button btnAddParticipant;
        private Button btnExport;
        private ListBox lstParticipants;
        private Panel pnlMorna;
        private CheckBox chkTraditional;
        private TextBox txtInstrument;
        private Panel pnlFunana;
        private NumericUpDown numDancers;
        private Label lblStats;
        private Label lblTotalFees;

        private void InitializeComponent()
        {
           //form settings
            this.SuspendLayout();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.MinimumSize = new Size(800, 600);
            this.BackColor = Color.FromArgb(0, 102, 179);
            this.Text = "Cape Verdean Festival";
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            // main layout panel 
            this.mainLayoutPanel = new TableLayoutPanel();
            this.mainLayoutPanel.Dock = DockStyle.Fill;
            this.mainLayoutPanel.ColumnCount = 2;
            this.mainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.mainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.mainLayoutPanel.RowCount = 5;
            this.mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));  // Title
            this.mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));  // Name
            this.mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));  // Category
            this.mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));  // Contact
            this.mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // List + Stats
            this.mainLayoutPanel.Padding = new Padding(10);
            this.Controls.Add(this.mainLayoutPanel);

            // Header banner
            this.headerBanner = new PictureBox();
            this.headerBanner.Dock = DockStyle.Top;
            this.headerBanner.Height = 80;
            this.headerBanner.BackColor = Color.FromArgb(0, 61, 121);
            this.Controls.Add(this.headerBanner);

            // Title label
            this.lblTitle = new Label();
            this.lblTitle.Text = "CAPE VERDEAN CULTURAL FESTIVAL";
            this.lblTitle.Font = new Font("Montserrat", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = DockStyle.Fill;
            this.headerBanner.Controls.Add(this.lblTitle);

            // Name input
            this.txtName = new TextBox();
            this.txtName.Dock = DockStyle.Fill;
            this.txtName.Margin = new Padding(3, 5, 3, 5);
            this.txtName.Font = new Font("Segoe UI", 10F);
            this.txtName.PlaceholderText = "Participant Name";
            this.mainLayoutPanel.Controls.Add(this.txtName, 0, 1);
            this.mainLayoutPanel.SetColumnSpan(this.txtName, 2);

            // Category dropdown
            this.cmbCategory = new ComboBox();
            this.cmbCategory.Dock = DockStyle.Fill;
            this.cmbCategory.Margin = new Padding(3, 5, 3, 5);
            this.cmbCategory.Font = new Font("Segoe UI", 10F);
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.Items.AddRange(new object[] {
                "Morna Music",
                "Funana Dance",
                "Batuque Performance",
                "Cachupa Cooking"
            });
            this.mainLayoutPanel.Controls.Add(this.cmbCategory, 0, 2);
            this.mainLayoutPanel.SetColumnSpan(this.cmbCategory, 2);

            // Contact input
            this.txtContact = new TextBox();
            this.txtContact.Dock = DockStyle.Fill;
            this.txtContact.Margin = new Padding(3, 5, 3, 5);
            this.txtContact.Font = new Font("Segoe UI", 10F);
            this.txtContact.PlaceholderText = "Contact Information";
            this.mainLayoutPanel.Controls.Add(this.txtContact, 0, 3);
            this.mainLayoutPanel.SetColumnSpan(this.txtContact, 2);

            // Add Participant button
            this.btnAddParticipant = new Button();
            this.btnAddParticipant.Dock = DockStyle.Fill;
            this.btnAddParticipant.Margin = new Padding(3, 10, 3, 5);
            this.btnAddParticipant.Text = "ADD PARTICIPANT";
            this.btnAddParticipant.BackColor = Color.FromArgb(206, 17, 38);
            this.btnAddParticipant.ForeColor = Color.White;
            this.btnAddParticipant.FlatStyle = FlatStyle.Flat;
            this.btnAddParticipant.FlatAppearance.BorderSize = 0;
            this.btnAddParticipant.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.mainLayoutPanel.Controls.Add(this.btnAddParticipant, 0, 4);

            // Export button
            this.btnExport = new Button();
            this.btnExport.Dock = DockStyle.Fill;
            this.btnExport.Margin = new Padding(3, 10, 3, 5);
            this.btnExport.Text = "EXPORT TO CSV";
            this.btnExport.BackColor = Color.Gold;
            this.btnExport.ForeColor = Color.Black;
            this.btnExport.FlatStyle = FlatStyle.Flat;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.mainLayoutPanel.Controls.Add(this.btnExport, 1, 4);

            // Participants list
            this.lstParticipants = new ListBox();
            this.lstParticipants.Dock = DockStyle.Fill;
            this.lstParticipants.Margin = new Padding(3, 5, 3, 5);
            this.lstParticipants.Font = new Font("Segoe UI", 10F);
            this.lstParticipants.DrawMode = DrawMode.OwnerDrawVariable;
            this.mainLayoutPanel.Controls.Add(this.lstParticipants, 0, 5);
            this.mainLayoutPanel.SetColumnSpan(this.lstParticipants, 2);

            // Stats labels
            this.lblStats = new Label();
            this.lblStats.Dock = DockStyle.Fill;
            this.lblStats.Margin = new Padding(3, 5, 3, 5);
            this.lblStats.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblStats.ForeColor = Color.White;
            this.mainLayoutPanel.Controls.Add(this.lblStats, 0, 6);

            this.lblTotalFees = new Label();
            this.lblTotalFees.Dock = DockStyle.Fill;
            this.lblTotalFees.Margin = new Padding(3, 5, 3, 5);
            this.lblTotalFees.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblTotalFees.ForeColor = Color.Gold;
            this.lblTotalFees.TextAlign = ContentAlignment.TopRight;
            this.mainLayoutPanel.Controls.Add(this.lblTotalFees, 1, 6);

            // Category-specific panels
            InitializeCategoryPanels();

            this.ResumeLayout(false);
        }

        private void InitializeCategoryPanels()
        {
            // Morna Panel
            this.pnlMorna = new Panel();
            this.pnlMorna.Dock = DockStyle.Fill;
            this.pnlMorna.BackColor = Color.FromArgb(50, 0, 61, 121);
            this.pnlMorna.Visible = false;

            this.chkTraditional = new CheckBox();
            this.chkTraditional.Text = "Traditional Style";
            this.chkTraditional.ForeColor = Color.White;
            this.chkTraditional.Location = new Point(10, 10);
            this.chkTraditional.Font = new Font("Segoe UI", 9F);

            this.txtInstrument = new TextBox();
            this.txtInstrument.PlaceholderText = "Instrument";
            this.txtInstrument.Location = new Point(10, 40);
            this.txtInstrument.Font = new Font("Segoe UI", 9F);
            this.txtInstrument.Width = 150;

            this.pnlMorna.Controls.Add(this.chkTraditional);
            this.pnlMorna.Controls.Add(this.txtInstrument);
            this.mainLayoutPanel.Controls.Add(this.pnlMorna, 0, 2);
            this.mainLayoutPanel.SetColumnSpan(this.pnlMorna, 2);

            // Funana Panel
            this.pnlFunana = new Panel();
            this.pnlFunana.Dock = DockStyle.Fill;
            this.pnlFunana.BackColor = Color.FromArgb(50, 206, 17, 38);
            this.pnlFunana.Visible = false;

            this.numDancers = new NumericUpDown();
            this.numDancers.Minimum = 2;
            this.numDancers.Maximum = 20;
            this.numDancers.Location = new Point(10, 10);
            this.numDancers.Font = new Font("Segoe UI", 9F);
            this.numDancers.Width = 60;

            this.pnlFunana.Controls.Add(this.numDancers);
            this.mainLayoutPanel.Controls.Add(this.pnlFunana, 0, 2);
            this.mainLayoutPanel.SetColumnSpan(this.pnlFunana, 2);
        }
    }
}