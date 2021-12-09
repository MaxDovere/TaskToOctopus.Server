using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Setting_Group")]
    public partial class T_Setting_Group
    {
        public T_Setting_Group()
        {
            T_Settings = new HashSet<T_Setting>();
        }

        [Key]
        public int SettingGroupID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int? SortOrder { get; set; }

        [InverseProperty(nameof(T_Setting.SettingGroup))]
        public virtual ICollection<T_Setting> T_Settings { get; set; }
    }
}
