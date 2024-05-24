using Microsoft.EntityFrameworkCore;

using Utility.AsontuDynamicOrderBy;

using DGU_ConsoleAssist;
using EntityFrameworkSample.Console;
using EntityFrameworkSample.DB;

using ModelsDB;

using DynamicOrderBy.TableModels;


namespace DynamicOrderBy;

internal class Program
{
    static void Main(string[] args)
    {
        DateTime dtNow = DateTime.Now;

        Console.WriteLine("Hello, Entity Framework Dynamic OrderBy!");
        
        
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

        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nIndex,
            TextFormat = "{0}. EF 자체 정렬",
            Action = (MenuModel menuThis) =>
            {
                System.Console.WriteLine(" --- --- --- --- --- --- ---");

                Console.WriteLine("------ start order EF --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    //리스트 초기화
                    //리스트를 받고
                    IQueryable<TestOrderBy> iqTO = db1.TestOrderBy;

                    iqTO = iqTO.OrderBy(ob => ob.idTestOrderBy);
                    List<TestOrderBy> listTO = iqTO.ToList();
                }
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<TestOrderBy> iqTO = db1.TestOrderBy;

                    iqTO = iqTO.OrderByDescending(ob => ob.Int);
                    List<TestOrderBy> listTO = iqTO.ToList();

                    Console.WriteLine("Int : " + (DateTime.Now.Ticks - dtNow.Ticks));
                }
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<TestOrderBy> iqTO = db1.TestOrderBy;

                    iqTO = iqTO.OrderBy(ob => ob.Str);
                    List<TestOrderBy> listTO = iqTO.ToList();

                    Console.WriteLine("Str : " + (DateTime.Now.Ticks - dtNow.Ticks));
                }
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<TestOrderBy> iqTO = db1.TestOrderBy;

                    iqTO = iqTO.OrderByDescending(ob => ob.Date);
                    List<TestOrderBy> listTO = iqTO.ToList();

                    Console.WriteLine("Date : " + (DateTime.Now.Ticks - dtNow.Ticks));
                }

                System.Console.WriteLine(" --- --- --- --- --- --- ---");
                return true;
            }
        });


        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nIndex,
            TextFormat = "{0}. EF 자체 정렬 - 많은 데이터",
            Action = (MenuModel menuThis) =>
            {
                System.Console.WriteLine(" --- --- --- --- --- --- ---");

                Console.WriteLine("------ start order EF - Big --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    //리스트 초기화
                    //리스트를 받고
                    IQueryable<TestOrderBy_Big> iqTO = db1.TestOrderBy_Big;

                    iqTO = iqTO.OrderBy(ob => ob.idTestOrderBy);
                    List<TestOrderBy_Big> listTO = iqTO.ToList();
                }
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<TestOrderBy_Big> iqTO = db1.TestOrderBy_Big;

                    iqTO = iqTO.OrderByDescending(ob => ob.Int);
                    List<TestOrderBy_Big> listTO = iqTO.ToList();

                    Console.WriteLine("Int : " + (DateTime.Now.Ticks - dtNow.Ticks));
                }
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<TestOrderBy_Big> iqTO = db1.TestOrderBy_Big;

                    iqTO = iqTO.OrderBy(ob => ob.Str);
                    List<TestOrderBy_Big> listTO = iqTO.ToList();

                    Console.WriteLine("Str : " + (DateTime.Now.Ticks - dtNow.Ticks));
                }
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<TestOrderBy_Big> iqTO = db1.TestOrderBy_Big;

                    iqTO = iqTO.OrderByDescending(ob => ob.Date);
                    List<TestOrderBy_Big> listTO = iqTO.ToList();

                    Console.WriteLine("Date : " + (DateTime.Now.Ticks - dtNow.Ticks));
                }

                System.Console.WriteLine(" --- --- --- --- --- --- ---");
                return true;
            }
        });


        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nIndex,
            TextFormat = "{0}. Asontu님 방식",
            Action = (MenuModel menuThis) =>
            {
                System.Console.WriteLine(" --- --- --- --- --- --- ---");

                //https://asontu.github.io/2020/04/02/a-better-way-to-do-dynamic-orderby-in-c-sharp.html
                Console.WriteLine("------ start order Asontu --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    //리스트 초기화
                    //리스트를 받고
                    IQueryable<TestOrderBy> iqTO = db1.TestOrderBy;

                    iqTO = iqTO.OrderBy(ob => ob.idTestOrderBy);
                    List<TestOrderBy> listTO = iqTO.ToList();

                    //Test code
                    //string sColumn = "Name";
                    //bool bAsc = true;

                    //IOrderBy? orderBy = null;

                    //switch (sColumn)
                    //{
                    //    case "idTestOrderBy":
                    //        orderBy = new OrderBy<TestOrderBy, int>(x => x.idTestOrderBy);
                    //        break;

                    //    case "Str":
                    //        orderBy = new OrderBy<TestOrderBy, string>(x => x.Str);
                    //        break;

                    //    case "Int":
                    //        orderBy = new OrderBy<TestOrderBy, int>(x => x.Int);
                    //        break;
                    //}

                    //if (true == bAsc)
                    //{
                    //    iqTO = iqTO.OrderBy(orderBy!);
                    //}
                    //else
                    //{
                    //    iqTO = iqTO.OrderByDescending(orderBy!);
                    //}


                }
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<TestOrderBy> iqTO = db1.TestOrderBy;

                    iqTO = iqTO.OrderByDescending(OrderFunctions.OrderFunctionList["Int"]);
                    List<TestOrderBy> listTO = iqTO.ToList();

                    Console.WriteLine("Int : " + (DateTime.Now.Ticks - dtNow.Ticks));
                }
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<TestOrderBy> iqTO = db1.TestOrderBy;

                    iqTO = iqTO.OrderBy(OrderFunctions.OrderFunctionList["Str"]);
                    List<TestOrderBy> listTO = iqTO.ToList();

                    Console.WriteLine("Str : " + (DateTime.Now.Ticks - dtNow.Ticks));
                }
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<TestOrderBy> iqTO = db1.TestOrderBy;

                    iqTO = iqTO.OrderByDescending(OrderFunctions.OrderFunctionList["Date"]);
                    List<TestOrderBy> listTO = iqTO.ToList();

                    Console.WriteLine("Date : " + (DateTime.Now.Ticks - dtNow.Ticks));
                }

                System.Console.WriteLine(" --- --- --- --- --- --- ---");
                return true;
            }
        });




        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nIndex,
            TextFormat = "{0}. Asontu님 방식 - 많은 데이터",
            Action = (MenuModel menuThis) =>
            {
                System.Console.WriteLine(" --- --- --- --- --- --- ---");

                Console.WriteLine("------ start order Asontu - Big --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    //리스트 초기화
                    //리스트를 받고
                    IQueryable<TestOrderBy_Big> iqTO = db1.TestOrderBy_Big;

                    iqTO = iqTO.OrderBy(ob => ob.idTestOrderBy);
                    List<TestOrderBy_Big> listTO = iqTO.ToList();
                }
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<TestOrderBy_Big> iqTO = db1.TestOrderBy_Big;

                    iqTO = iqTO.OrderByDescending(OrderFunctions.OrderFunctionList_Big["Int"]);
                    List<TestOrderBy_Big> listTO = iqTO.ToList();

                    Console.WriteLine("Int : " + (DateTime.Now.Ticks - dtNow.Ticks));
                }
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<TestOrderBy_Big> iqTO = db1.TestOrderBy_Big;

                    iqTO = iqTO.OrderBy(OrderFunctions.OrderFunctionList_Big["Str"]);
                    List<TestOrderBy_Big> listTO = iqTO.ToList();

                    Console.WriteLine("Str : " + (DateTime.Now.Ticks - dtNow.Ticks));
                }
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<TestOrderBy_Big> iqTO = db1.TestOrderBy_Big;

                    iqTO = iqTO.OrderByDescending(OrderFunctions.OrderFunctionList_Big["Date"]);
                    List<TestOrderBy_Big> listTO = iqTO.ToList();

                    Console.WriteLine("Date : " + (DateTime.Now.Ticks - dtNow.Ticks));
                }

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
            for (int i = 1; i < 10; ++i)
            {
                TestOrderBy newTO = new TestOrderBy();
                newTO.Int = rand.Next(0, 100000);
                newTO.Str = Guid.NewGuid().ToString();
                newTO.Date = new DateTime(rand.Next(0, 1000000));
                db1.TestOrderBy.Add(newTO);
            }

            db1.SaveChanges();
        }

        using (ModelsDbContextTable db2 = new ModelsDbContextTable())
        {
            Console.WriteLine("DB data add start2");
            for (int i = 1; i < 1000000; ++i)
            {
                TestOrderBy_Big newTO_Big = new TestOrderBy_Big();
                newTO_Big.Int = rand.Next(0, 100000);
                newTO_Big.Str = Guid.NewGuid().ToString();
                newTO_Big.Date = new DateTime(rand.Next(0, 1000000));
                db2.TestOrderBy_Big.Add(newTO_Big);
            }

            db2.SaveChanges();
            Console.WriteLine("DB data add End");
        }

    }
}