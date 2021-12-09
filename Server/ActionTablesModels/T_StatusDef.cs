using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_StatusDef")]
    public partial class T_StatusDef
    {
        [Key]
        public short StatusID { get; set; }
        [Required]
        [StringLength(30)]
        public string StatusKey { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsOpen { get; set; }
        public bool? IsClosed { get; set; }
        public bool? IsSuccess { get; set; }
        public bool? IsFail { get; set; }
    }
}
