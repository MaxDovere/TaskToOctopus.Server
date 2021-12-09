using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Brand")]
    public partial class T_Brand
    {
        public T_Brand()
        {
            T_Brand_BusinessUnits = new HashSet<T_Brand_BusinessUnit>();
            T_Models = new HashSet<T_Model>();
            T_StatCodes = new HashSet<T_StatCode>();
        }

        [Key]
        public int BrandID { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(6)]
        public string InfocarCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreationTimeUtc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastWriteTimeUtc { get; set; }
        [StringLength(10)]
        public string ShortName { get; set; }
        [StringLength(255)]
        public string Logo { get; set; }
        [StringLength(255)]
        public string Thumbnail { get; set; }
        public bool IsUsedVehicle { get; set; }
        public bool IsGeneric { get; set; }

        [InverseProperty(nameof(T_Brand_BusinessUnit.Brand))]
        public virtual ICollection<T_Brand_BusinessUnit> T_Brand_BusinessUnits { get; set; }
        [InverseProperty(nameof(T_Model.Brand))]
        public virtual ICollection<T_Model> T_Models { get; set; }
        [InverseProperty(nameof(T_StatCode.Brand))]
        public virtual ICollection<T_StatCode> T_StatCodes { get; set; }
    }
}
