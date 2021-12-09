using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ClosureReasonDef")]
    public partial class T_ClosureReasonDef
    {
        [Key]
        public int ClosureReasonID { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public bool IsSold { get; set; }
        public int? SortOrder { get; set; }
        [StringLength(10)]
        public string ClosureParameterKey { get; set; }
        [StringLength(5)]
        public string SalesDepartmentID { get; set; }
    }
}
