using System.Text.Json;
using System.Text.RegularExpressions;
using ModelsDB;
using ModelsDB.MultiMigrations;


namespace Global.DB;

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
    /// 지정된 파일(json)에서 지정된 이름의 DbString을 리턴한다.
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

        if (true == File.Exists(sPath))
        {

            //파일에서 찾을 내용 넣기
            string sJson = File.ReadAllText(sPath);
            //주석 제거
            string jsonWithoutComments = Regex.Replace(sJson, @"(/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/)|(//.*)", ""); 

            List<DbContextDefaultInfo_Temp>? listDbInfo
                = JsonSerializer.Deserialize<List<DbContextDefaultInfo_Temp>>(jsonWithoutComments);

            if (null != listDbInfo)
            {//지정된 파일을 재대로 읽음
                DbContextDefaultInfoInterface? findItem
                    = listDbInfo
                        .Where(w => w.DBType == typeUseDb)
                        .FirstOrDefault();

                if (null != findItem)
                {//지정된 DB 타입을 찾음

                    sReturn = findItem.DBString;
                }
            }
        }

        return sReturn;
    }

    /// <summary>
    /// 지정된 타입으로 DB GlobalDb.DBString정보를 불러온다.
    /// </summary>
    /// <param name="typeDb"></param>
    /// <param name="bDbStringEmpty">GlobalDb.DBString값을 강제로 비울지 여부</param>
    public static void DbStringLoad(
        UseDbType typeDb
        , bool bDbStringEmpty = false)
    {
        if(true == bDbStringEmpty)
        {
            GlobalDb.DBString = string.Empty;
        }

        switch(typeDb)
        {
            case UseDbType.InMemory:
                GlobalDb.DbStringLoad(new DbContextDefaultInfo_InMemory());
                break;
            case UseDbType.SQLite:
                GlobalDb.DbStringLoad(new DbContextDefaultInfo_Sqlite());
                break;
            case UseDbType.MSSQL:
                GlobalDb.DbStringLoad(new DbContextDefaultInfo_Mssql());
                break;
            case UseDbType.PostgreSQL:
                GlobalDb.DbStringLoad(new DbContextDefaultInfo_Postgresql());
                break;
            case UseDbType.MariaDB:
                GlobalDb.DbStringLoad(new DbContextDefaultInfo_Mariadb());
                break;

            case UseDbType.None:
                GlobalDb.DbStringLoad(new DbContextDefaultInfo_InMemory());
                break;
        }
    }

    /// <summary>
    /// DbContextDefaultInfoInterface를 전달받아 DB정보를 갱신한다.
    /// </summary>
    /// <param name="dbContextDefaultInfo"></param>
    public static void DbStringLoad(DbContextDefaultInfoInterface dbContextDefaultInfo)
    {
        GlobalDb.DBType = dbContextDefaultInfo.DBType;

        if (string.Empty == GlobalDb.DBString)
        {//DB 연결 문자열 정보가 없거나

            //DB 연결정보를 다시 불러온다.
            GlobalDb.DBString = dbContextDefaultInfo.DBString;
        }
    }
        
}
