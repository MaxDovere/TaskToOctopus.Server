using System;

namespace TaskToOctopus.Server.Models
{
    public class StatusDefModel // Tabella su CRMTables T_StatusDef
    {
        public short StatusID { get; set; }
        public string? StatusKey { get; set; }
        public string? Description { get; set; }
        public bool IsNew { get; set; }
        public bool IsOpen { get; set; }
        public bool IsClosed { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsFail { get; set; }
    }
}
