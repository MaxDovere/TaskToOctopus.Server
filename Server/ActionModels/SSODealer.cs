using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionModels
{
    public partial class SSODealer
    {
        public SSODealer()
        {
            AspNetUsers = new HashSet<AspNetUser>();
            SSODealerInterfaceLogins = new HashSet<SSODealerInterfaceLogin>();
            SSODealerRels = new HashSet<SSODealerRel>();
            SSODealersSubcscriptions = new HashSet<SSODealersSubcscription>();
            SSOProcedureDealers = new HashSet<SSOProcedureDealer>();
        }

        [Key]
        [StringLength(128)]
        public string Id { get; set; }
        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }
        [StringLength(255)]
        public string CRMLink { get; set; }
        [StringLength(50)]
        public string DBServer { get; set; }
        [Required]
        [StringLength(50)]
        public string DBName { get; set; }
        [StringLength(50)]
        public string ConnName { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        public int? SubscriptionID { get; set; }

        [ForeignKey(nameof(SubscriptionID))]
        [InverseProperty(nameof(T_Subscription.SSODealers))]
        public virtual T_Subscription Subscription { get; set; }
        [InverseProperty(nameof(AspNetUser.DealerKeyNavigation))]
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
        [InverseProperty(nameof(SSODealerInterfaceLogin.DealerKeyNavigation))]
        public virtual ICollection<SSODealerInterfaceLogin> SSODealerInterfaceLogins { get; set; }
        [InverseProperty(nameof(SSODealerRel.ParentKeyNavigation))]
        public virtual ICollection<SSODealerRel> SSODealerRels { get; set; }
        [InverseProperty(nameof(SSODealersSubcscription.DealerKeyNavigation))]
        public virtual ICollection<SSODealersSubcscription> SSODealersSubcscriptions { get; set; }
        [InverseProperty(nameof(SSOProcedureDealer.DealerKeyNavigation))]
        public virtual ICollection<SSOProcedureDealer> SSOProcedureDealers { get; set; }
    }
}
