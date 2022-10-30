namespace AutoSaver
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.enabled = new System.Windows.Forms.CheckBox();
            this.dosave = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.schoice = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.makesounds = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.AvailableProcesses = new System.Windows.Forms.ListView();
            this.ProcName = new System.Windows.Forms.ColumnHeader();
            this.RefreshList = new System.Windows.Forms.Timer(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.TimeTicker = new System.Windows.Forms.Timer(this.components);
            this.CancelSave = new System.Windows.Forms.Label();
            this.ToggleSave = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.DrawIcon = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SelectedProcesses = new System.Windows.Forms.ListView();
            this.ProcName1 = new System.Windows.Forms.ColumnHeader();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.schoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(38, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "AutoSaver";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(142, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "v1.1";
            // 
            // enabled
            // 
            this.enabled.AutoSize = true;
            this.enabled.Location = new System.Drawing.Point(14, 44);
            this.enabled.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.enabled.Name = "enabled";
            this.enabled.Size = new System.Drawing.Size(68, 19);
            this.enabled.TabIndex = 2;
            this.enabled.Text = "Enabled";
            this.enabled.UseVisualStyleBackColor = true;
            this.enabled.CheckedChanged += new System.EventHandler(this.Enabled_CheckedChanged);
            // 
            // dosave
            // 
            this.dosave.AutoSize = true;
            this.dosave.Checked = true;
            this.dosave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dosave.Location = new System.Drawing.Point(14, 110);
            this.dosave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dosave.Name = "dosave";
            this.dosave.Size = new System.Drawing.Size(210, 19);
            this.dosave.TabIndex = 3;
            this.dosave.Text = "Press CTRL + S for me when saving";
            this.dosave.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(12, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "/\\ If disabled, i\'ll only remind you to save!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Seconds between saves:";
            // 
            // schoice
            // 
            this.schoice.Location = new System.Drawing.Point(152, 85);
            this.schoice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.schoice.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.schoice.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.schoice.Name = "schoice";
            this.schoice.Size = new System.Drawing.Size(90, 23);
            this.schoice.TabIndex = 8;
            this.schoice.ThousandsSeparator = true;
            this.schoice.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 213);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Time until next save:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(133, 215);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "00:00:00";
            // 
            // makesounds
            // 
            this.makesounds.AutoSize = true;
            this.makesounds.Checked = true;
            this.makesounds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.makesounds.Location = new System.Drawing.Point(14, 66);
            this.makesounds.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.makesounds.Name = "makesounds";
            this.makesounds.Size = new System.Drawing.Size(96, 19);
            this.makesounds.TabIndex = 11;
            this.makesounds.Text = "Make sounds";
            this.makesounds.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 173);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Cancel save (reset time):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(10, 151);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Hotkeys:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(279, 3);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(239, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Select programs to autosave on";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(270, 21);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(258, 39);
            this.label10.TabIndex = 16;
            this.label10.Text = "While one of these program is in focus, the autosave \r\ntimer will tick!  Otherwis" +
    "e, it\'ll pause. Click programs\r\non one side to move them to the other!";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AvailableProcesses
            // 
            this.AvailableProcesses.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.AvailableProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProcName});
            this.AvailableProcesses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.AvailableProcesses.Location = new System.Drawing.Point(250, 76);
            this.AvailableProcesses.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AvailableProcesses.MultiSelect = false;
            this.AvailableProcesses.Name = "AvailableProcesses";
            this.AvailableProcesses.Size = new System.Drawing.Size(143, 153);
            this.AvailableProcesses.TabIndex = 17;
            this.AvailableProcesses.UseCompatibleStateImageBehavior = false;
            this.AvailableProcesses.View = System.Windows.Forms.View.Details;
            this.AvailableProcesses.Click += new System.EventHandler(this.AvailableProcesses_Click);
            // 
            // ProcName
            // 
            this.ProcName.Width = 250;
            // 
            // RefreshList
            // 
            this.RefreshList.Enabled = true;
            this.RefreshList.Interval = 2000;
            this.RefreshList.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 193);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 15);
            this.label11.TabIndex = 19;
            this.label11.Text = "Toggle autosave:";
            // 
            // TimeTicker
            // 
            this.TimeTicker.Interval = 1000;
            this.TimeTicker.Tick += new System.EventHandler(this.ticker_Tick);
            // 
            // CancelSave
            // 
            this.CancelSave.AutoSize = true;
            this.CancelSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CancelSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CancelSave.Location = new System.Drawing.Point(144, 173);
            this.CancelSave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CancelSave.Name = "CancelSave";
            this.CancelSave.Size = new System.Drawing.Size(102, 15);
            this.CancelSave.TabIndex = 20;
            this.CancelSave.Text = "CTRL + ALT + C";
            // 
            // ToggleSave
            // 
            this.ToggleSave.AutoSize = true;
            this.ToggleSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ToggleSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ToggleSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ToggleSave.Location = new System.Drawing.Point(144, 192);
            this.ToggleSave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ToggleSave.Name = "ToggleSave";
            this.ToggleSave.Size = new System.Drawing.Size(102, 15);
            this.ToggleSave.TabIndex = 21;
            this.ToggleSave.Text = "CTRL + ALT + S";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(448, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 15);
            this.label14.TabIndex = 23;
            this.label14.Text = "Selected";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(292, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 15);
            this.label15.TabIndex = 24;
            this.label15.Text = "Available";
            // 
            // DrawIcon
            // 
            this.DrawIcon.Image = global::AutoSaver.ASResources.saveicon1;
            this.DrawIcon.Location = new System.Drawing.Point(11, 11);
            this.DrawIcon.Name = "DrawIcon";
            this.DrawIcon.Size = new System.Drawing.Size(24, 24);
            this.DrawIcon.TabIndex = 26;
            this.DrawIcon.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label12.Location = new System.Drawing.Point(41, 25);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(166, 12);
            this.label12.TabIndex = 27;
            this.label12.Text = "by andreweathan, idea by Cioss";
            // 
            // SelectedProcesses
            // 
            this.SelectedProcesses.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.SelectedProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProcName1});
            this.SelectedProcesses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.SelectedProcesses.Location = new System.Drawing.Point(401, 76);
            this.SelectedProcesses.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SelectedProcesses.MultiSelect = false;
            this.SelectedProcesses.Name = "SelectedProcesses";
            this.SelectedProcesses.Size = new System.Drawing.Size(143, 153);
            this.SelectedProcesses.TabIndex = 28;
            this.SelectedProcesses.UseCompatibleStateImageBehavior = false;
            this.SelectedProcesses.View = System.Windows.Forms.View.Details;
            this.SelectedProcesses.Click += new System.EventHandler(this.SelectedProcesses_Click);
            // 
            // ProcName1
            // 
            this.ProcName1.Width = 250;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Enabled = false;
            this.label16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label16.Location = new System.Drawing.Point(143, 152);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 15);
            this.label16.TabIndex = 25;
            this.label16.Text = "(Click to change...)";
            this.label16.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 236);
            this.Controls.Add(this.SelectedProcesses);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.DrawIcon);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ToggleSave);
            this.Controls.Add(this.CancelSave);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.AvailableProcesses);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.makesounds);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.schoice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dosave);
            this.Controls.Add(this.enabled);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoSaver";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainform_FormClosed);
            this.Load += new System.EventHandler(this.mainform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrawIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox enabled;
        private System.Windows.Forms.CheckBox dosave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown schoice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox makesounds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView AvailableProcesses;
        private System.Windows.Forms.Timer RefreshList;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer TimeTicker;
        private System.Windows.Forms.Label CancelSave;
        private System.Windows.Forms.Label ToggleSave;
        private Label label14;
        private Label label15;
        private PictureBox DrawIcon;
        private ColumnHeader ProcName;
        private Label label12;
        private ListView SelectedProcesses;
        private ColumnHeader ProcName1;
        private Label label16;
    }
}