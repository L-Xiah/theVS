namespace WinAppPageSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_OddAndEven = new System.Windows.Forms.CheckBox();
            this.chk_FirstPage = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_FooterDistance = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_HeaderDistance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Gutter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Right = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Left = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Down = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Up = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 431);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(23, 389);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(810, 32);
            this.progressBar1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(23, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(810, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "浏览文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(23, 66);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(810, 308);
            this.listBox1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.chk_OddAndEven);
            this.groupBox2.Controls.Add(this.chk_FirstPage);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.txt_FooterDistance);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_HeaderDistance);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_Gutter);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_Right);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_Left);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_Down);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_Up);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(874, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 421);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "页面设置（cm）";
            // 
            // chk_OddAndEven
            // 
            this.chk_OddAndEven.AutoSize = true;
            this.chk_OddAndEven.Location = new System.Drawing.Point(140, 160);
            this.chk_OddAndEven.Name = "chk_OddAndEven";
            this.chk_OddAndEven.Size = new System.Drawing.Size(84, 16);
            this.chk_OddAndEven.TabIndex = 17;
            this.chk_OddAndEven.Text = "奇偶页不同";
            this.chk_OddAndEven.UseVisualStyleBackColor = true;
            // 
            // chk_FirstPage
            // 
            this.chk_FirstPage.AutoSize = true;
            this.chk_FirstPage.Location = new System.Drawing.Point(140, 123);
            this.chk_FirstPage.Name = "chk_FirstPage";
            this.chk_FirstPage.Size = new System.Drawing.Size(72, 16);
            this.chk_FirstPage.TabIndex = 16;
            this.chk_FirstPage.Text = "首页不同";
            this.chk_FirstPage.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(16, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(223, 96);
            this.button2.TabIndex = 11;
            this.button2.Text = "设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_FooterDistance
            // 
            this.txt_FooterDistance.Location = new System.Drawing.Point(49, 201);
            this.txt_FooterDistance.Name = "txt_FooterDistance";
            this.txt_FooterDistance.Size = new System.Drawing.Size(68, 21);
            this.txt_FooterDistance.TabIndex = 15;
            this.txt_FooterDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Up_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "页脚";
            // 
            // txt_HeaderDistance
            // 
            this.txt_HeaderDistance.Location = new System.Drawing.Point(49, 161);
            this.txt_HeaderDistance.Name = "txt_HeaderDistance";
            this.txt_HeaderDistance.Size = new System.Drawing.Size(68, 21);
            this.txt_HeaderDistance.TabIndex = 11;
            this.txt_HeaderDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Up_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "页眉";
            // 
            // txt_Gutter
            // 
            this.txt_Gutter.Location = new System.Drawing.Point(49, 121);
            this.txt_Gutter.Name = "txt_Gutter";
            this.txt_Gutter.Size = new System.Drawing.Size(68, 21);
            this.txt_Gutter.TabIndex = 9;
            this.txt_Gutter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Up_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "装订线";
            // 
            // txt_Right
            // 
            this.txt_Right.Location = new System.Drawing.Point(172, 76);
            this.txt_Right.Name = "txt_Right";
            this.txt_Right.Size = new System.Drawing.Size(68, 21);
            this.txt_Right.TabIndex = 7;
            this.txt_Right.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Up_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "右";
            // 
            // txt_Left
            // 
            this.txt_Left.Location = new System.Drawing.Point(49, 76);
            this.txt_Left.Name = "txt_Left";
            this.txt_Left.Size = new System.Drawing.Size(68, 21);
            this.txt_Left.TabIndex = 5;
            this.txt_Left.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Up_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "左";
            // 
            // txt_Down
            // 
            this.txt_Down.Location = new System.Drawing.Point(172, 36);
            this.txt_Down.Name = "txt_Down";
            this.txt_Down.Size = new System.Drawing.Size(68, 21);
            this.txt_Down.TabIndex = 3;
            this.txt_Down.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Up_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "下";
            // 
            // txt_Up
            // 
            this.txt_Up.Location = new System.Drawing.Point(49, 36);
            this.txt_Up.Name = "txt_Up";
            this.txt_Up.Size = new System.Drawing.Size(68, 21);
            this.txt_Up.TabIndex = 1;
            this.txt_Up.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Up_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "上";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(11, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(237, 60);
            this.label8.TabIndex = 18;
            this.label8.Text = "注：设置前调整好word文档第一节的页眉页脚，设置好之后注意分节页中横向页面";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 461);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "WordPageSetup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_FooterDistance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_HeaderDistance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Gutter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Right;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Left;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Down;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Up;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chk_OddAndEven;
        private System.Windows.Forms.CheckBox chk_FirstPage;
        private System.Windows.Forms.Label label8;
    }
}

