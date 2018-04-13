using Comp213002SchedulerApplication.AppCode.controls.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp213002SchedulerApplication {
    public partial class ErrorList : System.Web.UI.Page {
        public DataTable dt;
        public DataTable userList;

        protected void Page_Load(object sender, EventArgs e) {
            SetUserList();
            string sql = BuildSearchSql();
            dt = DBUtil.Select(sql);
        }

        private void SetUserList() {
            userList = DBUtil.Select("SELECT * FROM USERINFO");
        }
        private string BuildSearchSql() {
            SessionUtil.putSessionInfo("searchCondition", Request.QueryString);

            string errorMsg = Request["errorMsg"];
            string errorDate = Request["errorDate"];
            string userId = Request["userId"];
            string conditions = "";

            if (!String.IsNullOrEmpty(errorMsg)) conditions += " AND A.ERRORMSG LIKE '%" + errorMsg.Trim() + "%' ";
            if (!String.IsNullOrEmpty(errorDate)) conditions += " AND CONVERT(char(10), A.CREATEDATE, 120) = '" + errorDate + "' ";
            if (!String.IsNullOrEmpty(userId) && userId!="A") conditions += " AND A.USERID = '" + userId + "' ";

            string sql = "select A.ID, B.USERNAME, "
                + " CONVERT(VARCHAR(10), A.CREATEDATE, 120) AS 'CREATEDATE', A.ERRORMSG FROM ERROR A, USERINFO B "
                + "WHERE A.USERID = B.ID " + conditions + " order by A.CREATEDATE desc";

            return sql;
        }
    }
}