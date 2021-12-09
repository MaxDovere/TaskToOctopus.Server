using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ScriptParameter")]
    [Index(nameof(FriendlyName), Name = "IX_T_ScriptParameter", IsUnique = true)]
    public partial class T_ScriptParameter
    {
        [Key]
        [StringLength(50)]
        public string ParameterName { get; set; }
        [Required]
        [StringLength(50)]
        public string FriendlyName { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(100)]
        public string TableName { get; set; }
        [StringLength(255)]
        public string FieldNames { get; set; }
        public string FIeldFormats { get; set; }
        [StringLength(255)]
        public string MorningText { get; set; }
        [StringLength(255)]
        public string AfternoonText { get; set; }
        [StringLength(255)]
        public string EveningText { get; set; }
        public string FormatString { get; set; }
        public bool? MassiveValid { get; set; }
        public bool? CanBeOptional { get; set; }
        [StringLength(20)]
        public string GroupID { get; set; }
        public bool? Obsolete { get; set; }
    }
}
