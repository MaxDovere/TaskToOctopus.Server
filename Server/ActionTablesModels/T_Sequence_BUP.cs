using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Keyless]
    [Table("T_Sequence_BUP")]
    public partial class T_Sequence_BUP
    {
        [Required]
        [StringLength(59)]
        public string SequenceID { get; set; }
        [Required]
        [StringLength(20)]
        public string ActivityResultID { get; set; }
        public short? LevelID { get; set; }
        public short? ActionStep { get; set; }
        [StringLength(20)]
        public string SequenceParam { get; set; }
        [StringLength(10)]
        public string ActivityTypeID { get; set; }
        public int? BrandBusinessUnitID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public bool? CanOverride { get; set; }
    }
}
