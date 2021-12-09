using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ModelVersion")]
    public partial class T_ModelVersion
    {
        [Key]
        [StringLength(30)]
        public string VersionCode { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        [StringLength(30)]
        public string ModelCode { get; set; }
        [StringLength(6)]
        public string VersionInfocarCode { get; set; }
        public int? ModelYear { get; set; }
        public int? ModelMonth { get; set; }
        [StringLength(12)]
        public string FullInfocarCode { get; set; }
        [StringLength(30)]
        public string BrandVersionCode { get; set; }
        [StringLength(10)]
        public string FuelTypeID { get; set; }

        [ForeignKey(nameof(FuelTypeID))]
        [InverseProperty(nameof(T_FuelTypeDef.T_ModelVersions))]
        public virtual T_FuelTypeDef FuelType { get; set; }
        [ForeignKey(nameof(ModelCode))]
        [InverseProperty(nameof(T_Model.T_ModelVersions))]
        public virtual T_Model ModelCodeNavigation { get; set; }
    }
}
