using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.AuthenticationModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "İsim zorunludur.")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Soyisim zorunludur.")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "E-Posta zorunludur.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon Numarası zorunludur.")]
        [RegularExpression(@"^\d{9,15}$", ErrorMessage = "Geçersiz telefon numarası. Sadece rakamlar ve 10-15 haneli olmalı.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
