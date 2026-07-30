using System;
using System.Windows.Forms;
using System.IO;
using DefenderRemover.Logic;

namespace DefenderRemover.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            RefreshStatus();
        }

        private void RefreshStatus()
        {
            bool on = DefenderRegistry.IsRealTimeEnabled();
            lblStatus.Text      = on ? "Windows Defender: ENABLED" : "Windows Defender: DISABLED";
            lblStatus.ForeColor = on ? System.Drawing.Color.OrangeRed : System.Drawing.Color.LimeGreen;
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Create a Restore Point first?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                DefenderService.CreateRestorePoint("Before Windows Defender disable");

            DefenderQuery.DisableTamperProtection();
            DefenderRegistry.DisableViaPolicy();
            DefenderRegistry.DisableRealTime();
            DefenderService.StopAll();
            MessageBox.Show("Windows Defender disabled. Restart recommended.", "Done");
            RefreshStatus();
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            DefenderRegistry.EnableViaPolicy();
            DefenderRegistry.EnableRealTime();
            MessageBox.Show("Windows Defender re-enabled.", "Done");
            RefreshStatus();
        }

        private void btnExportPS_Click(object sender, EventArgs e)
        {
            using var dlg = new SaveFileDialog { FileName = "disable-defender.ps1", Filter = "PowerShell|*.ps1" };
            if (dlg.ShowDialog() == DialogResult.OK) {
                PowerShellExporter.SaveScript(dlg.FileName);
                MessageBox.Show($"Script saved to {dlg.FileName}", "Exported");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => RefreshStatus();
    }
}