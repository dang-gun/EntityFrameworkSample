using Global.DB;

namespace ModelsDB.MultiMigrations;

/// <summary>
/// MSSQL DB 정보
/// </summary>
public class DbContextInfo_Mssql : DbContextInfoInterface
{
    /// <inheritdoc />
    public UseDbType DBType { get; set; } = UseDbType.Mssql;
    /// <inheritdoc />
    public string DBString { get; set; } = string.Empty;

    /// <summary>
    /// 루트에 있는 "SettingInfo_gitignore.json"파일을 읽어 DB를 초기화 한다.
    /// </summary>
    public DbContextInfo_Mssql()
    {
        this.DbStringLoad("SettingInfo_gitignore.json");
    }

    /// <summary>
    /// 지정된 경로의 파일에서 'ConnectionString_Mssql'를 찾아 'DBString'을 넣어준다. 
    /// </summary>
    /// <param name="sPath"></param>
    public DbContextInfo_Mssql(string sPath)
    {
        this.DbStringLoad(sPath);
    }

    /// <summary>
    /// 지정된 경로의 파일에서 'ConnectionString_Mssql'를 찾아 'DBString'을 넣어준다.
    /// </summary>
    /// <param name="sPath"></param>
    public void DbStringLoad(string sPath)
    {
        this.DBString = GlobalDb.DbStringLoad(sPath, "ConnectionString_Mssql");
    }
}
