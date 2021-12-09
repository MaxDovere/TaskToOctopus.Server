using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Customer_MaritalStatusDef")]
    public partial class T_Customer_MaritalStatusDef
    {
        [Key]
        [StringLength(1)]
        public string MaritalStatusID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
