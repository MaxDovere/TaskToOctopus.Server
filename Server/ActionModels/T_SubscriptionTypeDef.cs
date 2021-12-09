using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionModels
{
    [Table("T_SubscriptionTypeDef")]
    public partial class T_SubscriptionTypeDef
    {
        public T_SubscriptionTypeDef()
        {
            T_Subscriptions = new HashSet<T_Subscription>();
        }

        [Key]
        public int SubcriptionTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int FeeMethodID { get; set; }
        public double? StartUpAmount { get; set; }

        [ForeignKey(nameof(FeeMethodID))]
        [InverseProperty(nameof(T_SubscriptionFeeMethodDef.T_SubscriptionTypeDefs))]
        public virtual T_SubscriptionFeeMethodDef FeeMethod { get; set; }
        [InverseProperty(nameof(T_Subscription.SubscriptionType))]
        public virtual ICollection<T_Subscription> T_Subscriptions { get; set; }
    }
}
