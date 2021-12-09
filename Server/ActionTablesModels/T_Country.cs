using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Country")]
    public partial class T_Country
    {
        public T_Country()
        {
            T_Country_HolidayDates = new HashSet<T_Country_HolidayDate>();
        }

        [Key]
        [StringLength(3)]
        public string CountryID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(5)]
        public string LangID { get; set; }
        [StringLength(10)]
        public string TelPrefix { get; set; }
        [StringLength(3)]
        public string DBDateFormat { get; set; }
        public byte? DBDateFirst { get; set; }

        [InverseProperty(nameof(T_Country_HolidayDate.Country))]
        public virtual ICollection<T_Country_HolidayDate> T_Country_HolidayDates { get; set; }
    }
}
