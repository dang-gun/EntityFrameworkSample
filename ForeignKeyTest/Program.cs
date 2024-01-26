using System.Linq;

using Microsoft.EntityFrameworkCore;

using Global.DB;
using ModelsDB;
using ModelsDB.Test3Blog;
using DGU_ConsoleAssist;

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
                GlobalDb.DBType = UseDbType.Sqlite;
                return false;
            }
        });
        newCA.MenuList.Add(new MenuModel()
        {
            Index = 2,
            TextFormat = "{0}. MSSQL (SettingInfo_gitignore.json 파일이 있어야 에러가 나지 않습니다.)",
            Action = (MenuModel menuThis) =>
            {
                GlobalDb.DBType = UseDbType.Mssql;
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
                Console.WriteLine($"Use Database '${UseDbType.Sqlite.ToString()}'");
                return false;
            }
        });

        newCA.MenuList.Add(new MenuModel());
        newCA.QuestionMessage = $"Select DB Type : ";
        //메뉴 표시
        newCA.ShowKeyWait(false);


        //선택된 DB 표시
        Console.WriteLine($"Use Database '${GlobalDb.DBType.ToString()}'");
        Console.WriteLine("");
        Console.WriteLine("DB Setting....");

        //db 마이그레이션 적용
        switch (GlobalDb.DBType)
        {
            case UseDbType.Sqlite:
                using (ModelsDbContext_Sqlite db1 = new ModelsDbContext_Sqlite())
                {
                    db1.Database.Migrate();
                }
                break;
            case UseDbType.Mssql:
                using (ModelsDbContext_Mssql db1 = new ModelsDbContext_Mssql())
                {
                    db1.Database.Migrate();
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

        #region 메뉴 - 데이터 생성 딜레이 체크
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}. 검색 테스트",
            Action = (MenuModel menuThis) =>
            {
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    Test1Blog iqTO = db1.Test1Blog.Include(x => x.Posts).First();

                    List<Test1Post> listTO = new List<Test1Post>();

                    Test1Post t1pTemp = db1.Test1Post.First();
                    Test1Blog? t1bTemp = t1pTemp.Blog;

                    Console.WriteLine($"iqTO : {iqTO.Name}, listTO count : {listTO.Count}");
                    if(null == t1bTemp)
                    {
                        Console.WriteLine($"t1pTemp = t1bTemp : null");
                    }
                    else
                    {
                        Console.WriteLine($"t1pTemp = t1bTemp : {t1bTemp.Name}");
                    }
                    
                }

                Console.WriteLine("");
                return true;
            }
        });
        #endregion

        #region 메뉴 - Select List Speed Test
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}. Select List Speed Test",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine("");

                Console.WriteLine("****** select list ******");
                Console.WriteLine(" start select fk list --------------");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<Test1Blog> iqTO = db1.Test1Blog;
                    List<Test1Blog> listTO = iqTO.ToList();

                    Console.WriteLine($"count : {listTO.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                Console.WriteLine(" start select non fk list --------------");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<Test2Blog> iqTO = db1.Test2Blog;

                    List<Test2Blog> listTO = iqTO.ToList();

                    Console.WriteLine($"count : {listTO.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }


                Console.WriteLine(" ");
                Console.WriteLine("****** select take(non Include) child ******");
                Console.WriteLine(" start select fk list --------------");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    List<Test1Select> listTo
                        = (from t1b in db1.Test1Blog.Take(1)
                           select new Test1Select()
                           {
                               idTest1Blog = t1b.idTest1Blog,
                               Name = t1b.Name,
                               Posts = t1b.Posts.ToList(),
                           })
                           .ToList();

                    Console.WriteLine($"count : {listTo.Count}, post:{listTo[0].Posts!.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                Console.WriteLine(" start select non fk list --------------");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    List<Test2Select> listTo
                        = (from t2b in db1.Test2Blog.Take(1)
                           select new Test2Select()
                           {
                               idTest2Blog = t2b.idTest2Blog,
                               Name = t2b.Name,
                               Posts = db1.Test2Post.Where(w => w.idTest2Blog == t2b.idTest2Blog).ToList(),
                           })
                           .ToList();

                    Console.WriteLine($"count : {listTo.Count}, post:{listTo[0].Posts!.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                Console.WriteLine("");
                return true;
            }
        });
        #endregion

        #region 메뉴 - select take child Test
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}.  select take child Test",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine("****** select take child ******");
                Console.WriteLine(" start select fk list --------------");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<Test1Select> list
                        = (from t1b in db1.Test1Blog.Take(1).Include(i => i.Posts)
                           select new Test1Select()
                           {
                               idTest1Blog = t1b.idTest1Blog,
                               Name = t1b.Name,
                               Posts = t1b.Posts.ToList(),
                           });

                    List<Test1Select> listTo = list.ToList();

                    Console.WriteLine($"count : {listTo.Count}, post:{listTo[0].Posts!.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    //Console.WriteLine("query : ");
                    //Console.WriteLine(list.ToQueryString());
                }

                Console.WriteLine(" start select non fk list --------------");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<Test2Select> list
                        = (from t2b in db1.Test2Blog.Take(1)
                           select new Test2Select()
                           {
                               idTest2Blog = t2b.idTest2Blog,
                               Name = t2b.Name,
                               Posts = db1.Test2Post.Where(w => w.idTest2Blog == t2b.idTest2Blog).ToList(),
                           });

                    List<Test2Select> listTo = list.ToList();
                    Console.WriteLine($"count : {listTo.Count}, post:{listTo[0].Posts!.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    //Console.WriteLine("query : ");
                    //Console.WriteLine(list.ToQueryString());
                }

                return true;
            }
        });
        #endregion

        #region 메뉴 - select where child
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}.  select where child",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine("****** select where child ******");
                Console.WriteLine(" start select fk list --------------");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<Test1Select> list
                        = (from t1b in db1.Test1Blog.Where(w => w.idTest1Blog == 1)
                           select new Test1Select()
                           {
                               idTest1Blog = t1b.idTest1Blog,
                               Name = t1b.Name,
                               Posts = t1b.Posts.ToList(),
                           });

                    List<Test1Select> listTo = list.ToList();

                    Console.WriteLine($"count : {listTo.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    //Console.WriteLine("query : ");
                    //Console.WriteLine(list.ToQueryString());
                }

                Console.WriteLine(" start select non fk list --------------");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<Test2Select> list
                        = (from t2b in db1.Test2Blog.Where(w => w.idTest2Blog == 1)
                           select new Test2Select()
                           {
                               idTest2Blog = t2b.idTest2Blog,
                               Name = t2b.Name,
                               Posts = db1.Test2Post.Where(w => w.idTest2Blog == t2b.idTest2Blog).ToList(),
                           });

                    List<Test2Select> listTo = list.ToList();
                    Console.WriteLine($"count : {listTo.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    //Console.WriteLine("query : ");
                    //Console.WriteLine(list.ToQueryString());
                }

                return true;
            }
        });
        #endregion

        #region 메뉴 - select where child 30
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}.  select where child 30",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine("****** select where child 30 ******");
                Console.WriteLine(" start select fk list --------------");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<Test1Select> list
                        = (from t1b in db1.Test1Blog.Where(w => 1 <= w.idTest1Blog && w.idTest1Blog <= 30)
                           select new Test1Select()
                           {
                               idTest1Blog = t1b.idTest1Blog,
                               Name = t1b.Name,
                               Posts = t1b.Posts.ToList(),
                           });

                    List<Test1Select> listTo = list.ToList();

                    Console.WriteLine($"count : {listTo.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    //Console.WriteLine("query : ");
                    //Console.WriteLine(list.ToQueryString());
                }

                Console.WriteLine(" start select non fk list --------------");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<Test2Select> list
                        = (from t2b in db1.Test2Blog.Where(w => 1 <= w.idTest2Blog && w.idTest2Blog <= 30)
                           select new Test2Select()
                           {
                               idTest2Blog = t2b.idTest2Blog,
                               Name = t2b.Name,
                               Posts = db1.Test2Post.Where(w => w.idTest2Blog == t2b.idTest2Blog).ToList(),
                           });

                    List<Test2Select> listTo = list.ToList();
                    Console.WriteLine($"count : {listTo.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    //Console.WriteLine("query : ");
                    //Console.WriteLine(list.ToQueryString());
                }

                return true;
            }
        });
        #endregion

        #region 메뉴 - select child list
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}.  select child list",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine("****** select child list ******");
                Console.WriteLine(" start select fk list --------------");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    List<Test1Select> list
                        = (from t1b in db1.Test1Blog.Where(w => 1 <= w.idTest1Blog && w.idTest1Blog <= 10)
                           select new Test1Select()
                           {
                               idTest1Blog = t1b.idTest1Blog,
                               Name = t1b.Name,
                               Posts = t1b.Posts.ToList(),
                           })
                          .ToList();

                    int c = 0;
                    foreach (Test1Select t in list)
                    {
                        if (null != t.Posts)
                        {
                            c += t.Posts.Count;
                        }
                    }

                    Console.WriteLine($"count : {list.Count}, post:{c}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                Console.WriteLine(" start select non fk list --------------");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    List<Test2Select> list
                        = (from t2b in db1.Test2Blog.Where(w => 1 <= w.idTest2Blog && w.idTest2Blog <= 10)
                           select new Test2Select()
                           {
                               idTest2Blog = t2b.idTest2Blog,
                               Name = t2b.Name,
                               Posts = db1.Test2Post.Where(w => w.idTest2Blog == t2b.idTest2Blog).ToList(),
                           })
                          .ToList();

                    int c = 0;
                    foreach (Test2Select t in list)
                    {
                        if (null != t.Posts)
                        {
                            c += t.Posts.Count;
                        }
                    }

                    Console.WriteLine($"count : {list.Count}, post:{c}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                return true;
            }
        });
        #endregion

        #region 메뉴 - item to parent list
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}.  item to parent list",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine("****** item to parent list ******");
                Console.WriteLine(" start select fk list --------------");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    Test1Post iqTO = db1.Test1Post.Include(i => i.Blog).First();
                    Console.WriteLine($"item select, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    Test1Blog? t1b = iqTO.Blog;
                    string sName = string.Empty;
                    if (null != t1b)
                    {
                        sName = t1b.Name;
                    }
                    Console.WriteLine($"blog : {sName}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                Console.WriteLine(" start select non fk list --------------");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    Test2Post iqTO = db1.Test2Post.First();
                    Console.WriteLine($"item select, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");


                    Test2Blog t2b
                        = db1.Test2Blog
                            .Where(w => w.idTest2Blog == iqTO.idTest2Blog)
                            .First();
                    Console.WriteLine($"blog : {t2b.Name}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                return true;
            }
        });
        #endregion

        #region 메뉴 - item to parent list (non Include)
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}.  item to parent list (non Include)",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine("****** item to parent list ******");
                Console.WriteLine(" start select fk list --------------");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    Test1Post iqTO = db1.Test1Post.Include(i => i.Blog).First();
                    Console.WriteLine($"item select, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    Test1Blog? t1b = iqTO.Blog;
                    string sName = string.Empty;
                    if (null != t1b)
                    {
                        sName = t1b.Name;
                    }
                    Console.WriteLine($"blog : {sName}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                Console.WriteLine(" start select non fk list --------------");
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    Test2Post iqTO = db1.Test2Post.First();
                    Console.WriteLine($"item select, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");


                    Test2Blog t2b
                        = db1.Test2Blog
                            .Where(w => w.idTest2Blog == iqTO.idTest2Blog)
                            .First();
                    Console.WriteLine($"blog : {t2b.Name}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                return true;
            }
        });
        #endregion

        newCA.MenuList.Add(new MenuModel());

        #region 메뉴 - 데이터 추가
        newCA.MenuList.Add(new MenuModel()
        {
            Index = 100,
            TextFormat = "{0}. DB에 데이터 추가",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine("");
                Console.WriteLine("DB Data adding....");

                Db_DataAdd();

                using (ModelsDbContext db1 = new ModelsDbContext())
                {

                    //블로그는 순차 생성
                    for (int i = 1; i < 100; ++i)
                    {
                        Test1Blog newT1B = new Test1Blog();
                        newT1B.Name = $"Test1Blog {i}";
                        db1.Test1Blog.Add(newT1B);

                        Test2Blog newT2B = new Test2Blog();
                        newT2B.Name = $"Test2Blog {i}";
                        db1.Test2Blog.Add(newT2B);
                    }

                    db1.SaveChanges();

                    Db_DataAdd_Temp2(new Random(), db1);
                    db1.SaveChanges();

                    Console.WriteLine($"DB Data complete. Total Count: {db1.Test1Blog.Count()}(Test1Blog), {db1.Test2Blog.Count()}(Test2Blog)");
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

        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            Console.WriteLine("DB data add start1");

            //블로그는 순차 생성
            for (int i = 1; i < 10000; ++i)
            {
                Test1Blog newT1B = new Test1Blog();
                newT1B.Name = $"Test1Blog {i}";
                db1.Test1Blog.Add(newT1B);

                Test2Blog newT2B = new Test2Blog();
                newT2B.Name = $"Test2Blog {i}";
                db1.Test2Blog.Add(newT2B);
            }

            db1.SaveChanges();
        }

        using (ModelsDbContext db2 = new ModelsDbContext())
        {
            Console.WriteLine("DB data add start2");
            for (int i = 1; i <= 1; ++i)
            {
                Db_DataAdd_Temp1(i, rand);
            }

            Console.WriteLine("DB data add End");
        }

    }

    /// <summary>
    /// 10만번씩 끊어서 실행
    /// </summary>
    /// <param name="nCount"></param>
    /// <param name="rand"></param>
    static void Db_DataAdd_Temp1(
        int nCount
        , Random rand)
    {
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            Console.WriteLine("DB data add start2-" + nCount);
            for (int i = 1; i < 100000; ++i)
            {
                Db_DataAdd_Temp2(rand, db1);
            }

            db1.SaveChanges();
        }
    }

    /// <summary>
    /// 1개를 넣는다.
    /// </summary>
    /// <param name="rand"></param>
    /// <param name="db1"></param>
    static void Db_DataAdd_Temp2(
        Random rand
        , ModelsDbContext db1)
    {
        int Int = rand.Next(0, 100000);
        string Str = Guid.NewGuid().ToString();
        DateTime Date = new DateTime(rand.Next(0, 1000000));
        long idFK = rand.Next(1, 10000);
        //long idFK = rand.Next(0, 100);

        Test1Post newT1P = new Test1Post();
        newT1P.Int = Int;
        newT1P.Str = Str;
        newT1P.Date = Date;
        //외래키 연결 랜덤하게 
        newT1P.idTest1Blog = idFK;
        db1.Test1Post.Add(newT1P);


        Test2Post newT2P = new Test2Post();
        newT2P.Int = Int;
        newT2P.Str = Str;
        newT2P.Date = Date;
        //외래키 연결 랜덤하게 
        newT2P.idTest2Blog = idFK;
        db1.Test2Post.Add(newT2P);
    }
}