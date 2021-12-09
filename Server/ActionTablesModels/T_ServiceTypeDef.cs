using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ServiceTypeDef")]
    public partial class T_ServiceTypeDef
    {
        [Key]
        [StringLength(5)]
        public string ServiceTypeID { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public bool IsService { get; set; }
        public bool IsPartsSale { get; set; }
        public int? SortOrder { get; set; }
    }
}
