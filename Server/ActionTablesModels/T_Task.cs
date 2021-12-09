using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Task")]
    public partial class T_Task
    {
        public T_Task()
        {
            InverseParentTask = new HashSet<T_Task>();
            T_ActionTypes = new HashSet<T_ActionType>();
            T_Profile_Tasks = new HashSet<T_Profile_Task>();
            T_ReportTypeDefs = new HashSet<T_ReportTypeDef>();
        }

        [Key]
        [StringLength(50)]
        public string TaskID { get; set; }
        [StringLength(50)]
        public string ParentTaskID { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public bool FreeTask { get; set; }

        [ForeignKey(nameof(ParentTaskID))]
        [InverseProperty(nameof(T_Task.InverseParentTask))]
        public virtual T_Task ParentTask { get; set; }
        [InverseProperty(nameof(T_Task.ParentTask))]
        public virtual ICollection<T_Task> InverseParentTask { get; set; }
        [InverseProperty(nameof(T_ActionType.Task))]
        public virtual ICollection<T_ActionType> T_ActionTypes { get; set; }
        [InverseProperty(nameof(T_Profile_Task.Task))]
        public virtual ICollection<T_Profile_Task> T_Profile_Tasks { get; set; }
        [InverseProperty(nameof(T_ReportTypeDef.Task))]
        public virtual ICollection<T_ReportTypeDef> T_ReportTypeDefs { get; set; }
    }
}
