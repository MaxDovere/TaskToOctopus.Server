using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Data_Provider")]
    public partial class T_Data_Provider
    {
        [Key]
        [StringLength(50)]
        public string ProviderID { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        [StringLength(10)]
        public string ProviderTypeID { get; set; }
    }
}
