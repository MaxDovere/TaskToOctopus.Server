using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Setting_Type")]
    public partial class T_Setting_Type
    {
        public T_Setting_Type()
        {
            T_Settings = new HashSet<T_Setting>();
        }

        [Key]
        [StringLength(20)]
        public string SettingTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        [StringLength(100)]
        public string TypeName { get; set; }
        [Required]
        [StringLength(100)]
        public string TypeFullName { get; set; }
        [Required]
        [StringLength(50)]
        public string TargetField { get; set; }

        [InverseProperty(nameof(T_Setting.SettingType))]
        public virtual ICollection<T_Setting> T_Settings { get; set; }
    }
}
