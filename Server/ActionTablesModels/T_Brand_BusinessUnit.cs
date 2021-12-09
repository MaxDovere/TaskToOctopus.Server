using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Brand_BusinessUnit")]
    [Index(nameof(BrandID), nameof(BusinessUnitID), Name = "IX_T_Brand_BusinessUnit", IsUnique = true)]
    public partial class T_Brand_BusinessUnit
    {
        public T_Brand_BusinessUnit()
        {
            T_Brand_BusinessUnitLinks = new HashSet<T_Brand_BusinessUnitLink>();
            T_Brand_Models = new HashSet<T_Brand_Model>();
            T_StatCodes = new HashSet<T_StatCode>();
        }

        [Key]
        public int BrandBusinessUnitID { get; set; }
        public int BrandID { get; set; }
        public int BusinessUnitID { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public bool AllowGrouping { get; set; }
        public bool ExtendToOpenLeads { get; set; }

        [ForeignKey(nameof(BrandID))]
        [InverseProperty(nameof(T_Brand.T_Brand_BusinessUnits))]
        public virtual T_Brand Brand { get; set; }
        [ForeignKey(nameof(BusinessUnitID))]
        [InverseProperty(nameof(T_BusinessUnit.T_Brand_BusinessUnits))]
        public virtual T_BusinessUnit BusinessUnit { get; set; }
        [InverseProperty(nameof(T_Brand_BusinessUnitLink.BrandBusinessUnit))]
        public virtual ICollection<T_Brand_BusinessUnitLink> T_Brand_BusinessUnitLinks { get; set; }
        [InverseProperty(nameof(T_Brand_Model.BrandBusinessUnit))]
        public virtual ICollection<T_Brand_Model> T_Brand_Models { get; set; }
        [InverseProperty(nameof(T_StatCode.BrandBusinessUnit))]
        public virtual ICollection<T_StatCode> T_StatCodes { get; set; }
    }
}
