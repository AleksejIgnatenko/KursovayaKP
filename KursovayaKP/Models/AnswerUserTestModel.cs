using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KursovayaKP.Models
{
    public class AnswerUserTestModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdAnswerUser { get; set; }

        [ForeignKey("UserModel")]
        public int UserId { get; set; }

		[ForeignKey("TestModel")]
		public int TestId { get; set; }

        [Required]
        public int ResultTest { get; set; }
    }
}
