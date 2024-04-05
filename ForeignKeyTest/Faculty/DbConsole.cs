using System;
using Microsoft.EntityFrameworkCore;
using DGU_ConsoleAssist;

using EntityFrameworkSample.DB;
using EntityFrameworkSample.DB.Models;


namespace EntityFrameworkSample.Console;

public class DbConsole
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tyepsUseDb">화면에 표시할 DB를 비트 플래그로 넣어준다..</param>
    public void DbSelectConsole(UseDbType tyepsUseDb)
    {
        ConsoleMenuAssist newCA = new ConsoleMenuAssist();

        //새로 메뉴 작성
        newCA = new ConsoleMenuAssist();

        if (tyepsUseDb.HasFlag(UseDbType.InMemory))
        {
            newCA.MenuList.Add(new MenuModel()
            {
                Index = 0,
                TextFormat = "{0}. Memory DB",
                Action = (MenuModel menuThis) =>
                {
                    GlobalDb.DBType = UseDbType.InMemory;
                    return false;
                }
            });
        }

        if (tyepsUseDb.HasFlag(UseDbType.SQLite))
        {
            newCA.MenuList.Add(new MenuModel()
            {
                Index = 1,
                TextFormat = "{0}. SQLite",
                Action = (MenuModel menuThis) =>
                {
                    GlobalDb.DBType = UseDbType.SQLite;
                    return false;
                }
            });
        }

        if (tyepsUseDb.HasFlag(UseDbType.MSSQL))
        {
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
        }

        if (tyepsUseDb.HasFlag(UseDbType.PostgreSQL))
        {
            newCA.MenuList.Add(new MenuModel()
            {
                Index = 3,
                TextFormat = "{0}. PostgreSQL (SettingInfo_gitignore.json 파일이 있어야 에러가 나지 않습니다.)",
                Action = (MenuModel menuThis) =>
                {
                    GlobalDb.DBType = UseDbType.PostgreSQL;
                    return false;
                }
            });
        }

        if (tyepsUseDb.HasFlag(UseDbType.MariaDB))
        {
            newCA.MenuList.Add(new MenuModel()
            {
                Index = 4,
                TextFormat = "{0}. MariaDB (SettingInfo_gitignore.json 파일이 있어야 에러가 나지 않습니다.)",
                Action = (MenuModel menuThis) =>
                {
                    GlobalDb.DBType = UseDbType.MariaDB;
                    return false;
                }
            });
        }

        newCA.MenuList.Add(new MenuModel());
        newCA.QuestionMessage = $"Select DB Type : ";
        //메뉴 표시
        newCA.ShowKeyWait(false);

        newCA.MenuEnd = new MenuModel()
        {
            Index = 999,
            MatchString = "Exit",
            TextFormat = "{0}. [{1}] Exit",
        };


        //선택된 DB 표시
        System.Console.WriteLine($"Use Database '{GlobalDb.DBType.ToString()}'");
        System.Console.WriteLine("");
        System.Console.WriteLine("DB Setting....");

        //db 마이그레이션 적용
        //DB연결 문자열이 없으면 기본값을 사용
        switch (GlobalDb.DBType)
        {
            case UseDbType.InMemory:
                //InMomey는 마이그레이션 개념이 없다.
                using (ModelsDbContext db1 = new ModelsDbContext(true))
                {
                    //DBString 재설정
                }
                break;

            default://기본
                using (ModelsDbContext db1 = new ModelsDbContext(true))
                {
                    //DBString 재설정

                    //마이그레이션
                    db1.Database.Migrate();
                }
                break;
        }

        System.Console.WriteLine("DB Setting complete");
        System.Console.WriteLine("");
    }
}
