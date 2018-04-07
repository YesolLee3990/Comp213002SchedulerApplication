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
            string sql = BuildSearchSql();
            dt = DBUtil.Select(sql);
        }

        private string BuildSearchSql() {
            string subject = Request["subject"].Trim();
            string description = Request["description"].Trim();
            string scheduleStart = Request["scheduleStart"].Trim();
            string scheduleEnd = Request["scheduleEnd"].Trim();
            string actorName = Request["actorName"].Trim();
            string status = Request["status"].Trim();
            string conditions = "";

            if (!String.IsNullOrEmpty(subject)) conditions += " AND A.SUBJECT LIKE '%" + subject + "%' ";
            if (!String.IsNullOrEmpty(description)) conditions += " AND A.DESCRIPTION LIKE '%" + description + "%' ";
            if (!String.IsNullOrEmpty(scheduleStart)) conditions += " AND A.SCHEDULESTART >= '" + scheduleStart + "' ";
            if (!String.IsNullOrEmpty(scheduleEnd)) conditions += " AND A.SCHEDULEEND <= '" + scheduleEnd + "' ";
            if (!String.IsNullOrEmpty(actorName)) conditions += " AND B.USERNAME LIKE '%" + actorName + "%' ";
            if (!String.IsNullOrEmpty(status)) conditions += " AND A.STATUS = '" + status + "' ";

            string sql = "select B.USERNAME, A.* from task A, USERINFO B "
                + "WHERE A.assignor = '" + UserInfoUtil.getLoginUserId()
                + "' AND A.USERINFO_ID = B.ID order " + conditions + " by A.schedulestart desc";

            return sql;
        }
    }
}