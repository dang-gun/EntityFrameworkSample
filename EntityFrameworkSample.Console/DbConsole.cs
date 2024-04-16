using System;
using Microsoft.EntityFrameworkCore;
using DGU_ConsoleAssist;

using EntityFrameworkSample.DB;
using EntityFrameworkSample.DB.Models;


namespace EntityFrameworkSample.Console;

public class DbConsole
{
    /// <summary>
    /// DB 선택 메뉴를 표시하고 선택한 DB를 저장한다.
    /// <para>마이그레이션은 각자 해야 한다.</para>
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


        //선택된 DB 표시
        System.Console.WriteLine($"Use Database '{GlobalDb.DBType.ToString()}'");
        System.Console.WriteLine("");

    }
}
