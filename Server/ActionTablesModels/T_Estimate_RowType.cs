using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Estimate_RowType")]
    public partial class T_Estimate_RowType
    {
        [Key]
        public int EstimateRowTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int? GroupSortOrder { get; set; }
        [StringLength(50)]
        public string EstimateGroupField { get; set; }
        [StringLength(50)]
        public string ContractGroupField { get; set; }
    }
}
