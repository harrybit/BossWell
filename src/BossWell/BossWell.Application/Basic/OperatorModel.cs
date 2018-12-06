using System;

namespace BossWell.Application
{
    public class OperatorModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string RoleId { get; set; }
        public string LoginToken { get; set; }
        public DateTime LoginTime { get; set; }
        public string HeadIcon { get; set; }
        public bool IsSystem { get; set; }
    }
}