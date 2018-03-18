using Comp213002SchedulerApplication.App_Code.controls.types;
using Comp213002SchedulerApplication.App_Code.controls.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Comp213002SchedulerApplication.App_Code.controls.task {
    [Route("api/task")]
    public class TaskController : ApiController {
        TaskDAO dao = new TaskDAO();
        [HttpGet]
        public Task Get(int id) {
            Task task = dao.GetTask(id);
            if (id == 0 || task == null) task = new Task() { Id = 1, Assignor = UserInfoUtil.getLoginUser().UserId };
            return task;
        }

        // POST api/<controller>
        public void Post([FromBody]string value) {
        }
    }
}