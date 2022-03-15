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
using System.ComponentModel;
using System.Windows.Forms;
using BazaarChecker.Classes;
using BazaarChecker.Panels;
using System.Collections.Generic;

namespace BazaarChecker
{
    public partial class MainForm : Form
    {
        class SAHComparer : IComparer<Auction>
        {
            public int Compare(Auction a, Auction b)
            {
                //First, BIN, next Auction
                if (a.bin && !b.bin)
                {
                    return -1;
                }
                else if (!a.bin && b.bin)
                {
                    return 1;
                }
                else
                {
                    //Then by category
                    var categoryCompared = a.category.CompareTo(b.category);
                    if (categoryCompared < 0)
                    {
                        return -1;
                    }
                    else if (categoryCompared > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        //Next is name
                        var nameCompared = a.item_name.CompareTo(b.item_name);
                        if (nameCompared < 0)
                        {
                            return -1;
                        }
                        else if (nameCompared > 0)
                        {
                            return 1;
                        }
                        else
                        {
                            //finally lowest pfu to higest pfu 
                            var a_pfu = (a.higest_bid_amount == 0m ? a.starting_bid : a.higest_bid_amount);
                            var b_pfu = (b.higest_bid_amount == 0m ? b.starting_bid : b.higest_bid_amount);
                            return a_pfu.CompareTo(b_pfu);
                        }
                    }
                }
            }
        }

        private bool inSettings = false;

        public delegate void ClosePanel();
        private ClosePanel closePanelContent;
        public ClosePanel ClosePanelContent { get => closePanelContent; }

        public MainForm()
        {
            InitializeComponent();
            closePanelContent = new(ClearPanel);

            if (!ProgramSettings.Read())
            {
                main_Panel.Controls.Add(new Panels.Settings_Panel());
                inSettings = true;
            }
            else
            {
                ah_Timer.Interval = ProgramSettings.settings.AuctionHouseRefreshInterval;
                ah_Timer.Enabled = ProgramSettings.settings.AuctionHouseRefresh;
                bazaar_Timer.Interval = ProgramSettings.settings.BazzarRefreshInterval;
                bazaar_Timer.Enabled = ProgramSettings.settings.BazzarRefresh;
            }
        }

        public void ClearPanel()
        {
            if (inSettings)
            {
                ah_Timer.Interval = ProgramSettings.settings.AuctionHouseRefreshInterval;
                ah_Timer.Enabled = ProgramSettings.settings.AuctionHouseRefresh;
                bazaar_Timer.Interval = ProgramSettings.settings.BazzarRefreshInterval;
                bazaar_Timer.Enabled = ProgramSettings.settings.BazzarRefresh;
                inSettings = false;
            }
            foreach (Control item in main_Panel.Controls)
            {
                item.Dispose();
            }
        }

        #region Form Events
        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            main_Panel.AutoScroll = false;
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            main_Panel.AutoScroll = true;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ClearPanel();
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ClearPanel();
                Hide();
                tray_Notify.Visible = true;
            }
        }
        #endregion

        #region Click On Menu Items Events
        private void menu_settings_openSettings_MenuItem_Click(object sender, EventArgs e)
        {
            ClearPanel();
            main_Panel.Controls.Add(new Panels.Settings_Panel());
            inSettings = true;
        }

        private void menu_dataView_bazaar_MenuItem_Click(object sender, EventArgs e)

        {
            ClearPanel();
            main_Panel.Controls.Add(new Panels.BazaarList());
        }

        private void menu_dataView_ah_MenuItem_Click(object sender, EventArgs e)
        {
            ClearPanel();
            main_Panel.Controls.Add(new AuctionList());
        }

        private void menu_refresh_bazaar_MenuItem_Click(object sender, EventArgs e)
        {
            if (!bazaar_Worker.IsBusy)
            {
                bazaar_Timer.Enabled = false;
                bazaar_Worker.RunWorkerAsync();
            }
        }

        private void menu_refresh_ah_MenuItem_Click(object sender, EventArgs e)
        {
            if (!ah_Worker.IsBusy)
            {
                ah_Timer.Enabled = false;
                ah_Worker.RunWorkerAsync();
            }
        }
        #endregion

        #region Other Events
        private void bazaar_Timer_Tick(object sender, EventArgs e)
        {
            bazaar_Timer.Enabled = false;
            bazaar_Worker.RunWorkerAsync();
        }

        private void bazaar_Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var data = DataDownloader.GetBazaarData();
            GlobalVariables.bazaar_Mutex.WaitOne();
            GlobalVariables.bazaar = data;
            GlobalVariables.bazaar_Mutex.ReleaseMutex();
        }

        private void bazaar_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bazaar_Timer.Enabled = inSettings ? false : ProgramSettings.settings.BazzarRefresh;
        }

        private void ah_Timer_Tick(object sender, EventArgs e)
        {
            ah_Timer.Enabled = false;
            ah_Worker.RunWorkerAsync();
        }

        private void ah_Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var dataT = DataDownloader.GetWholeAh();
            var data = dataT.Result;
            data.auctions.Sort(new SAHComparer());
            GlobalVariables.activeAuctions_Mutex.WaitOne();
            GlobalVariables.activeAuctions = data;
            GlobalVariables.activeAuctions_Mutex.ReleaseMutex();

        }

        private void ah_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ah_Timer.Enabled = inSettings ? false : ProgramSettings.settings.AuctionHouseRefresh;
        }

        private void tray_Notify_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            tray_Notify.Visible = false;
        }

        #endregion


       


    }
}

