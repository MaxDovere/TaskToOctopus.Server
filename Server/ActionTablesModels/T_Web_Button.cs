using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Web_Button")]
    public partial class T_Web_Button
    {
        [Key]
        public int ButtonID { get; set; }
        [Required]
        [StringLength(20)]
        public string FormKey { get; set; }
        [Required]
        [StringLength(50)]
        public string ButtonLabel { get; set; }
        [Required]
        public string Tooltip { get; set; }
        [StringLength(50)]
        public string Glyphicon { get; set; }
        [StringLength(255)]
        public string Icon { get; set; }
        public int SortOrder { get; set; }
        public int ButtonGroup { get; set; }
        public bool IsGlobal { get; set; }
        public long? Bitmask { get; set; }
        public long? ReferenceBitmask { get; set; }
        public long? RefChannelBitmask { get; set; }
        public long? ActivityTypeBitmask { get; set; }
        public string HtmlAttributes { get; set; }
    }
}
