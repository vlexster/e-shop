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
            //SqlConnection dbCon = new SqlConnection("Database=eshop;Data Source=localhost; User Id=eshop_usr; Password=WNAQWdE9GFEpXLts");
            SqlConnection dbCon = new SqlConnection("server=192.168.184.134; initial catalog=eshop; uid=eshop_usr; pwd=eshop_usr"); 
            dbCon.Open();
            SqlCommand AddItem = dbCon.CreateCommand();
            AddItem.CommandText = "INSERT INTO items (imgSrc, hlText, hlSrc, descr) values (@imgSrc, @hlText, @hlSrc, @desc)";
            //SqlDataReader read = AddItem.ExecuteReader();
            AddItem.Parameters.Add("@imgSrc", SqlDbType.VarChar);
            AddItem.Parameters["@imgSrc"].Value = imgSrc.Text.ToString();
            AddItem.Parameters.Add("@hlText", SqlDbType.VarChar);
            AddItem.Parameters["@hlText"].Value = HLTxt.Text.ToString();
            AddItem.Parameters.Add("@hlSrc", SqlDbType.VarChar);
            AddItem.Parameters["@hlSrc"].Value = HLsrc.Text.ToString();
            AddItem.Parameters.Add("@desc", SqlDbType.VarChar);
            AddItem.Parameters["@desc"].Value = Desctxt.Text.ToString();
            AddItem.ExecuteNonQuery();
            //read.Close();
            dbCon.Close();
            Response.Redirect("./default.aspx");
        }
    }
}