using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ReferenceTypeDef")]
    public partial class T_ReferenceTypeDef
    {
        public T_ReferenceTypeDef()
        {
            T_ReferenceChannelCodeDefs = new HashSet<T_ReferenceChannelCodeDef>();
        }

        [Key]
        [StringLength(3)]
        public string ReferenceTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int? SortOrder { get; set; }
        public long? Bitmask { get; set; }

        [InverseProperty(nameof(T_ReferenceChannelCodeDef.ReferenceType))]
        public virtual ICollection<T_ReferenceChannelCodeDef> T_ReferenceChannelCodeDefs { get; set; }
    }
}
