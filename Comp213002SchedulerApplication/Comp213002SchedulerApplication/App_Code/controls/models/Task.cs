using System;

namespace Comp213002SchedulerApplication.App_Code.controls.models {
    public class Task {
        public int Id { get; set; }
        public string UserInfo_Id { get; set; }
        public string Assignor { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public char Priority { get; set; }
        public char Status { get; set; }
        public DateTime ScheduleStart { get; set; }
        public DateTime ScheduleEnd { get; set; }
        public char DeleteFlag { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}