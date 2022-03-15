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
    public partial class AuctionList : Classes.UserControlButAdoptable
    {
        Int64 lastDataTimeStamp = 0;

        public AuctionList() : base(CreationOptions.resizeWithParent)
        {
            InitializeComponent();
            timeElapsed_Label.Text = "";
        }

        private void OnAHUpdateCompleate(object sender, RunWorkerCompletedEventArgs e)
        {
            GlobalVariables.activeAuctions_Mutex.WaitOne();
            if (GlobalVariables.activeAuctions.auctions == null)
            {
                GlobalVariables.activeAuctions_Mutex.ReleaseMutex();
                return;
            }

            List<ListViewItem> newList = new List<ListViewItem>();

            foreach (var auction in GlobalVariables.activeAuctions.auctions)
            {
                ListViewItem item = new ListViewItem(auction.item_name);
                item.SubItems.Add(auction.category);
                item.SubItems.Add(auction.tier);
                item.SubItems.Add(auction.bin ? "BIN" : "Auction");
                item.SubItems.Add((auction.higest_bid_amount == 0m ? auction.starting_bid : auction.higest_bid_amount).ToString("F"));
                newList.Add(item);
            }

            lastDataTimeStamp = (Int64)GlobalVariables.activeAuctions.lastUpdated;
            GlobalVariables.activeAuctions_Mutex.ReleaseMutex();

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

        private void AuctionList_GotAdopted(Control tak)
        {
            (tak.Parent as MainForm).ah_Worker.RunWorkerCompleted += OnAHUpdateCompleate;
            OnAHUpdateCompleate(null, null);
        }

        private void AuctionList_GotOrphaned(Control tak)
        {
            (tak.Parent as MainForm).ah_Worker.RunWorkerCompleted -= OnAHUpdateCompleate;
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
