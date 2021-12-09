using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ReferenceChannelCode_ScriptType")]
    [Index(nameof(ChannelCodeID), nameof(ScriptTypeID), Name = "IX_T_ReferenceChannelCode_ScriptType", IsUnique = true)]
    public partial class T_ReferenceChannelCode_ScriptType
    {
        [Key]
        public int ReferenceChannelCodeScriptID { get; set; }
        [Required]
        [StringLength(4)]
        public string ChannelCodeID { get; set; }
        [Required]
        [StringLength(10)]
        public string ScriptTypeID { get; set; }

        [ForeignKey(nameof(ChannelCodeID))]
        [InverseProperty(nameof(T_ReferenceChannelCodeDef.T_ReferenceChannelCode_ScriptTypes))]
        public virtual T_ReferenceChannelCodeDef ChannelCode { get; set; }
        [ForeignKey(nameof(ScriptTypeID))]
        [InverseProperty(nameof(T_ScriptTypeDef.T_ReferenceChannelCode_ScriptTypes))]
        public virtual T_ScriptTypeDef ScriptType { get; set; }
    }
}
