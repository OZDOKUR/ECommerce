using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml.Linq;

namespace ECommerce.Areas.Admin.Models.ViewModels
{
    public class AdminUserVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public IEnumerable<SelectListItem> RoleOptions { get; set; }
    }
}
