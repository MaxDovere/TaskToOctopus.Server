using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Process_ActionStructure")]
    public partial class T_Process_ActionStructure
    {
        [Key]
        [StringLength(10)]
        public string ProcessActionID { get; set; }
        [Key]
        public int SequenceNumber { get; set; }
        [Required]
        [StringLength(10)]
        public string ActivityTypeID { get; set; }
        public int StepNumber { get; set; }
        [StringLength(255)]
        public string ViewPage { get; set; }
        [StringLength(255)]
        public string EditPage { get; set; }
        [StringLength(255)]
        public string ViewPartial { get; set; }
        [StringLength(255)]
        public string EditPartial { get; set; }
        public bool InterviewLinked { get; set; }

        [ForeignKey(nameof(ProcessActionID))]
        [InverseProperty(nameof(T_Process_ActionDef.T_Process_ActionStructures))]
        public virtual T_Process_ActionDef ProcessAction { get; set; }
    }
}
