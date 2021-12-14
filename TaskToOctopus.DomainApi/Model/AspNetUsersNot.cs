using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskToOctopus.DomainApi.Model
{
    [Table("AspNetUsersNot")]
    public partial class AspNetUsersNot
    {
        [Key]
        [StringLength(128)]
        public string UserID { get; set; }
        [Key]
        public long LeadPlanActivityID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NotificationDateTimeUtc { get; set; }
        public short StatusID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NotifiedDateTimeUtc { get; set; }

        [ForeignKey(nameof(UserID))]
        [InverseProperty(nameof(AspNetUser.AspNetUsersNots))]
        public virtual AspNetUser User { get; set; }
    }
}
