using Global.DB;

namespace ModelsDB.MultiMigrations;

/// <summary>
/// Sqlite DB 기본 정보
/// </summary>
public class DbContextDefaultInfo_Sqlite : DbContextDefaultInfoInterface
{
    /// <inheritdoc />
    public UseDbType DBType { get; set; } = UseDbType.Sqlite;
    /// <inheritdoc />
    public string DBString { get; set; } = "Data Source=Test.db";
}
