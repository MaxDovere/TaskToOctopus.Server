using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Profile_Task")]
    [Index(nameof(ProfileID), nameof(TaskID), Name = "IX_T_Profile_Task", IsUnique = true)]
    public partial class T_Profile_Task
    {
        [Key]
        public int ProfileTaskID { get; set; }
        public int ProfileID { get; set; }
        [Required]
        [StringLength(50)]
        public string TaskID { get; set; }

        [ForeignKey(nameof(ProfileID))]
        [InverseProperty(nameof(T_Profile.T_Profile_Tasks))]
        public virtual T_Profile Profile { get; set; }
        [ForeignKey(nameof(TaskID))]
        [InverseProperty(nameof(T_Task.T_Profile_Tasks))]
        public virtual T_Task Task { get; set; }
    }
}
