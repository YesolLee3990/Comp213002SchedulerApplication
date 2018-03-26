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
        public Task Get(string id) {
            Task task = null;
            try { 
                task = dao.GetTask(int.Parse(id));
            }catch(Exception e) {
                
            }
            if (id == "0" || task == null) {
                task = new Task() { Id = 1, Assignor = UserInfoUtil.getLoginUserId() };
            }
            return task;
        }

        [WebMethod(EnableSession = true)]
        [Route("api/task/searchUser/{name}")]
        [HttpGet]
        public UserInfo[] SearchUser(string name) {
            return dao.SearchUser(name);
        }
        

        [WebMethod(EnableSession = true)]
        [Route("api/task/save")]
        [HttpPost]
        public Result Save(Task task) {
            return dao.SaveTask(task);
        }

        

        //// POST api/<controller>
        //public void Post([FromBody]string value) {
        //}
    }
}