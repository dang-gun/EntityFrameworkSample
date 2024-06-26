﻿namespace EntityFrameworkSample.DB.MultiMigrations;

/// <summary>
/// MSSQL DB 기본 정보
/// </summary>
public class DbContextDefaultInfo_Mssql : DbContextDefaultInfoInterface
{
    /// <inheritdoc />
    public UseDbType DBType { get; set; } = UseDbType.MSSQL;
    /// <inheritdoc />
    public string DBString { get; set; } = string.Empty;

    /// <summary>
    /// 루트에 있는 "SettingInfo_gitignore.json"파일을 읽어 DB를 초기화 한다.
    /// </summary>
    public DbContextDefaultInfo_Mssql()
    {
        this.DbStringLoad(null);
    }

    /// <summary>
    /// 지정된 경로의 파일에서 'ConnectionString_Mssql'를 찾아 'DBString'을 넣어준다. 
    /// </summary>
    /// <param name="sPath"></param>
    public DbContextDefaultInfo_Mssql(string sPath)
    {
        this.DbStringLoad(sPath);
    }

    /// <summary>
    /// 지정된 경로의 파일에서 정보를 찾아 'DBString'을 넣어준다. 
    /// </summary>
    /// <param name="sPath"></param>
    public void DbStringLoad(string? sPath)
    {
        if (string.IsNullOrEmpty(sPath))
        {//경로가 비어 있다.
            this.DBString = GlobalDb.DbStringLoad(UseDbType.MSSQL);
        }
        else
        {//경로가 있다.
            this.DBString = GlobalDb.DbStringLoad(sPath, UseDbType.MSSQL);
        }
    }
}
