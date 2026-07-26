namespace ThermalReceiptPrinter.Demo
{
    partial class SamplePosForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.rdoLocal = new System.Windows.Forms.RadioButton();
            this.rdoNetwork = new System.Windows.Forms.RadioButton();
            this.lblPrinterName = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.grpPaper = new System.Windows.Forms.GroupBox();
            this.rdo58mm = new System.Windows.Forms.RadioButton();
            this.rdo80mm = new System.Windows.Forms.RadioButton();
            this.chkAutoCut = new System.Windows.Forms.CheckBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnTestCut = new System.Windows.Forms.Button();
            this.btnTestNetwork = new System.Windows.Forms.Button();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbPrinterName = new System.Windows.Forms.ComboBox();
            this.grpConnection.SuspendLayout();
            this.grpPaper.SuspendLayout();
            this.pnlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(440, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "نظام طباعة الفواتير - نسخة تجريبية";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.cmbPrinterName);
            this.grpConnection.Controls.Add(this.rdoLocal);
            this.grpConnection.Controls.Add(this.rdoNetwork);
            this.grpConnection.Controls.Add(this.lblPrinterName);
            this.grpConnection.Controls.Add(this.lblIp);
            this.grpConnection.Controls.Add(this.txtIp);
            this.grpConnection.Controls.Add(this.lblPort);
            this.grpConnection.Controls.Add(this.txtPort);
            this.grpConnection.Location = new System.Drawing.Point(20, 55);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(440, 148);
            this.grpConnection.TabIndex = 1;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "إعدادات الاتصال بالطابعة";
            // 
            // rdoLocal
            // 
            this.rdoLocal.Location = new System.Drawing.Point(15, 25);
            this.rdoLocal.Name = "rdoLocal";
            this.rdoLocal.Size = new System.Drawing.Size(200, 20);
            this.rdoLocal.TabIndex = 0;
            this.rdoLocal.Text = "طابعة محلية (USB / ويندوز)";
            this.rdoLocal.CheckedChanged += new System.EventHandler(this.ConnectionType_CheckedChanged);
            // 
            // rdoNetwork
            // 
            this.rdoNetwork.Location = new System.Drawing.Point(230, 25);
            this.rdoNetwork.Name = "rdoNetwork";
            this.rdoNetwork.Size = new System.Drawing.Size(200, 20);
            this.rdoNetwork.TabIndex = 1;
            this.rdoNetwork.Text = "طابعة شبكية (IP)";
            this.rdoNetwork.CheckedChanged += new System.EventHandler(this.ConnectionType_CheckedChanged);
            // 
            // lblPrinterName
            // 
            this.lblPrinterName.Location = new System.Drawing.Point(333, 50);
            this.lblPrinterName.Name = "lblPrinterName";
            this.lblPrinterName.Size = new System.Drawing.Size(95, 20);
            this.lblPrinterName.TabIndex = 2;
            this.lblPrinterName.Text = "اسم الطابعة:";
            this.lblPrinterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIp
            // 
            this.lblIp.Location = new System.Drawing.Point(399, 118);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(30, 20);
            this.lblIp.TabIndex = 4;
            this.lblIp.Text = "IP:";
            this.lblIp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(184, 115);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(210, 20);
            this.txtIp.TabIndex = 5;
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(119, 118);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(55, 20);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "المنفذ:";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(19, 115);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(95, 20);
            this.txtPort.TabIndex = 7;
            // 
            // grpPaper
            // 
            this.grpPaper.Controls.Add(this.rdo58mm);
            this.grpPaper.Controls.Add(this.rdo80mm);
            this.grpPaper.Controls.Add(this.chkAutoCut);
            this.grpPaper.Location = new System.Drawing.Point(20, 207);
            this.grpPaper.Name = "grpPaper";
            this.grpPaper.Size = new System.Drawing.Size(440, 65);
            this.grpPaper.TabIndex = 2;
            this.grpPaper.TabStop = false;
            this.grpPaper.Text = "إعدادات الورق";
            // 
            // rdo58mm
            // 
            this.rdo58mm.Location = new System.Drawing.Point(330, 28);
            this.rdo58mm.Name = "rdo58mm";
            this.rdo58mm.Size = new System.Drawing.Size(90, 20);
            this.rdo58mm.TabIndex = 0;
            this.rdo58mm.Text = "58 مم";
            // 
            // rdo80mm
            // 
            this.rdo80mm.Location = new System.Drawing.Point(230, 28);
            this.rdo80mm.Name = "rdo80mm";
            this.rdo80mm.Size = new System.Drawing.Size(90, 20);
            this.rdo80mm.TabIndex = 1;
            this.rdo80mm.Text = "80 مم";
            // 
            // chkAutoCut
            // 
            this.chkAutoCut.Location = new System.Drawing.Point(15, 28);
            this.chkAutoCut.Name = "chkAutoCut";
            this.chkAutoCut.Size = new System.Drawing.Size(210, 20);
            this.chkAutoCut.TabIndex = 2;
            this.chkAutoCut.Text = "قص تلقائي بعد الطباعة";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(250, 278);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(210, 35);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "معاينة الفاتورة";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(20, 278);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(220, 35);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "طباعة فاتورة تجريبية";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // btnTestCut
            // 
            this.btnTestCut.Location = new System.Drawing.Point(250, 317);
            this.btnTestCut.Name = "btnTestCut";
            this.btnTestCut.Size = new System.Drawing.Size(210, 35);
            this.btnTestCut.TabIndex = 5;
            this.btnTestCut.Text = "اختبار القص";
            this.btnTestCut.UseVisualStyleBackColor = true;
            this.btnTestCut.Click += new System.EventHandler(this.BtnTestCut_Click);
            // 
            // btnTestNetwork
            // 
            this.btnTestNetwork.Location = new System.Drawing.Point(20, 317);
            this.btnTestNetwork.Name = "btnTestNetwork";
            this.btnTestNetwork.Size = new System.Drawing.Size(220, 35);
            this.btnTestNetwork.TabIndex = 6;
            this.btnTestNetwork.Text = "اختبار الاتصال بالشبكة";
            this.btnTestNetwork.UseVisualStyleBackColor = true;
            this.btnTestNetwork.Click += new System.EventHandler(this.BtnTestNetwork_Click);
            // 
            // pnlPreview
            // 
            this.pnlPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPreview.AutoScroll = true;
            this.pnlPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPreview.Controls.Add(this.pbPreview);
            this.pnlPreview.Location = new System.Drawing.Point(20, 358);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(440, 287);
            this.pnlPreview.TabIndex = 7;
            // 
            // pbPreview
            // 
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.Location = new System.Drawing.Point(0, 0);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(438, 285);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(20, 655);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(440, 25);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "جاهز.";
            // 
            // cmbPrinterName
            // 
            this.cmbPrinterName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrinterName.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmbPrinterName.Location = new System.Drawing.Point(19, 73);
            this.cmbPrinterName.Name = "cmbPrinterName";
            this.cmbPrinterName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbPrinterName.Size = new System.Drawing.Size(409, 27);
            this.cmbPrinterName.TabIndex = 11;
            // 
            // SamplePosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(480, 695);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpConnection);
            this.Controls.Add(this.grpPaper);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnTestCut);
            this.Controls.Add(this.btnTestNetwork);
            this.Controls.Add(this.pnlPreview);
            this.Controls.Add(this.lblStatus);
            this.Name = "SamplePosForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نظام طباعة الفواتير - تجربة";
            this.Load += new System.EventHandler(this.SamplePosForm_Load);
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.grpPaper.ResumeLayout(false);
            this.pnlPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.RadioButton rdoLocal;
        private System.Windows.Forms.RadioButton rdoNetwork;
        private System.Windows.Forms.Label lblPrinterName;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.GroupBox grpPaper;
        private System.Windows.Forms.RadioButton rdo58mm;
        private System.Windows.Forms.RadioButton rdo80mm;
        private System.Windows.Forms.CheckBox chkAutoCut;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnTestCut;
        private System.Windows.Forms.Button btnTestNetwork;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Label lblStatus;
        internal System.Windows.Forms.ComboBox cmbPrinterName;
    }
}
