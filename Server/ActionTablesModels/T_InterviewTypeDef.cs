using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_InterviewTypeDef")]
    public partial class T_InterviewTypeDef
    {
        public T_InterviewTypeDef()
        {
            T_Interviews = new HashSet<T_Interview>();
        }

        [Key]
        [StringLength(10)]
        public string InterviewTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty(nameof(T_Interview.InterviewType))]
        public virtual ICollection<T_Interview> T_Interviews { get; set; }
    }
}
