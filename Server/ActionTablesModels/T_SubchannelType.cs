using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_SubchannelType")]
    public partial class T_SubchannelType
    {
        [Key]
        public int SubchannelTypeID { get; set; }
        [Required]
        [StringLength(10)]
        public string ChannelID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int? SortOrder { get; set; }

        [ForeignKey(nameof(ChannelID))]
        [InverseProperty(nameof(T_Channel.T_SubchannelTypes))]
        public virtual T_Channel Channel { get; set; }
    }
}
