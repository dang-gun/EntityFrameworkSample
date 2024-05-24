using System.ComponentModel.DataAnnotations;


namespace TableModels;

/// <summary>
/// 테스트용 테이블1
/// </summary>
public class TestTable1
{
    /// <summary>
    /// 고유키
    /// </summary>
    [Key]
    public int idTestTable1 { get; set; }

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
}
