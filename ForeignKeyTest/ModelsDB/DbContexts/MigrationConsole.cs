using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Global.DB;
using Microsoft.EntityFrameworkCore;

namespace ModelsDB;


/// <summary>
/// 마이그레이션 만들기 전용 Main
/// <para>시작 개체를 ModelsDB.MigrationConsole.Main 으로 설정해놓고 마이그레이션을 하면된다.</para>
/// </summary>
/// <remarks>
/// 응용프로그램에 따라 동적/입력 으로 db정보를 제어하는 경우
/// 마이그레이션을 만들 수 없는데 그럴때 사용하는 메인이다.
/// 
/// </remarks>
internal class MigrationConsole
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Migration Console!");

        //범용으로 사용할 데이트
        DateTime dtNow = DateTime.Now;


        GlobalDb.DBType = UseDbType.Sqlite;
        //GlobalDb.DBType = UseDbType.Mssql;


        //db 마이그레이션 적용
        switch (GlobalDb.DBType)
        {
            case UseDbType.Sqlite:
                {
                    GlobalDb.DBString = "Data Source=Test.db";
                    using (ModelsDbContext_Sqlite db1 = new ModelsDbContext_Sqlite())
                    {
                        db1.Database.Migrate();
                    }
                }
                break;
            case UseDbType.Mssql:
                {
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
                                GlobalDb.DBString = sCut[1].Substring(2, sCut[1].Length - 4);
                                break;
                            }
                        }
                    }//end for i

                    using (ModelsDbContext_Mssql db1 = new ModelsDbContext_Mssql())
                    {
                        db1.Database.Migrate();
                    }
                }
                break;
            case UseDbType.InMemory:
                //InMomey는 마이그레이션 개념이 없다.
                break;

            default://기본
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    db1.Database.Migrate();
                }
                break;
        }
    }
}
