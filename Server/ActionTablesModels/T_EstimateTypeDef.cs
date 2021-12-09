using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_EstimateTypeDef")]
    public partial class T_EstimateTypeDef
    {
        [Key]
        public int EstimateTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int? SortOrder { get; set; }
    }
}
