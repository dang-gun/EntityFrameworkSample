
using Global.DB;

namespace ModelsDB.MultiMigrations;

/// <summary>
/// DbContext에 입력할 기본 정보 인터페이스
/// </summary>
/// <remarks>
/// 마이그레이션에 사용될 기본DB정보를 생성하거나 전달하는 용도로 사용된다.
/// </remarks>
public interface DbContextDefaultInfoInterface
{
    /// <summary>
    /// DB 타입
    /// </summary>
    public UseDbType DBType { get; set; }

    /// <summary>
    /// DB 연결 문자열
    /// </summary>
    public string DBString { get; set; }
}
