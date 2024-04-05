using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EntityFrameworkSample.DB.Models;

/// <summary>
/// FK키가 자동으로 증가되는 오류 재연용
/// </summary>
public class AutoIncreases_Test3
{
    /// <summary>
    /// 고유키
    /// </summary>
    [Key]
    public long idAutoIncreases_Test3 { get; set; }

    /// <summary>
    /// 표시 데이터
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 연결된 외래키
    /// </summary>
    [ForeignKey("idAutoIncreases_Test1")]
    public long idAutoIncreases_Test1 { get; set; } = 0;
    /// <summary>
    /// 외래키에 연결된 대상
    /// </summary>
    public AutoIncreases_Test1 Test1 { get; set; } = new AutoIncreases_Test1();
}
