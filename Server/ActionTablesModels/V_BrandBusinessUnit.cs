using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Keyless]
    public partial class V_BrandBusinessUnit
    {
        public int BrandBusinessUnitID { get; set; }
        public int BrandID { get; set; }
        public int BusinessUnitID { get; set; }
        [Required]
        [StringLength(100)]
        public string Brand { get; set; }
        [Required]
        [StringLength(151)]
        public string BrandBusinessUnit { get; set; }
        [Required]
        [StringLength(100)]
        public string BusinessUnit { get; set; }
        [StringLength(6)]
        public string InfocarCode { get; set; }
        [StringLength(10)]
        public string ShortName { get; set; }
        [StringLength(255)]
        public string Logo { get; set; }
        public bool IsUsedVehicle { get; set; }
        public bool IsGeneric { get; set; }
    }
}
