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

    public partial class _default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] != null)
            {
                loginFrm.Text = "Hi, " + Session["uname"].ToString() + "!";
                loginFrm.Enabled = false;
                logout.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "displCont", "displCont();", true);
                loadCont();
            }
            if (((string)Session["role"]) == "admin")
            {
                addHL.Visible = true;
            }
        }
        protected void log_checker(object sender, EventArgs e)
        {

        }
        private void loadCont()
        {
            //SqlConnection dbCon = new SqlConnection("Database=eshop;Data Source=localhost; User Id=eshop_usr; Password=WNAQWdE9GFEpXLts");
            SqlConnection dbCon = new SqlConnection("server=192.168.184.134; initial catalog=eshop; uid=eshop_usr; pwd=eshop_usr");
            dbCon.Open();
            SqlCommand fetchCont = dbCon.CreateCommand();
            fetchCont.CommandText = "SELECT * FROM items;";
            SqlDataReader reader = fetchCont.ExecuteReader();
            while (reader.Read()){
                String test = reader.GetString(1);

                contPlcHldr.Controls.Add(BuildItem(reader.GetSqlValue(1).ToString(), reader.GetSqlValue(2).ToString(), reader.GetSqlValue(3).ToString(), reader.GetSqlValue(4).ToString()));

            }
        }
        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("./default.aspx");
        }

        private item BuildItem(string imgUrl, string hlText, string url, string desc)
        {
            item newItem = (item)Page.LoadControl("Controls/item.ascx");
            newItem.Desc = desc;
            newItem.HLSrc = url;
            newItem.HLText = hlText;
            newItem.ImgSrc = imgUrl;
            return newItem;
        }

    }
}