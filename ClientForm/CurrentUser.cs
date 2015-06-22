using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ClientForm
{
     static class CurrentUser
    {
        static string connectStr = @"Data Source=(LocalDB)\v11.0;AttachDbFilename="+Application.StartupPath+ @"\Database1.mdf;Integrated Security=True";
        static SqlConnection objConnection = new SqlConnection(connectStr);
        static public DataRow currentUser ;

        static public DataRow getProtype()
        {
            string cmdstring = "select * from [dbo].[userData] where Username = 'a'";
            SqlDataAdapter sa = new SqlDataAdapter(cmdstring, objConnection);
            DataTable dtOut = new DataTable();
            sa.Fill(dtOut);
            return dtOut.NewRow();
        }
        static public bool Check(string username)
        {
            objConnection.Open();
            string cmdstring = "select Username from [dbo].[userData] where Username = '" + username + "'";
            SqlCommand sqlcmd = new SqlCommand(cmdstring,objConnection);
            try
            {
                 string result = (string)sqlcmd.ExecuteScalar();
                 if (result == "" || result == null)
                 {
                     objConnection.Close();
                     return false;
                 }
                 else
                 {
                     objConnection.Close();
                     return true;
                 }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                objConnection.Close();
                return false;
            }
            
        }

        static public DataTable LogIn(DataTable dtIn)
        {
            string cmdstring = "select * from [dbo].[userData]";
            SqlDataAdapter sa = new SqlDataAdapter(cmdstring, objConnection);
            DataTable dtOut = new DataTable();
            sa.Fill(dtOut);
            dtOut.Rows.Add(dtIn.Rows[0].ItemArray);
            SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(sa);
            sa.Update(dtOut);
            currentUser = dtIn.Rows[0];
            objConnection.Close();
            return dtIn;
        }

        static public void Update(DataRow dr)
        {
            string cmdstring = "select * from [dbo].[userData] where Username ='" + currentUser["Username"] + "'";
            SqlDataAdapter sa = new SqlDataAdapter(cmdstring, objConnection);
            DataTable dtOut = new DataTable();
            sa.Fill(dtOut);
            dtOut.Rows[0].ItemArray = dr.ItemArray;
            SqlCommandBuilder objCommandBuilder = new SqlCommandBuilder(sa);
            sa.Update(dtOut);
            currentUser = dr;
            objConnection.Close();
        }

        static public void SignIn(string username, string password)
        {
            string cmdstring = "select * from [dbo].[userData] where Username = '" + username + "'and Password = '" + password + "'";
            SqlDataAdapter sa = new SqlDataAdapter(cmdstring, objConnection);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                throw (new Exception("账号或密码错误！"));
            }
            else{
                currentUser = dt.Rows[0];
            }
        }
    }
}
