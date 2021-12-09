using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_FinancialOptionDef")]
    public partial class T_FinancialOptionDef
    {
        [Key]
        [StringLength(10)]
        public string FinancialOptionID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int? SortOrder { get; set; }
        public bool IsFinancial { get; set; }
    }
}
