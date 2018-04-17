using Comp213002SchedulerApplication.SharedCode.controls.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp213002SchedulerApplication {
    public partial class ErrorDetail : System.Web.UI.Page {

        private void Page_PreInit(object sender, EventArgs e)
        {
            string temp = (string)Session["theme"];
            if (StyleMaker.theme == null)
            {
                if (StyleMaker.theme == null || StyleMaker.theme.Equals("No change"))
                {
                    Page.Theme = null;
                }
                else
                {
                    StyleMaker.theme = (string)Session["theme"];
                }

            }

            if (StyleMaker.theme == null || StyleMaker.theme.Equals("Normal"))
            {
                Page.Theme = null;
            }
            else
            {
                if (!temp.Equals("No change"))
                {
                    StyleMaker.theme = (string)Session["theme"];
                }
                Page.Theme = StyleMaker.theme;
            }

        }
        protected void Page_Load(object sender, EventArgs e) {
            changeSettings();
        }

        public void changeSettings()
        {
            Style primaryStyle = StyleMaker.makingStyle((string)Session["Font"], (string)Session["FontSize"], (string)Session["FontColor"]);

            if (primaryStyle != null)
            {
                this.Label1.ApplyStyle(primaryStyle);
            }
        }
    }
}