using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Sequence")]
    [Index(nameof(ActivityResultID), nameof(ActionStep), nameof(SequenceParam), nameof(ActivityTypeID), nameof(BrandBusinessUnitID), Name = "IX_T_Sequence", IsUnique = true)]
    public partial class T_Sequence
    {
        public T_Sequence()
        {
            T_Sequence_Actions = new HashSet<T_Sequence_Action>();
        }

        [Key]
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

        [InverseProperty(nameof(T_Sequence_Action.Sequence))]
        public virtual ICollection<T_Sequence_Action> T_Sequence_Actions { get; set; }
    }
}
