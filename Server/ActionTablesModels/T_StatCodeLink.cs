using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_StatCodeLink")]
    public partial class T_StatCodeLink
    {
        [Key]
        public long StatCodeLinkID { get; set; }
        [Required]
        [StringLength(20)]
        public string StatCodeID { get; set; }
        [Required]
        [StringLength(50)]
        public string TableName { get; set; }
        [Required]
        [StringLength(50)]
        public string FieldName { get; set; }
        public long? NumberFieldID { get; set; }
        [StringLength(50)]
        public string StringFieldID { get; set; }

        [ForeignKey(nameof(StatCodeID))]
        [InverseProperty(nameof(T_StatCode.T_StatCodeLinks))]
        public virtual T_StatCode StatCode { get; set; }
    }
}
