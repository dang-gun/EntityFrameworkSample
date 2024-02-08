using System.Text.Json;
using System.Text.RegularExpressions;

using EntityFrameworkSample.DB.MultiMigrations;

namespace EntityFrameworkSample.DB.Faculty;

/// <summary>
/// 
/// </summary>
public class DbStringFileLoad
{
    /// <summary>
    /// 지정된 파일(json)에서 지정된 이름의 DbString을 리턴한다.
    /// </summary>
    /// <param name="sPath"></param>
    /// <param name="typeUseDb"></param>
    /// <returns></returns>
    public string DbStringLoad(
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
