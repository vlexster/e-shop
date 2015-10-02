using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace e_shop
{
    public partial class addItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((string)Session["role"]) != "admin")
            {
                Response.Redirect("./default.aspx");
            }
            itemPV.SetImgSrc("");
            itemPV.SetHLSrc("", "./");
            itemPV.SetDesc("");
        }
        public void Preview()
        {
            if(imgSrc!=null && imgSrc.Text!="Image source")itemPV.SetImgSrc(imgSrc.Text);
            if (HLTxt != null && HLsrc != null && HLTxt.Text != "Hyperlink text" && HLsrc.Text != "Hyperlink source") itemPV.SetHLSrc(HLTxt.Text, HLsrc.Text);
            if(Desctxt!=null && Desctxt.Text != "Description")itemPV.SetDesc(Desctxt.Text);
        }
        protected void imgSrc_TextChanged(object sender, EventArgs e)
        {
            Preview();

        }

        protected void HLTxt_TextChanged(object sender, EventArgs e)
        {
            Preview();
        }

        protected void HLsrc_TextChanged(object sender, EventArgs e)
        {
            Preview();
        }

        protected void Desctxt_TextChanged(object sender, EventArgs e)
        {
            Preview();
        }

        protected void Submit(object sender, EventArgs e)
        {
            MySqlConnection dbCon = new MySqlConnection("Database=eshop;Data Source=localhost; User Id=eshop_usr; Password=WNAQWdE9GFEpXLts");
            dbCon.Open();
            MySqlCommand AddItem = dbCon.CreateCommand();
            AddItem.CommandText = "INSERT INTO items (`imgSrc`, `hlText`, `hlSrc`, `desc` ) VALUES('" + imgSrc.Text.ToString() + "','" + HLTxt.Text.ToString() + "','" + HLsrc.Text.ToString() + "','" + Desctxt.Text.ToString() + "');";
            MySqlDataReader read = AddItem.ExecuteReader();
            read.Close();
            dbCon.Close();
            Response.Redirect("./default.aspx");
        }
    }
}