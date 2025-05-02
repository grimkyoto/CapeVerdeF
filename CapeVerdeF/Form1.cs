using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace CapeVerdeF
{
    public partial class Form1 : Form
    {
        private readonly FestivalManager _manager = new FestivalManager();
        
        public Form1()
        {
            InitializeComponent();
            _manager.ManagerName = "Your Name";
            SetupCulturalUI();
        }

        private void SetupCulturalUI()
        {
            this.BackColor = Color.FromArgb(0, 102, 179);
            lblTitle.ForeColor = Color.White;
            lblStats.ForeColor = Color.Gold;
        }

        private void btnAddParticipant_Click(object sender, EventArgs e)
        {
            try
            {
                var participant = CreateParticipant();
                if (_manager.RegisterParticipant(participant))
                {
                    RefreshUI();
                    MessageBox.Show($"Registered for {participant.Category}!", "Success", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cultural Validation", 
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Participant CreateParticipant()
        {
            return cmbCategory.SelectedItem.ToString() switch
            {
                "Morna Music" => new MornaParticipant(
                    txtName.Text,
                    txtContact.Text,
                    txtInstrument.Text, 
                    chkTraditional.Checked),

                "Funana Dance" => new FunanaDanceParticipant(
                    txtName.Text,
                    txtContact.Text,
                    (int)numDancers.Value,
                    true),

                _ => new Participant(
                    txtName.Text,
                    cmbCategory.SelectedItem.ToString(),
                    txtContact.Text)
            };
        }

        private void RefreshUI()
        {
            lstParticipants.Items.Clear();
            foreach (var p in _manager.Participants)
            {
                lstParticipants.Items.Add(p.GetDisplayInfo());
            }
            UpdateCulturalStats();
        }

        private void UpdateCulturalStats()
        {
            lblStats.Text = _manager.GetCulturalStats();
            lblTotalFees.Text = $"Total Fees: {_manager.GetTotalFees():C}";
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlMorna.Visible = cmbCategory.SelectedItem.ToString() == "Morna Music";
            pnlFunana.Visible = cmbCategory.SelectedItem.ToString() == "Funana Dance";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "CSV Files (*.csv)|*.csv";
                saveDialog.Title = "Export Festival Data";
                saveDialog.FileName = $"CapeVerdeFestival_{DateTime.Now:yyyyMMdd}.csv";
                
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    _manager.ExportToCSV(saveDialog.FileName);
                    MessageBox.Show($"Exported {_manager.Participants.Count} participants!\n" +
                                   $"Managed by: {_manager.ManagerName}",
                                   "Export Complete", 
                                   MessageBoxButtons.OK, 
                                   MessageBoxIcon.Information);
                }
            }
        }
    }
}