using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapeVerdeCulturalFestival
{
    public partial class MainForm : Form
    {
        private List<Participant> participants = new List<Participant>();
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAddParticipant_Click(object sender, EventArgs e)
        {
            try
            {
                // Get input from form controls
                string name = txtName.Text;
                string category = cmbCategory.SelectedItem.ToString();
                string contact = txtContact.Text;
                
                // Validate input
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category))
                {
                    MessageBox.Show("Please enter name and select category");
                    return;
                }

                // Create participant
                Participant newParticipant = new Participant(name, category, contact);
                participants.Add(newParticipant);
                
                // Update display
                RefreshParticipantList();
                
                // Clear inputs
                txtName.Text = "";
                cmbCategory.SelectedIndex = -1;
                txtContact.Text = "";
                
                MessageBox.Show("Participant added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void RefreshParticipantList()
        {
            lstParticipants.Items.Clear();
            foreach (Participant p in participants)
            {
                lstParticipants.Items.Add($"{p.Name} - {p.Category}");
            }
        }
    }

    public class Participant
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string ContactInfo { get; set; }

        public Participant(string name, string category, string contactInfo)
        {
            Name = name;
            Category = category;
            ContactInfo = contactInfo;
        }
    }
}
