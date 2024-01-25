using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfTest.Models;

namespace ModelsDB;

public class EfList_Test2
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idEfList_Test2 { get; set; }


	public string[] ListString1 { get; set; } = new string[0];
	public List<string> ListString2 { get; set; } = new List<string>();

	public List<JsonTestModel> ListJson1 { get; set; } = new List<JsonTestModel>();

}
