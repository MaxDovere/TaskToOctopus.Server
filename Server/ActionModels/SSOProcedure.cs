using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionModels
{
    public partial class SSOProcedure
    {
        public SSOProcedure()
        {
            SSOProcedureDealers = new HashSet<SSOProcedureDealer>();
        }

        [Key]
        [StringLength(50)]
        public string ProcedureID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public string SqlText { get; set; }
        public bool ExecByDB { get; set; }
        public bool IsActive { get; set; }
        public bool NeedsDealerInclude { get; set; }

        [InverseProperty(nameof(SSOProcedureDealer.Procedure))]
        public virtual ICollection<SSOProcedureDealer> SSOProcedureDealers { get; set; }
    }
}
