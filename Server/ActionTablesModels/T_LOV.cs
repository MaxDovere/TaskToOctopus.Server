using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_LOV")]
    public partial class T_LOV
    {
        [Key]
        [StringLength(20)]
        public string LOVKey { get; set; }
        [Key]
        [StringLength(10)]
        public string LOVCode { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(30)]
        public string ShortDescription { get; set; }
        [StringLength(5)]
        public string TinyDescription { get; set; }
        public int? SortOrder { get; set; }
    }
}
