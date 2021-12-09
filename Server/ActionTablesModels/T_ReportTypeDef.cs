using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ReportTypeDef")]
    public partial class T_ReportTypeDef
    {
        [Key]
        public int ReportID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        [StringLength(100)]
        public string FileName { get; set; }
        [StringLength(50)]
        public string DateSuffixFormatStr { get; set; }
        [StringLength(50)]
        public string TaskID { get; set; }
        public string ReportDataJson { get; set; }

        [ForeignKey(nameof(TaskID))]
        [InverseProperty(nameof(T_Task.T_ReportTypeDefs))]
        public virtual T_Task Task { get; set; }
    }
}
