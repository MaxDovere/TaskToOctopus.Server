using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ImportInterface")]
    public partial class T_ImportInterface
    {
        public T_ImportInterface()
        {
            T_ImportInterface_Conversions = new HashSet<T_ImportInterface_Conversion>();
        }

        [Key]
        [StringLength(20)]
        public string InterfaceID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        [StringLength(10)]
        public string InterfaceTypeID { get; set; }
        public bool IsDefault { get; set; }

        [InverseProperty(nameof(T_ImportInterface_Conversion.Interface))]
        public virtual ICollection<T_ImportInterface_Conversion> T_ImportInterface_Conversions { get; set; }
    }
}
