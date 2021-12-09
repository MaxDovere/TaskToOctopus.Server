using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_ActionType_Department")]
    [Index(nameof(ActionTypeID), nameof(SalesDepartmentID), Name = "IX_T_ActionType_Department", IsUnique = true)]
    public partial class T_ActionType_Department
    {
        [Key]
        public int ActionTypeDepartmentID { get; set; }
        [Required]
        [StringLength(5)]
        public string ActionTypeID { get; set; }
        [Required]
        [StringLength(5)]
        public string SalesDepartmentID { get; set; }
        public int? SortOrder { get; set; }

        [ForeignKey(nameof(ActionTypeID))]
        [InverseProperty(nameof(T_ActionType.T_ActionType_Departments))]
        public virtual T_ActionType ActionType { get; set; }
        [ForeignKey(nameof(SalesDepartmentID))]
        [InverseProperty(nameof(T_Sales_Department.T_ActionType_Departments))]
        public virtual T_Sales_Department SalesDepartment { get; set; }
    }
}
