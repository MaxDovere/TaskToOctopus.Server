using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ScriptDef")]
    public partial class T_ScriptDef
    {
        [Key]
        [StringLength(20)]
        public string ScriptID { get; set; }
        [Required]
        [StringLength(10)]
        public string ScriptTypeID { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public string SubjectText { get; set; }
        public string BodyText { get; set; }
        public bool? IsBodyHtml { get; set; }
        public bool? CreateCalendarLink { get; set; }

        [ForeignKey(nameof(ScriptTypeID))]
        [InverseProperty(nameof(T_ScriptTypeDef.T_ScriptDefs))]
        public virtual T_ScriptTypeDef ScriptType { get; set; }
    }
}
