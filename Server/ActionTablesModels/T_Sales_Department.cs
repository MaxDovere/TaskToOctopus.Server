using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    [Table("T_Sales_Department")]
    public partial class T_Sales_Department
    {
        public T_Sales_Department()
        {
            T_ActionType_Departments = new HashSet<T_ActionType_Department>();
            T_RequestTypeDefs = new HashSet<T_RequestTypeDef>();
        }

        [Key]
        [StringLength(5)]
        public string SalesDepartmentID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(10)]
        public string SortOrder { get; set; }
        public bool IsSales { get; set; }
        public bool IsService { get; set; }

        [InverseProperty(nameof(T_ActionType_Department.SalesDepartment))]
        public virtual ICollection<T_ActionType_Department> T_ActionType_Departments { get; set; }
        [InverseProperty(nameof(T_RequestTypeDef.SalesDepartment))]
        public virtual ICollection<T_RequestTypeDef> T_RequestTypeDefs { get; set; }
    }
}
