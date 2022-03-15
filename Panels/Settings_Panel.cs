//  Bazaar Checker
//  Copyright (C) 2022 AlvaroBajceps(marcinwal9@gmail.com)
//  
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//  
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//  Source: https://github.com/AlvaroBajceps/BazaarChecker

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
