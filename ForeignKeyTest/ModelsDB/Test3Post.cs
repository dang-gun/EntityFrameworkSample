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
public class Test3Post
{
    /// <summary>
    /// 고유키
    /// </summary>
    [Key]
    public long idTest3Post { get; set; }

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
    [ForeignKey("idTest3Blog")]
    public long idTest3Blog { get; set; } = 0;
    /// <summary>
    /// 외래키에 연결된 대상
    /// </summary>
    [ForeignKey("idTest3Blog")]
    public Test3Blog.Test3Blog? Blog3 { get; set; }


}
