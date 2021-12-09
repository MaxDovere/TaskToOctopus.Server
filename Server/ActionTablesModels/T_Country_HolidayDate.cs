using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Country_HolidayDate")]
    public partial class T_Country_HolidayDate
    {
        [Key]
        [StringLength(3)]
        public string CountryID { get; set; }
        [Key]
        [Column(TypeName = "date")]
        public DateTime RefDate { get; set; }

        [ForeignKey(nameof(CountryID))]
        [InverseProperty(nameof(T_Country.T_Country_HolidayDates))]
        public virtual T_Country Country { get; set; }
    }
}
