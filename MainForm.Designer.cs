namespace CapeVerdeCulturalFestival
{
    partial class MainForm
    {
        private TextBox txtName;
        private ComboBox cmbCategory;
        private TextBox txtContact;
        private Button btnAddParticipant;
        private ListBox lstParticipants;
        
        private void InitializeComponent()
        {
            // form
            this.Text = "Cape Verdean-American Cultural Festival";
            this.ClientSize = new System.Drawing.Size(400, 400);
            
            // text
            txtName = new TextBox();
            txtName.Location = new System.Drawing.Point(20, 20);
            txtName.Size = new System.Drawing.Size(200, 20);
            txtName.PlaceholderText = "Participant Name";
            this.Controls.Add(txtName);
            
            // combobox
            cmbCategory = new ComboBox();
            cmbCategory.Location = new System.Drawing.Point(20, 50);
            cmbCategory.Size = new System.Drawing.Size(200, 20);
            cmbCategory.Items.AddRange(new object[] { "Music", "Dance", "Art", "Food", "Storytelling" });
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cmbCategory);
            
            // contact
            txtContact = new TextBox();
            txtContact.Location = new System.Drawing.Point(20, 80);
            txtContact.Size = new System.Drawing.Size(200, 20);
            txtContact.PlaceholderText = "Contact Info";
            this.Controls.Add(txtContact);
            
            // buttton
            btnAddParticipant = new Button();
            btnAddParticipant.Location = new System.Drawing.Point(20, 110);
            btnAddParticipant.Size = new System.Drawing.Size(100, 30);
            btnAddParticipant.Text = "Add Participant";
            btnAddParticipant.Click += btnAddParticipant_Click;
            this.Controls.Add(btnAddParticipant);
            var btnExport = new Button
            {
            Text = "Export to CSV",
            Location = new Point(300, 350),
            BackColor = Color.Gold,
            ForeColor = Color.Blue
            };
            btnExport.Click += btnExport_Click;
            this.Controls.Add(btnExport);
            
            // listbox
            lstParticipants = new ListBox();
            lstParticipants.Location = new System.Drawing.Point(20, 150);
            lstParticipants.Size = new System.Drawing.Size(350, 200);
            this.Controls.Add(lstParticipants);

            // culture comboBox
            cmbCategory.Items.AddRange(new object[] {
                "Morna Music",
                "Funana Dance",
                "Batuque Performance",
                "Cachupa Cooking",
                "Morabeza Art"
            });

            // morna
            pnlMorna = new Panel();
            chkTraditional = new CheckBox { Text = "Traditional Style", Location = new Point(10, 10) };
            txtInstrument = new TextBox { Location = new Point(10, 40), PlaceholderText = "Instrument" };
            pnlMorna.Controls.AddRange(new Control[] { chkTraditional, txtInstrument });

            // funana panel
            pnlFunana = new Panel();
            numDancers = new NumericUpDown { Minimum = 2, Maximum = 20, Location = new Point(10, 10) };
            pnlFunana.Controls.Add(numDancers);

        }

        // controls
        private Panel pnlMorna;
        private Panel pnlFunana;
        private CheckBox chkTraditional;
        private TextBox txtInstrument;
        private NumericUpDown numDancers;
    }
}
