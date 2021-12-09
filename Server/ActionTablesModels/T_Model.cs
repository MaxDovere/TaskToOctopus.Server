using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Model")]
    public partial class T_Model
    {
        public T_Model()
        {
            T_ModelVersions = new HashSet<T_ModelVersion>();
        }

        [Key]
        [StringLength(30)]
        public string ModelCode { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public int BrandID { get; set; }
        [StringLength(6)]
        public string ModelInfocarCode { get; set; }
        [StringLength(30)]
        public string BrandModelCode { get; set; }
        public int? ModelYearFrom { get; set; }
        public int? ModelMonthFrom { get; set; }
        public int? ModelYearTo { get; set; }
        public int? ModelMonthTo { get; set; }
        [StringLength(255)]
        public string FullDescription { get; set; }

        [ForeignKey(nameof(BrandID))]
        [InverseProperty(nameof(T_Brand.T_Models))]
        public virtual T_Brand Brand { get; set; }
        [InverseProperty(nameof(T_ModelVersion.ModelCodeNavigation))]
        public virtual ICollection<T_ModelVersion> T_ModelVersions { get; set; }
    }
}
