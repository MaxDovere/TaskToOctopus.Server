using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ScriptTypeDef")]
    public partial class T_ScriptTypeDef
    {
        public T_ScriptTypeDef()
        {
            T_ReferenceChannelCode_ScriptTypes = new HashSet<T_ReferenceChannelCode_ScriptType>();
            T_ScriptDefs = new HashSet<T_ScriptDef>();
        }

        [Key]
        [StringLength(10)]
        public string ScriptTypeID { get; set; }
        public short ScriptOptionTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public bool HasSubject { get; set; }
        public bool IsMessageScript { get; set; }
        public bool Active { get; set; }

        [ForeignKey(nameof(ScriptOptionTypeID))]
        [InverseProperty(nameof(T_ScriptOptionTypeDef.T_ScriptTypeDefs))]
        public virtual T_ScriptOptionTypeDef ScriptOptionType { get; set; }
        [InverseProperty(nameof(T_ReferenceChannelCode_ScriptType.ScriptType))]
        public virtual ICollection<T_ReferenceChannelCode_ScriptType> T_ReferenceChannelCode_ScriptTypes { get; set; }
        [InverseProperty(nameof(T_ScriptDef.ScriptType))]
        public virtual ICollection<T_ScriptDef> T_ScriptDefs { get; set; }
    }
}
