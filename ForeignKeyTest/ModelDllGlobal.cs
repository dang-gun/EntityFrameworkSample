using System.Security.Cryptography;
using System.Text;

namespace Global.DB;

    /// <summary>
    /// Static으로 선언된 적역 변수들
    /// </summary>
    public static class ModelDllGlobal
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
    /// DB 컨낵션 스트링 저장 - Sqlite 용
    /// </summary>
    /// <remarks>
    /// DBString가 빈값인데 Sqlite을 요청하면 이것을 사용한다.
    /// </remarks>
    public static string DBString_Sqlite = "";
    /// <summary>
    /// DB 컨낵션 스트링 저장 - MSSQL 용
    /// </summary>
    /// <remarks>
    /// DBString가 빈값인데 MSSQL을 요청하면 이것을 사용한다.
    /// </remarks>
    public static string DBString_Mssql = "";

    /// <summary>
    /// 문자열로 저장된 배열(혹은 리스트)의 데이터를 구분할때 사용하는 구분자
    /// </summary>
    /// <remarks>
    /// 이 값을 중간에 바꾸면 기존의 데이터를 재대로 못읽을 수 있다.
    /// </remarks>
    public static char DbArrayDiv = '▒';

	static ModelDllGlobal()
	{
        //기본 Sqlite DB스트링 만들기 *************************
        if (string.Empty == ModelDllGlobal.DBString_Sqlite)
        {
            ModelDllGlobal.DBString_Sqlite = "Data Source=Test.db";
        }

        //기본 MSSQL DB스트링 만들기 *************************
        if (string.Empty == ModelDllGlobal.DBString_Mssql)
        {
            //SettingInfo_gitignore.json 파일 찾기
            List<Tuple<int, string>> listSettingInfoTitle
                            = new List<Tuple<int, string>>();
            listSettingInfoTitle.Add(new Tuple<int, string>(1, "\"ConnectionString_Mssql\""));

            string[] sSettingInfo = File.ReadAllLines("SettingInfo_gitignore.json");
            //불러온 데이터 공백제거
            sSettingInfo = sSettingInfo.Select(s => s.Trim()).ToArray();

            for (int i = 0; i < listSettingInfoTitle.Count; ++i)
            {
                Tuple<int, string> item = listSettingInfoTitle[i];

                //설정 검색
                string? findSI
                    = sSettingInfo
                        .Where(w => w.Length >= item.Item2.Length
                                    && w.Substring(0, item.Item2.Length) == item.Item2)
                        .FirstOrDefault();

                if (null != findSI)
                {//검색 성공

                    if (1 == item.Item1)
                    {
                        //콘론으로 자르고
                        string[] sCut = findSI.Split(":");
                        //앞뒤 큰따옴표 제거
                        ModelDllGlobal.DBString_Mssql = sCut[1].Substring(2, sCut[1].Length - 4);
                        break;
                    }
                }
            }//end for i
        }
    }

}
