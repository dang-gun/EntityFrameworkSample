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
    /// 루트에 있는 'SettingInfo_gitignore.json'파일을 읽어 지정된 타입의 DbString을 리턴한다.
    /// </summary>
    /// <param name="typeUseDb"></param>
    /// <returns></returns>
    public static string DbStringLoad(
        UseDbType typeUseDb)
    {
        return GlobalDb.DbStringLoad(
            Path.Combine("SettingInfo_gitignore.json")
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
        sReturn = (new DbStringFileLoad()).DbStringLoad( sPath , typeUseDb );

        return sReturn;
    }
}
