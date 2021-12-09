using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Interview_Question")]
    [Index(nameof(InterviewID), nameof(Position), Name = "IX_T_Interview_Question", IsUnique = true)]
    public partial class T_Interview_Question
    {
        [Key]
        public int InterviewQuestionID { get; set; }
        [Required]
        [StringLength(20)]
        public string InterviewID { get; set; }
        [Required]
        public string QuestionText { get; set; }
        public int Position { get; set; }
        public byte PrevFeedbackMatch { get; set; }
        public byte DefaultFeedbackStatus { get; set; }
        public string ScriptText { get; set; }
        public bool? NoFeedback { get; set; }
        public int? PosGoto { get; set; }
        public int? NegGoto { get; set; }
        [StringLength(20)]
        public string StatCodeID { get; set; }

        [ForeignKey(nameof(InterviewID))]
        [InverseProperty(nameof(T_Interview.T_Interview_Questions))]
        public virtual T_Interview Interview { get; set; }
    }
}
