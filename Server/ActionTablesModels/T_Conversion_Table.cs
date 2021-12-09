using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Conversion_Table")]
    public partial class T_Conversion_Table
    {
        [Key]
        [StringLength(30)]
        public string TableKey { get; set; }
        [Key]
        [StringLength(30)]
        public string FieldKey { get; set; }
        [Key]
        [StringLength(50)]
        public string ActionValue { get; set; }
        [Key]
        [StringLength(50)]
        public string SourceID { get; set; }
        [Key]
        [StringLength(50)]
        public string SourceValue { get; set; }
    }
}
