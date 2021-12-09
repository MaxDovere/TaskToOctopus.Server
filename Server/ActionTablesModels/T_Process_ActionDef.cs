using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Process_ActionDef")]
    public partial class T_Process_ActionDef
    {
        public T_Process_ActionDef()
        {
            T_Process_ActionStructures = new HashSet<T_Process_ActionStructure>();
        }

        [Key]
        [StringLength(10)]
        public string ProcessActionID { get; set; }
        [StringLength(10)]
        public string ProcessID { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public int? SortOrder { get; set; }
        public bool IsDefaultForNew { get; set; }
        public bool? CanBePrevious { get; set; }
        public bool RepeatOnCustomer { get; set; }
        public int? RepeatOnLeadAfterMonths { get; set; }
        public int? RepeatOnCustomerAfterMonths { get; set; }
        public bool IsTempProcess { get; set; }

        [ForeignKey(nameof(ProcessID))]
        [InverseProperty(nameof(T_Process.T_Process_ActionDefs))]
        public virtual T_Process Process { get; set; }
        [InverseProperty(nameof(T_Process_ActionStructure.ProcessAction))]
        public virtual ICollection<T_Process_ActionStructure> T_Process_ActionStructures { get; set; }
    }
}
