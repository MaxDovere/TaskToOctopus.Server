using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TaskToOctopus.Server.Models
{
    public partial class MainMessageNotification
    {
        public MainMessageNotification()
        {
            Notifications = new HashSet<Notification>();
        }

        [Key]
        public int id { get; set; }
        public Guid Guid { get; set; }
        [Required]
        public string Message { get; set; }
        public string Status { get; set; }

        [InverseProperty(nameof(Notification.Message))]
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
