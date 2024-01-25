
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
	Memory,

	/// <summary>
	/// Sqlite
	/// </summary>
	Sqlite,

	/// <summary>
	/// MS Sql
	/// </summary>
	Mssql,
}
