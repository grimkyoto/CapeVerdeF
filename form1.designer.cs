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
            // Form
            this.Text = "Cape Verdean-American Cultural Festival";
            this.ClientSize = new System.Drawing.Size(400, 400);
            
            // Name TextBox
            txtName = new TextBox();
            txtName.Location = new System.Drawing.Point(20, 20);
            txtName.Size = new System.Drawing.Size(200, 20);
            txtName.PlaceholderText = "Participant Name";
            this.Controls.Add(txtName);
            
            // Category ComboBox
            cmbCategory = new ComboBox();
            cmbCategory.Location = new System.Drawing.Point(20, 50);
            cmbCategory.Size = new System.Drawing.Size(200, 20);
            cmbCategory.Items.AddRange(new object[] { "Music", "Dance", "Art", "Food", "Storytelling" });
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cmbCategory);
            
            // Contact TextBox
            txtContact = new TextBox();
            txtContact.Location = new System.Drawing.Point(20, 80);
            txtContact.Size = new System.Drawing.Size(200, 20);
            txtContact.PlaceholderText = "Contact Info";
            this.Controls.Add(txtContact);
            
            // Add Button
            btnAddParticipant = new Button();
            btnAddParticipant.Location = new System.Drawing.Point(20, 110);
            btnAddParticipant.Size = new System.Drawing.Size(100, 30);
            btnAddParticipant.Text = "Add Participant";
            btnAddParticipant.Click += btnAddParticipant_Click;
            this.Controls.Add(btnAddParticipant);
            
            // Participants ListBox
            lstParticipants = new ListBox();
            lstParticipants.Location = new System.Drawing.Point(20, 150);
            lstParticipants.Size = new System.Drawing.Size(350, 200);
            this.Controls.Add(lstParticipants);
        }
    }
}
