using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace e_shop
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void log_in_Click(object sender, EventArgs e)
        {
            //SqlConnection dbCon = new SqlConnection("Database=eshop;Data Source=localhost; User Id=eshop_usr; Password=WNAQWdE9GFEpXLts");
            SqlConnection dbCon = new SqlConnection("server=192.168.184.134; initial catalog=eshop; uid=eshop_usr; pwd=eshop_usr"); 
            dbCon.Open();
            SqlCommand login = dbCon.CreateCommand();
            login.CommandText = "SELECT * FROM users_new WHERE uname ='" + uname.Text.ToString()+"';";
            SqlDataReader reader = login.ExecuteReader();
            while (reader.Read()){
                String check_psd = reader.GetSqlValue(2).ToString();
                String check_role = reader.GetSqlValue(3).ToString();
                if (pass.Text == check_psd) {
                    loginStatus.Text = "Success logged in as " + uname.Text; ;
                    loginStatus.ForeColor = System.Drawing.Color.Green;
                    Session["uname"] = uname.Text;
                    Session["role"] = check_role;
                    Response.Redirect("./default.aspx");
                }
                else
                {
                    loginStatus.Text = "Fail";
                    loginStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            reader.Close();
            dbCon.Close();
        }

        protected void reg_Click(object sender, EventArgs e)
        {
            unameTaken.Visible = false;
            SqlConnection dbCon = new SqlConnection("server=192.168.184.134; initial catalog=eshop; uid=eshop_usr; pwd=eshop_usr");
            dbCon.Open();
            SqlCommand regPreCheck = dbCon.CreateCommand();
            regPreCheck.CommandText = "SELECT uname FROM users_new;";
            SqlDataReader reader = regPreCheck.ExecuteReader();
            int err = 0;
            while (reader.Read())
            {
                reader.GetString(0);
                if (reader.ToString()==regUname.Text.ToString())
                {
                    err++;
                    unameTaken.Visible = true;
                    break;
                }
            }
            reader.Close();
            if (err == 0)
            {
                SqlCommand reg = dbCon.CreateCommand();
                reg.CommandText = "INSERT INTO users_new (uname, passw, role) values (@uname, @pass, @role)";
                reg.Parameters.Add("@uname", SqlDbType.VarChar);
                reg.Parameters["@uname"].Value = uname.Text.ToString();
                reg.Parameters.Add("@pass", SqlDbType.VarChar);
                reg.Parameters["@pass"].Value = regPass.Text.ToString();
                reg.Parameters.Add("@role", SqlDbType.VarChar);
                TextBox dummy = new TextBox { Text = "user" };
                reg.Parameters["@role"].Value = dummy.Text.ToString();
                reg.ExecuteNonQuery();
                Session["uname"] = regUname.Text.ToString();
                Session["role"] = "user";

            }
            dbCon.Close();
            if (err == 0) { Response.Redirect("./default.aspx"); }
        }
    }
}