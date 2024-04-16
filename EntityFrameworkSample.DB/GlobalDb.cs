using System.Text.Json;
using System.Text.RegularExpressions;
using EntityFrameworkSample.DB.Faculty;
using EntityFrameworkSample.DB.MultiMigrations;


namespace EntityFrameworkSample.DB;

/// <summary>
/// Static으로 선언된 적역 변수들
/// </summary>
public static class GlobalDb
{
	/// <summary>
	/// DB 타입
	/// </summary>
	public static UseDbType DBType = UseDbType.InMemory;
	/// <summary>
	/// DB 컨낵션 스트링 저장
	/// </summary>
	public static string DBString = "";

    
    /// <summary>
    /// 문자열로 저장된 배열(혹은 리스트)의 데이터를 구분할때 사용하는 구분자
    /// </summary>
    /// <remarks>
    /// 이 값을 중간에 바꾸면 기존의 데이터를 재대로 못읽을 수 있다.
    /// </remarks>
    public static char DbArrayDiv = '▒';


	static GlobalDb()
	{
    }

    /// <summary>
    /// 지정한 UseDbType를 기준으로 GlobalDb.DBString을 다시 불러 저장한다.
    /// </summary>
    /// <param name="typeUseDb">사용할 DB 타입</param>
    /// <param name="bOnlyEmpty">GlobalDb.DBString가 비었을때만 다시 불러올지 여부</param>
    public static void DbStringReload(
        UseDbType typeUseDb
        , bool bOnlyEmpty)
    {
        GlobalDb.DBType = typeUseDb;
        GlobalDb.DbStringReload(bOnlyEmpty);
    }

    /// <summary>
    /// GlobalDb.DBType을 기준으로 GlobalDb.DBString을 다시 불러 저장한다.
    /// </summary>
    /// <remarks>
    /// DB정보를 다시 불러와야 할 상황에서만 사용하는 것이 좋다.
    /// </remarks>
    /// <param name="bOnlyEmpty">GlobalDb.DBString가 비었을때만 다시 불러올지 여부</param>
    public static void DbStringReload(bool bOnlyEmpty)
    {
        if(string.Empty == GlobalDb.DBString
            || false == bOnlyEmpty)
        {
            DbContextDefaultInfoInterface newDbInfo
                = new DbContextDefaultInfo_Temp();

            switch (GlobalDb.DBType)
            {
                case UseDbType.SQLite:
                    newDbInfo = new DbContextDefaultInfo_Sqlite();
                    break;

                case UseDbType.MSSQL:
                    newDbInfo = new DbContextDefaultInfo_Mssql();
                    break;

                case UseDbType.PostgreSQL:
                    newDbInfo = new DbContextDefaultInfo_Postgresql();
                    break;

                case UseDbType.MariaDB:
                    newDbInfo = new DbContextDefaultInfo_Mariadb();
                    break;

                case UseDbType.InMemory:
                    newDbInfo = new DbContextDefaultInfo_InMemory();
                    break;
            }//end switch

            GlobalDb.DBString = newDbInfo.DBString;
        }
        
    }

    /// <summary>
    /// 루트에 있는 'SettingInfo_gitignore.json'파일을 읽어 지정된 타입의 DbString을 리턴한다.
    /// <para>실행 위치를 기준으로 절대 경로를 만들어 'SettingInfo_gitignore.json'파일을 찾는다.</para>
    /// </summary>
    /// <param name="typeUseDb"></param>
    /// <returns></returns>
    public static string DbStringLoad(
        UseDbType typeUseDb)
    {
        string sFullPath = string.Empty;

        string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string? directoryPath = Path.GetDirectoryName(path);

        //시스템 경로라 null리는 없지만...혹시나 해서 이렇게 작성함
        if(null == directoryPath)
        {
            sFullPath = Path.Combine("SettingInfo_gitignore.json");
        }
        else
        {
            sFullPath = Path.Combine(directoryPath, "SettingInfo_gitignore.json");
        }

        return GlobalDb.DbStringLoad(
            sFullPath
            , typeUseDb);
    }

    /// <summary>
    /// 지정된 파일(json)에서 지정된 타입의 DbString을 리턴한다.
    /// </summary>
    /// <param name="sPath"></param>
    /// <param name="typeUseDb"></param>
    /// <returns></returns>
    public static string DbStringLoad(
        string sPath
        , UseDbType typeUseDb)
    {
        string sReturn = string.Empty;


        //Console.WriteLine($"DbStringLoad : {sPath}");

        //한번쓰고 버려지는 개체라 필요할대 생성해서 사용한다.
        sReturn = (new DbStringFileLoad()).DbStringLoad(sPath , typeUseDb );

        return sReturn;
    }
}
