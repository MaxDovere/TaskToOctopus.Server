using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_BusinessUnit")]
    public partial class T_BusinessUnit
    {
        public T_BusinessUnit()
        {
            T_Brand_BusinessUnits = new HashSet<T_Brand_BusinessUnit>();
        }

        [Key]
        public int BusinessUnitID { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [InverseProperty(nameof(T_Brand_BusinessUnit.BusinessUnit))]
        public virtual ICollection<T_Brand_BusinessUnit> T_Brand_BusinessUnits { get; set; }
    }
}
