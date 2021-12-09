using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Brand_Model")]
    [Index(nameof(BrandBusinessUnitID), nameof(BrandModelCode), Name = "IX_T_Brand_Model", IsUnique = true)]
    public partial class T_Brand_Model
    {
        [Key]
        public long ModelID { get; set; }
        public int BrandBusinessUnitID { get; set; }
        [Required]
        [StringLength(100)]
        public string ModelName { get; set; }
        [StringLength(50)]
        public string BrandModelCode { get; set; }
        [StringLength(10)]
        public string InfocarCode { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [StringLength(512)]
        public string Keywords { get; set; }

        [ForeignKey(nameof(BrandBusinessUnitID))]
        [InverseProperty(nameof(T_Brand_BusinessUnit.T_Brand_Models))]
        public virtual T_Brand_BusinessUnit BrandBusinessUnit { get; set; }
    }
}
