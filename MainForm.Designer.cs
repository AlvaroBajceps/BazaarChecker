
namespace BazaarChecker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ah_Timer = new System.Windows.Forms.Timer(this.components);
            this.menu_dataView_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_dataView_ah_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_dataView_bazaar_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_settings_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_settings_openSettings_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menu_refresh_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_refresh_ah_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_refresh_bazaar_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.main_Panel = new System.Windows.Forms.Panel();
            this.bazaar_Timer = new System.Windows.Forms.Timer(this.components);
            this.bazaar_Worker = new System.ComponentModel.BackgroundWorker();
            this.ah_Worker = new System.ComponentModel.BackgroundWorker();
            this.tray_Notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ah_Timer
            // 
            this.ah_Timer.Interval = 1000;
            this.ah_Timer.Tick += new System.EventHandler(this.ah_Timer_Tick);
            // 
            // menu_dataView_MenuItem
            // 
            this.menu_dataView_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_dataView_ah_MenuItem,
            this.menu_dataView_bazaar_MenuItem});
            this.menu_dataView_MenuItem.Name = "menu_dataView_MenuItem";
            this.menu_dataView_MenuItem.Size = new System.Drawing.Size(71, 19);
            this.menu_dataView_MenuItem.Text = "Data View";
            // 
            // menu_dataView_ah_MenuItem
            // 
            this.menu_dataView_ah_MenuItem.Name = "menu_dataView_ah_MenuItem";
            this.menu_dataView_ah_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.menu_dataView_ah_MenuItem.Size = new System.Drawing.Size(193, 22);
            this.menu_dataView_ah_MenuItem.Text = "Auction House";
            this.menu_dataView_ah_MenuItem.Click += new System.EventHandler(this.menu_dataView_ah_MenuItem_Click);
            // 
            // menu_dataView_bazaar_MenuItem
            // 
            this.menu_dataView_bazaar_MenuItem.Name = "menu_dataView_bazaar_MenuItem";
            this.menu_dataView_bazaar_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.menu_dataView_bazaar_MenuItem.Size = new System.Drawing.Size(193, 22);
            this.menu_dataView_bazaar_MenuItem.Text = "Bazaar";
            this.menu_dataView_bazaar_MenuItem.Click += new System.EventHandler(this.menu_dataView_bazaar_MenuItem_Click);
            // 
            // menu_settings_MenuItem
            // 
            this.menu_settings_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_settings_openSettings_MenuItem});
            this.menu_settings_MenuItem.Name = "menu_settings_MenuItem";
            this.menu_settings_MenuItem.ShowShortcutKeys = false;
            this.menu_settings_MenuItem.Size = new System.Drawing.Size(61, 19);
            this.menu_settings_MenuItem.Text = "Settings";
            // 
            // menu_settings_openSettings_MenuItem
            // 
            this.menu_settings_openSettings_MenuItem.Name = "menu_settings_openSettings_MenuItem";
            this.menu_settings_openSettings_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.menu_settings_openSettings_MenuItem.Size = new System.Drawing.Size(211, 22);
            this.menu_settings_openSettings_MenuItem.Text = "Open Settings";
            this.menu_settings_openSettings_MenuItem.Click += new System.EventHandler(this.menu_settings_openSettings_MenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_dataView_MenuItem,
            this.menu_settings_MenuItem,
            this.menu_refresh_MenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(767, 23);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menu_refresh_MenuItem
            // 
            this.menu_refresh_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_refresh_ah_MenuItem,
            this.menu_refresh_bazaar_MenuItem});
            this.menu_refresh_MenuItem.Name = "menu_refresh_MenuItem";
            this.menu_refresh_MenuItem.Size = new System.Drawing.Size(101, 19);
            this.menu_refresh_MenuItem.Text = "Manual Refersh";
            // 
            // menu_refresh_ah_MenuItem
            // 
            this.menu_refresh_ah_MenuItem.Name = "menu_refresh_ah_MenuItem";
            this.menu_refresh_ah_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.menu_refresh_ah_MenuItem.Size = new System.Drawing.Size(189, 22);
            this.menu_refresh_ah_MenuItem.Text = "Auction House";
            this.menu_refresh_ah_MenuItem.Click += new System.EventHandler(this.menu_refresh_ah_MenuItem_Click);
            // 
            // menu_refresh_bazaar_MenuItem
            // 
            this.menu_refresh_bazaar_MenuItem.Name = "menu_refresh_bazaar_MenuItem";
            this.menu_refresh_bazaar_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.menu_refresh_bazaar_MenuItem.Size = new System.Drawing.Size(189, 22);
            this.menu_refresh_bazaar_MenuItem.Text = "Bazaar";
            this.menu_refresh_bazaar_MenuItem.Click += new System.EventHandler(this.menu_refresh_bazaar_MenuItem_Click);
            // 
            // main_Panel
            // 
            this.main_Panel.AutoScroll = true;
            this.main_Panel.BackgroundImage = global::BazaarChecker.Properties.Resources.Bazaar_Checker_BG;
            this.main_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.main_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_Panel.Location = new System.Drawing.Point(0, 23);
            this.main_Panel.MinimumSize = new System.Drawing.Size(100, 100);
            this.main_Panel.Name = "main_Panel";
            this.main_Panel.Size = new System.Drawing.Size(767, 407);
            this.main_Panel.TabIndex = 2;
            // 
            // bazaar_Timer
            // 
            this.bazaar_Timer.Tick += new System.EventHandler(this.bazaar_Timer_Tick);
            // 
            // bazaar_Worker
            // 
            this.bazaar_Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bazaar_Worker_DoWork);
            this.bazaar_Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bazaar_Worker_RunWorkerCompleted);
            // 
            // ah_Worker
            // 
            this.ah_Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ah_Worker_DoWork);
            this.ah_Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ah_Worker_RunWorkerCompleted);
            // 
            // tray_Notify
            // 
            this.tray_Notify.BalloonTipText = "Remember, I\'am down here ;)";
            this.tray_Notify.Icon = ((System.Drawing.Icon)(resources.GetObject("tray_Notify.Icon")));
            this.tray_Notify.Text = "Bazaaar Checker";
            this.tray_Notify.Click += new System.EventHandler(this.tray_Notify_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(767, 430);
            this.Controls.Add(this.main_Panel);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Bazaar Checker";
            this.ResizeBegin += new System.EventHandler(this.MainForm_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem menu_dataView_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_dataView_ah_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_dataView_bazaar_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_settings_MenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Panel main_Panel;
        public System.ComponentModel.BackgroundWorker bazaar_Worker;
        public System.Windows.Forms.Timer ah_Timer;
        public System.Windows.Forms.Timer bazaar_Timer;
        private System.Windows.Forms.NotifyIcon tray_Notify;
        private System.Windows.Forms.ToolStripMenuItem menu_refresh_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_refresh_ah_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_refresh_bazaar_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_settings_openSettings_MenuItem;
        public System.ComponentModel.BackgroundWorker ah_Worker;
    }
}