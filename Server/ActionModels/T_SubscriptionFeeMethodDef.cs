using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionModels
{
    [Table("T_SubscriptionFeeMethodDef")]
    public partial class T_SubscriptionFeeMethodDef
    {
        public T_SubscriptionFeeMethodDef()
        {
            T_SubscriptionTypeDefs = new HashSet<T_SubscriptionTypeDef>();
        }

        [Key]
        public int FeeMethodID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        [StringLength(3)]
        public string PeriodBaseID { get; set; }
        public bool MultiplyByUser { get; set; }
        public bool MultiplyByBrand { get; set; }
        public bool MultiplyByBU { get; set; }
        public bool MultiplyByOutlet { get; set; }

        [ForeignKey(nameof(PeriodBaseID))]
        [InverseProperty(nameof(T_SubscriptionPeriodBaseDef.T_SubscriptionFeeMethodDefs))]
        public virtual T_SubscriptionPeriodBaseDef PeriodBase { get; set; }
        [InverseProperty(nameof(T_SubscriptionTypeDef.FeeMethod))]
        public virtual ICollection<T_SubscriptionTypeDef> T_SubscriptionTypeDefs { get; set; }
    }
}
