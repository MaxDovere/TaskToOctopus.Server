using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ColorDef")]
    public partial class T_ColorDef
    {
        [Key]
        [StringLength(30)]
        public string TableKey { get; set; }
        [Key]
        [StringLength(50)]
        public string ID { get; set; }
        [StringLength(255)]
        public string BgColor { get; set; }
        public int? BgTransparency { get; set; }
        [StringLength(255)]
        public string Color { get; set; }
    }
}
