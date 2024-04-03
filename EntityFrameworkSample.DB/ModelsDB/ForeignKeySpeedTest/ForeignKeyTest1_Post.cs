using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.DB.Models.ForeignKeySpeedTest;

/// <summary>
/// 테스트용 테이블 - 많은 데이터용
/// </summary>
public class ForeignKeyTest1_Post
{
    /// <summary>
    /// 고유키
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    [ForeignKey("idTest1Blog")]
    public long idTest1Blog { get; set; }
    /// <summary>
    /// 외래키에 연결된 대상
    /// </summary>
    public ForeignKeyTest1_Blog? Blog { get; set; }
}
