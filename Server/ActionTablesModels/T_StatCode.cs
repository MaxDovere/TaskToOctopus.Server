using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_StatCode")]
    public partial class T_StatCode
    {
        public T_StatCode()
        {
            T_StatCodeLinks = new HashSet<T_StatCodeLink>();
        }

        [Key]
        [StringLength(20)]
        public string StatCodeID { get; set; }
        [Required]
        [StringLength(20)]
        public string StatCodeKey { get; set; }
        public int? BrandID { get; set; }
        public int? BrandBusinessUnitID { get; set; }
        [StringLength(100)]
        public string GroupDescription { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(30)]
        public string ShortDescription { get; set; }
        [StringLength(5)]
        public string TinyDescription { get; set; }
        public int? SortOrder { get; set; }

        [ForeignKey(nameof(BrandID))]
        [InverseProperty(nameof(T_Brand.T_StatCodes))]
        public virtual T_Brand Brand { get; set; }
        [ForeignKey(nameof(BrandBusinessUnitID))]
        [InverseProperty(nameof(T_Brand_BusinessUnit.T_StatCodes))]
        public virtual T_Brand_BusinessUnit BrandBusinessUnit { get; set; }
        [InverseProperty(nameof(T_StatCodeLink.StatCode))]
        public virtual ICollection<T_StatCodeLink> T_StatCodeLinks { get; set; }
    }
}
