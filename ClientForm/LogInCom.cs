using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;

namespace ClientForm
{
    public partial class LogInCom : UserControl
    {
        public LogInCom()
        {
            InitializeComponent();

        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            if (CurrentUser.Check(this.userNameBox.Text))
            {
                MessageBox.Show("此用户已存在");
            }
            else
            {
                string[] infoType = {  "Username","Name","Age", "College", "Password","Gender","Like","TestTime" };
                DataTable dt1 = new DataTable();
                foreach (string str in infoType)
                {
                    dt1.Columns.Add(str);
                }
                DataRow dr = dt1.NewRow();
                dr["Name"] = this.nameBox.Text;
                dr["Username"] = this.userNameBox.Text;
                dr["College"] = this.collegeBox.Text;
                dr["Password"] = this.pwdBox.Text;
                dr["Gender"] = this.genderBox.Text;
                dr["Like"] = this.likeBox.Text;
                dr["TestTime"] = 0;

                dt1.Rows.Add(dr);
                try
                {
                    CurrentUser.LogIn(dt1);
                    Event.StepDoneEventArgs sdea = new Event.StepDoneEventArgs(Event.Step.StepEnum.USERINFO);
                    Event.Step.OnStepDone(this, sdea);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message.ToString());
                }
            }
           
        }


    }
}
