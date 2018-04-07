using Comp213002SchedulerApplication.AppCode.controls.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp213002SchedulerApplication {
    public partial class ManageTasks : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            ListView1.DataSource = DBUtil.Select("select * from task where assignor = '" + UserInfoUtil.getLoginUserId() + "' order by schedulestart desc");
            ListView1.DataBind();
        }
    }
}