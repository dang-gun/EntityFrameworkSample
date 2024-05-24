using DGU_ConsoleAssist;
using EntityFrameworkSample.Console;
using EntityFrameworkSample.DB;
using Microsoft.EntityFrameworkCore;
using ModelsDB;
using TableModels;

namespace ContextLifeCycleTest;

/// <summary>
/// Context의 생명주기와 관련된 테스트
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
        DateTime dtNow = DateTime.Now;
        long totalMemory = 0;

        Console.WriteLine("Hello, Entity Framework Context Life Cycle Test!");

        //db 선택 받기
        DbConsole consoleMenuDb = new DbConsole();
        consoleMenuDb.DbSelectConsole(UseDbType.InMemory | UseDbType.SQLite);


        #region 마이그레이션
        //마이그레이션
        //마이그레이션은 마이그레이션을 생성할때 사용한 DbContext를 사용해야 재대로 동작하므로
        //라이브러리화를 할 수 없다.
        System.Console.WriteLine("DB Setting....");

        //DB 정보가 없으면 기본 정보 불러오기
        GlobalDb.DbStringReload(true);


        //db 마이그레이션 적용
        //DB연결 문자열이 없으면 기본값을 사용
        switch (GlobalDb.DBType)
        {
            case UseDbType.SQLite:
                using (ModelsDbContext_Sqlite db1 = new ModelsDbContext_Sqlite())
                {
                    //마이그레이션
                    db1.Database.Migrate();
                }
                break;

            case UseDbType.InMemory://InMomey는 마이그레이션 개념이 없다.
            default:
                //동작 없음
                break;
        }
        #endregion

        System.Console.WriteLine("DB Setting complete");
        System.Console.WriteLine("");





        //새로 메뉴 작성
        //https://github.com/dang-gun/DGUtility_DotNet/tree/main/DGU_ConsoleAssist
        ConsoleMenuAssist newCA = new ConsoleMenuAssist();

        int nIndex = 0;

        newCA.WelcomeMessage = $"{Environment.NewLine}"
            + $"--------------------------------------------";

        newCA.MenuList.Add(new MenuModel()
        {
            Index = 0,
            TextFormat = "{0}. 데이터 추가",
            Action = (MenuModel menuThis) =>
            {
                System.Console.WriteLine(" --- --- --- --- --- --- ---");

                Db_DataAdd();

                System.Console.WriteLine(" --- --- --- --- --- --- ---");
                return true;
            }
        });

        newCA.MenuList.Add(new MenuModel());
        newCA.MenuList.Add(new MenuModel());


        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nIndex,
            TextFormat = "{0}. DB를 읽는 순간 확인",
            Action = (MenuModel menuThis) =>
            {
                System.Console.WriteLine(" --- --- --- --- --- --- ---");
                System.Console.WriteLine($" {menuThis.TextFormat} ");

                Console.WriteLine($"start - use Momery: {GetTotalMemory()} byte");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    //리스트를 받고
                    IQueryable<TestTable1> iqTO1 = db1.TestTable1;
                    Console.WriteLine($"IQueryable - use Momery: {GetTotalMemory()} byte");

                    List<TestTable1> listTO1 = iqTO1.ToList();
                    Console.WriteLine($"ToList - use Momery: {GetTotalMemory()} byte");


                }//end using db1
                Console.WriteLine($"db1 closed - use Momery: {GetTotalMemory()} byte");
                Console.WriteLine("");

                System.Console.WriteLine(" --- --- --- --- --- --- ---");
                return true;
            }
        });

        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nIndex,
            TextFormat = "{0}. 조회 테스트",
            Action = (MenuModel menuThis) =>
            {
                System.Console.WriteLine(" --- --- --- --- --- --- ---");
                System.Console.WriteLine($" {menuThis.TextFormat} ");

                long nTemp1 = 0;
                long nTemp2 = 0;
                long nTemp3 = 0;
                long nTemp4 = 0;


                Console.WriteLine($"Queryable start - use Momery: {GetTotalMemory(out nTemp1)} byte");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    //리스트를 받고
                    IQueryable<TestTable1> iqTO1 = db1.TestTable1.Where(w => w.Int > 50000);
                    List<TestTable1> listTO1 = iqTO1.ToList();
                    Console.WriteLine($"Queryable ToList - use Momery: {GetTotalMemory(out nTemp2)} byte");
                }//end using db1

                nTemp3 = nTemp2 - nTemp1;
                Console.WriteLine($"Queryable closed - use Momery: {GetTotalMemory(out nTemp1)} byte");
                Console.WriteLine("");


                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    //리스트를 받고
                    List<TestTable1> listTO1 = db1.TestTable1.ToList();
                    listTO1 = listTO1.Where(w => w.Int > 50000).ToList();
                    Console.WriteLine($"ToList - use Momery: {GetTotalMemory(out nTemp2)} byte");
                }//end using db1

                nTemp4 = nTemp2 - nTemp1;


                Console.WriteLine($"ToList closed - use Momery: {GetTotalMemory()} byte, diff:{(nTemp3 - nTemp4):#,###}");
                Console.WriteLine("");

                System.Console.WriteLine(" --- --- --- --- --- --- ---");
                return true;
            }
        });




        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nIndex,
            TextFormat = "{0}. 추적 끊기",
            Action = (MenuModel menuThis) =>
            {
                System.Console.WriteLine(" --- --- --- --- --- --- ---");
                System.Console.WriteLine($" {menuThis.TextFormat} ");

                //임시 리스트
                List<TestTable1> listTO1 = new List<TestTable1>();
                List<TestTable2> listTO2 = new List<TestTable2>();

                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    listTO1 = db1.TestTable1.Where(w => w.idTestTable1 == 1).ToList();
                    listTO2 = db1.TestTable2.Where(w => w.idTestTable2 == 1).ToList();

                    listTO1.First().Str = "추적 끊김 테스트(1)";
                    listTO2.First().Str = "추적 끊김 테스트(2)";
                    db1.SaveChanges();

                    Console.WriteLine($"Before disconnect : listTO1[0].Str{listTO1.First().Str}, listTO2[0].Str{listTO2.First().Str}");
                }//end using db1

                using (ModelsDbContextTable db2 = new ModelsDbContextTable())
                {
                    listTO1.First().Str = "추적이 완전히 끊김(1)";
                    listTO2.First().Str = "추적 다시 연결(2)";

                    db2.TestTable2.Attach(listTO2.First());

                    db2.SaveChanges();

                    listTO1 = db2.TestTable1.Where(w => w.idTestTable1 == 1).ToList();
                    listTO2 = db2.TestTable2.Where(w => w.idTestTable2 == 1).ToList();

                    Console.WriteLine($"After disconnect : listTO1[0].Str{listTO1.First().Str}, listTO2[0].Str{listTO2.First().Str}");
                }//end using db1

                Console.WriteLine("");

                System.Console.WriteLine(" --- --- --- --- --- --- ---");
                return true;
            }
        });

        newCA.MenuList.Add(new MenuModel());

        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nIndex,
            TextFormat = "{0}. 사용하고 바로 제거",
            Action = (MenuModel menuThis) =>
            {
                System.Console.WriteLine(" --- --- --- --- --- --- ---");
                System.Console.WriteLine($" {menuThis.TextFormat} ");

                Console.WriteLine($"start - use Momery: {GetTotalMemory()} byte");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    //리스트를 받고
                    IQueryable<TestTable1> iqTO1 = db1.TestTable1;
                    List<TestTable1> listTO1 = iqTO1.ToList();

                    Console.WriteLine($"db1 Not closed - use Momery: {GetTotalMemory()} byte");
                }//end using db1
                Console.WriteLine($"db1 closed - use Momery: {GetTotalMemory()} byte");
                Console.WriteLine("");

                using (ModelsDbContextTable db2 = new ModelsDbContextTable())
                {
                    //리스트를 받고
                    IQueryable<TestTable2> iqTO = db2.TestTable2;
                    List<TestTable2> listTO = iqTO.ToList();

                    Console.WriteLine($"db2 Not closed - use Momery: {GetTotalMemory()} byte");
                }//end using db2
                Console.WriteLine($"db2 closed - use Momery: {GetTotalMemory()} byte");
                Console.WriteLine("");

                using (ModelsDbContextTable db3 = new ModelsDbContextTable())
                {
                    //리스트를 받고
                    IQueryable<TestTable3> iqTO = db3.TestTable3;
                    List<TestTable3> listTO = iqTO.ToList();

                    Console.WriteLine($"db3 Not closed - use Momery: {GetTotalMemory()} byte");
                }//end using db1
                Console.WriteLine($"db3 closed - use Momery: {GetTotalMemory()} byte");
                Console.WriteLine("");

                System.Console.WriteLine(" --- --- --- --- --- --- ---");
                return true;
            }
        });


        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nIndex,
            TextFormat = "{0}. 하나의 컨택스트로 사용",
            Action = (MenuModel menuThis) =>
            {
                System.Console.WriteLine(" --- --- --- --- --- --- ---");
                System.Console.WriteLine($" {menuThis.TextFormat} ");

                Console.WriteLine($"start - use Momery: {GetTotalMemory()} byte");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    //리스트를 받고
                    IQueryable<TestTable1> iqTO1 = db1.TestTable1;
                    List<TestTable1> listTO1 = iqTO1.ToList();

                    Console.WriteLine($"iqTO1 use Momery: {GetTotalMemory()} byte");

                    //리스트를 받고
                    IQueryable<TestTable2> iqTO2 = db1.TestTable2;
                    List<TestTable2> listTO2 = iqTO2.ToList();

                    Console.WriteLine($"iqTO2 use Momery: {GetTotalMemory()} byte");

                    //리스트를 받고
                    IQueryable<TestTable3> iqTO3 = db1.TestTable3;
                    List<TestTable3> listTO3 = iqTO3.ToList();

                    Console.WriteLine($"iqTO3 use Momery: {GetTotalMemory()} byte");
                }//end using db1

                Console.WriteLine($"db closed - use Momery: {GetTotalMemory()} byte");
                Console.WriteLine("");

                System.Console.WriteLine(" --- --- --- --- --- --- ---");
                return true;
            }
        });



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


    /// <summary>
    /// 데이터 생성
    /// </summary>
    /// <remarks>
    /// 마이그레이션에서 데이터를 넣으면 마이그레이션 파일이 너무 커지는 현상이 있다.
    /// 이 함수를 수동으로 한번만 호출하여 테스트용 DB파일을 생성한다.
    /// </remarks>
    static void Db_DataAdd()
    {
        Random rand = new Random();

        using (ModelsDbContextTable db1 = new ModelsDbContextTable())
        {
            Console.WriteLine("DB data add start1");
            for (int i = 1; i < 100000; ++i)
            {
                TestTable1 newTD1 = new TestTable1();
                newTD1.Int = rand.Next(0, 100000);
                newTD1.Str = Guid.NewGuid().ToString();
                newTD1.Date = new DateTime(rand.Next(0, 1000000));
                db1.TestTable1.Add(newTD1);
            }

            db1.SaveChanges();
        }

        using (ModelsDbContextTable db2 = new ModelsDbContextTable())
        {
            Console.WriteLine("DB data add start2");
            for (int i = 1; i < 100000; ++i)
            {
                TestTable2 newTD2 = new TestTable2();
                newTD2.Int = rand.Next(0, 100000);
                newTD2.Str = Guid.NewGuid().ToString();
                newTD2.Date = new DateTime(rand.Next(0, 1000000));
                db2.TestTable2.Add(newTD2);
            }

            db2.SaveChanges();
        }

        using (ModelsDbContextTable db3 = new ModelsDbContextTable())
        {
            Console.WriteLine("DB data add start3");
            for (int i = 1; i < 100000; ++i)
            {
                TestTable3 newTD3 = new TestTable3();
                newTD3.Int = rand.Next(0, 100000);
                newTD3.Str = Guid.NewGuid().ToString();
                newTD3.Date = new DateTime(rand.Next(0, 1000000));
                db3.TestTable3.Add(newTD3);
            }

            db3.SaveChanges();
        }


        Console.WriteLine("DB data add End");
    }

    /// <summary>
    /// 사용중이 메모리양을 문자열로 바꿔 전달한다.
    /// </summary>
    /// <returns></returns>
    static string GetTotalMemory()
    {
        return $"{GC.GetTotalMemory(false):#,###}";
    }
    /// <summary>
    /// 사용중이 메모리양을 문자열로 바꿔 전달한다.
    /// </summary>
    /// <param name="nMomery"></param>
    /// <returns></returns>
    static string GetTotalMemory(out long nMomery)
    {
        nMomery = GC.GetTotalMemory(false);
        return $"{nMomery:#,###}";
    }

    /// <summary>
    /// 사용중인 메모리양을 리턴한다.
    /// </summary>
    /// <returns></returns>
    static long GetTotalMemoryInt()
    {
        return GC.GetTotalMemory(false);
    }
}
