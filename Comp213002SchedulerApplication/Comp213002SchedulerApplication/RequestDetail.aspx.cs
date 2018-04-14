using Comp213002SchedulerApplication.AppCode.controls.models;
using Comp213002SchedulerApplication.AppCode.controls.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comp213002SchedulerApplication {
    public partial class RequestDetail : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        [WebMethod]
        public static Result Reject(string id) {
            Result result = new Result();
            try {
                // re'J'ected
                DBUtil.Execute("UPDATE REQUESTTRANSACTION SET STATUS = 'J' WHERE ID = '" + id + "' ");
                // Send email about reject or and so forth..
                // 
            }
            catch (Exception e) {
                result.Success = false;
                result.ErrorMsg = e.Message;
            }
            return result;
        }

        [WebMethod]
        public static Result Accept(string id, string taskId, string dayoff) {
            Result result = new Result();
            
            try {
                DataRow task = DBUtil.SelectOne("SELECT USERINFO_ID, ID, SCHEDULESTART, SCHEDULEEND FROM TASK WHERE ID = '" + taskId + "' ");

                List<string> sqls = new List<string>();
                sqls.Add("UPDATE REQUESTTRANSACTION SET STATUS = 'F' WHERE ID = " + id + " ");

                if("T".Equals(dayoff)) {
                    sqls.Add("UPDATE TASK SET SCHEDULESTART = DATEADD(D, 1, SCHEDULESTART), SCHEDULEEND = DATEADD(D, 1, SCHEDULEEND)"
                        + " WHERE USERINFO_ID = '" + task["USERINFO_ID"] + "' AND SCHEDULESTART = (SELECT SCHEDULESTART FROM TASK WHERE ID = " + taskId + ")");
                } else {
                    sqls.Add("UPDATE TASK SET SCHEDULEEND = (SELECT NEWENDDATE FROM REQUESTTRANSACTION WHERE ID = " + id + "), "
                        + "SCHEDULESTART  = (SELECT NEWSTARTDATE FROM REQUESTTRANSACTION WHERE ID = " + id + ") WHERE ID = " + taskId);
                }
                
                DBUtil.ExecuteWithTransaction(sqls);
            }
            catch(Exception e) {
                result.Success = false;
                result.ErrorMsg = e.Message;
            }
            return result;
        }
    }
}