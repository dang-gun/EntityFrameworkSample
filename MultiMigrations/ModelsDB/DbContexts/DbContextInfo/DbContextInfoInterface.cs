
using Global.DB;

namespace ModelsDB.MultiMigrations;

/// <summary>
/// DbContextInfo 인터페이스
/// </summary>
/// <remarks>
/// 마이그레이션에 사용될 기본DB정보를 생성하거나 
/// 
/// </remarks>
public interface DbContextInfoInterface
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
