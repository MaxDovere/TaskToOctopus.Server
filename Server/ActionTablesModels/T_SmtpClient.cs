using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesModels
{
    public partial class T_SmtpClient
    {
        [Key]
        [StringLength(50)]
        public string SmtpClientID { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(512)]
        public string Notes { get; set; }
        public bool IsDefault { get; set; }
        public bool Active { get; set; }
        public int? Port { get; set; }
        [StringLength(50)]
        public string Host { get; set; }
        public bool? UseDefaultCredentials { get; set; }
        [StringLength(255)]
        public string UserID { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public bool? EnableSsl { get; set; }
        [StringLength(50)]
        public string DeliveryMethod { get; set; }
        [StringLength(255)]
        public string PickupDirectory { get; set; }
        public bool? UseReplyTo { get; set; }
        [StringLength(255)]
        public string DefaultFromAccount { get; set; }
        [StringLength(50)]
        public string DllName { get; set; }
    }
}
