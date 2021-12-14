using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskToOctopus.Domain.Model
{
    [Table("AspUsersHubConnection")]
    public partial class AspUsersHubConnection
    {
        [Key]
        public int Id { get; set; }
        [StringLength(128)]
        public string UserID { get; set; }
        public string ConnectionID { get; set; }

        [ForeignKey(nameof(UserID))]
        [InverseProperty(nameof(AspNetUser.AspUsersHubConnections))]
        public virtual AspNetUser User { get; set; }
    }
}
