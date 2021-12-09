using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionModels
{
    [Table("SSODealerUserStatus")]
    public partial class SSODealerUserStatus
    {
        [Key]
        [StringLength(128)]
        public string DealerKey { get; set; }
        [Key]
        [Column(TypeName = "date")]
        public DateTime RefDate { get; set; }
        [Key]
        [StringLength(128)]
        public string SSOUserID { get; set; }
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }
        public short StatusID { get; set; }
        public bool ProfileEnabled { get; set; }
        public int? ProfileID { get; set; }
    }
}
