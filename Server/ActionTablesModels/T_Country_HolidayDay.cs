using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Country_HolidayDay")]
    public partial class T_Country_HolidayDay
    {
        [Key]
        [StringLength(3)]
        public string CountryID { get; set; }
        [Key]
        public int RefMonth { get; set; }
        [Key]
        public int RefDay { get; set; }
    }
}
