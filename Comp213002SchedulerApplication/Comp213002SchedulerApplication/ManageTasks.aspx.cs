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

        public DataTable dt;
        protected void Page_Load(object sender, EventArgs e) {
            dt = DBUtil.Select("select B.USERNAME, A.* from task A, USERINFO B where A.assignor = '" + UserInfoUtil.getLoginUserId() + "' AND A.USERINFO_ID = B.ID order by A.schedulestart desc");
        }
    }
}