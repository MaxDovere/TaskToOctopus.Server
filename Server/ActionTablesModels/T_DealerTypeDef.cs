using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_DealerTypeDef")]
    public partial class T_DealerTypeDef
    {
        [Key]
        [StringLength(10)]
        public string DealerTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(10)]
        public string ParentDealerTypeID { get; set; }
    }
}
