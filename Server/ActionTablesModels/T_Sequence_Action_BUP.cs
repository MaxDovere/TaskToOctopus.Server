using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Keyless]
    [Table("T_Sequence_Action_BUP")]
    public partial class T_Sequence_Action_BUP
    {
        [Required]
        [StringLength(59)]
        public string SequenceID { get; set; }
        [Required]
        [StringLength(10)]
        public string SeqActionID { get; set; }
        public double ActionOrder { get; set; }
        public double? GoToActionOrder { get; set; }
        [Required]
        [StringLength(20)]
        public string SeqActionBehaviourID { get; set; }
        [StringLength(20)]
        public string RefProcessID { get; set; }
        [StringLength(50)]
        public string RefProcessStep { get; set; }
        [StringLength(50)]
        public string RefUser { get; set; }
        public int? RefUserID { get; set; }
        public int? RefTeamID { get; set; }
        [StringLength(1)]
        public string TimeUnit { get; set; }
        public int? TimeAdd { get; set; }
        public bool? TimeAllDays { get; set; }
        [StringLength(50)]
        public string RefScriptID { get; set; }
        public int? ClosureReasonID { get; set; }
        public bool IsAuto { get; set; }
        public int? InterviewNumber { get; set; }
        [StringLength(50)]
        public string Alert { get; set; }
        [StringLength(1)]
        public string AlertTimeUnit { get; set; }
        public int? AlertTimeAdd { get; set; }
        public bool? AlertTimeAllDays { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public string CheckSql { get; set; }
        public string GetValuesSql { get; set; }
    }
}
