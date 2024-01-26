using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDB;

/// <summary>
/// 테스트용 테이블 - 많은 데이터용
/// </summary>
public class Test1Post
{
    /// <summary>
    /// 고유키
    /// </summary>
    [Key]
    public long idTest1Post { get; set; }

    /// <summary>
    /// 숫자형
    /// </summary>
    public int Int { get; set; }
    
    /// <summary>
    /// 문자형
    /// </summary>
    public string Str { get; set; } = string.Empty;

    /// <summary>
    /// 날짜형
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// 연결된 외래키
    /// </summary>
    [ForeignKey("Test1Blog")]
    public long idTest1Blog { get; set; } = 0;
    /// <summary>
    /// 외래키에 연결된 대상
    /// </summary>
    public Test1Blog? Blog { get; set; }
}
