using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionModels
{
    [Table("SSODealerInterfaceLogin")]
    [Index(nameof(InterfaceID), nameof(UserName), Name = "IX_SSODealerInterfaceLogin", IsUnique = true)]
    public partial class SSODealerInterfaceLogin
    {
        [Key]
        [StringLength(128)]
        public string DealerKey { get; set; }
        [Key]
        [StringLength(20)]
        public string InterfaceID { get; set; }
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }
        [StringLength(256)]
        public string Pwd { get; set; }

        [ForeignKey(nameof(DealerKey))]
        [InverseProperty(nameof(SSODealer.SSODealerInterfaceLogins))]
        public virtual SSODealer DealerKeyNavigation { get; set; }
    }
}
