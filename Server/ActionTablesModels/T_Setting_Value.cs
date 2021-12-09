using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    public partial class T_Setting_Value
    {
        [Key]
        [StringLength(30)]
        public string SettingID { get; set; }
        [Key]
        [StringLength(50)]
        public string OptionValue { get; set; }
        [StringLength(255)]
        public string OptionText { get; set; }

        [ForeignKey(nameof(SettingID))]
        [InverseProperty(nameof(T_Setting.T_Setting_Values))]
        public virtual T_Setting Setting { get; set; }
    }
}
