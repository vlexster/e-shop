using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

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
        }
        protected void log_checker(object sender, EventArgs e)
        {

        }
        private void loadCont()
        {
            int size=1;
            MySqlConnection dbCon = new MySqlConnection("Database=eshop;Data Source=localhost; User Id=eshop_usr; Password=WNAQWdE9GFEpXLts");
            dbCon.Open();
            MySqlCommand fetchSize = dbCon.CreateCommand();
            fetchSize.CommandText = "SELECT COUNT(*) FROM items;";
            object sizeRes = fetchSize.ExecuteScalar();
            if (sizeRes!=null){
                size= Convert.ToUInt16(sizeRes);
            }
            //fetchSize.Close();            
            MySqlCommand fetchCont = dbCon.CreateCommand();
            fetchCont.CommandText = "SELECT * FROM items;";
            MySqlDataReader reader = fetchCont.ExecuteReader();
            while (reader.Read()){
                reader.GetString(0);

                contPlcHldr.Controls.Add(BuildItem(reader["imgSrc"].ToString(), reader["hlText"].ToString(), reader["hlSrc"].ToString(), reader["desc"].ToString()));

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




       /* protected void Button1_Click(object sender, EventArgs e)
        {
            /*MySqlConnection dbCon = new MySqlConnection("Database=eshop;Data Source=localhost; User Id=eshop_usr; Password=WNAQWdE9GFEpXLts");
            try
            {
                dbCon.Open();
                uid.Text = "success";
            }
            catch (Exception)
            {
                uid.Text = "fail";
            }
            item1.setImgURL("http://theinfosphere.org/images/thumb/f/fc/Planet_Express_Logo.svg/225px-Planet_Express_Logo.svg.png");
            item1.setHL("Google mofo!", "http://google.com");
            item1.setDescr("Just google it...");
        }*/
    }
}