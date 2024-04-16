using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignKeySpeedTest.TableModels;

/// <summary>
/// 테스트용 테이블 - 많은 데이터용
/// </summary>
public class ForeignKeyTest3_Post
{
    /// <summary>
    /// 고유키
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    public long idTest3Blog { get; set; }
    /// <summary>
    /// 외래키에 연결된 대상
    /// </summary>
    [ForeignKey("idTest3Blog")]
    public ForeignKeyTest3_Blog? Blog3 { get; set; }


}
