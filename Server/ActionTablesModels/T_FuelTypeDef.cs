using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_FuelTypeDef")]
    public partial class T_FuelTypeDef
    {
        public T_FuelTypeDef()
        {
            T_ModelVersions = new HashSet<T_ModelVersion>();
        }

        [Key]
        [StringLength(10)]
        public string FuelTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int? SortOrder { get; set; }

        [InverseProperty(nameof(T_ModelVersion.FuelType))]
        public virtual ICollection<T_ModelVersion> T_ModelVersions { get; set; }
    }
}
