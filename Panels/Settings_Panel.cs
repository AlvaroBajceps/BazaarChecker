using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BazaarChecker.Panels
{
    public partial class Settings_Panel : Classes.UserControlButAdoptable
        { 
        public Settings_Panel() : base(CreationOptions.resizeWithParent)
        {
            InitializeComponent();
            saveStatus_Label.Text = "";
            LoadToPanel();
        }

        private void LoadToPanel()
        {
            bazaar_autoRefresh_CheckBox.Checked = ProgramSettings.settings.BazzarRefresh;
            bazaar_interval_Numeric.Value = ProgramSettings.settings.BazzarRefreshInterval / 1000m;

            ah_autoRefresh_CheckBox.Checked = ProgramSettings.settings.AuctionHouseRefresh;
            ah_interval_Numeric.Value = ProgramSettings.settings.AuctionHouseRefreshInterval / 1000m;
        }

        private void restore_Button_Click(object sender, EventArgs e)
        {
            ProgramSettings.BackToDefault();
            saveStatus_Label.Text = "Reseted to defaults!";
            saveStatus_Label.ForeColor = Color.LightGreen;
            LoadToPanel();
        }

        private void save_Button_Click(object sender, EventArgs e)
        {
            ProgramSettings.settings.BazzarRefresh = bazaar_autoRefresh_CheckBox.Checked;
            ProgramSettings.settings.BazzarRefreshInterval = (int)(bazaar_interval_Numeric.Value * 1000m);

            ProgramSettings.settings.AuctionHouseRefresh = ah_autoRefresh_CheckBox.Checked;
            ProgramSettings.settings.AuctionHouseRefreshInterval = (int)(ah_interval_Numeric.Value * 1000m);

            if (ProgramSettings.Save())
            {
                saveStatus_Label.Text = "Saved!";
                saveStatus_Label.ForeColor = Color.LightGreen;
            }
            else
            {
                saveStatus_Label.Text = "Save failed!";
                saveStatus_Label.ForeColor = Color.Red;
            }
        }

        private void load_button_Click(object sender, EventArgs e)
        {
            if (ProgramSettings.Read())
            {
                saveStatus_Label.Text = "Settings loaded!";
                saveStatus_Label.ForeColor = Color.LightGreen;
            }
            else
            {
                saveStatus_Label.Text = "Settings failed to load!";
                saveStatus_Label.ForeColor = Color.Red;
            }
            LoadToPanel();
        }

        private void close_Button_Click(object sender, EventArgs e)
        {
            Invoke((Parent.Parent as MainForm).ClosePanelContent);
        }

    }
}
