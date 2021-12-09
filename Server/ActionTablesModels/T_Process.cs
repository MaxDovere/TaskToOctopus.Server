using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Process")]
    public partial class T_Process
    {
        public T_Process()
        {
            T_Process_ActionDefs = new HashSet<T_Process_ActionDef>();
        }

        [Key]
        [StringLength(10)]
        public string ProcessID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public bool IsSales { get; set; }
        public bool IsService { get; set; }
        public int? SortOrder { get; set; }

        [InverseProperty(nameof(T_Process_ActionDef.Process))]
        public virtual ICollection<T_Process_ActionDef> T_Process_ActionDefs { get; set; }
    }
}
