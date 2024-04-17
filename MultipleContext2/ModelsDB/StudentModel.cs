using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ModelsDB;

public class StudentModel
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int ID { get; set; }
	public string LastName { get; set; } = string.Empty;
	public string FirstMidName { get; set; } = string.Empty;
	public DateTime EnrollmentDate { get; set; }
}
