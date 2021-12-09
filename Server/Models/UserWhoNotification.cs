using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TaskToOctopus.Server.Models
{
    public partial class UserWhoNotification
    {
        public UserWhoNotification()
        {
            NotificationByWhos = new HashSet<Notification>();
            NotificationToWhos = new HashSet<Notification>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public string Endpoint { get; set; }
        [Required]
        [StringLength(15)]
        public string Method { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeletedDate { get; set; }

        [InverseProperty(nameof(Notification.ByWho))]
        public virtual ICollection<Notification> NotificationByWhos { get; set; }
        [InverseProperty(nameof(Notification.ToWho))]
        public virtual ICollection<Notification> NotificationToWhos { get; set; }
    }
}
