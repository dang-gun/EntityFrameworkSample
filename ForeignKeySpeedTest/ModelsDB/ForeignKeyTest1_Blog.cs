using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignKeySpeedTest.TableModels;

/// <summary>
/// 테스트용 테이블
/// </summary>
public class ForeignKeyTest1_Blog
{
    /// <summary>
    /// 고유키
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long idTest1Blog { get; set; }

    /// <summary>
    /// 블로그 이름
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 외래키에 연결된 리스트
    /// </summary>
    [ForeignKey("idTest1Blog")]
    public ICollection<ForeignKeyTest1_Post> Posts { get; set; } 
        = new List<ForeignKeyTest1_Post>();


    //[ForeignKey("idTest3Blog")]
    //public ICollection<Test3Post> Posts3 { get; set; } = new List<Test3Post>();


}
