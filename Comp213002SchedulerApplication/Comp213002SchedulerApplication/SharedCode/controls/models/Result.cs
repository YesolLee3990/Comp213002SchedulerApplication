using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comp213002SchedulerApplication.AppCode.controls.models {
    public class Result {
        public bool Success { get; set; } = true;
        public string ErrorMsg { get; set; } = "";
    }
}