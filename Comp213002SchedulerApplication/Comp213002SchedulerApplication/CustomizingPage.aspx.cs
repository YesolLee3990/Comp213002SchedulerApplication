using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp213002SchedulerApplication
{
    public partial class CustomizingPage : System.Web.UI.Page
    {

        public string themeStr = "";
        public string fontStr = "";
        public string fontSizeStr = "";
        public string fontColorStr = "";
        List<String> themeSource = new List<String>();
        List<String> fontSource = new List<String>();
        List<String> fontSizeSource = new List<String>();
        List<String> fontCOlorSource = new List<String>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                initSource();
                
            }

        }

        public void initSource()
        {
            themeSource.Add("Normal");
            themeSource.Add("Dark");
            themeSource.Add("Blue");
            themeSource.Add("Pink");
            this.ddTheme.DataSource = themeSource;
            this.ddTheme.DataBind();

            fontSource.Add("Arial");
            fontSource.Add("Calibri");
            fontSource.Add("Algerian");
            fontSource.Add("Headline R");
            this.ddFont.DataSource = fontSource;
            this.ddFont.DataBind();

            fontSizeSource.Add("Small");
            fontSizeSource.Add("Medium");
            fontSizeSource.Add("Large");
            fontSizeSource.Add("XLarge");
            this.ddFontSize.DataSource = fontSizeSource;
            this.ddFontSize.DataBind();

            fontCOlorSource.Add("Black");
            fontCOlorSource.Add("Red");
            fontCOlorSource.Add("Blue");
            fontCOlorSource.Add("Green");
            fontCOlorSource.Add("White");
            fontCOlorSource.Add("Yellow");
            this.ddFontColor.DataSource = fontCOlorSource;
            this.ddFontColor.DataBind();
        }

        protected void ddTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["theme"] = this.ddTheme.SelectedValue;
        }

        protected void ddFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Font"] = this.ddFont.SelectedValue;
        }

        protected void ddFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["FontSize"] = this.ddFontSize.SelectedValue;
        }

        protected void ddFontColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["FontColor"] = this.ddFontColor.SelectedValue;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["theme"] = this.ddTheme.SelectedValue;
            Session["Font"] = this.ddFont.SelectedValue;
            Session["FontSize"] = this.ddFontSize.SelectedValue;
            Session["FontColor"] = this.ddFontColor.SelectedValue;

            string script = @"window.opener.location.reload(true);self.close();";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", script, true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["theme"] = "none";
            Session["Font"] = "none";
            Session["FontSize"] = "none";
            Session["FontColor"] = "none";
            string script = @"window.opener.location.reload(true);self.close();";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", script, true);
        }
    }
}