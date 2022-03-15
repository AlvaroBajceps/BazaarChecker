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
using BazaarChecker.Classes;

namespace BazaarChecker.Panels
{
    public partial class BazaarList : UserControlButAdoptable
    {
        Int64 lastDataTimeStamp = 0;

        public BazaarList() : base(CreationOptions.resizeWithParent)
        {
            InitializeComponent();
            timeElapsed_Label.Text = "";
            OnBazaarUpdateCompleate(null, null);
        }

        private void OnBazaarUpdateCompleate(object sender, RunWorkerCompletedEventArgs e)
        {
            
            GlobalVariables.bazaar_Mutex.WaitOne();
            if (GlobalVariables.bazaar.products == null)
            {
                GlobalVariables.bazaar_Mutex.ReleaseMutex();
                return;
            }

            List<ListViewItem> newList = new List<ListViewItem>();

            foreach (var product in GlobalVariables.bazaar.products)
            {
                ListViewItem item = new ListViewItem(product.Value.product_id);
                if (product.Value.buy_summary.Count != 0)
                {
                    item.SubItems.Add(product.Value.buy_summary[0].pricePerUnit.ToString());
                }
                else
                {
                    item.SubItems.Add("ND");
                }
                if (product.Value.sell_summary.Count != 0)
                {
                    item.SubItems.Add(product.Value.sell_summary[0].pricePerUnit.ToString());
                }
                else
                {
                    item.SubItems.Add("ND");
                }
                newList.Add(item);
            }

            lastDataTimeStamp = (Int64)GlobalVariables.bazaar.lastUpdated;
            GlobalVariables.bazaar_Mutex.ReleaseMutex();

            //pro update TM ;)
            listView1.BeginUpdate();

            int lastTopLevel = 0;
            List<int> lastSelected = new List<int>(); ;

            if (listView1.Items.Count > 0)
            {
                lastTopLevel = listView1.TopItem.Index;
                foreach (int item in listView1.SelectedIndices)
                {
                    lastSelected.Add(item);
                }

                listView1.Items.Clear();
            }

            if (newList.Count > 0)
            {
                listView1.Items.AddRange(newList.ToArray());
                listView1.TopItem = listView1.Items[lastTopLevel <= newList.Count ? lastTopLevel : 0];

                foreach (int item in lastSelected)
                {
                    listView1.SelectedIndices.Add(item);
                }
            }

            listView1.EndUpdate();

        }

        private void BazaarList_GotAdopted(Control tak)
        {
            (tak.Parent as MainForm).bazaar_Worker.RunWorkerCompleted += OnBazaarUpdateCompleate;
        }

        private void BazaarList_GotOrphaned(Control tak)
        {
            (tak.Parent as MainForm).bazaar_Worker.RunWorkerCompleted -= OnBazaarUpdateCompleate;
        }

        private void tick_Timer_Tick(object sender, EventArgs e)
        {
            var time = TimeSpan.FromMilliseconds(DateTimeOffset.Now.ToUnixTimeMilliseconds() - lastDataTimeStamp);
            timeElapsed_Label.Text = "Data age: " + (time.TotalHours <= 24d ? time.ToString(@"hh\:mm\:ss\.fff") : "More than day");
        }

        private void close_Button_Click(object sender, EventArgs e)
        {
            Invoke((Parent.Parent as MainForm).ClosePanelContent);
        }
    }
}
