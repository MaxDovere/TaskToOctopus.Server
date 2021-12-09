using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ActivityType_ResultLink")]
    public partial class T_ActivityType_ResultLink
    {
        [Key]
        [StringLength(10)]
        public string PlanActivityTypeID { get; set; }
        [Key]
        [StringLength(20)]
        public string FirstActivityResultID { get; set; }
        [Key]
        [StringLength(20)]
        public string NextActivityResultID { get; set; }
        [StringLength(10)]
        public string DoneActivityTypeID { get; set; }
        public short? ResultStatusID { get; set; }
        public int? SortOrder { get; set; }
        public bool Active { get; set; }
        public bool Global { get; set; }
        [Required]
        [StringLength(20)]
        public string ActivityResultID { get; set; }
        public bool? RequiresPhone { get; set; }
        public bool? RequiresEmail { get; set; }
        [StringLength(20)]
        public string RequiresProcessActionID { get; set; }
        [StringLength(20)]
        public string OnlyProcessActionID { get; set; }
        public int? DealerIDOnly { get; set; }
        public int? DealerBrandIDOnly { get; set; }
        [StringLength(5)]
        public string SalesDepartmentIDOnly { get; set; }
        [StringLength(20)]
        public string ExclProcessActionID { get; set; }
        [StringLength(50)]
        public string Description { get; set; }

        [ForeignKey(nameof(PlanActivityTypeID))]
        [InverseProperty(nameof(T_ActivityTypeDef.T_ActivityType_ResultLinks))]
        public virtual T_ActivityTypeDef PlanActivityType { get; set; }
    }
}
