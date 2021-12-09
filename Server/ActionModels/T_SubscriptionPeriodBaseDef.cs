using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionModels
{
    [Table("T_SubscriptionPeriodBaseDef")]
    public partial class T_SubscriptionPeriodBaseDef
    {
        public T_SubscriptionPeriodBaseDef()
        {
            T_SubscriptionFeeMethodDefs = new HashSet<T_SubscriptionFeeMethodDef>();
        }

        [Key]
        [StringLength(3)]
        public string PeriodBaseID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty(nameof(T_SubscriptionFeeMethodDef.PeriodBase))]
        public virtual ICollection<T_SubscriptionFeeMethodDef> T_SubscriptionFeeMethodDefs { get; set; }
    }
}
