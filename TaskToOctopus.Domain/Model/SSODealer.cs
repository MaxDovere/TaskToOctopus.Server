using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskToOctopus.Domain.Model
{
    [Table("SSODealers")]
    public partial class SSODealer
    {
        [Key]
        [StringLength(128)]
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string CRMLink { get; set; }
        public string DBServer { get; set; }
        public string DBName { get; set; }
        public string ConnName { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> SubscriptionID { get; set; }
        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(AspNetUser.Dealers))]
        public virtual AspNetUser User { get; set; }
    }
}
