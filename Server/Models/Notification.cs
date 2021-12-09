using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TaskToOctopus.Server.Models
{
    public partial class Notification
    {
        [Key]
        public int Id { get; set; }
        public int MessageId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime WhenDate { get; set; }
        public int ByWhoId { get; set; }
        public int? ToWhoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeletedDate { get; set; }

        [ForeignKey(nameof(ByWhoId))]
        [InverseProperty(nameof(UserWhoNotification.NotificationByWhos))]
        public virtual UserWhoNotification ByWho { get; set; }
        [ForeignKey(nameof(MessageId))]
        [InverseProperty(nameof(MainMessageNotification.Notifications))]
        public virtual MainMessageNotification Message { get; set; }
        [ForeignKey(nameof(ToWhoId))]
        [InverseProperty(nameof(UserWhoNotification.NotificationToWhos))]
        public virtual UserWhoNotification ToWho { get; set; }
    }
}
