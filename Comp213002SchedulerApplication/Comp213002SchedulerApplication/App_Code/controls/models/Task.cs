using System;

namespace Comp213002SchedulerApplication.App_Code.controls.models {
    public class Task {
        public int Id { get; set; } = 0;
        public int UserInfo_Id { get; set; } = 0;
        public int Assignor { get; set; } = 0;
        public string Subject { get; set; } = "";
        public string Description { get; set; } = "";
        public char Priority { get; set; } = '3';
        public char Status { get; set; } = 'S';
        public DateTime ScheduleStart { get; set; } = DateTime.Now;
        public DateTime ScheduleEnd { get; set; } = DateTime.Now;
        public char DeleteFlag { get; set; } = '0';
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}