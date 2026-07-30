namespace DefenderRemover.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblStatus    = new System.Windows.Forms.Label();
            this.btnDisable   = new System.Windows.Forms.Button();
            this.btnEnable    = new System.Windows.Forms.Button();
            this.btnExportPS  = new System.Windows.Forms.Button();
            this.btnRefresh   = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblStatus.Location  = new System.Drawing.Point(12, 20);
            this.lblStatus.Size      = new System.Drawing.Size(440, 28);
            this.lblStatus.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            this.btnDisable.Text     = "Disable Defender";
            this.btnDisable.Location = new System.Drawing.Point(12, 64);
            this.btnDisable.Size     = new System.Drawing.Size(150, 36);
            this.btnDisable.Click   += new System.EventHandler(this.btnDisable_Click);

            this.btnEnable.Text      = "Enable Defender";
            this.btnEnable.Location  = new System.Drawing.Point(176, 64);
            this.btnEnable.Size      = new System.Drawing.Size(130, 36);
            this.btnEnable.Click    += new System.EventHandler(this.btnEnable_Click);

            this.btnExportPS.Text    = "Export PowerShell";
            this.btnExportPS.Location= new System.Drawing.Point(12, 114);
            this.btnExportPS.Size    = new System.Drawing.Size(150, 36);
            this.btnExportPS.Click  += new System.EventHandler(this.btnExportPS_Click);

            this.btnRefresh.Text     = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(176, 114);
            this.btnRefresh.Size     = new System.Drawing.Size(90, 36);
            this.btnRefresh.Click   += new System.EventHandler(this.btnRefresh_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblStatus, this.btnDisable, this.btnEnable, this.btnExportPS, this.btnRefresh });

            this.Text         = "Windows Defender Disabler v14";
            this.ClientSize   = new System.Drawing.Size(470, 168);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label  lblStatus;
        private System.Windows.Forms.Button btnDisable, btnEnable, btnExportPS, btnRefresh;
    }
}