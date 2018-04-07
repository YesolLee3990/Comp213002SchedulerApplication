using Comp213002SchedulerApplication.AppCode.controls.models;
using Comp213002SchedulerApplication.AppCode.controls.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Web;

namespace Comp213002SchedulerApplication.AppCode.controls.task {
    public class TaskDAO{
        public Task GetTask(int id) {
            return DBUtil.SelectOne<Task>("SELECT * FROM TASK WHERE ID = '" + id + "'");
        }

        public Result SaveTask(Task task) {
            Result result = new Result();
            try {
                string sql = "";
                if (task.Id != 1) sql = DBUtil.BuildUpdateQuery(task, new String[]{"SUBJECT", "ASSIGNOR", "DESCRIPTION", "PRIRORITY", "SCHEDULESTART", "SCHEDULEEND", "RESULT", "STATUS"});
                else sql = DBUtil.BuildInsertQuery(task);
                
                int cnt = DBUtil.Execute(sql);
                result.Success = cnt > 0;
            }
            catch(Exception e) {
                result.Success = false;
                result.ErrorMsg = e.Message;
            }
            return result;
        }

        public UserInfo[] SearchUser(string name) {
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

        public UserInfo getAssignerInfo(Task task) {
            return (UserInfo)DBUtil.SelectOneById<UserInfo>(task.Assignor);
        }
    }
}