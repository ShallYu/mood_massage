namespace ClientForm
{
    partial class SignInCom
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
            this.LogInBtn = new System.Windows.Forms.Button();
            this.signInBtn = new System.Windows.Forms.Button();
            this.pwdBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LogInBtn);
            this.panel1.Controls.Add(this.signInBtn);
            this.panel1.Controls.Add(this.pwdBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.nameBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 224);
            this.panel1.TabIndex = 0;
            // 
            // LogInBtn
            // 
            this.LogInBtn.Location = new System.Drawing.Point(150, 162);
            this.LogInBtn.Name = "LogInBtn";
            this.LogInBtn.Size = new System.Drawing.Size(89, 32);
            this.LogInBtn.TabIndex = 7;
            this.LogInBtn.Text = "注册";
            this.LogInBtn.UseVisualStyleBackColor = true;
            this.LogInBtn.Click += new System.EventHandler(this.LogInBtn_Click);
            // 
            // signInBtn
            // 
            this.signInBtn.Location = new System.Drawing.Point(32, 162);
            this.signInBtn.Name = "signInBtn";
            this.signInBtn.Size = new System.Drawing.Size(89, 32);
            this.signInBtn.TabIndex = 6;
            this.signInBtn.Text = "登陆";
            this.signInBtn.UseVisualStyleBackColor = true;
            this.signInBtn.Click += new System.EventHandler(this.signInBtn_Click);
            // 
            // pwdBox
            // 
            this.pwdBox.Font = new System.Drawing.Font("宋体", 12F);
            this.pwdBox.Location = new System.Drawing.Point(114, 104);
            this.pwdBox.Name = "pwdBox";
            this.pwdBox.Size = new System.Drawing.Size(125, 26);
            this.pwdBox.TabIndex = 5;
            this.pwdBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(42, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "密码";
            // 
            // nameBox
            // 
            this.nameBox.Font = new System.Drawing.Font("宋体", 12F);
            this.nameBox.Location = new System.Drawing.Point(114, 47);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(125, 26);
            this.nameBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(42, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "账号";
            // 
            // SignInCom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SignInCom";
            this.Size = new System.Drawing.Size(277, 224);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button signInBtn;
        private System.Windows.Forms.TextBox pwdBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LogInBtn;
    }
}
