using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ActivityTypeDef")]
    public partial class T_ActivityTypeDef
    {
        public T_ActivityTypeDef()
        {
            InversePreviousActivity = new HashSet<T_ActivityTypeDef>();
            T_ActivityType_ResultLinks = new HashSet<T_ActivityType_ResultLink>();
        }

        [Key]
        [StringLength(10)]
        public string ActivityTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public bool RequiresModel { get; set; }
        public bool RequiresClosureReason { get; set; }
        public bool? RequiresAgenda { get; set; }
        public bool? IsPhoneCall { get; set; }
        public bool? IsEmail { get; set; }
        public bool? IsVisit { get; set; }
        [StringLength(10)]
        public string PreviousActivityID { get; set; }
        public bool? IsSelectable { get; set; }
        public int? SortOrder { get; set; }
        public long? Bitmask { get; set; }
        public int? ManualListOrder { get; set; }

        [ForeignKey(nameof(PreviousActivityID))]
        [InverseProperty(nameof(T_ActivityTypeDef.InversePreviousActivity))]
        public virtual T_ActivityTypeDef PreviousActivity { get; set; }
        [InverseProperty(nameof(T_ActivityTypeDef.PreviousActivity))]
        public virtual ICollection<T_ActivityTypeDef> InversePreviousActivity { get; set; }
        [InverseProperty(nameof(T_ActivityType_ResultLink.PlanActivityType))]
        public virtual ICollection<T_ActivityType_ResultLink> T_ActivityType_ResultLinks { get; set; }
    }
}
