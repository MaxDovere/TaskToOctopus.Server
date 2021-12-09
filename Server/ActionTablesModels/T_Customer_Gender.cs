using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Customer_Gender")]
    public partial class T_Customer_Gender
    {
        [Key]
        [StringLength(1)]
        public string GenderID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
