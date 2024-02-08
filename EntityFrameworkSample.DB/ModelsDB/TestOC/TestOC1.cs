using System.ComponentModel.DataAnnotations;


namespace EntityFrameworkSample.DB.Models;

/// <summary>
/// 테스트용 테이블 - 클라이언트 관리 토큰
/// </summary>
public class TestOC1
{
    /// <summary>
    /// 고유키
    /// </summary>
    [Key]
    public int idTestOC1 { get; set; }

    /// <summary>
    /// 숫자형
    /// </summary>
    public int Int { get; set; }

    /// <summary>
    /// 문자형
    /// </summary>
    [MaxLength(32)]
    public string Str { get; set; } = string.Empty;


    /// <summary>
    /// 클라이언트 관리 토큰(GUID로 생성)
    /// </summary>
    [ConcurrencyCheck]
    public Guid Version { get; set; }
}
