using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskToOctopus.Server.Models
{
    [Keyless]
    public class V_MessagesNotification
    {
        public int? MessageId { get; set; }
        public string? Guid { get; set; }
        public string? Message { get; set; }
        public string? Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? WhenDate { get; set; }
        public int? ByWhoId { get; set; }
        public int? ToWhoId { get; set; }
        public string? ByUserId { get; set; }
        public string? Endpoint { get; set; }
        public string? Method { get; set; }
        public string? ToUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeletedDate { get; set; }
    }
}