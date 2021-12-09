using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ImportInterface_Conversion")]
    public partial class T_ImportInterface_Conversion
    {
        [Key]
        [StringLength(20)]
        public string InterfaceID { get; set; }
        [Key]
        [StringLength(30)]
        public string DataKey { get; set; }
        [Key]
        [StringLength(100)]
        public string SourceData { get; set; }
        [StringLength(100)]
        public string CRMData { get; set; }

        [ForeignKey(nameof(InterfaceID))]
        [InverseProperty(nameof(T_ImportInterface.T_ImportInterface_Conversions))]
        public virtual T_ImportInterface Interface { get; set; }
    }
}
