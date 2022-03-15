
namespace BazaarChecker.Panels
{
    partial class Settings_Panel
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
            this.bazaar_autoRefresh_CheckBox = new System.Windows.Forms.CheckBox();
            this.bazaar_Group = new System.Windows.Forms.GroupBox();
            this.bazaar_interval_Label = new System.Windows.Forms.Label();
            this.bazaar_interval_Numeric = new System.Windows.Forms.NumericUpDown();
            this.ah_Group = new System.Windows.Forms.GroupBox();
            this.ah_interval_Label = new System.Windows.Forms.Label();
            this.ah_interval_Numeric = new System.Windows.Forms.NumericUpDown();
            this.ah_autoRefresh_CheckBox = new System.Windows.Forms.CheckBox();
            this.save_Button = new System.Windows.Forms.Button();
            this.restore_Button = new System.Windows.Forms.Button();
            this.saveStatus_Label = new System.Windows.Forms.Label();
            this.close_Button = new System.Windows.Forms.Button();
            this.load_button = new System.Windows.Forms.Button();
            this.bazaar_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bazaar_interval_Numeric)).BeginInit();
            this.ah_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ah_interval_Numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // bazaar_autoRefresh_CheckBox
            // 
            this.bazaar_autoRefresh_CheckBox.AutoSize = true;
            this.bazaar_autoRefresh_CheckBox.ForeColor = System.Drawing.Color.White;
            this.bazaar_autoRefresh_CheckBox.Location = new System.Drawing.Point(6, 22);
            this.bazaar_autoRefresh_CheckBox.Name = "bazaar_autoRefresh_CheckBox";
            this.bazaar_autoRefresh_CheckBox.Size = new System.Drawing.Size(94, 19);
            this.bazaar_autoRefresh_CheckBox.TabIndex = 0;
            this.bazaar_autoRefresh_CheckBox.Text = "Auto Refresh";
            this.bazaar_autoRefresh_CheckBox.UseVisualStyleBackColor = true;
            // 
            // bazaar_Group
            // 
            this.bazaar_Group.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bazaar_Group.Controls.Add(this.bazaar_interval_Label);
            this.bazaar_Group.Controls.Add(this.bazaar_interval_Numeric);
            this.bazaar_Group.Controls.Add(this.bazaar_autoRefresh_CheckBox);
            this.bazaar_Group.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bazaar_Group.ForeColor = System.Drawing.Color.White;
            this.bazaar_Group.Location = new System.Drawing.Point(20, 12);
            this.bazaar_Group.Name = "bazaar_Group";
            this.bazaar_Group.Size = new System.Drawing.Size(189, 86);
            this.bazaar_Group.TabIndex = 2;
            this.bazaar_Group.TabStop = false;
            this.bazaar_Group.Text = "Bazaar";
            // 
            // bazaar_interval_Label
            // 
            this.bazaar_interval_Label.AutoSize = true;
            this.bazaar_interval_Label.Location = new System.Drawing.Point(6, 49);
            this.bazaar_interval_Label.Name = "bazaar_interval_Label";
            this.bazaar_interval_Label.Size = new System.Drawing.Size(65, 15);
            this.bazaar_interval_Label.TabIndex = 2;
            this.bazaar_interval_Label.Text = "Interval (s):";
            // 
            // bazaar_interval_Numeric
            // 
            this.bazaar_interval_Numeric.BackColor = System.Drawing.Color.DimGray;
            this.bazaar_interval_Numeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bazaar_interval_Numeric.DecimalPlaces = 1;
            this.bazaar_interval_Numeric.ForeColor = System.Drawing.Color.White;
            this.bazaar_interval_Numeric.Location = new System.Drawing.Point(77, 47);
            this.bazaar_interval_Numeric.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.bazaar_interval_Numeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bazaar_interval_Numeric.Name = "bazaar_interval_Numeric";
            this.bazaar_interval_Numeric.Size = new System.Drawing.Size(97, 19);
            this.bazaar_interval_Numeric.TabIndex = 1;
            this.bazaar_interval_Numeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ah_Group
            // 
            this.ah_Group.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ah_Group.Controls.Add(this.ah_interval_Label);
            this.ah_Group.Controls.Add(this.ah_interval_Numeric);
            this.ah_Group.Controls.Add(this.ah_autoRefresh_CheckBox);
            this.ah_Group.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ah_Group.ForeColor = System.Drawing.Color.White;
            this.ah_Group.Location = new System.Drawing.Point(246, 12);
            this.ah_Group.Name = "ah_Group";
            this.ah_Group.Size = new System.Drawing.Size(189, 86);
            this.ah_Group.TabIndex = 3;
            this.ah_Group.TabStop = false;
            this.ah_Group.Text = "Auction House";
            // 
            // ah_interval_Label
            // 
            this.ah_interval_Label.AutoSize = true;
            this.ah_interval_Label.Location = new System.Drawing.Point(6, 49);
            this.ah_interval_Label.Name = "ah_interval_Label";
            this.ah_interval_Label.Size = new System.Drawing.Size(65, 15);
            this.ah_interval_Label.TabIndex = 2;
            this.ah_interval_Label.Text = "Interval (s):";
            // 
            // ah_interval_Numeric
            // 
            this.ah_interval_Numeric.BackColor = System.Drawing.Color.DimGray;
            this.ah_interval_Numeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ah_interval_Numeric.DecimalPlaces = 1;
            this.ah_interval_Numeric.ForeColor = System.Drawing.Color.White;
            this.ah_interval_Numeric.Location = new System.Drawing.Point(77, 47);
            this.ah_interval_Numeric.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.ah_interval_Numeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ah_interval_Numeric.Name = "ah_interval_Numeric";
            this.ah_interval_Numeric.Size = new System.Drawing.Size(97, 19);
            this.ah_interval_Numeric.TabIndex = 1;
            this.ah_interval_Numeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ah_autoRefresh_CheckBox
            // 
            this.ah_autoRefresh_CheckBox.AutoSize = true;
            this.ah_autoRefresh_CheckBox.ForeColor = System.Drawing.Color.White;
            this.ah_autoRefresh_CheckBox.Location = new System.Drawing.Point(6, 22);
            this.ah_autoRefresh_CheckBox.Name = "ah_autoRefresh_CheckBox";
            this.ah_autoRefresh_CheckBox.Size = new System.Drawing.Size(94, 19);
            this.ah_autoRefresh_CheckBox.TabIndex = 0;
            this.ah_autoRefresh_CheckBox.Text = "Auto Refresh";
            this.ah_autoRefresh_CheckBox.UseVisualStyleBackColor = true;
            // 
            // save_Button
            // 
            this.save_Button.BackColor = System.Drawing.Color.Gray;
            this.save_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.save_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.save_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_Button.ForeColor = System.Drawing.Color.White;
            this.save_Button.Location = new System.Drawing.Point(21, 146);
            this.save_Button.Name = "save_Button";
            this.save_Button.Size = new System.Drawing.Size(99, 23);
            this.save_Button.TabIndex = 4;
            this.save_Button.Text = "Save";
            this.save_Button.UseVisualStyleBackColor = false;
            this.save_Button.Click += new System.EventHandler(this.save_Button_Click);
            // 
            // restore_Button
            // 
            this.restore_Button.BackColor = System.Drawing.Color.Gray;
            this.restore_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.restore_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.restore_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restore_Button.ForeColor = System.Drawing.Color.White;
            this.restore_Button.Location = new System.Drawing.Point(231, 146);
            this.restore_Button.Name = "restore_Button";
            this.restore_Button.Size = new System.Drawing.Size(99, 23);
            this.restore_Button.TabIndex = 5;
            this.restore_Button.Text = "Restore Default";
            this.restore_Button.UseVisualStyleBackColor = false;
            this.restore_Button.Click += new System.EventHandler(this.restore_Button_Click);
            // 
            // saveStatus_Label
            // 
            this.saveStatus_Label.AutoSize = true;
            this.saveStatus_Label.ForeColor = System.Drawing.Color.White;
            this.saveStatus_Label.Location = new System.Drawing.Point(20, 117);
            this.saveStatus_Label.Name = "saveStatus_Label";
            this.saveStatus_Label.Size = new System.Drawing.Size(95, 15);
            this.saveStatus_Label.TabIndex = 6;
            this.saveStatus_Label.Text = "saveStatus_Label";
            // 
            // close_Button
            // 
            this.close_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close_Button.BackColor = System.Drawing.Color.Gray;
            this.close_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.close_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.close_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_Button.ForeColor = System.Drawing.Color.White;
            this.close_Button.Location = new System.Drawing.Point(333, 146);
            this.close_Button.MinimumSize = new System.Drawing.Size(99, 36);
            this.close_Button.Name = "close_Button";
            this.close_Button.Size = new System.Drawing.Size(99, 36);
            this.close_Button.TabIndex = 7;
            this.close_Button.Text = "Close Settings";
            this.close_Button.UseVisualStyleBackColor = false;
            this.close_Button.Click += new System.EventHandler(this.close_Button_Click);
            // 
            // load_button
            // 
            this.load_button.BackColor = System.Drawing.Color.Gray;
            this.load_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.load_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.load_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.load_button.ForeColor = System.Drawing.Color.White;
            this.load_button.Location = new System.Drawing.Point(126, 146);
            this.load_button.Name = "load_button";
            this.load_button.Size = new System.Drawing.Size(99, 23);
            this.load_button.TabIndex = 8;
            this.load_button.Text = "Load";
            this.load_button.UseVisualStyleBackColor = false;
            this.load_button.Click += new System.EventHandler(this.load_button_Click);
            // 
            // Settings_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::BazaarChecker.Properties.Resources.Bazaar_Checker_BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.load_button);
            this.Controls.Add(this.close_Button);
            this.Controls.Add(this.saveStatus_Label);
            this.Controls.Add(this.restore_Button);
            this.Controls.Add(this.save_Button);
            this.Controls.Add(this.ah_Group);
            this.Controls.Add(this.bazaar_Group);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(449, 201);
            this.Name = "Settings_Panel";
            this.Size = new System.Drawing.Size(449, 201);
            this.bazaar_Group.ResumeLayout(false);
            this.bazaar_Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bazaar_interval_Numeric)).EndInit();
            this.ah_Group.ResumeLayout(false);
            this.ah_Group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ah_interval_Numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox bazaar_autoRefresh_CheckBox;
        private System.Windows.Forms.GroupBox bazaar_Group;
        private System.Windows.Forms.Label bazaar_interval_Label;
        private System.Windows.Forms.NumericUpDown bazaar_interval_Numeric;
        private System.Windows.Forms.GroupBox ah_Group;
        private System.Windows.Forms.Label ah_interval_Label;
        private System.Windows.Forms.NumericUpDown ah_interval_Numeric;
        private System.Windows.Forms.CheckBox ah_autoRefresh_CheckBox;
        private System.Windows.Forms.Button save_Button;
        private System.Windows.Forms.Button restore_Button;
        private System.Windows.Forms.Label saveStatus_Label;
        private System.Windows.Forms.Button close_Button;
        private System.Windows.Forms.Button load_button;
    }
}
