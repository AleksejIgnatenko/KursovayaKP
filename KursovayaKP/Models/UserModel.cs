using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace KursovayaKP.Models
{
    public class UserModel
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required(ErrorMessage = "Неверный логин")]
		[MinLength(3, ErrorMessage = "Имя не должно быть меньше 3 символов")]
		public string UserName { get; set; }

		[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Неверный Email")]
		public string Email { get; set; }

		[MinLength(8, ErrorMessage = "Пароль должен состоять минимум из 8 символов")]
		public string Password { get; set; }

		[NotMapped]
		[Compare("Password", ErrorMessage = "Пароли не совпадают")]
		public string Repeat_password { get; set; }

		public string Role { get; set; } = "Admin";//User Admin

		public static string HashPassword(string password)
		{
			using (SHA512 sha512 = SHA512.Create())
			{
				byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
				byte[] hashBytes = sha512.ComputeHash(passwordBytes);

				return Convert.ToBase64String(hashBytes);
			}
		}
	}
}
