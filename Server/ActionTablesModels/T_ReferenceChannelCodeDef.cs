using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ReferenceChannelCodeDef")]
    public partial class T_ReferenceChannelCodeDef
    {
        public T_ReferenceChannelCodeDef()
        {
            T_ReferenceChannelCode_ScriptTypes = new HashSet<T_ReferenceChannelCode_ScriptType>();
        }

        [Key]
        [StringLength(4)]
        public string ChannelCodeID { get; set; }
        [Required]
        [StringLength(3)]
        public string ReferenceTypeID { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public long? Bitmask { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsMobile { get; set; }
        public bool? VoiceCall { get; set; }

        [ForeignKey(nameof(ReferenceTypeID))]
        [InverseProperty(nameof(T_ReferenceTypeDef.T_ReferenceChannelCodeDefs))]
        public virtual T_ReferenceTypeDef ReferenceType { get; set; }
        [InverseProperty(nameof(T_ReferenceChannelCode_ScriptType.ChannelCode))]
        public virtual ICollection<T_ReferenceChannelCode_ScriptType> T_ReferenceChannelCode_ScriptTypes { get; set; }
    }
}
