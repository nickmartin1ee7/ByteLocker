namespace ByteLocker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.fileDialogOpenButton = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.selectedFileTextBox = new System.Windows.Forms.TextBox();
            this.encryptButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.keyLabel = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.keyDialogOpenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileDialogOpenButton
            // 
            this.fileDialogOpenButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.fileDialogOpenButton.Location = new System.Drawing.Point(447, 224);
            this.fileDialogOpenButton.Name = "fileDialogOpenButton";
            this.fileDialogOpenButton.Size = new System.Drawing.Size(28, 21);
            this.fileDialogOpenButton.TabIndex = 1;
            this.fileDialogOpenButton.Text = "...";
            this.fileDialogOpenButton.UseVisualStyleBackColor = true;
            this.fileDialogOpenButton.Click += new System.EventHandler(this.fileDialogOpenButton_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.fileLabel.AutoSize = true;
            this.fileLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileLabel.Location = new System.Drawing.Point(12, 228);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(43, 15);
            this.fileLabel.TabIndex = 97;
            this.fileLabel.Text = "Target:";
            // 
            // selectedFileTextBox
            // 
            this.selectedFileTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.selectedFileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectedFileTextBox.Location = new System.Drawing.Point(61, 225);
            this.selectedFileTextBox.Name = "selectedFileTextBox";
            this.selectedFileTextBox.Size = new System.Drawing.Size(380, 20);
            this.selectedFileTextBox.TabIndex = 99;
            this.selectedFileTextBox.WordWrap = false;
            // 
            // encryptButton
            // 
            this.encryptButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.encryptButton.Location = new System.Drawing.Point(380, 9);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(95, 23);
            this.encryptButton.TabIndex = 2;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.decryptButton.Location = new System.Drawing.Point(380, 38);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(95, 23);
            this.decryptButton.TabIndex = 3;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // keyTextBox
            // 
            this.keyTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.keyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyTextBox.Location = new System.Drawing.Point(48, 12);
            this.keyTextBox.MaxLength = 2097152;
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(292, 20);
            this.keyTextBox.TabIndex = 0;
            this.keyTextBox.UseSystemPasswordChar = true;
            this.keyTextBox.WordWrap = false;
            // 
            // keyLabel
            // 
            this.keyLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.keyLabel.AutoSize = true;
            this.keyLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyLabel.Location = new System.Drawing.Point(12, 14);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(30, 15);
            this.keyLabel.TabIndex = 98;
            this.keyLabel.Text = "Key:";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 251);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(495, 18);
            this.progressBar.TabIndex = 9;
            // 
            // keyDialogOpenButton
            // 
            this.keyDialogOpenButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.keyDialogOpenButton.Location = new System.Drawing.Point(346, 10);
            this.keyDialogOpenButton.Name = "keyDialogOpenButton";
            this.keyDialogOpenButton.Size = new System.Drawing.Size(28, 21);
            this.keyDialogOpenButton.TabIndex = 100;
            this.keyDialogOpenButton.Text = "...";
            this.keyDialogOpenButton.UseVisualStyleBackColor = true;
            this.keyDialogOpenButton.Click += new System.EventHandler(this.keyDialogOpenButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ByteLocker.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(495, 269);
            this.Controls.Add(this.keyDialogOpenButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.fileDialogOpenButton);
            this.Controls.Add(this.selectedFileTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ByteLocker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Form1_HelpRequested);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fileDialogOpenButton;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.TextBox selectedFileTextBox;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.Label keyLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button keyDialogOpenButton;
    }
}

