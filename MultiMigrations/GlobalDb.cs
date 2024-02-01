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
}
