using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionModels
{
    [Table("SSODealersSubscriptionItem")]
    public partial class SSODealersSubscriptionItem
    {
        [Key]
        public int DealerSubscriptionItemID { get; set; }
        public int DealerSubscriptionID { get; set; }
        [Required]
        [StringLength(30)]
        public string ParameterID { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        [StringLength(3)]
        public string PeriodBaseID { get; set; }
        public double DefValue { get; set; }
        public double MinValueApply { get; set; }
        public int? ProfileID { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LastInvoiced { get; set; }

        [ForeignKey(nameof(DealerSubscriptionID))]
        [InverseProperty(nameof(SSODealersSubcscription.SSODealersSubscriptionItems))]
        public virtual SSODealersSubcscription DealerSubscription { get; set; }
    }
}
