using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Keyless]
    [Table("T_DataCapture")]
    public partial class T_DataCapture
    {
        public int CaptureID { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public string ModelData { get; set; }
        [Required]
        [StringLength(10)]
        public string ViewMode { get; set; }
        [Required]
        [StringLength(10)]
        public string AssignmentMode { get; set; }
        public int SortOrder { get; set; }
    }
}
