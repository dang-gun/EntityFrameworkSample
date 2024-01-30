using Global.DB;

namespace ModelsDB.MultiMigrations;

/// <summary>
/// Sqlite DB 정보
/// </summary>
public class DbContextInfo_Sqlite : DbContextInfoInterface
{
    /// <inheritdoc />
    public UseDbType DBType { get; set; } = UseDbType.Sqlite;
    /// <inheritdoc />
    public string DBString { get; set; } = "Data Source=Test.db";
}
