using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_VATCodeDef")]
    public partial class T_VATCodeDef
    {
        [Key]
        [StringLength(10)]
        public string VATID { get; set; }
        [Required]
        [StringLength(3)]
        public string CountryID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public double VATPerc { get; set; }
        public bool ActiveItem { get; set; }
        public bool CountryDefault { get; set; }
    }
}
