using Global.DB;

namespace ModelsDB.MultiMigrations;

/// <summary>
/// InMomey DB 정보
/// </summary>
public class DbContextInfo_InMomey : DbContextInfoInterface
{
    /// <inheritdoc />
    public UseDbType DBType { get; set; } = UseDbType.InMemory;
    /// <inheritdoc />
    public string DBString { get; set; } = "TestDb";

}
