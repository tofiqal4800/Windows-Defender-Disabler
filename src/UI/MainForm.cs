using System;
using System.Windows.Forms;

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
            bool realtimeOn = DefenderRegistry.IsRealTimeEnabled();
            lblRealtime.Text  = realtimeOn ? "Real-Time: ON" : "Real-Time: OFF";
            lblRealtime.ForeColor = realtimeOn ? System.Drawing.Color.LimeGreen : System.Drawing.Color.OrangeRed;
            lblTamper.Text     = "Tamper Protection: see Windows Security";
            string update = "";
            try { update = DefenderQuery.GetLastUpdateTime(); } catch { }
            lblUpdate.Text    = $"Last update: {update}";
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Create a System Restore Point first?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes) DefenderService.CreateRestorePoint("Before Defender disable");

            DefenderService.DisableTamperProtection();
            DefenderRegistry.DisableRealTimeProtection();
            DefenderRegistry.DisableViaPolicy();
            DefenderService.StopAll();
            MessageBox.Show("Windows Defender disabled. Restart recommended.", "Done", MessageBoxButtons.OK);
            RefreshStatus();
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            DefenderRegistry.EnableRealTimeProtection();
            DefenderRegistry.EnableViaPolicy();
            MessageBox.Show("Windows Defender re-enabled.", "Done", MessageBoxButtons.OK);
            RefreshStatus();
        }

        private void btnRefresh_Click(object sender, EventArgs e) => RefreshStatus();
    }
}