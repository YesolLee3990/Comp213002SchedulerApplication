using Comp213002SchedulerApplication.App_Code.controls.models;
using Comp213002SchedulerApplication.App_Code.controls.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Web;

namespace Comp213002SchedulerApplication.App_Code.controls.task {
    public class TaskDAO{
        string columns = "ID, USERINFO_ID, ASSIGNOR";
        public Task GetTask(int id) {
            return DBUtil.SelectOne<Task>("SELECT * FROM TASK WHERE ID = '" + id + "'");
        }

        public Result SaveTask(Task task) {
            Result result = new Result();
            try {
                string sql = DBUtil.BuildInsertQuery(task);
                int cnt = DBUtil.Execute(sql);
                result.Success = cnt > 0;
            }
            catch(Exception e) {
                result.Success = false;
                result.ErrorMsg = e.Message;
            }
            return result;
        }

        internal UserInfo[] SearchUser(string name) {
            DataTable dt = DBUtil.Select("SELECT * FROM USERINFO WHERE USERNAME LIKE '%" + name + "%'");
            if (dt.Rows.Count >= 0) {
                UserInfo[] users = new UserInfo[dt.Rows.Count];
                for(int i=0;i< dt.Rows.Count; i++) {
                    DataRow dr = dt.Rows[i];
                    users[i] = new UserInfo() { Id = (int)dr["Id"], UserId = (string)dr["UserId"], UserName = (string)dr["UserName"] };
                }
                return users;
            }
            return null;
        }
    }
}