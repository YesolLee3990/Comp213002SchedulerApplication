using Comp213002SchedulerApplication.App_Code.controls.models;
using Comp213002SchedulerApplication.App_Code.controls.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services;

namespace Comp213002SchedulerApplication.App_Code.controls.task {
    
    public class TaskController : ApiController {
        TaskDAO dao = new TaskDAO();

        [WebMethod(EnableSession = true)]
        [Route("api/task/{id}")]
        [HttpGet]
        public Task Get() {
            int id = 0;
            Task task = dao.GetTask(id);
            if (id == 0 || task == null) task = new Task() { Id = 1, Assignor = UserInfoUtil.getLoginUser().UserId };
            return task;
        }

        // POST api/<controller>
        public void Post([FromBody]string value) {
        }
    }
}