using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_User_NotificationDef")]
    public partial class T_User_NotificationDef
    {
        [Key]
        [StringLength(30)]
        public string NotifyID { get; set; }
        [Required]
        [StringLength(10)]
        public string NotifyGroupID { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(255)]
        public string Note { get; set; }
        public int SortOrder { get; set; }
        public bool DefaultValue { get; set; }
        public bool AllowMinuteBefore { get; set; }
    }
}
