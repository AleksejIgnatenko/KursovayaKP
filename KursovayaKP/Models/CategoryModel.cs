using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KursovayaKP.Models
{
	public class CategoryModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdCategory { get; set; }

		[Required]
		public string NameCategory { get; set; }
	}
}
