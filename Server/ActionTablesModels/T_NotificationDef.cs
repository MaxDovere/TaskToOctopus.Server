using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_NotificationDef")]
    public partial class T_NotificationDef
    {
        [Key]
        [StringLength(10)]
        public string NotificationID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public string SubjectText { get; set; }
        public string BodyText { get; set; }
        public bool AutoSend { get; set; }
    }
}
