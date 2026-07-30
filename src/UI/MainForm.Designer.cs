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
            this.btnDisable  = new Button();
            this.btnEnable   = new Button();
            this.btnRefresh  = new Button();
            this.lblRealtime = new Label();
            this.lblTamper   = new Label();
            this.lblUpdate   = new Label();
            this.SuspendLayout();

            this.lblRealtime.Location = new System.Drawing.Point(16, 16);
            this.lblRealtime.Size     = new System.Drawing.Size(280, 22);
            this.lblTamper.Location    = new System.Drawing.Point(16, 44);
            this.lblTamper.Size        = new System.Drawing.Size(280, 22);
            this.lblUpdate.Location    = new System.Drawing.Point(16, 72);
            this.lblUpdate.Size        = new System.Drawing.Size(280, 22);

            this.btnDisable.Text      = "Disable Defender";
            this.btnDisable.Location  = new System.Drawing.Point(16, 110);
            this.btnDisable.Size       = new System.Drawing.Size(150, 36);
            this.btnDisable.Click     += new EventHandler(this.btnDisable_Click);

            this.btnEnable.Text       = "Enable Defender";
            this.btnEnable.Location   = new System.Drawing.Point(180, 110);
            this.btnEnable.Size       = new System.Drawing.Size(120, 36);
            this.btnEnable.Click      += new EventHandler(this.btnEnable_Click);

            this.btnRefresh.Text      = "Refresh";
            this.btnRefresh.Location   = new System.Drawing.Point(314, 110);
            this.btnRefresh.Size       = new System.Drawing.Size(80, 36);
            this.btnRefresh.Click      += new EventHandler(this.btnRefresh_Click);

            this.Controls.AddRange(new Control[] {
                this.lblRealtime, this.lblTamper, this.lblUpdate,
                this.btnDisable, this.btnEnable, this.btnRefresh,
            });

            this.Text         = "Windows Defender Disabler v14";
            this.ClientSize   = new System.Drawing.Size(406, 160);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private Label  lblRealtime;
        private Label  lblTamper;
        private Label  lblUpdate;
        private Button btnDisable;
        private Button btnEnable;
        private Button btnRefresh;
    }
}