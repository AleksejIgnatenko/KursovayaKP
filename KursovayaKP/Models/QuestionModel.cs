using System.ComponentModel.DataAnnotations;

namespace KursovayaKP.Models
{
	public class QuestionModel
	{
		[Required]
		public string QuestionText { get; set; }

        [Url(ErrorMessage = "Неверный формат ссылки")]
        public string? LinkPhoto { get; set; }

        [Required]
		public string Answer1 { get; set; }

		[Required]
		public string Answer2 { get; set; }

		[Required]
		public string Answer3 { get; set; }

		[Required]
		public string Answer4 { get; set; }

        [Required]
        public string CorrectAnswer { get; set; }
    }
}
