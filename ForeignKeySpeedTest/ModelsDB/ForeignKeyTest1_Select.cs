
namespace ForeignKeySpeedTest.TableModels;

/// <summary>
/// 테스트용 테이블
/// </summary>
public class ForeignKeyTest1_Select
{
    /// <summary>
    /// 고유키
    /// </summary>
    public long idTest1Blog { get; set; }

    /// <summary>
    /// 블로그 이름
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 외래키에 연결된 리스트
    /// </summary>
    public List<ForeignKeyTest1_Post>? Posts { get; set; }
}
