using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_NotificationTypeDef")]
    public partial class T_NotificationTypeDef
    {
        [Key]
        [StringLength(30)]
        public string NotificationTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int? SortOrder { get; set; }
        [StringLength(50)]
        public string ActivityRule { get; set; }
        [StringLength(50)]
        public string PlanActivityRule { get; set; }
        [StringLength(50)]
        public string TimeRuleRule { get; set; }
        [StringLength(50)]
        public string ActivityDefault { get; set; }
        [StringLength(50)]
        public string PlanActivityDefault { get; set; }
        [StringLength(50)]
        public string TimeRuleDefault { get; set; }
        [StringLength(2)]
        public string TimeUnitDefault { get; set; }
        public int? TimeAddDefault { get; set; }
        public TimeSpan? TimeSpecDefault { get; set; }
        public bool? TimeAllDaysDefault { get; set; }
        [StringLength(50)]
        public string HolidayMode { get; set; }
        public int? MonthNoDefault { get; set; }
        public int? DayNoDefault { get; set; }
        [StringLength(50)]
        public string DateFilterMode { get; set; }
        [StringLength(50)]
        public string DateFilterDefault { get; set; }
        public int? DateMonthUnitDefault { get; set; }
    }
}
