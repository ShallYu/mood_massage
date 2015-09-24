using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class UserInfo : UserControl
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (moodBox.SelectedItem.ToString() != "" && moodBox.SelectedItem.ToString() != null)
                {

                    MusicList.setType(moodBox.SelectedItem.ToString());
                    Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.TEST);
                    Event.Step.OnStepDone(this, sdea);
                }
                else
                {
                    MessageBox.Show("请选择测试情绪。");
                }
            }
            catch(Exception arg)
            {

                MessageBox.Show("音乐打开出错");
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.SIGNIN);
            Event.Step.OnStepDone(this, sdea);
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            this.nameBox.Text = CurrentUser.currentUser["Name"].ToString() ;
            this.genderBox.Text = CurrentUser.currentUser["Gender"].ToString();
            this.ageBox.Text = CurrentUser.currentUser["Age"].ToString();
            this.likeBox.Text = CurrentUser.currentUser["Like"].ToString();
            this.pwdBox.Text = CurrentUser.currentUser["Password"].ToString();
            this.collegeBox.Text = CurrentUser.currentUser["College"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //DataRow dr = CurrentUser.getProtype();
            //dr["Name"] = this.nameBox.Text;
            //dr["College"] = this.collegeBox.Text;
            //dr["Password"] = this.pwdBox.Text;
            //dr["Gender"] = this.genderBox.Text;
            //dr["Like"] = this.likeBox.Text;
            //CurrentUser.Update(dr);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.MASSAGE);
            Event.Step.OnStepDone(this, sdea);
        }
    }
}
