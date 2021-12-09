using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionModels
{
    [Table("AspNetUsersRel")]
    public partial class AspNetUsersRel
    {
        [Key]
        [StringLength(128)]
        public string UserID { get; set; }
        [Key]
        [StringLength(128)]
        public string ParentID { get; set; }
    }
}
