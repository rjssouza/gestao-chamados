using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Security.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Domain = string.Empty;
        }

        public DateTime? CreationDate { get; set; }
        public string Domain { get; set; }
        public DateTime? LastPasswordChangedDate { get; set; }
        public bool? OldHash { get; set; }
    }
}