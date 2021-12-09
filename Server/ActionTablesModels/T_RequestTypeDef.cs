using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_RequestTypeDef")]
    public partial class T_RequestTypeDef
    {
        [Key]
        [StringLength(5)]
        public string LeadRequestTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int? SortOrder { get; set; }
        [StringLength(5)]
        public string SalesDepartmentID { get; set; }

        [ForeignKey(nameof(SalesDepartmentID))]
        [InverseProperty(nameof(T_Sales_Department.T_RequestTypeDefs))]
        public virtual T_Sales_Department SalesDepartment { get; set; }
    }
}
