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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.brainGraph1 = new ClientForm.BrainGraph();
            this.moodStat1 = new ClientForm.MoodStat();
            this.moodVector1 = new ClientForm.MoodVector();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(742, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(20, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 31);
            this.label1.TabIndex = 13;
            this.label1.Text = "O(∩_∩)O";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(20, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 31);
            this.label2.TabIndex = 14;
            this.label2.Text = "￣へ￣";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(16, 264);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(435, 73);
            this.axWindowsMediaPlayer1.TabIndex = 16;
            // 
            // brainGraph1
            // 
            this.brainGraph1.Location = new System.Drawing.Point(254, 0);
            this.brainGraph1.Name = "brainGraph1";
            this.brainGraph1.Size = new System.Drawing.Size(272, 258);
            this.brainGraph1.TabIndex = 18;
            // 
            // moodStat1
            // 
            this.moodStat1.BackColor = System.Drawing.Color.Black;
            this.moodStat1.Location = new System.Drawing.Point(156, 3);
            this.moodStat1.Name = "moodStat1";
            this.moodStat1.Size = new System.Drawing.Size(53, 255);
            this.moodStat1.TabIndex = 17;
            // 
            // moodVector1
            // 
            this.moodVector1.Location = new System.Drawing.Point(532, 0);
            this.moodVector1.Name = "moodVector1";
            this.moodVector1.Size = new System.Drawing.Size(286, 258);
            this.moodVector1.TabIndex = 19;
            // 
            // MoodTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.moodVector1);
            this.Controls.Add(this.brainGraph1);
            this.Controls.Add(this.moodStat1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "MoodTest";
            this.Size = new System.Drawing.Size(850, 376);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private MoodStat moodStat1;
        private BrainGraph brainGraph1;
        private MoodVector moodVector1;
    }
}
