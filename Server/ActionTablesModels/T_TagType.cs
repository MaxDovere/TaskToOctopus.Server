using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_TagType")]
    public partial class T_TagType
    {
        [Key]
        [StringLength(30)]
        public string TagTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public bool UnForCustomer { get; set; }
        public bool UnForLead { get; set; }
        public bool UnForVehicle { get; set; }
        public bool UnForProduct { get; set; }
        public bool UseCustomer { get; set; }
        public bool UseLead { get; set; }
        public bool UseVehicle { get; set; }
        public bool UseProduct { get; set; }
    }
}
