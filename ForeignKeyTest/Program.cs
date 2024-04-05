using System.Linq;

using Microsoft.EntityFrameworkCore;
using DGU_ConsoleAssist;

using EntityFrameworkSample.DB;
using EntityFrameworkSample.DB.Models;


namespace ForeignKeyTest;

internal class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Entity Framework Sample!");
        Console.WriteLine("☆☆☆ Entity Framework Foreign Key Test(ForeignKeyTest) ☆☆☆");


        //범용으로 사용할 데이트
        DateTime dtNow = DateTime.Now;


        //.NET 콘솔 지원
        //https://github.com/dang-gun/DGUtility_DotNet/tree/main/DGU_ConsoleAssist
        ConsoleMenuAssist newCA = new ConsoleMenuAssist();

        #region 사용 DB 세팅
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
        Console.WriteLine($"Use Database '{GlobalDb.DBType.ToString()}'");
        Console.WriteLine("");
        Console.WriteLine("DB Setting....");

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

        Console.WriteLine("DB Setting complete");
        Console.WriteLine("");
        #endregion

        newCA.MenuEnd = new MenuModel()
        {
            Index = 999,
            MatchString = "Exit",
            TextFormat = "{0}. [{1}] Exit",
        };




        //새로 메뉴 작성
        newCA = new ConsoleMenuAssist();
        newCA.WelcomeMessage = $"{Environment.NewLine}"
            + $"{Environment.NewLine}"
            + $"테스트 메뉴를 선택해 주세요. {Environment.NewLine}"
            + $"데이터가 없다면 데이터부터 생성해야 합니다. {Environment.NewLine}"
            + $"--------------------------------------------";

        //메뉴 넘버링용
        int nMenuCount = 0;

        #region 메뉴 - FK Auto Increases - 부모 기준 검색
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}. FK Auto Increases - 부모 기준 검색",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine(" --- --- --- --- --- --- ---");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //부모1 추출
                    AutoIncreases_Test1 iqTest1 
                    = db1.AutoIncreases_Test1
                        .Include(inc2 => inc2.Test2)
                        .Include(inc3 => inc3.Test3)
                        .First();
                    Console.WriteLine($"부모({iqTest1.idAutoIncreases_Test1}, {iqTest1.Name})");
                    Console.WriteLine("");

                    //소속된 자식2 추출
                    List<AutoIncreases_Test2> listTest2 = iqTest1.Test2.ToList();
                    Console.WriteLine($"자식2(Test2) : 자식({listTest2.Count})");
                    foreach (AutoIncreases_Test2 item in listTest2)
                    {
                        Console.WriteLine($"자식2 : ${item.idAutoIncreases_Test1}(Parent)"
                            + ", ${item.idAutoIncreases_Test2}(id)"
                            + ", ${item.Name}(Name)");
                    }

                    //소속된 자식3 추출
                    List<AutoIncreases_Test3> listTest3 = iqTest1.Test3.ToList();
                    Console.WriteLine($"자식3(Test3) : 자식({listTest3.Count})");
                    foreach (AutoIncreases_Test3 item in listTest3)
                    {
                        Console.WriteLine($"자식3 : ${item.idAutoIncreases_Test1}(Parent)"
                            + ", ${item.idAutoIncreases_Test3}(id)"
                            + ", ${item.Name}(Name)");
                    }
                }

                Console.WriteLine(" --- --- --- --- --- --- ---");
                return true;
            }
        });
        #endregion

        #region 메뉴 - FK Auto Increases - 자식 기준 검색
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}. FK Auto Increases - 자식 기준 검색",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine(" --- --- --- --- --- --- ---");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //소속된 자식2 추출
                    List<AutoIncreases_Test2> listTest2 
                        = db1.AutoIncreases_Test2.ToList();
                    Console.WriteLine($"자식2(Test2) : 자식({listTest2.Count})");
                    foreach (AutoIncreases_Test2 item in listTest2)
                    {
                        Console.WriteLine($"자식2 : ${item.idAutoIncreases_Test1}(Parent)"
                            + ", ${item.idAutoIncreases_Test2}(id)"
                            + ", ${item.Name}(Name)");
                    }

                    //소속된 자식3 추출
                    List<AutoIncreases_Test3> listTest3 
                        = db1.AutoIncreases_Test3.ToList();
                    Console.WriteLine($"자식3(Test3) : 자식({listTest3.Count})");
                    foreach (AutoIncreases_Test3 item in listTest3)
                    {
                        Console.WriteLine($"자식3 : ${item.idAutoIncreases_Test1}(Parent)"
                            + ", ${item.idAutoIncreases_Test3}(id)"
                            + ", ${item.Name}(Name)");
                    }
                }

                Console.WriteLine(" --- --- --- --- --- --- ---");
                return true;
            }
        });
        #endregion

        newCA.MenuList.Add(new MenuModel());

        #region 메뉴 - 데이터 추가
        newCA.MenuList.Add(new MenuModel()
        {
            Index = 100,
            TextFormat = "{0}. DB에 자식 데이터 추가",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine("");
                Console.WriteLine("DB Data adding....");

                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    for(int i = 0; i < 10; ++i)
                    {
                        string sGuid = Guid.NewGuid().ToString();

                        AutoIncreases_Test2 newT1B = new AutoIncreases_Test2();
                        newT1B.Name = sGuid;
                        newT1B.idAutoIncreases_Test1 = 1;
                        db1.AutoIncreases_Test2.Add(newT1B);

                        AutoIncreases_Test3 newT2B = new AutoIncreases_Test3();
                        newT2B.Name = sGuid;
                        newT1B.idAutoIncreases_Test1 = 1;
                        db1.AutoIncreases_Test3.Add(newT2B);
                    }

                    db1.SaveChanges();

                    Console.WriteLine($"DB Data add complete.");
                }

                Console.WriteLine("");
                return true;
            }
        });
        #endregion

        newCA.MenuList.Add(new MenuModel());

        newCA.MenuEnd = new MenuModel()
        {
            Index = 999,
            MatchString = "Exit",
            TextFormat = "{0}. [{1}] Exit",
        };

        newCA.QuestionMessage = $"--------------------------------------------{Environment.NewLine}"
            + $"Select Command : ";

        //메뉴 표시
        newCA.ShowKeyWait(false);


    }

}