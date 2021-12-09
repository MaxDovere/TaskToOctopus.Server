using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Profile")]
    public partial class T_Profile
    {
        public T_Profile()
        {
            T_Profile_Tasks = new HashSet<T_Profile_Task>();
        }

        [Key]
        public int ProfileID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public bool DealerProfile { get; set; }
        public bool AdminProfile { get; set; }
        public bool RequiresBrand { get; set; }
        public bool RequiresOutlet { get; set; }
        public bool RequiresTeam { get; set; }
        public bool IsTeamLeader { get; set; }
        public byte MaxTeamOccur { get; set; }

        [InverseProperty(nameof(T_Profile_Task.Profile))]
        public virtual ICollection<T_Profile_Task> T_Profile_Tasks { get; set; }
    }
}
