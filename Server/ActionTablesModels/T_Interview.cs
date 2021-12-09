using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Interview")]
    public partial class T_Interview
    {
        public T_Interview()
        {
            T_Interview_Questions = new HashSet<T_Interview_Question>();
        }

        [Key]
        [StringLength(20)]
        public string InterviewID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(10)]
        public string InterviewTypeID { get; set; }

        [ForeignKey(nameof(InterviewTypeID))]
        [InverseProperty(nameof(T_InterviewTypeDef.T_Interviews))]
        public virtual T_InterviewTypeDef InterviewType { get; set; }
        [InverseProperty(nameof(T_Interview_Question.Interview))]
        public virtual ICollection<T_Interview_Question> T_Interview_Questions { get; set; }
    }
}
