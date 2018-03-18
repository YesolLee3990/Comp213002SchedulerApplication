using Comp213002SchedulerApplication.App_Code.controls.types;
using Comp213002SchedulerApplication.App_Code.controls.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Web;

namespace Comp213002SchedulerApplication.App_Code.controls.task {
    public class TaskDAO{
        public Task GetTask(int id) {
            return DBUtil.SelectOne<Task>("SELECT * FROM TASK WHERE ID = '" + id + "'");
        }
    }
}