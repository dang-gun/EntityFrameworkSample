
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
    /// 지정된 파일에서 지정된 이름의 DbString을 리턴한다.
    /// </summary>
    /// <param name="sPath"></param>
    /// <param name="sFindName"></param>
    /// <returns></returns>
    public static string DbStringLoad(string sPath, string sFindName)
    {
        string sReturn = string.Empty;

        if (true == File.Exists(sPath))
        {
            //파일에서 찾을 내용 넣기

            //파일 읽기
            string[] sSettingInfo = File.ReadAllLines(sPath);
            //불러온 데이터 공백제거
            sSettingInfo = sSettingInfo.Select(s => s.Trim()).ToArray();

            //찾을 이름
            string item = $"\"{sFindName}\"";

            //설정 검색
            string? findSI
                = sSettingInfo
                    .Where(w => w.Length >= item.Length
                                && w.Substring(0, item.Length) == item)
                    .FirstOrDefault();

            if (null != findSI)
            {//검색 성공

                //콘론으로 자르고
                string[] sCut = findSI.Split(":");
                //앞뒤 큰따옴표 제거
                sReturn = sCut[1].Substring(2, sCut[1].Length - 4);
            }
        }

        return sReturn;
    }

}
