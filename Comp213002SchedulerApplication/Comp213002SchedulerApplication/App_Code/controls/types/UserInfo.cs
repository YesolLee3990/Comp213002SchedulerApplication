using System;

namespace Comp213002SchedulerApplication.App_Code.controls.types {
    public class UserInfo {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public char UserType { get; set; }
        public char EmployeeStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}