using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursovayaKP.Models
{
    public class TestModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTest { get; set; }

        [Required(ErrorMessage = "Введите название вопроса")]
        public string NameTest { get; set; }
    }
}
