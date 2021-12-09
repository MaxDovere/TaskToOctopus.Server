using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TaskToOctopus.Server.ActionModels
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            AspNetUsersNots = new HashSet<AspNetUsersNot>();
            AspUsersHubConnections = new HashSet<AspUsersHubConnection>();
        }

        [Key]
        [StringLength(128)]
        public string Id { get; set; }
        [StringLength(256)]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }
        public bool IsRootAdmin { get; set; }
        [StringLength(128)]
        public string DealerKey { get; set; }
        public short? StatusID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreationTimeUtc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastPwdResetTimeUtc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastPwdChangeTimeUtc { get; set; }
        [StringLength(128)]
        public string ParentUserID { get; set; }

        [ForeignKey(nameof(DealerKey))]
        [InverseProperty(nameof(SSODealer.AspNetUsers))]
        public virtual SSODealer DealerKeyNavigation { get; set; }
        [InverseProperty(nameof(AspNetUserClaim.User))]
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        [InverseProperty(nameof(AspNetUserLogin.User))]
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        [InverseProperty(nameof(AspNetUserRole.User))]
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        [InverseProperty(nameof(AspNetUsersNot.User))]
        public virtual ICollection<AspNetUsersNot> AspNetUsersNots { get; set; }

        [InverseProperty(nameof(AspUsersHubConnection.User))]
        public virtual ICollection<AspUsersHubConnection> AspUsersHubConnections { get; set; }
        
    }
}
