namespace OBS_Now_Playing
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.previewBox = new System.Windows.Forms.TextBox();
            this.previewLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.saveLocation = new System.Windows.Forms.TextBox();
            this.selectLocation = new System.Windows.Forms.Button();
            this.mediaPlayerBox = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.settingsLocation = new System.Windows.Forms.Button();
            this.defaultSaveLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.defaultMediaBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(340, 247);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.previewBox);
            this.tabPage1.Controls.Add(this.previewLabel);
            this.tabPage1.Controls.Add(this.startButton);
            this.tabPage1.Controls.Add(this.saveLocation);
            this.tabPage1.Controls.Add(this.selectLocation);
            this.tabPage1.Controls.Add(this.mediaPlayerBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(332, 221);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Players";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // previewBox
            // 
            this.previewBox.Location = new System.Drawing.Point(11, 115);
            this.previewBox.Name = "previewBox";
            this.previewBox.ReadOnly = true;
            this.previewBox.Size = new System.Drawing.Size(313, 20);
            this.previewBox.TabIndex = 5;
            // 
            // previewLabel
            // 
            this.previewLabel.AutoSize = true;
            this.previewLabel.Location = new System.Drawing.Point(8, 98);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(69, 13);
            this.previewLabel.TabIndex = 4;
            this.previewLabel.Text = "Now Playing:";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(128, 138);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(76, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // saveLocation
            // 
            this.saveLocation.Location = new System.Drawing.Point(8, 59);
            this.saveLocation.Name = "saveLocation";
            this.saveLocation.ReadOnly = true;
            this.saveLocation.Size = new System.Drawing.Size(253, 20);
            this.saveLocation.TabIndex = 2;
            this.saveLocation.WordWrap = false;
            // 
            // selectLocation
            // 
            this.selectLocation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.selectLocation.Location = new System.Drawing.Point(267, 59);
            this.selectLocation.Name = "selectLocation";
            this.selectLocation.Size = new System.Drawing.Size(57, 20);
            this.selectLocation.TabIndex = 1;
            this.selectLocation.Text = "Browse";
            this.selectLocation.UseVisualStyleBackColor = true;
            this.selectLocation.Click += new System.EventHandler(this.selectLocation_Click);
            // 
            // mediaPlayerBox
            // 
            this.mediaPlayerBox.FormattingEnabled = true;
            this.mediaPlayerBox.Items.AddRange(new object[] {
            "iTunes",
            "MPC-HC",
            "Pandora",
            "Soundcloud",
            "Spotify",
            "Spotify (web)",
            "VLC",
            "WinAmp",
            "YouTube"});
            this.mediaPlayerBox.Location = new System.Drawing.Point(8, 15);
            this.mediaPlayerBox.Name = "mediaPlayerBox";
            this.mediaPlayerBox.Size = new System.Drawing.Size(121, 21);
            this.mediaPlayerBox.Sorted = true;
            this.mediaPlayerBox.TabIndex = 0;
            this.mediaPlayerBox.Text = "Media Player";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.settingsLocation);
            this.tabPage2.Controls.Add(this.defaultSaveLocation);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.defaultMediaBox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(332, 221);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // settingsLocation
            // 
            this.settingsLocation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.settingsLocation.Location = new System.Drawing.Point(267, 83);
            this.settingsLocation.Name = "settingsLocation";
            this.settingsLocation.Size = new System.Drawing.Size(57, 20);
            this.settingsLocation.TabIndex = 5;
            this.settingsLocation.Text = "Browse";
            this.settingsLocation.UseVisualStyleBackColor = true;
            this.settingsLocation.Click += new System.EventHandler(this.settingsLocation_Click);
            // 
            // defaultSaveLocation
            // 
            this.defaultSaveLocation.Location = new System.Drawing.Point(8, 83);
            this.defaultSaveLocation.Name = "defaultSaveLocation";
            this.defaultSaveLocation.Size = new System.Drawing.Size(253, 20);
            this.defaultSaveLocation.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Default Save Location:";
            // 
            // defaultMediaBox
            // 
            this.defaultMediaBox.FormattingEnabled = true;
            this.defaultMediaBox.Items.AddRange(new object[] {
            "iTunes",
            "MPC-HC",
            "Pandora",
            "Soundcloud",
            "Spotify",
            "Spotify (web)",
            "VLC",
            "WinAmp",
            "YouTube"});
            this.defaultMediaBox.Location = new System.Drawing.Point(8, 29);
            this.defaultMediaBox.Name = "defaultMediaBox";
            this.defaultMediaBox.Size = new System.Drawing.Size(121, 21);
            this.defaultMediaBox.Sorted = true;
            this.defaultMediaBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Default Media Player:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(340, 247);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(356, 286);
            this.MinimumSize = new System.Drawing.Size(356, 286);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Music Overlay";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox mediaPlayerBox;
        private System.Windows.Forms.Button selectLocation;
        private System.Windows.Forms.TextBox saveLocation;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox defaultSaveLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox defaultMediaBox;
        private System.Windows.Forms.Button settingsLocation;
        private System.Windows.Forms.TextBox previewBox;
        private System.Windows.Forms.Label previewLabel;
    }
}

