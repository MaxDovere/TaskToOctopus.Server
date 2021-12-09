using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Channel")]
    public partial class T_Channel
    {
        public T_Channel()
        {
            T_SubchannelTypes = new HashSet<T_SubchannelType>();
        }

        [Key]
        [StringLength(10)]
        public string ChannelID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public short? SortOrder { get; set; }
        [StringLength(100)]
        public string Glyphicon { get; set; }

        [InverseProperty(nameof(T_SubchannelType.Channel))]
        public virtual ICollection<T_SubchannelType> T_SubchannelTypes { get; set; }
    }
}
