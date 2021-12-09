using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionModels
{
    [Table("SSODealersSubcscription")]
    public partial class SSODealersSubcscription
    {
        public SSODealersSubcscription()
        {
            SSODealersSubscriptionItems = new HashSet<SSODealersSubscriptionItem>();
        }

        [Key]
        public int DealerSubscriptionID { get; set; }
        [Required]
        [StringLength(128)]
        public string DealerKey { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartInvoiceDate { get; set; }
        [StringLength(3)]
        public string InvPeriodBaseID { get; set; }
        [StringLength(100)]
        public string SellerName { get; set; }
        public int AutoRenewalMonth { get; set; }

        [ForeignKey(nameof(DealerKey))]
        [InverseProperty(nameof(SSODealer.SSODealersSubcscriptions))]
        public virtual SSODealer DealerKeyNavigation { get; set; }
        [InverseProperty(nameof(SSODealersSubscriptionItem.DealerSubscription))]
        public virtual ICollection<SSODealersSubscriptionItem> SSODealersSubscriptionItems { get; set; }
    }
}
