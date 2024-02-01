
namespace Global.DB;

/// <summary>
/// 사용하는 DB 타입
/// </summary>
public enum UseDbType
{
	/// <summary>
	/// 없음
	/// </summary>
	None = 0,

	/// <summary>
	/// In Memory
	/// </summary>
	InMemory,

    /// <summary>
    /// SQLite
    /// </summary>
    SQLite,

    /// <summary>
    /// MS SQL
    /// </summary>
    MSSQL,

    /// <summary>
    /// Postgre SQL
    /// </summary>
    PostgreSQL,

    /// <summary>
    /// Maria DB
    /// </summary>
    Mariadb,
}
