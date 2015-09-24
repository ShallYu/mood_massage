namespace ClientForm
{
    partial class UserInfo
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.moodBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.likeBox = new System.Windows.Forms.TextBox();
            this.pwdBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.genderBox = new System.Windows.Forms.ComboBox();
            this.collegeBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ageBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TestBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.moodBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.likeBox);
            this.panel1.Controls.Add(this.pwdBox);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.genderBox);
            this.panel1.Controls.Add(this.collegeBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ageBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.nameBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 253);
            this.panel1.TabIndex = 0;
            // 
            // moodBox
            // 
            this.moodBox.Font = new System.Drawing.Font("宋体", 12F);
            this.moodBox.FormattingEnabled = true;
            this.moodBox.Items.AddRange(new object[] {
            "愉快",
            "兴奋",
            "悲伤",
            "恐惧"});
            this.moodBox.Location = new System.Drawing.Point(105, 198);
            this.moodBox.Name = "moodBox";
            this.moodBox.Size = new System.Drawing.Size(56, 24);
            this.moodBox.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(96, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 21);
            this.label6.TabIndex = 30;
            this.label6.Text = "1";
            // 
            // likeBox
            // 
            this.likeBox.Font = new System.Drawing.Font("宋体", 12F);
            this.likeBox.Location = new System.Drawing.Point(306, 139);
            this.likeBox.Name = "likeBox";
            this.likeBox.Size = new System.Drawing.Size(101, 26);
            this.likeBox.TabIndex = 29;
            this.likeBox.UseSystemPasswordChar = true;
            // 
            // pwdBox
            // 
            this.pwdBox.Font = new System.Drawing.Font("宋体", 12F);
            this.pwdBox.Location = new System.Drawing.Point(306, 195);
            this.pwdBox.Name = "pwdBox";
            this.pwdBox.Size = new System.Drawing.Size(101, 26);
            this.pwdBox.TabIndex = 28;
            this.pwdBox.UseSystemPasswordChar = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(226, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 21);
            this.label11.TabIndex = 27;
            this.label11.Text = "密码：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(11, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 21);
            this.label9.TabIndex = 25;
            this.label9.Text = "测试情绪：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(226, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 21);
            this.label7.TabIndex = 23;
            this.label7.Text = "爱好：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(11, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 21);
            this.label5.TabIndex = 21;
            this.label5.Text = "测试轮数：";
            // 
            // genderBox
            // 
            this.genderBox.Font = new System.Drawing.Font("宋体", 12F);
            this.genderBox.FormattingEnabled = true;
            this.genderBox.Items.AddRange(new object[] {
            "男",
            "女"});
            this.genderBox.Location = new System.Drawing.Point(306, 23);
            this.genderBox.Name = "genderBox";
            this.genderBox.Size = new System.Drawing.Size(56, 24);
            this.genderBox.TabIndex = 20;
            // 
            // collegeBox
            // 
            this.collegeBox.Font = new System.Drawing.Font("宋体", 12F);
            this.collegeBox.Location = new System.Drawing.Point(306, 73);
            this.collegeBox.Name = "collegeBox";
            this.collegeBox.Size = new System.Drawing.Size(101, 26);
            this.collegeBox.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(226, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 18;
            this.label4.Text = "学院";
            // 
            // ageBox
            // 
            this.ageBox.Font = new System.Drawing.Font("宋体", 12F);
            this.ageBox.Location = new System.Drawing.Point(83, 74);
            this.ageBox.Name = "ageBox";
            this.ageBox.Size = new System.Drawing.Size(44, 26);
            this.ageBox.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(11, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "年龄";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(226, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "性别";
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("宋体", 12F);
            this.nameBox.Location = new System.Drawing.Point(83, 23);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(101, 26);
            this.nameBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "姓名";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestBtn
            // 
            this.TestBtn.Location = new System.Drawing.Point(127, 295);
            this.TestBtn.Name = "TestBtn";
            this.TestBtn.Size = new System.Drawing.Size(183, 33);
            this.TestBtn.TabIndex = 2;
            this.TestBtn.Text = "开始测试";
            this.TestBtn.UseVisualStyleBackColor = true;
            this.TestBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(337, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "注销";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(162, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 28);
            this.label8.TabIndex = 4;
            this.label8.Text = "个人信息";
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TestBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "UserInfo";
            this.Size = new System.Drawing.Size(439, 335);
            this.Load += new System.EventHandler(this.UserInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox genderBox;
        private System.Windows.Forms.TextBox collegeBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ageBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button TestBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox pwdBox;
        private System.Windows.Forms.TextBox likeBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox moodBox;
        private System.Windows.Forms.Label label8;
    }
}
