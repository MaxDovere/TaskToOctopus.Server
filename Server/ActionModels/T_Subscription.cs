using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionModels
{
    [Table("T_Subscription")]
    public partial class T_Subscription
    {
        public T_Subscription()
        {
            SSODealers = new HashSet<SSODealer>();
        }

        [Key]
        public int SubscriptionID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int SubscriptionTypeID { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        public bool AllowExternalDealer { get; set; }

        [ForeignKey(nameof(SubscriptionTypeID))]
        [InverseProperty(nameof(T_SubscriptionTypeDef.T_Subscriptions))]
        public virtual T_SubscriptionTypeDef SubscriptionType { get; set; }
        [InverseProperty(nameof(SSODealer.Subscription))]
        public virtual ICollection<SSODealer> SSODealers { get; set; }
    }
}
