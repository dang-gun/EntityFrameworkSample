using System;
using Microsoft.EntityFrameworkCore;
using DGU_ConsoleAssist;

using EntityFrameworkSample.DB;
using EntityFrameworkSample.DB.Models;
using EntityFrameworkSample.DB.Models.ForeignKeySpeedTest;

namespace EntityFrameworkSample.Console;

public class DbConsole
{
    public void DbSelectConsole()
    {
        ConsoleMenuAssist newCA = new ConsoleMenuAssist();

        //새로 메뉴 작성
        newCA = new ConsoleMenuAssist();

        //DB 세팅
        newCA.MenuList.Add(new MenuModel()
        {
            Index = 1,
            TextFormat = "{0}. Sqlite",
            Action = (MenuModel menuThis) =>
            {
                GlobalDb.DBType = UseDbType.SQLite;
                return false;
            }
        });
        newCA.MenuList.Add(new MenuModel()
        {
            Index = 2,
            TextFormat = "{0}. MSSQL (SettingInfo_gitignore.json 파일이 있어야 에러가 나지 않습니다.)",
            Action = (MenuModel menuThis) =>
            {
                GlobalDb.DBType = UseDbType.MSSQL;
                return false;
            }
        });
        newCA.MenuList.Add(new MenuModel()
        {
            Index = 3,
            TextFormat = "{0}. Memory DB",
            Action = (MenuModel menuThis) =>
            {
                GlobalDb.DBType = UseDbType.InMemory;
                return false;
            }
        });

        newCA.MenuList.Add(new MenuModel());
        newCA.QuestionMessage = $"Select DB Type : ";
        //메뉴 표시
        newCA.ShowKeyWait(false);


        //선택된 DB 표시
        System.Console.WriteLine($"Use Database '{GlobalDb.DBType.ToString()}'");
        System.Console.WriteLine("");
        System.Console.WriteLine("DB Setting....");

        //db 마이그레이션 적용
        switch (GlobalDb.DBType)
        {
            case UseDbType.SQLite:
                {
                    //GlobalDb.DBString = "Data Source=Test.db";
                    using (ModelsDbContext_Sqlite db1 = new ModelsDbContext_Sqlite())
                    {
                        db1.Database.Migrate();
                    }
                }
                break;
            case UseDbType.MSSQL:
                {
                    using (ModelsDbContext_Mssql db1 = new ModelsDbContext_Mssql())
                    {
                        db1.Database.Migrate();
                    }
                }
                break;
            case UseDbType.InMemory:
                //InMomey는 마이그레이션 개념이 없다.
                //GlobalDb.DBString = "TestDB";
                break;

            default://기본
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    db1.Database.Migrate();
                }
                break;
        }

        System.Console.WriteLine("DB Setting complete");
        System.Console.WriteLine("");
    }
}
