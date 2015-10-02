using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_shop
{
    public partial class item : System.Web.UI.UserControl
    {            
        protected void Page_Load(object sender, EventArgs e)
        {
            this.iDescr.Text = this.Desc;
            this.iImg.ImageUrl = this.ImgSrc;
            this.iHLink.Text = this.HLText;
            this.iHLink.NavigateUrl = this.HLSrc;
        }
        public item()
        {

        }
        public item(String imgSrc, String hlTxt, String url, String Descr)
        {

            this.iImg.ImageUrl = imgSrc;
            this.iHLink.Text = hlTxt;
            this.iHLink.NavigateUrl = url;
            this.iDescr.Text = Descr;
            /*this.setImgURL(imgSrc);
            this.setHL(hlTxt, url);
            this.setDescr(Descr);*/
        }
        public void setImgURL(String url)
        {
            this.iImg.ImageUrl = url;
        }
        public void setHL(String hlTxt, String url)
        {
            this.iHLink.NavigateUrl = url;
            this.iHLink.Text = hlTxt;
        }
        public void setDescr(String desc)
        {
            this.iDescr.Text = desc;
        }

        public string Desc
        {
            get;
            set;
        }
        public string HLText
        {
            get;
            set;
        }
        public string HLSrc
        {
            get;
            set;
        }
        public string ImgSrc
        {
            get;
            set;
        }
    }
}