using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionModels
{
    [Table("T_SubscriptionParDef")]
    public partial class T_SubscriptionParDef
    {
        [Key]
        [StringLength(30)]
        public string ParameterID { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [StringLength(3)]
        public string PeriodBaseID { get; set; }
        public double? DefValue { get; set; }
        public double? MinValueApply { get; set; }
        public int Operator { get; set; }
        [StringLength(10)]
        public string GroupID { get; set; }
        public int? SortOrder { get; set; }
        public int? ProfileID { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
    }
}
