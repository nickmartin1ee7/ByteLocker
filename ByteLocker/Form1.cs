using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace ByteLocker
{
    public partial class Form1 : Form
    {
        bool[] task = new bool[2];
        string key = "";

        #region Form ctor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region FileDialog Functions
        private void fileDialogOpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            string defaultValue = "Folder";
            fileDialog.Title = "Open File/Folder";
            fileDialog.RestoreDirectory = true;
            fileDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            fileDialog.CheckFileExists = false;
            fileDialog.FileName = defaultValue;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileName.Contains(defaultValue))
                    fileDialog.FileName = fileDialog.FileName.Replace(defaultValue, "");
                selectedFileTextBox.Text = fileDialog.FileName;
            }

        }
        #endregion

        #region Button Functions
        private void encryptButton_Click(object sender, EventArgs e)
        {
            ResetProgressBar();
            task[0] = true;
            backgroundWorker.RunWorkerAsync();
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Yes;
            if (keyTextBox.TextLength == 0)
                result = MessageBox.Show("Warning! Your key length is 0. This will only decode a file's contents from Base64", "ByteLocker - Key Length Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                ResetProgressBar();
                task[1] = true;
                backgroundWorker.RunWorkerAsync();
            }
            else
                Display("Decryption cancelled!");
        }
        #endregion

        #region Background Worker Functions
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (backgroundWorker.CancellationPending)
                e.Cancel = true;
            else
            {
                if (task[0])
                {
                    bool f = BusinessLogic.Encrypt(selectedFileTextBox.Text, key);
                    if (f)
                        backgroundWorker.ReportProgress(100);
                    else
                        e.Cancel = true;
                }
                else if (task[1])
                {
                    bool f = BusinessLogic.Decrypt(selectedFileTextBox.Text, key);
                    if (f)
                        backgroundWorker.ReportProgress(100);
                    else
                        e.Cancel = true;
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                if (task[0])
                {
                    task[0] = false;
                    Display("Encryption failed!");
                }
                else if (task[1])
                {
                    task[1] = false;
                    Display("Decryption failed!");
                }
            }
            else
            {
                if (task[0])
                {
                    task[0] = false;
                    Display("Encryption completed!");
                }
                else if (task[1])
                {
                    task[1] = false;
                    Display("Decryption completed!");
                }
            }
        }
        #endregion
        private void ResetProgressBar() => progressBar.Value = 0;

        private void Display(string text)
        {
            MessageBox.Show(text, "ByteLocker");
        }
        private void Display(string text, string title)
        {
            MessageBox.Show(text, title);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

        private void Form1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Display("Author: Nick Martin\n\nEncryption: XOR\nEncoding: Base64\nUpcoming Encryption: AES", "ByteLocker - About");
        }

        private void keyDialogOpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = NewFileDialog("key.txt", "Open Key File");
            if (fileDialog.ShowDialog() == DialogResult.OK)
                keyTextBox.Text = Path.GetFullPath(fileDialog.FileName);
        }

        private static OpenFileDialog NewFileDialog(string defaultValue, string title)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Title = title,
                RestoreDirectory = true,
                InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString(),
                CheckFileExists = true,
                FileName = defaultValue
            };
            return fileDialog;
        }

        private void keyTextBox_TextChanged(object sender, EventArgs e)
        {
            KeyChange();
        }

        private void KeyChange()
        {
            if (File.Exists(keyTextBox.Text))
                key = File.ReadAllText(keyTextBox.Text);
            else
                key = keyTextBox.Text;
        }
    }
}
