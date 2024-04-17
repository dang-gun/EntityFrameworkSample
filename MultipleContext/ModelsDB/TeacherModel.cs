using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ModelsDB;

public class TeacherModel
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int ID { get; set; }
	public string LastName { get; set; } = string.Empty;
	public string FirstMidName { get; set; } = string.Empty;
	public DateTime HireDate { get; set; }
}
