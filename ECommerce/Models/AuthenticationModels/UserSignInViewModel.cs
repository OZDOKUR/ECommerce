using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.AuthenticationModels
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Lütfen Mail Giriniz.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen şifre giriniz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
