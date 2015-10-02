using System;

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

        public void SetImgSrc(String url)
        {
            this.iImg.ImageUrl = url;
        }
        public void SetHLSrc(String text, String url)
        {
            this.iHLink.Text = text;
            this.iHLink.NavigateUrl = url;
        }
        public void SetHLSrc(String text)
        {
            this.iHLink.Text = text;
        }
        public void SetDesc(String desc)
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