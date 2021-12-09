using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_VehicleChannelDef")]
    public partial class T_VehicleChannelDef
    {
        [Key]
        [StringLength(10)]
        public string VehicleChannelID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public bool IsUsed { get; set; }
        public bool IsNew { get; set; }
        public int? SortOrder { get; set; }
    }
}
