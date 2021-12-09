using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionModels
{
    [Table("SSOProcedureDealer")]
    public partial class SSOProcedureDealer
    {
        [Key]
        [StringLength(50)]
        public string ProcedureID { get; set; }
        [Key]
        [StringLength(128)]
        public string DealerKey { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey(nameof(DealerKey))]
        [InverseProperty(nameof(SSODealer.SSOProcedureDealers))]
        public virtual SSODealer DealerKeyNavigation { get; set; }
        [ForeignKey(nameof(ProcedureID))]
        [InverseProperty(nameof(SSOProcedure.SSOProcedureDealers))]
        public virtual SSOProcedure Procedure { get; set; }
    }
}
