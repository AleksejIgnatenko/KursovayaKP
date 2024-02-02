using System.ComponentModel.DataAnnotations;

namespace KursovayaKP.Models
{
	public class QuestionModel
	{
		[Required]
		public string QuestionText { get; set; }

		[Required]
		public string Answer1 { get; set; }

		[Required]
		public string Answer2 { get; set; }

		[Required]
		public string Answer3 { get; set; }

		[Required]
		public string Answer4 { get; set; }

		[Required]
		[RegularExpression("^(Answer1|Answer2|Answer3|Answer4)$", ErrorMessage = "Одно из полей с ответами должно содержать правильный ответ")]
		public string CorrectAnswer { get; set; }
	}
}
