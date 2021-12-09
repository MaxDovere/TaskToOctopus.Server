using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionModels
{
    [Table("SSODealerRel")]
    [Index(nameof(UserExt), Name = "IX_SSODealerRel", IsUnique = true)]
    public partial class SSODealerRel
    {
        [Key]
        [StringLength(128)]
        public string DealerKey { get; set; }
        [Key]
        [StringLength(128)]
        public string ParentKey { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [Required]
        [StringLength(50)]
        public string UserExt { get; set; }

        [ForeignKey(nameof(ParentKey))]
        [InverseProperty(nameof(SSODealer.SSODealerRels))]
        public virtual SSODealer ParentKeyNavigation { get; set; }
    }
}
