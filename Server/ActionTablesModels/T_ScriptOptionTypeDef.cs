using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ScriptOptionTypeDef")]
    public partial class T_ScriptOptionTypeDef
    {
        public T_ScriptOptionTypeDef()
        {
            T_ScriptTypeDefs = new HashSet<T_ScriptTypeDef>();
        }

        [Key]
        public short ScriptOptionTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public bool AllowHtml { get; set; }
        public bool AllowText { get; set; }

        [InverseProperty(nameof(T_ScriptTypeDef.ScriptOptionType))]
        public virtual ICollection<T_ScriptTypeDef> T_ScriptTypeDefs { get; set; }
    }
}
