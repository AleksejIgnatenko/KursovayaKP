using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursovayaKP.Models
{
    public class QuestionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdQuestion { get; set; }

        [ForeignKey("TestModel")]
        public int IdTest { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        public string QuestionText { get; set; }

        [Url(ErrorMessage = "Неверный формат ссылки")]
        public string? LinkPhoto { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        public string Answer1 { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        public string Answer2 { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        public string Answer3 { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        public string Answer4 { get; set; }

        [Required(ErrorMessage = "Заполните поле")]
        public string CorrectAnswer { get; set; }

/*        public string Topic { get; set; }

        public enum Section
        {
            TrafficRegulations,
            RoadSigns,
            MedicalCare,
            CarDevice
        }*/
    }
}
