using Comp213002SchedulerApplication.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp213002SchedulerApplication {
    public partial class TemplateMain : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            tmplList.DataSource = DBUtil.Select("SELECT * FROM USERINFO");
            //DataTable dt = new DataTable();

        }
    }
}