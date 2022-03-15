
namespace BazaarChecker.Panels
{
    partial class AuctionList
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.tick_Timer = new System.Windows.Forms.Timer(this.components);
            this.timeElapsed_Label = new System.Windows.Forms.Label();
            this.close_Button = new System.Windows.Forms.Button();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(697, 109);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item";
            this.columnHeader1.Width = 260;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Category";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Rarity";
            this.columnHeader3.Width = 80;
            // 
            // tick_Timer
            // 
            this.tick_Timer.Enabled = true;
            this.tick_Timer.Interval = 50;
            this.tick_Timer.Tick += new System.EventHandler(this.tick_Timer_Tick);
            // 
            // timeElapsed_Label
            // 
            this.timeElapsed_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeElapsed_Label.AutoSize = true;
            this.timeElapsed_Label.ForeColor = System.Drawing.Color.White;
            this.timeElapsed_Label.Location = new System.Drawing.Point(3, 114);
            this.timeElapsed_Label.Name = "timeElapsed_Label";
            this.timeElapsed_Label.Size = new System.Drawing.Size(104, 15);
            this.timeElapsed_Label.TabIndex = 1;
            this.timeElapsed_Label.Text = "timeElapsed_Label";
            this.timeElapsed_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // close_Button
            // 
            this.close_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close_Button.BackColor = System.Drawing.Color.Gray;
            this.close_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.close_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.close_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_Button.ForeColor = System.Drawing.Color.White;
            this.close_Button.Location = new System.Drawing.Point(598, 109);
            this.close_Button.Name = "close_Button";
            this.close_Button.Size = new System.Drawing.Size(99, 24);
            this.close_Button.TabIndex = 8;
            this.close_Button.Text = "Close";
            this.close_Button.UseVisualStyleBackColor = false;
            this.close_Button.Click += new System.EventHandler(this.close_Button_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "BIN?";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "PriceForU©";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 100;
            // 
            // AuctionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.close_Button);
            this.Controls.Add(this.timeElapsed_Label);
            this.Controls.Add(this.listView1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(458, 115);
            this.Name = "AuctionList";
            this.Size = new System.Drawing.Size(697, 133);
            this.GotAdopted += new BazaarChecker.Classes.UserControlButAdoptable.AdoptionHouseEventHandler(this.AuctionList_GotAdopted);
            this.GotOrphaned += new BazaarChecker.Classes.UserControlButAdoptable.AdoptionHouseEventHandler(this.AuctionList_GotOrphaned);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Timer tick_Timer;
        private System.Windows.Forms.Label timeElapsed_Label;
        private System.Windows.Forms.Button close_Button;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
