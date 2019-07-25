namespace BloodStoneGUI {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gameLocationGUI = new System.Windows.Forms.TextBox();
            this.installLocationLabel = new System.Windows.Forms.Label();
            this.buttonSpecifyLocation = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.modDescription = new System.Windows.Forms.TextBox();
            this.backgroundImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).BeginInit();
            this.SuspendLayout();
            // 
            // gameLocationGUI
            // 
            this.gameLocationGUI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameLocationGUI.Location = new System.Drawing.Point(276, 367);
            this.gameLocationGUI.Name = "gameLocationGUI";
            this.gameLocationGUI.ReadOnly = true;
            this.gameLocationGUI.Size = new System.Drawing.Size(442, 26);
            this.gameLocationGUI.TabIndex = 0;
            // 
            // installLocationLabel
            // 
            this.installLocationLabel.AutoSize = true;
            this.installLocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installLocationLabel.Location = new System.Drawing.Point(401, 344);
            this.installLocationLabel.Name = "installLocationLabel";
            this.installLocationLabel.Size = new System.Drawing.Size(317, 20);
            this.installLocationLabel.TabIndex = 1;
            this.installLocationLabel.Text = "Install Location (Location of BizLaunch.exe)";
            // 
            // buttonSpecifyLocation
            // 
            this.buttonSpecifyLocation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSpecifyLocation.Location = new System.Drawing.Point(450, 396);
            this.buttonSpecifyLocation.Name = "buttonSpecifyLocation";
            this.buttonSpecifyLocation.Size = new System.Drawing.Size(187, 23);
            this.buttonSpecifyLocation.TabIndex = 3;
            this.buttonSpecifyLocation.Text = "Specify Location Manually";
            this.buttonSpecifyLocation.UseVisualStyleBackColor = true;
            this.buttonSpecifyLocation.Click += new System.EventHandler(this.ButtonSpecifyLocation_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "BizLaunch.exe";
            this.openFileDialog1.Filter = "Exe files (*.exe)|*.exe";
            this.openFileDialog1.Title = "Please select BizLaunch.exe from the Blood Stone install directory.";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // buttonInstall
            // 
            this.buttonInstall.Enabled = false;
            this.buttonInstall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonInstall.Location = new System.Drawing.Point(643, 396);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(75, 23);
            this.buttonInstall.TabIndex = 5;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.ButtonInstall_Click);
            // 
            // modDescription
            // 
            this.modDescription.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.modDescription.Location = new System.Drawing.Point(12, 12);
            this.modDescription.Multiline = true;
            this.modDescription.Name = "modDescription";
            this.modDescription.ReadOnly = true;
            this.modDescription.Size = new System.Drawing.Size(265, 141);
            this.modDescription.TabIndex = 6;
            this.modDescription.Text = resources.GetString("modDescription.Text");
            this.modDescription.TextChanged += new System.EventHandler(this.ModDescription_TextChanged);
            // 
            // backgroundImage
            // 
            this.backgroundImage.Image = global::BloodStoneGUI.Properties.Resources.BloodStone;
            this.backgroundImage.Location = new System.Drawing.Point(-2, 0);
            this.backgroundImage.Name = "backgroundImage";
            this.backgroundImage.Size = new System.Drawing.Size(769, 437);
            this.backgroundImage.TabIndex = 4;
            this.backgroundImage.TabStop = false;
            this.backgroundImage.Click += new System.EventHandler(this.BackgroundImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 431);
            this.Controls.Add(this.modDescription);
            this.Controls.Add(this.buttonInstall);
            this.Controls.Add(this.buttonSpecifyLocation);
            this.Controls.Add(this.installLocationLabel);
            this.Controls.Add(this.gameLocationGUI);
            this.Controls.Add(this.backgroundImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "007: Blood Stone Stutter Fix";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox gameLocationGUI;
        private System.Windows.Forms.Label installLocationLabel;
        private System.Windows.Forms.Button buttonSpecifyLocation;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox backgroundImage;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.TextBox modDescription;
    }
}

