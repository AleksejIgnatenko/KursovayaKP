using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KursovayaKP.Models
{
    public class AnswerUserTestModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required] 
        public string NameTest { get; set; }

        [Required]
        public int ResultTest { get; set; }
    }
}
