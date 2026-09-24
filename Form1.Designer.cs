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
            textBox1 = new TextBox();
            label1 = new Label();
            btnConnect = new Button();
            gridProcessList = new DataGridView();
            dgProcessMain = new Panel();
            lblpFilter = new Label();
            txtFilterpListgrid = new TextBox();
            dgridpHolder = new Panel();
            ((System.ComponentModel.ISupportInitialize)gridProcessList).BeginInit();
            dgProcessMain.SuspendLayout();
            dgridpHolder.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(14, 43);
            textBox1.Margin = new Padding(5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(186, 33);
            textBox1.TabIndex = 0;
            textBox1.Text = "192.168.68.7";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 13);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 1;
            label1.Text = "Console IP";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(14, 84);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(186, 31);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // gridProcessList
            // 
            gridProcessList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridProcessList.Dock = DockStyle.Fill;
            gridProcessList.Location = new Point(0, 0);
            gridProcessList.Name = "gridProcessList";
            gridProcessList.Size = new Size(403, 477);
            gridProcessList.TabIndex = 4;
            // 
            // dgProcessMain
            // 
            dgProcessMain.Controls.Add(lblpFilter);
            dgProcessMain.Controls.Add(txtFilterpListgrid);
            dgProcessMain.Controls.Add(dgridpHolder);
            dgProcessMain.Dock = DockStyle.Right;
            dgProcessMain.Location = new Point(990, 0);
            dgProcessMain.Name = "dgProcessMain";
            dgProcessMain.Size = new Size(403, 569);
            dgProcessMain.TabIndex = 5;
            // 
            // lblpFilter
            // 
            lblpFilter.AutoSize = true;
            lblpFilter.Location = new Point(153, 13);
            lblpFilter.Margin = new Padding(5, 0, 5, 0);
            lblpFilter.Name = "lblpFilter";
            lblpFilter.Size = new Size(123, 25);
            lblpFilter.TabIndex = 6;
            lblpFilter.Text = "Process Filter";
            // 
            // txtFilterpListgrid
            // 
            txtFilterpListgrid.Location = new Point(84, 43);
            txtFilterpListgrid.Name = "txtFilterpListgrid";
            txtFilterpListgrid.Size = new Size(265, 33);
            txtFilterpListgrid.TabIndex = 7;
            txtFilterpListgrid.TextChanged += txtFilterpListgrid_TextChanged;
            // 
            // dgridpHolder
            // 
            dgridpHolder.Controls.Add(gridProcessList);
            dgridpHolder.Dock = DockStyle.Bottom;
            dgridpHolder.Location = new Point(0, 92);
            dgridpHolder.Name = "dgridpHolder";
            dgridpHolder.Size = new Size(403, 477);
            dgridpHolder.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1393, 569);
            Controls.Add(dgProcessMain);
            Controls.Add(btnConnect);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Font = new Font("Segoe UI Historic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(5);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)gridProcessList).EndInit();
            dgProcessMain.ResumeLayout(false);
            dgProcessMain.PerformLayout();
            dgridpHolder.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button btnConnect;
        private ComboBox cmbProcesses;
        private DataGridView gridProcessList;
        private Panel dgProcessMain;
        private TextBox txtFilterpListgrid;
        private Panel dgridpHolder;
        private Label lblpFilter;
    }
}
