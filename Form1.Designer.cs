namespace Memx
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            gridProcessList = new DataGridView();
            txtPID = new TextBox();
            txtValue = new TextBox();
            label2 = new Label();
            label3 = new Label();
            cmbScanType = new ComboBox();
            btnScan = new Button();
            dgScanResults = new DataGridView();
            Address = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            Previous = new DataGridViewTextBoxColumn();
            lblResults = new Label();
            toolStrip1 = new ToolStrip();
            tslblIP = new ToolStripLabel();
            tstxtIP = new ToolStripTextBox();
            tsbtnConnect = new ToolStripButton();
            button1 = new Button();
            cbHex = new CheckBox();
            lblScanType = new Label();
            lblValueType = new Label();
            cmbValueType = new ComboBox();
            groupBox1 = new GroupBox();
            checkBox2 = new CheckBox();
            cbWritable = new CheckBox();
            txtProcessEndRegion = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtProcessStartRegion = new TextBox();
            label1 = new Label();
            cmbProcessRegions = new ComboBox();
            txtProcessFilter = new TextBox();
            label4 = new Label();
            btnAttach = new Button();
            statusStrip1 = new StatusStrip();
            tslblConnectionStatus = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)gridProcessList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgScanResults).BeginInit();
            toolStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // gridProcessList
            // 
            gridProcessList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridProcessList.Location = new Point(913, 112);
            gridProcessList.Margin = new Padding(2);
            gridProcessList.MultiSelect = false;
            gridProcessList.Name = "gridProcessList";
            gridProcessList.Size = new Size(358, 209);
            gridProcessList.TabIndex = 4;
            // 
            // txtPID
            // 
            txtPID.Location = new Point(150, 671);
            txtPID.Margin = new Padding(2);
            txtPID.Name = "txtPID";
            txtPID.Size = new Size(66, 22);
            txtPID.TabIndex = 6;
            txtPID.Text = "476";
            txtPID.TextAlign = HorizontalAlignment.Center;
            // 
            // txtValue
            // 
            txtValue.Location = new Point(981, 384);
            txtValue.Margin = new Padding(2);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(290, 22);
            txtValue.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(115, 675);
            label2.Name = "label2";
            label2.Size = new Size(24, 13);
            label2.TabIndex = 9;
            label2.Text = "PID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(981, 369);
            label3.Name = "label3";
            label3.Size = new Size(39, 13);
            label3.TabIndex = 10;
            label3.Text = "Value:";
            // 
            // cmbScanType
            // 
            cmbScanType.FormattingEnabled = true;
            cmbScanType.Items.AddRange(new object[] { "String", "AOB", "Int", "Float", "Double" });
            cmbScanType.Location = new Point(981, 410);
            cmbScanType.Margin = new Padding(2);
            cmbScanType.Name = "cmbScanType";
            cmbScanType.Size = new Size(160, 21);
            cmbScanType.TabIndex = 11;
            // 
            // btnScan
            // 
            btnScan.FlatStyle = FlatStyle.Flat;
            btnScan.Location = new Point(953, 332);
            btnScan.Margin = new Padding(2);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(92, 28);
            btnScan.TabIndex = 12;
            btnScan.Text = "New Scan";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += btnScan_Click;
            // 
            // dgScanResults
            // 
            dgScanResults.AllowUserToAddRows = false;
            dgScanResults.AllowUserToDeleteRows = false;
            dgScanResults.BorderStyle = BorderStyle.None;
            dgScanResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgScanResults.Columns.AddRange(new DataGridViewColumn[] { Address, Value, Previous });
            dgScanResults.Location = new Point(0, 36);
            dgScanResults.Margin = new Padding(2);
            dgScanResults.Name = "dgScanResults";
            dgScanResults.Size = new Size(892, 556);
            dgScanResults.TabIndex = 13;
            // 
            // Address
            // 
            Address.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Address.HeaderText = "Address";
            Address.Name = "Address";
            Address.Resizable = DataGridViewTriState.False;
            // 
            // Value
            // 
            Value.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Value.HeaderText = "Value";
            Value.Name = "Value";
            // 
            // Previous
            // 
            Previous.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Previous.HeaderText = "Previous";
            Previous.Name = "Previous";
            // 
            // lblResults
            // 
            lblResults.AutoSize = true;
            lblResults.Location = new Point(0, 22);
            lblResults.Name = "lblResults";
            lblResults.Size = new Size(41, 13);
            lblResults.TabIndex = 15;
            lblResults.Text = "Found";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tslblIP, tstxtIP, tsbtnConnect });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1286, 25);
            toolStrip1.TabIndex = 15;
            toolStrip1.Text = "toolStrip1";
            // 
            // tslblIP
            // 
            tslblIP.Name = "tslblIP";
            tslblIP.Size = new Size(23, 22);
            tslblIP.Text = "IP: ";
            // 
            // tstxtIP
            // 
            tstxtIP.Name = "tstxtIP";
            tstxtIP.Size = new Size(100, 25);
            tstxtIP.Text = "192.168.68.7";
            // 
            // tsbtnConnect
            // 
            tsbtnConnect.Image = (Image)resources.GetObject("tsbtnConnect.Image");
            tsbtnConnect.ImageTransparentColor = Color.Magenta;
            tsbtnConnect.Name = "tsbtnConnect";
            tsbtnConnect.Size = new Size(72, 22);
            tsbtnConnect.Text = "Connect";
            tsbtnConnect.Click += tsbtnConnect_Click;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(1093, 332);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(92, 28);
            button1.TabIndex = 16;
            button1.Text = "Next Scan";
            button1.UseVisualStyleBackColor = true;
            // 
            // cbHex
            // 
            cbHex.AutoSize = true;
            cbHex.Location = new Point(931, 386);
            cbHex.Name = "cbHex";
            cbHex.Size = new Size(45, 17);
            cbHex.TabIndex = 17;
            cbHex.Text = "Hex";
            cbHex.UseVisualStyleBackColor = true;
            // 
            // lblScanType
            // 
            lblScanType.AutoSize = true;
            lblScanType.Location = new Point(919, 413);
            lblScanType.Name = "lblScanType";
            lblScanType.Size = new Size(57, 13);
            lblScanType.TabIndex = 18;
            lblScanType.Text = "Scan Type";
            // 
            // lblValueType
            // 
            lblValueType.AutoSize = true;
            lblValueType.Location = new Point(919, 438);
            lblValueType.Name = "lblValueType";
            lblValueType.Size = new Size(62, 13);
            lblValueType.TabIndex = 20;
            lblValueType.Text = "Value Type";
            // 
            // cmbValueType
            // 
            cmbValueType.FormattingEnabled = true;
            cmbValueType.Items.AddRange(new object[] { "String", "AOB", "Int", "Float", "Double" });
            cmbValueType.Location = new Point(981, 435);
            cmbValueType.Margin = new Padding(2);
            cmbValueType.Name = "cmbValueType";
            cmbValueType.Size = new Size(160, 21);
            cmbValueType.TabIndex = 19;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(cbWritable);
            groupBox1.Controls.Add(txtProcessEndRegion);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtProcessStartRegion);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbProcessRegions);
            groupBox1.Location = new Point(908, 466);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(363, 126);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Memory Scan Options";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(268, 103);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(81, 17);
            checkBox2.TabIndex = 15;
            checkBox2.Text = "Executable";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // cbWritable
            // 
            cbWritable.AutoSize = true;
            cbWritable.Checked = true;
            cbWritable.CheckState = CheckState.Checked;
            cbWritable.Location = new Point(9, 103);
            cbWritable.Name = "cbWritable";
            cbWritable.Size = new Size(70, 17);
            cbWritable.TabIndex = 14;
            cbWritable.Text = "Writable";
            cbWritable.UseVisualStyleBackColor = true;
            // 
            // txtProcessEndRegion
            // 
            txtProcessEndRegion.Location = new Point(45, 76);
            txtProcessEndRegion.Margin = new Padding(2);
            txtProcessEndRegion.Name = "txtProcessEndRegion";
            txtProcessEndRegion.Size = new Size(304, 22);
            txtProcessEndRegion.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 79);
            label6.Name = "label6";
            label6.Size = new Size(31, 13);
            label6.TabIndex = 10;
            label6.Text = "Stop";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 79);
            label7.Name = "label7";
            label7.Size = new Size(31, 13);
            label7.TabIndex = 11;
            label7.Text = "Start";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(9, 79);
            label8.Name = "label8";
            label8.Size = new Size(31, 13);
            label8.TabIndex = 12;
            label8.Text = "Start";
            // 
            // txtProcessStartRegion
            // 
            txtProcessStartRegion.Location = new Point(45, 50);
            txtProcessStartRegion.Margin = new Padding(2);
            txtProcessStartRegion.Name = "txtProcessStartRegion";
            txtProcessStartRegion.Size = new Size(304, 22);
            txtProcessStartRegion.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 59);
            label1.Name = "label1";
            label1.Size = new Size(31, 13);
            label1.TabIndex = 1;
            label1.Text = "Start";
            // 
            // cmbProcessRegions
            // 
            cmbProcessRegions.FormattingEnabled = true;
            cmbProcessRegions.Location = new Point(12, 24);
            cmbProcessRegions.Name = "cmbProcessRegions";
            cmbProcessRegions.Size = new Size(337, 21);
            cmbProcessRegions.TabIndex = 0;
            // 
            // txtProcessFilter
            // 
            txtProcessFilter.Location = new Point(983, 52);
            txtProcessFilter.Name = "txtProcessFilter";
            txtProcessFilter.Size = new Size(202, 22);
            txtProcessFilter.TabIndex = 22;
            txtProcessFilter.KeyUp += txtProcessFilter_KeyUp;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1044, 36);
            label4.Name = "label4";
            label4.Size = new Size(77, 13);
            label4.TabIndex = 23;
            label4.Text = "Process Name";
            // 
            // btnAttach
            // 
            btnAttach.FlatStyle = FlatStyle.Flat;
            btnAttach.Location = new Point(983, 80);
            btnAttach.Margin = new Padding(2);
            btnAttach.Name = "btnAttach";
            btnAttach.Size = new Size(202, 28);
            btnAttach.TabIndex = 24;
            btnAttach.Text = "Attach";
            btnAttach.UseVisualStyleBackColor = true;
            btnAttach.Click += btnAttach_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tslblConnectionStatus });
            statusStrip1.Location = new Point(0, 938);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1286, 22);
            statusStrip1.TabIndex = 25;
            statusStrip1.Text = "statusStrip1";
            // 
            // tslblConnectionStatus
            // 
            tslblConnectionStatus.Name = "tslblConnectionStatus";
            tslblConnectionStatus.Size = new Size(117, 17);
            tslblConnectionStatus.Text = "Status: Disconnected";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1286, 960);
            Controls.Add(statusStrip1);
            Controls.Add(btnAttach);
            Controls.Add(label4);
            Controls.Add(txtProcessFilter);
            Controls.Add(groupBox1);
            Controls.Add(lblValueType);
            Controls.Add(cmbValueType);
            Controls.Add(lblScanType);
            Controls.Add(cbHex);
            Controls.Add(button1);
            Controls.Add(gridProcessList);
            Controls.Add(lblResults);
            Controls.Add(btnScan);
            Controls.Add(dgScanResults);
            Controls.Add(txtPID);
            Controls.Add(cmbScanType);
            Controls.Add(txtValue);
            Controls.Add(toolStrip1);
            Controls.Add(label3);
            Controls.Add(label2);
            Font = new Font("Segoe UI Historic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)gridProcessList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgScanResults).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cmbProcesses;
        private DataGridView gridProcessList;
        private TextBox txtPID;
        private TextBox txtValue;
        private Label label2;
        private Label label3;
        private ComboBox cmbScanType;
        private Button btnScan;
        private DataGridView dgScanResults;
        private Label lblResults;
        private ToolStrip toolStrip1;
        private ToolStripLabel tslblIP;
        private ToolStripTextBox tstxtIP;
        private ToolStripButton tsbtnConnect;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn Value;
        private DataGridViewTextBoxColumn Previous;
        private Button button1;
        private CheckBox cbHex;
        private Label lblScanType;
        private Label lblValueType;
        private ComboBox cmbValueType;
        private GroupBox groupBox1;
        private ComboBox cmbProcessRegions;
        private CheckBox checkBox2;
        private CheckBox cbWritable;
        private TextBox txtProcessEndRegion;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtProcessStartRegion;
        private Label label1;
        private TextBox txtProcessFilter;
        private Label label4;
        private Button btnAttach;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tslblConnectionStatus;
    }
}
