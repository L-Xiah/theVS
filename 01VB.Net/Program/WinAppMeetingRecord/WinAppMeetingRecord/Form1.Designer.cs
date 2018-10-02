namespace WinAppMeetingRecord
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_ser = new System.Windows.Forms.TextBox();
            this.btn_ser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(937, 167);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // txt_ser
            // 
            this.txt_ser.Location = new System.Drawing.Point(23, 17);
            this.txt_ser.Name = "txt_ser";
            this.txt_ser.Size = new System.Drawing.Size(413, 21);
            this.txt_ser.TabIndex = 1;
            // 
            // btn_ser
            // 
            this.btn_ser.Location = new System.Drawing.Point(520, 13);
            this.btn_ser.Name = "btn_ser";
            this.btn_ser.Size = new System.Drawing.Size(330, 33);
            this.btn_ser.TabIndex = 2;
            this.btn_ser.Text = "Search";
            this.btn_ser.UseVisualStyleBackColor = true;
            this.btn_ser.Click += new System.EventHandler(this.btn_ser_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(961, 262);
            this.Controls.Add(this.btn_ser);
            this.Controls.Add(this.txt_ser);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_ser;
        private System.Windows.Forms.TextBox txt_ser;
        
    }
}

