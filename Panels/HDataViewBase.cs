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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BazaarChecker.Classes
{
    public class HDataViewBase : Classes.UserControlButAdoptable
    {
        public ListView theListView;
        private Timer tick_Timer;
        private Button close_Button;
        private Label timeElapsed_Label;

        private IContainer components;
        private Int64 lastDataTimeStamp = 0;
        public Int64 LastDataTimeStamp { get => lastDataTimeStamp; set => lastDataTimeStamp = value; }

        private bool sortingAscending = false;
        private int sortingColumn = 0;

        public delegate List<string> ItemToView_Delegate(object item);
        public ItemToView_Delegate ItemToView;


        public HDataViewBase()
        {
            InitializeComponent();
            Options = CreationOptions.resizeWithParent;
        }

        public void RefreshList<ListType>(List<ListType> list) 
        {
            if (list == null || list.Count == 0)
            {
                return;
            }
            List<ListViewItem> newList = new List<ListViewItem>();

            foreach (ListType item in list)
            {
                newList.Add(new ListViewItem(ItemToView(item).ToArray()));
            }

            //pro update TM ;)
            theListView.BeginUpdate();

            int lastTopLevel = 0;

            if (theListView.Items.Count > 0)
            {
                lastTopLevel = theListView.TopItem.Index;
                theListView.Items.Clear();
            }

            if (newList.Count > 0)
            {
                theListView.Items.AddRange(newList.ToArray());
                theListView.TopItem = theListView.Items[lastTopLevel <= newList.Count ? lastTopLevel : 0];
            }

            theListView.EndUpdate();
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



        private void theListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == sortingColumn)
            {
                if (!theListView.Columns[e.Column].Text.Contains('▲') && !theListView.Columns[e.Column].Text.Contains('▼'))
                {
                    if (sortingAscending)
                        theListView.Columns[e.Column].Text += " ▲";
                    else
                        theListView.Columns[e.Column].Text += " ▼";
                }
                else
                {
                    sortingAscending = !sortingAscending;
                    if (sortingAscending)
                    {
                        theListView.Columns[e.Column].Text = theListView.Columns[e.Column].Text.Replace('▼', '▲');
                    }
                    else
                    {
                        theListView.Columns[e.Column].Text = theListView.Columns[e.Column].Text.Replace('▲', '▼');
                    }
                }
            }
            else
            {
                if (sortingAscending)
                {
                    theListView.Columns[sortingColumn].Text = theListView.Columns[sortingColumn].Text.Replace('▲', ' ').TrimEnd();
                }
                else
                {
                    theListView.Columns[sortingColumn].Text = theListView.Columns[sortingColumn].Text.Replace('▼', ' ').TrimEnd();
                }

                sortingAscending = true;
                sortingColumn = e.Column;
                theListView.Columns[e.Column].Text += " ▲";
            }
            theListView.ListViewItemSorter = new ListViewItemComparer(sortingColumn, sortingAscending);
        }

        class ListViewItemComparer : System.Collections.IComparer
        {
            private int col;
            private bool desc;
            public ListViewItemComparer()
            {
                col = 0;
                desc = false;
            }
            public ListViewItemComparer(int column, bool descending)
            {
                col = column;
                desc = descending;
            }
            public int Compare(object x, object y)
            {
                return (desc ? String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text) : -String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text));
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.theListView = new System.Windows.Forms.ListView();
            this.tick_Timer = new System.Windows.Forms.Timer(this.components);
            this.close_Button = new System.Windows.Forms.Button();
            this.timeElapsed_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // theListView
            // 
            this.theListView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.theListView.AllowColumnReorder = true;
            this.theListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.theListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.theListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.theListView.ForeColor = System.Drawing.Color.White;
            this.theListView.FullRowSelect = true;
            this.theListView.HideSelection = false;
            this.theListView.Location = new System.Drawing.Point(0, 0);
            this.theListView.Name = "theListView";
            this.theListView.Size = new System.Drawing.Size(243, 44);
            this.theListView.TabIndex = 9;
            this.theListView.UseCompatibleStateImageBehavior = false;
            this.theListView.View = System.Windows.Forms.View.Details;
            this.theListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.theListView_ColumnClick);
            // 
            // tick_Timer
            // 
            this.tick_Timer.Enabled = true;
            this.tick_Timer.Interval = 50;
            this.tick_Timer.Tick += new EventHandler(this.tick_Timer_Tick);
            // 
            // close_Button
            // 
            this.close_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close_Button.BackColor = System.Drawing.Color.Gray;
            this.close_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.close_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.close_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_Button.ForeColor = System.Drawing.Color.White;
            this.close_Button.Location = new System.Drawing.Point(144, 44);
            this.close_Button.Name = "close_Button";
            this.close_Button.Size = new System.Drawing.Size(99, 24);
            this.close_Button.TabIndex = 11;
            this.close_Button.Text = "Close";
            this.close_Button.UseVisualStyleBackColor = false;
            this.close_Button.Click += new EventHandler(this.close_Button_Click);
            // 
            // timeElapsed_Label
            // 
            this.timeElapsed_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeElapsed_Label.AutoSize = true;
            this.timeElapsed_Label.ForeColor = System.Drawing.Color.White;
            this.timeElapsed_Label.Location = new System.Drawing.Point(3, 49);
            this.timeElapsed_Label.Name = "timeElapsed_Label";
            this.timeElapsed_Label.Size = new System.Drawing.Size(104, 15);
            this.timeElapsed_Label.TabIndex = 10;
            this.timeElapsed_Label.Text = "timeElapsed_Label";
            this.timeElapsed_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HDataViewBase
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.theListView);
            this.Controls.Add(this.close_Button);
            this.Controls.Add(this.timeElapsed_Label);
            this.Name = "HDataViewBase";
            this.Size = new System.Drawing.Size(243, 68);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
//▲ ▼