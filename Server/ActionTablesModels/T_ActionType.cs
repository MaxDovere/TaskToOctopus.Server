using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ActionType")]
    public partial class T_ActionType
    {
        public T_ActionType()
        {
            T_ActionType_Departments = new HashSet<T_ActionType_Department>();
        }

        [Key]
        [StringLength(5)]
        public string ActionTypeID { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public bool? IsFirstContact { get; set; }
        public int? SortOrder { get; set; }
        [StringLength(50)]
        public string TaskID { get; set; }
        [StringLength(50)]
        public string Glyphicon { get; set; }
        [StringLength(50)]
        public string Icon { get; set; }

        [ForeignKey(nameof(TaskID))]
        [InverseProperty(nameof(T_Task.T_ActionTypes))]
        public virtual T_Task Task { get; set; }
        [InverseProperty(nameof(T_ActionType_Department.ActionType))]
        public virtual ICollection<T_ActionType_Department> T_ActionType_Departments { get; set; }
    }
}
