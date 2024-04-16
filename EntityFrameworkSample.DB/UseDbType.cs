
namespace EntityFrameworkSample.DB;

/// <summary>
/// 사용하는 DB 타입
/// </summary>
[Flags]
public enum UseDbType
{
    /// <summary>
    /// 없음
    /// </summary>
    None = 0,

    /// <summary>
    /// In Memory
    /// </summary>
    InMemory = 1 << 0,

    /// <summary>
    /// SQLite
    /// </summary>
    SQLite = 1 << 1,

    /// <summary>
    /// MS SQL
    /// </summary>
    MSSQL = 1 << 2,

    /// <summary>
    /// Postgre SQL
    /// </summary>
    PostgreSQL = 1 << 3,

    /// <summary>
    /// Maria DB
    /// </summary>
    MariaDB = 1 << 4,

    /// <summary>
    /// 전체 사용
    /// </summary>
    All = int.MaxValue,
}
