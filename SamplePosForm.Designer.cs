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
            this.cmbPrinterName = new System.Windows.Forms.ComboBox();
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
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmboBxTitle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numBxTite = new System.Windows.Forms.NumericUpDown();
            this.numBxArName = new System.Windows.Forms.NumericUpDown();
            this.cmboBxArName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numBxEnName = new System.Windows.Forms.NumericUpDown();
            this.cmboBxEnName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numBxNumber = new System.Windows.Forms.NumericUpDown();
            this.cmboBxNumber = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numBxGeneral = new System.Windows.Forms.NumericUpDown();
            this.cmboBxGeneral = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpConnection.SuspendLayout();
            this.grpPaper.SuspendLayout();
            this.pnlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBxTite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBxArName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBxEnName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBxNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBxGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(376, 30);
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
            this.grpConnection.Size = new System.Drawing.Size(376, 148);
            this.grpConnection.TabIndex = 1;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "إعدادات الاتصال بالطابعة";
            // 
            // cmbPrinterName
            // 
            this.cmbPrinterName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrinterName.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmbPrinterName.Location = new System.Drawing.Point(56, 77);
            this.cmbPrinterName.Name = "cmbPrinterName";
            this.cmbPrinterName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbPrinterName.Size = new System.Drawing.Size(309, 27);
            this.cmbPrinterName.TabIndex = 11;
            // 
            // rdoLocal
            // 
            this.rdoLocal.Location = new System.Drawing.Point(32, 29);
            this.rdoLocal.Name = "rdoLocal";
            this.rdoLocal.Size = new System.Drawing.Size(200, 20);
            this.rdoLocal.TabIndex = 0;
            this.rdoLocal.Text = "طابعة محلية (USB / ويندوز)";
            this.rdoLocal.CheckedChanged += new System.EventHandler(this.ConnectionType_CheckedChanged);
            // 
            // rdoNetwork
            // 
            this.rdoNetwork.Location = new System.Drawing.Point(167, 29);
            this.rdoNetwork.Name = "rdoNetwork";
            this.rdoNetwork.Size = new System.Drawing.Size(200, 20);
            this.rdoNetwork.TabIndex = 1;
            this.rdoNetwork.Text = "طابعة شبكية (IP)";
            this.rdoNetwork.CheckedChanged += new System.EventHandler(this.ConnectionType_CheckedChanged);
            // 
            // lblPrinterName
            // 
            this.lblPrinterName.Location = new System.Drawing.Point(270, 54);
            this.lblPrinterName.Name = "lblPrinterName";
            this.lblPrinterName.Size = new System.Drawing.Size(95, 20);
            this.lblPrinterName.TabIndex = 2;
            this.lblPrinterName.Text = "اسم الطابعة:";
            this.lblPrinterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIp
            // 
            this.lblIp.Location = new System.Drawing.Point(340, 118);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(30, 20);
            this.lblIp.TabIndex = 4;
            this.lblIp.Text = "IP:";
            this.lblIp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(167, 119);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(164, 20);
            this.txtIp.TabIndex = 5;
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(106, 119);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(55, 20);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "المنفذ:";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(6, 116);
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
            this.grpPaper.Size = new System.Drawing.Size(376, 54);
            this.grpPaper.TabIndex = 2;
            this.grpPaper.TabStop = false;
            this.grpPaper.Text = "إعدادات الورق";
            // 
            // rdo58mm
            // 
            this.rdo58mm.Location = new System.Drawing.Point(277, 23);
            this.rdo58mm.Name = "rdo58mm";
            this.rdo58mm.Size = new System.Drawing.Size(90, 20);
            this.rdo58mm.TabIndex = 0;
            this.rdo58mm.Text = "58 مم";
            // 
            // rdo80mm
            // 
            this.rdo80mm.Location = new System.Drawing.Point(181, 23);
            this.rdo80mm.Name = "rdo80mm";
            this.rdo80mm.Size = new System.Drawing.Size(90, 20);
            this.rdo80mm.TabIndex = 1;
            this.rdo80mm.Text = "80 مم";
            // 
            // chkAutoCut
            // 
            this.chkAutoCut.Location = new System.Drawing.Point(13, 23);
            this.chkAutoCut.Name = "chkAutoCut";
            this.chkAutoCut.Size = new System.Drawing.Size(145, 20);
            this.chkAutoCut.TabIndex = 2;
            this.chkAutoCut.Text = "قص تلقائي بعد الطباعة";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(219, 278);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(177, 35);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "معاينة الفاتورة";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(20, 278);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(193, 35);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "طباعة فاتورة تجريبية";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // btnTestCut
            // 
            this.btnTestCut.Location = new System.Drawing.Point(219, 317);
            this.btnTestCut.Name = "btnTestCut";
            this.btnTestCut.Size = new System.Drawing.Size(177, 35);
            this.btnTestCut.TabIndex = 5;
            this.btnTestCut.Text = "اختبار القص";
            this.btnTestCut.UseVisualStyleBackColor = true;
            this.btnTestCut.Click += new System.EventHandler(this.BtnTestCut_Click);
            // 
            // btnTestNetwork
            // 
            this.btnTestNetwork.Location = new System.Drawing.Point(20, 317);
            this.btnTestNetwork.Name = "btnTestNetwork";
            this.btnTestNetwork.Size = new System.Drawing.Size(193, 35);
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
            this.pnlPreview.Location = new System.Drawing.Point(402, 12);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(522, 633);
            this.pnlPreview.TabIndex = 7;
            // 
            // pbPreview
            // 
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPreview.Location = new System.Drawing.Point(0, 0);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(520, 631);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(416, 655);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(372, 25);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "جاهز.";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveImage.Location = new System.Drawing.Point(794, 651);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(130, 29);
            this.btnSaveImage.TabIndex = 9;
            this.btnSaveImage.Text = "حفظ الصورة";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numBxGeneral);
            this.groupBox1.Controls.Add(this.cmboBxGeneral);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numBxNumber);
            this.groupBox1.Controls.Add(this.cmboBxNumber);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numBxEnName);
            this.groupBox1.Controls.Add(this.cmboBxEnName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numBxArName);
            this.groupBox1.Controls.Add(this.cmboBxArName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numBxTite);
            this.groupBox1.Controls.Add(this.cmboBxTitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(20, 358);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 304);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "إعدادات الخطوط";
            // 
            // cmboBxTitle
            // 
            this.cmboBxTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmboBxTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmboBxTitle.Items.AddRange(new object[] {
            "Time New Roman",
            "Consolas",
            "Segoe UI",
            "Tahoma",
            "Simplified Arabic"});
            this.cmboBxTitle.Location = new System.Drawing.Point(71, 44);
            this.cmboBxTitle.Name = "cmboBxTitle";
            this.cmboBxTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmboBxTitle.Size = new System.Drawing.Size(206, 27);
            this.cmboBxTitle.TabIndex = 11;
            this.cmboBxTitle.Text = "Time New Roman";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(182, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "اسم الشركة";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numBxTite
            // 
            this.numBxTite.DecimalPlaces = 1;
            this.numBxTite.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numBxTite.Location = new System.Drawing.Point(8, 44);
            this.numBxTite.Name = "numBxTite";
            this.numBxTite.Size = new System.Drawing.Size(57, 27);
            this.numBxTite.TabIndex = 13;
            this.numBxTite.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numBxTite.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // numBxArName
            // 
            this.numBxArName.DecimalPlaces = 1;
            this.numBxArName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numBxArName.Location = new System.Drawing.Point(8, 101);
            this.numBxArName.Name = "numBxArName";
            this.numBxArName.Size = new System.Drawing.Size(57, 27);
            this.numBxArName.TabIndex = 16;
            this.numBxArName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numBxArName.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // cmboBxArName
            // 
            this.cmboBxArName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmboBxArName.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmboBxArName.Items.AddRange(new object[] {
            "Time New Roman",
            "Consolas",
            "Segoe UI",
            "Tahoma",
            "Simplified Arabic"});
            this.cmboBxArName.Location = new System.Drawing.Point(71, 101);
            this.cmboBxArName.Name = "cmboBxArName";
            this.cmboBxArName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmboBxArName.Size = new System.Drawing.Size(206, 27);
            this.cmboBxArName.TabIndex = 15;
            this.cmboBxArName.Text = "Time New Roman";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(146, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "اسم المنتج عربي";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numBxEnName
            // 
            this.numBxEnName.DecimalPlaces = 1;
            this.numBxEnName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numBxEnName.Location = new System.Drawing.Point(8, 156);
            this.numBxEnName.Name = "numBxEnName";
            this.numBxEnName.Size = new System.Drawing.Size(57, 27);
            this.numBxEnName.TabIndex = 19;
            this.numBxEnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numBxEnName.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // cmboBxEnName
            // 
            this.cmboBxEnName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmboBxEnName.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmboBxEnName.Items.AddRange(new object[] {
            "Time New Roman",
            "Consolas",
            "Segoe UI",
            "Tahoma",
            "Simplified Arabic"});
            this.cmboBxEnName.Location = new System.Drawing.Point(71, 156);
            this.cmboBxEnName.Name = "cmboBxEnName";
            this.cmboBxEnName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmboBxEnName.Size = new System.Drawing.Size(206, 27);
            this.cmboBxEnName.TabIndex = 18;
            this.cmboBxEnName.Text = "Tahoma";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(146, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "اسم المنتج انجليزي";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numBxNumber
            // 
            this.numBxNumber.DecimalPlaces = 1;
            this.numBxNumber.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numBxNumber.Location = new System.Drawing.Point(8, 212);
            this.numBxNumber.Name = "numBxNumber";
            this.numBxNumber.Size = new System.Drawing.Size(57, 27);
            this.numBxNumber.TabIndex = 22;
            this.numBxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numBxNumber.Value = new decimal(new int[] {
            95,
            0,
            0,
            65536});
            // 
            // cmboBxNumber
            // 
            this.cmboBxNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmboBxNumber.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmboBxNumber.Items.AddRange(new object[] {
            "Time New Roman",
            "Consolas",
            "Segoe UI",
            "Tahoma",
            "Simplified Arabic"});
            this.cmboBxNumber.Location = new System.Drawing.Point(71, 212);
            this.cmboBxNumber.Name = "cmboBxNumber";
            this.cmboBxNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmboBxNumber.Size = new System.Drawing.Size(206, 27);
            this.cmboBxNumber.TabIndex = 21;
            this.cmboBxNumber.Text = "Tahoma";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(146, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "خط الأرقام والمبالغ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numBxGeneral
            // 
            this.numBxGeneral.DecimalPlaces = 1;
            this.numBxGeneral.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.numBxGeneral.Location = new System.Drawing.Point(5, 266);
            this.numBxGeneral.Name = "numBxGeneral";
            this.numBxGeneral.Size = new System.Drawing.Size(57, 27);
            this.numBxGeneral.TabIndex = 25;
            this.numBxGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numBxGeneral.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // cmboBxGeneral
            // 
            this.cmboBxGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmboBxGeneral.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cmboBxGeneral.Items.AddRange(new object[] {
            "Time New Roman",
            "Consolas",
            "Segoe UI",
            "Tahoma",
            "Simplified Arabic"});
            this.cmboBxGeneral.Location = new System.Drawing.Point(68, 266);
            this.cmboBxGeneral.Name = "cmboBxGeneral";
            this.cmboBxGeneral.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmboBxGeneral.Size = new System.Drawing.Size(206, 27);
            this.cmboBxGeneral.TabIndex = 24;
            this.cmboBxGeneral.Text = "Consolas";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(179, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "الخط العام";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SamplePosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(944, 695);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.grpConnection);
            this.Controls.Add(this.grpPaper);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnTestCut);
            this.Controls.Add(this.btnTestNetwork);
            this.Controls.Add(this.pnlPreview);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTitle);
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
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numBxTite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBxArName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBxEnName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBxNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBxGeneral)).EndInit();
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
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ComboBox cmboBxTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numBxTite;
        private System.Windows.Forms.NumericUpDown numBxGeneral;
        internal System.Windows.Forms.ComboBox cmboBxGeneral;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numBxNumber;
        internal System.Windows.Forms.ComboBox cmboBxNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numBxEnName;
        internal System.Windows.Forms.ComboBox cmboBxEnName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numBxArName;
        internal System.Windows.Forms.ComboBox cmboBxArName;
        private System.Windows.Forms.Label label2;
    }
}
