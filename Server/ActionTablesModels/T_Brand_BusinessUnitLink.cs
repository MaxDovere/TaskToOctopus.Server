using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Brand_BusinessUnitLink")]
    [Index(nameof(BrandBusinessUnitID), nameof(DealerID), Name = "IX_T_Brand_BusinessUnitLink", IsUnique = true)]
    public partial class T_Brand_BusinessUnitLink
    {
        [Key]
        public int BrandBusinessUnitLinkID { get; set; }
        public int BrandBusinessUnitID { get; set; }
        public int DealerID { get; set; }

        [ForeignKey(nameof(BrandBusinessUnitID))]
        [InverseProperty(nameof(T_Brand_BusinessUnit.T_Brand_BusinessUnitLinks))]
        public virtual T_Brand_BusinessUnit BrandBusinessUnit { get; set; }
    }
}
