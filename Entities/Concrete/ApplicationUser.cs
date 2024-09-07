using Microsoft.AspNetCore.Identity;
namespace Entities.Concrete
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
    }
}
