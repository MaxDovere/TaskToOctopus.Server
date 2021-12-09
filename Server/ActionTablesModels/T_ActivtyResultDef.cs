using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ActivtyResultDef")]
    public partial class T_ActivtyResultDef
    {
        [Key]
        [StringLength(20)]
        public string ActivityResultID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(50)]
        public string BtnLabel { get; set; }
        [StringLength(50)]
        public string Glyphicon { get; set; }
        [StringLength(255)]
        public string Icon { get; set; }
        [StringLength(50)]
        public string BtnClass { get; set; }
        public bool HasChildActions { get; set; }
        [StringLength(255)]
        public string DataAction { get; set; }
        [StringLength(50)]
        public string DefaultActionBehaviour { get; set; }
        public int? ClosureReasonID { get; set; }
        [StringLength(50)]
        public string TimeBehaviour { get; set; }
        [StringLength(50)]
        public string TimeUnit { get; set; }
        public int? TimeAdd { get; set; }
        [StringLength(50)]
        public string UserBehaviour { get; set; }
        [StringLength(50)]
        public string PlanActivityBehaviour { get; set; }
        [StringLength(10)]
        public string PlanActivityTypeID { get; set; }
        [StringLength(50)]
        public string ChangeProcessActionID { get; set; }
        public bool? RequiresPhone { get; set; }
        public bool? RequiresEmail { get; set; }
        [StringLength(20)]
        public string RequiresProcessActionID { get; set; }
        [StringLength(20)]
        public string OnlyProcessActionID { get; set; }
        [StringLength(20)]
        public string ExclProcessActionID { get; set; }
    }
}
