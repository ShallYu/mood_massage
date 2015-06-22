namespace ClientForm
{
    partial class MoodTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoodTest));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.freqDraw2 = new ClientForm.FreqDraw();
            this.moodVector2 = new ClientForm.MoodVector();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "您的脑电波：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(486, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "您的情绪状态：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(650, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(27, 258);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(435, 74);
            this.axWindowsMediaPlayer1.TabIndex = 10;
            this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer1_PlayStateChange);
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(27, 48);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(435, 183);
            this.elementHost1.TabIndex = 9;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.freqDraw2;
            // 
            // moodVector2
            // 
            this.moodVector2.Location = new System.Drawing.Point(489, 48);
            this.moodVector2.Name = "moodVector2";
            this.moodVector2.Size = new System.Drawing.Size(251, 207);
            this.moodVector2.TabIndex = 8;
            // 
            // 测试
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.moodVector2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "测试";
            this.Size = new System.Drawing.Size(759, 376);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private MoodVector moodVector2;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private FreqDraw freqDraw2;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}
