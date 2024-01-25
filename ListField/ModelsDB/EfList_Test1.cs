using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDB;

public class EfList_Test1
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idEfList_Test1 { get; set; }

    public int[] ListInt1{ get; set; } = new int[0];
    
	public string[] ListString1 { get; set; } = new string[0];
    public List<string> ListString2 { get; set; } = new List<string>();

}
