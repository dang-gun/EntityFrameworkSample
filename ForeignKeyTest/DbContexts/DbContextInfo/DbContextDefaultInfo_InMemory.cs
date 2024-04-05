namespace EntityFrameworkSample.DB.MultiMigrations;

/// <summary>
/// InMomey DB 기본 정보
/// </summary>
public class DbContextDefaultInfo_InMemory : DbContextDefaultInfoInterface
{
    /// <inheritdoc />
    public UseDbType DBType { get; set; } = UseDbType.InMemory;
    /// <inheritdoc />
    public string DBString { get; set; } = "TestDb";

}
