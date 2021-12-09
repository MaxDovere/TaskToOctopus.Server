using System;
using System.ComponentModel.DataAnnotations;

namespace TaskToOctopus.Server.Models
{
    public class AspNetUsersNot
    {
        [Key]
        public string UserID {get; set;}
        [Key]
        public long LeadPlanActivityID {get; set;}
        public TimeSpan NotificationDateTimeUtc { get; set; }
        public short StatusID { get; set; }
        public DateTime NotifiedDateTimeUtc { get; set; }
    }
}
