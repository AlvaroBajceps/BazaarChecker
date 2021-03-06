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
        private bool inSettings = false;

        public delegate void ClosePanel();
        private ClosePanel closePanelContent;
        public ClosePanel ClosePanelContent { get => closePanelContent; }

        private HDataViewBase dataViewPanel;
        private bool dataViewPanel_doRefreshWithAH = false;
        private bool dataViewPanel_doRefreshWithAHGroup = false;
        private bool dataViewPanel_doRefreshWithBazaar = false;

        public MainForm()
        {
            InitializeComponent();
            closePanelContent = new(ClearPanel);

            GlobalVariables.allItems = DataDownloader.GetAllItemsData();

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

        public static string GiveMeAscii(string input)
        {
            var keyString = "";
            var inputArray = input.Normalize(System.Text.NormalizationForm.FormKD).ToCharArray();
            foreach (var item in inputArray)
            {
                if (item >= 0 && item <= 127)
                {
                    keyString += item;
                }
            }
            return keyString.TrimStart().TrimEnd();
        }

        public static string ExcludeSquareBracket(string input)
        {
            while (input.Contains("[Lvl"))
            {
                input = input.Remove(input.IndexOf('['), input.IndexOf(']') - input.IndexOf('[') + 1);
            }
            return input.TrimStart().TrimEnd();
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
            dataViewPanel = null;
            dataViewPanel_doRefreshWithAH = false;
            dataViewPanel_doRefreshWithAHGroup = false;
            dataViewPanel_doRefreshWithBazaar = false;
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
            //main_Panel.Controls.Add(new Panels.BazaarList());

            dataViewPanel = new HDataViewBase();
            dataViewPanel_doRefreshWithBazaar = true;
            dataViewPanel.theListView.Columns.Add("Item");
            dataViewPanel.theListView.Columns.Add("QSell Price");
            dataViewPanel.ItemToView = (item) =>
            {
                var newList = new List<string>();
                var x = (Product)item;
                var chossenOne = GlobalVariables.allItems.items.Find((cur) => cur.id == x.product_id).name;

                if (chossenOne != null)
                {
                    newList.Add(GlobalVariables.allItems.items.Find((cur) => cur.id == x.product_id).name);
                }
                else
                {
                    newList.Add(x.product_id + " (ID)");
                }
                newList.Add(x.quick_status.sellPrice.ToString());
                return newList;
            };

            main_Panel.Controls.Add(dataViewPanel);

            GlobalVariables.bazaar_Mutex.WaitOne();
            if (GlobalVariables.bazaar.products != null)
            {
                var data = new List<Product>(GlobalVariables.bazaar.products.Values);
                GlobalVariables.bazaar_Mutex.ReleaseMutex();
                dataViewPanel.RefreshList(data);
            }
            else
            {
                GlobalVariables.bazaar_Mutex.ReleaseMutex();
            }

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
            if (dataViewPanel_doRefreshWithBazaar)
            {
                GlobalVariables.bazaar_Mutex.WaitOne();
                var data = new List<Product>(GlobalVariables.bazaar.products.Values);
                GlobalVariables.bazaar_Mutex.ReleaseMutex();
                dataViewPanel.RefreshList(data);
            }
        }

        private void ah_Timer_Tick(object sender, EventArgs e)
        {
            ah_Timer.Enabled = false;
            ah_Worker.RunWorkerAsync();
        }

        private void ah_Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var ahStamdard = DataDownloader.GetWholeAh();
            ahStamdard.auctions.Sort(new Comparison<Auction>(
                (x, y) =>
                {
                    var test1 = ExcludeSquareBracket(GiveMeAscii(x.item_name)).CompareTo(ExcludeSquareBracket(GiveMeAscii(y.item_name)));
                    if (test1 == 0)
                    {
                        return x.item_name.CompareTo(y.item_name);
                    }
                    else
                    {
                        return test1;
                    }
                }
                ));

            GroupedAuctions ahGrouped = new();
            ahGrouped.Auctions = new();

            //Knowing that ahStamdard is sorted we can look for same item until one not match,
            //we can move to next then item, unitl we run out of items
            for (int idx = 0; idx < ahStamdard.auctions.Count;)
            {
                var workingList = new List<Auction>();
                workingList.Add(ahStamdard.auctions[idx++]);

                var groupName = ExcludeSquareBracket(GiveMeAscii(workingList[0].item_name));

                //idx < ahStamdard.auctions.Count must be be here in case we run out of items
                for (; idx < ahStamdard.auctions.Count && ExcludeSquareBracket(GiveMeAscii(ahStamdard.auctions[idx].item_name)) == groupName; idx++)
                {
                    workingList.Add(ahStamdard.auctions[idx]);
                }

                ahGrouped.Auctions.Add(groupName, workingList);
            }

            ahGrouped.LastUpdated = ahStamdard.lastUpdated;
            ahGrouped.TotalAuctions = ahStamdard.totalAuctions;

            // var lastUsedName = "";
            //foreach (var auction in ahStamdard.auctions)
            //{
            //    if (auction.item_name == lastUsedName) continue;

            //    lastUsedName = auction.item_name;

            //    ahGrouped.Auctions.Add(lastUsedName, ahStamdard.auctions.FindAll(new Predicate<Auction>(target => target.item_name == lastUsedName)));
            //}

            GlobalVariables.activeAuctions_Mutex.WaitOne();
            GlobalVariables.activeAuctions = ahStamdard;
            GlobalVariables.groupedAuctions = ahGrouped;
            GlobalVariables.activeAuctions_Mutex.ReleaseMutex();

        }

        private void ah_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ah_Timer.Enabled = inSettings ? false : ProgramSettings.settings.AuctionHouseRefresh;
            if (dataViewPanel_doRefreshWithAH)
            {
                GlobalVariables.bazaar_Mutex.WaitOne();
                var data = new List<Auction>(GlobalVariables.activeAuctions.auctions);
                GlobalVariables.bazaar_Mutex.ReleaseMutex();
                dataViewPanel.RefreshList(data);
            }
            else if (dataViewPanel_doRefreshWithAHGroup)
            {
                GlobalVariables.activeAuctions_Mutex.WaitOne();
                var data = new List<List<Auction>>(GlobalVariables.groupedAuctions.Auctions.Values);
                GlobalVariables.activeAuctions_Mutex.ReleaseMutex();
                dataViewPanel.RefreshList(data);
            }
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

