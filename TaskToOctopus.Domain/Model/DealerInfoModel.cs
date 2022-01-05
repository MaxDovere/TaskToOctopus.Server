using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TaskToOctopus.Domain.Model
{
    [Keyless]
    public partial class DealerInfoModel
    {
        [StringLength(128)]
        public string SSODealerID { get; set; }
        public string DBName { get; set; }
        public string CRMLink { get; set; }
        public int NewMessages { get; set; }
    }
}
