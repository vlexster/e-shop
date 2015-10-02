using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace e_shop
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void log_in_Click(object sender, EventArgs e)
        {
            MySqlConnection dbCon = new MySqlConnection("Database=eshop;Data Source=localhost; User Id=eshop_usr; Password=WNAQWdE9GFEpXLts");
            dbCon.Open();
            MySqlCommand login = dbCon.CreateCommand();
            login.CommandText = "SELECT * FROM users WHERE uname ='" + uname.Text.ToString()+"';";
            MySqlDataReader reader = login.ExecuteReader();
            while (reader.Read()){
                reader.GetString(0);
                if (pass.Text == reader["pass"].ToString()) {
                    loginStatus.Text = "Success logged in as " + uname.Text; ;
                    loginStatus.ForeColor = System.Drawing.Color.Green;
                    Session["uname"] = uname.Text;
                    Session["role"] = reader["role"].ToString();
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
            MySqlConnection dbCon = new MySqlConnection("Database=eshop;Data Source=localhost; User Id=eshop_usr; Password=WNAQWdE9GFEpXLts");
            dbCon.Open();
            MySqlCommand regPreCheck = dbCon.CreateCommand();
            regPreCheck.CommandText = "SELECT * FROM users;";
            MySqlDataReader reader = regPreCheck.ExecuteReader();
            int err = 0;
            while (reader.Read())
            {
                reader.GetString(0);
                if (reader["uname"].ToString()==regUname.Text.ToString())
                {
                    err++;
                    unameTaken.Visible = true;
                    break;
                }
            }
            reader.Close();
            if (err == 0)
            {
                MySqlCommand reg = dbCon.CreateCommand();
                reg.CommandText = "INSERT INTO users (uname, pass, mail, role) VALUES ('" + regUname.Text.ToString() + "','" + regPass.Text.ToString() + "','" + regMail.Text.ToString() + "', 'user');";
                unameTaken.Text = reg.CommandText;
                MySqlDataReader regRead = reg.ExecuteReader();
                Session["uname"] = regUname.Text;
                Session["role"] = "user";
                regRead.Close();
                unameTaken.Text = reg.CommandText;
            }
            reader.Close();
            dbCon.Close();
            if (err == 0) { Response.Redirect("./default.aspx"); }
        }
    }
}