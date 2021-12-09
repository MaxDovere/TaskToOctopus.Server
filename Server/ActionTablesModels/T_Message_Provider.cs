using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Message_Provider")]
    public partial class T_Message_Provider
    {
        [Key]
        [StringLength(20)]
        public string MessageProviderID { get; set; }
        [StringLength(20)]
        public string ProviderID { get; set; }
        [Required]
        [StringLength(10)]
        public string ScriptTypeID { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public string Parameters { get; set; }
        public bool? IsScriptTypeDefault { get; set; }
        [StringLength(255)]
        public string DllName { get; set; }
        public bool UseProviderTemplate { get; set; }
    }
}
