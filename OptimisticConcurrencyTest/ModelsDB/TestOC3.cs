using System.ComponentModel.DataAnnotations;


namespace OptimisticConcurrencyTest.TableModels;

/// <summary>
/// 테스트용 테이블 - 관리토큰 없음
/// </summary>
public class TestOC3
{
    /// <summary>
    /// 고유키
    /// </summary>
    [Key]
    public int idTestOC3 { get; set; }

    /// <summary>
    /// 숫자형
    /// </summary>
    public int Int { get; set; }

    /// <summary>
    /// 문자형
    /// </summary>
    [MaxLength(32)]
    public string Str { get; set; } = string.Empty;
}
