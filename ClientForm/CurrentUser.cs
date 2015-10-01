using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace ClientForm
{
     static class CurrentUser
    {
        static SQLiteConnection objConnection = new SQLiteConnection(@"Data Source=UserData.sql;Version=3;");
        static public DataRow currentUser ;
        

        static public DataRow getProtype()
        {
            string cmdstring = "select * from userdata where Username = 'a'";
            SQLiteDataAdapter sa = new SQLiteDataAdapter(cmdstring, objConnection);
            DataTable dtOut = new DataTable();
            sa.Fill(dtOut);
            return dtOut.NewRow();
        }
        static public bool Check(string username)
        {
            objConnection.Open();
            string cmdstring = "select Username from userdata where Username = '" + username + "'";
            SQLiteCommand sqlcmd = new SQLiteCommand(cmdstring,objConnection);
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
            catch (System.Data.SQLite.SQLiteException)
            {
                objConnection.Close();
                return false;
            }
            
        }

        static public DataTable LogIn(DataTable dtIn)
        {
            string cmdstring = "select * from userdata";
            SQLiteDataAdapter sa = new SQLiteDataAdapter(cmdstring, objConnection);
            DataTable dtOut = new DataTable();
            sa.Fill(dtOut);
            dtOut.Rows.Add(dtIn.Rows[0].ItemArray);
            SQLiteCommandBuilder objCommandBuilder = new SQLiteCommandBuilder(sa);
            sa.Update(dtOut);
            currentUser = dtIn.Rows[0];
            objConnection.Close();
            return dtIn;
        }

        static public void Update(DataRow dr)
        {
            string cmdstring = "select * from userdata where Username ='" + currentUser["Username"] + "'";
            SQLiteDataAdapter sa = new SQLiteDataAdapter(cmdstring, objConnection);
            DataTable dtOut = new DataTable();
            sa.Fill(dtOut);
            dtOut.Rows[0].ItemArray = dr.ItemArray;
            SQLiteCommandBuilder objCommandBuilder = new SQLiteCommandBuilder(sa);
            sa.Update(dtOut);
            currentUser = dr;
            objConnection.Close();
        }

        static public void SignIn(string username, string password)
        {
            string cmdstring = "select * from userdata where Username = '" + username + "'and Password = '" + password + "'";
            SQLiteDataAdapter sa = new SQLiteDataAdapter(cmdstring, objConnection);
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
