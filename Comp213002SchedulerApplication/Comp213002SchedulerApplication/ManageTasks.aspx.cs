using Comp213002SchedulerApplication.AppCode.controls.util;
using Comp213002SchedulerApplication.SharedCode.controls.util;
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
        public string pagingHtml = "";

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
            string sql = BuildSearchSql();
            dt = DBUtil.Select(sql);
            changeSettings();
        }

        public void changeSettings()
        {
            Style primaryStyle = StyleMaker.makingStyle((string)Session["Font"], (string)Session["FontSize"], (string)Session["FontColor"]);

            if (primaryStyle != null)
            {
                this.Label1.ApplyStyle(primaryStyle);
                this.Label2.ApplyStyle(primaryStyle);
                this.Label3.ApplyStyle(primaryStyle);
                this.Label4.ApplyStyle(primaryStyle);
                this.Label5.ApplyStyle(primaryStyle);
                this.Label6.ApplyStyle(primaryStyle);
            }
        }

        private string BuildSearchSql() {
            SessionUtil.putSessionInfo("searchCondition", Request.QueryString);

            string subject = Request["subject"];
            string description = Request["description"];
            string scheduleStart = Request["scheduleStart"];
            string scheduleEnd = Request["scheduleEnd"];
            string actorName = Request["actorName"];
            string status = Request["status"];
            string conditions = "";

            if (!String.IsNullOrEmpty(subject)) conditions += " AND A.SUBJECT LIKE '%" + subject.Trim() + "%' ";
            if (!String.IsNullOrEmpty(description)) conditions += " AND A.DESCRIPTION LIKE '%" + description.Trim() + "%' ";
            if (!String.IsNullOrEmpty(scheduleStart)) conditions += " AND A.SCHEDULESTART >= '" + scheduleStart + "' ";
            if (!String.IsNullOrEmpty(scheduleEnd)) conditions += " AND A.SCHEDULEEND <= '" + scheduleEnd + "' ";
            if (!String.IsNullOrEmpty(actorName)) conditions += " AND B.USERNAME LIKE '%" + actorName.Trim() + "%' ";
            if (!String.IsNullOrEmpty(status) && "A" != status) conditions += " AND A.STATUS = '" + status + "' ";

            string sql = "select B.USERNAME, A.ID, A.SUBJECT, A.DESCRIPTION, CONVERT(VARCHAR(10), A.SCHEDULESTART,120) AS 'SCHEDULESTART'"
                + ", CONVERT(VARCHAR(10), A.SCHEDULEEND,120) AS 'SCHEDULEEND', A.STATUS from task A, USERINFO B "
                + "WHERE A.assignor = '" + UserInfoUtil.getLoginUserId()
                + "' AND A.USERINFO_ID = B.ID " + conditions + " AND A.DELETEFLAG = 0 order by A.schedulestart desc";

            return sql;
        }
    }
}