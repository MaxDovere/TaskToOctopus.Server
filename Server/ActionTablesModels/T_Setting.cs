using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Setting")]
    public partial class T_Setting
    {
        public T_Setting()
        {
            T_Setting_Values = new HashSet<T_Setting_Value>();
        }

        [Key]
        [StringLength(30)]
        public string SettingID { get; set; }
        public int SettingGroupID { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        [StringLength(20)]
        public string SettingTypeID { get; set; }
        public int? SortOrder { get; set; }
        public bool DealerVisible { get; set; }
        public bool DealerOverride { get; set; }
        public string OptionValuesSql { get; set; }
        public long? NumValue { get; set; }
        [StringLength(255)]
        public string StringValue { get; set; }
        public bool? BitValue { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateValue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeValue { get; set; }
        public string DescriptionSql { get; set; }
        [StringLength(50)]
        public string ActionGroup { get; set; }
        public bool AllowDefault { get; set; }

        [ForeignKey(nameof(SettingGroupID))]
        [InverseProperty(nameof(T_Setting_Group.T_Settings))]
        public virtual T_Setting_Group SettingGroup { get; set; }
        [ForeignKey(nameof(SettingTypeID))]
        [InverseProperty(nameof(T_Setting_Type.T_Settings))]
        public virtual T_Setting_Type SettingType { get; set; }
        [InverseProperty(nameof(T_Setting_Value.Setting))]
        public virtual ICollection<T_Setting_Value> T_Setting_Values { get; set; }
    }
}
