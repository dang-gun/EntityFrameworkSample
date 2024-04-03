
namespace EntityFrameworkSample.DB.Models.ForeignKeySpeedTest;

/// <summary>
/// 테스트용 테이블
/// </summary>
public class ForeignKeyTest2_Select
{
    /// <summary>
    /// 고유키
    /// </summary>
    public long idTest2Blog { get; set; }

    /// <summary>
    /// 블로그 이름
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 외래키에 연결된 리스트
    /// </summary>
    public List<ForeignKeyTest2_Post>? Posts { get; set; }
}
