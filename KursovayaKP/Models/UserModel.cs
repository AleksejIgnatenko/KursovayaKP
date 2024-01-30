using System.ComponentModel.DataAnnotations;

namespace KursovayaKP.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Неверный логин")]
        [MinLength(3, ErrorMessage = "Имя не должно быть меньше 3 символов")]
        public string UserName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Неверный Email")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "Пароль должен состоять минимум из 8 символов")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string Repeat_password { get; set; }

        public string Role { get; set; } = "User";
    }
}
