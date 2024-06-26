﻿
using Microsoft.EntityFrameworkCore;
using DGU_ConsoleAssist;

using EntityFrameworkSample.DB;
using EntityFrameworkSample.DB.Models;
using EntityFrameworkSample.Console;
using ForeignKeySpeedTest.TableModels;


namespace ForeignKeySpeedTest;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Entity Framework Sample!");
        Console.WriteLine("☆☆☆ Entity Framework Foreign Key Speed Test(ForeignKeySpeedTest) ☆☆☆");

        //범용으로 사용할 데이트
        DateTime dtNow = DateTime.Now;


        //.NET 콘솔 지원
        //https://github.com/dang-gun/DGUtility_DotNet/tree/main/DGU_ConsoleAssist
        ConsoleMenuAssist newCA;

        //db 선택 받기
        DbConsole consoleMenuDb = new DbConsole();
        consoleMenuDb.DbSelectConsole(UseDbType.All);

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

            case UseDbType.MSSQL:
                using (ModelsDbContext_Mssql db1 = new ModelsDbContext_Mssql())
                {
                    //마이그레이션
                    db1.Database.Migrate();
                }
                break;

            case UseDbType.PostgreSQL:
                using (ModelsDbContext_Postgresql db1 = new ModelsDbContext_Postgresql())
                {
                    //마이그레이션
                    db1.Database.Migrate();
                }
                break;

            case UseDbType.MariaDB:
                using (ModelsDbContext_Mariadb db1 = new ModelsDbContext_Mariadb())
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
        newCA = new ConsoleMenuAssist();
        newCA.WelcomeMessage = $"{Environment.NewLine}"
            + $"{Environment.NewLine}"
            + $"테스트 메뉴를 선택해 주세요. {Environment.NewLine}"
            + $"데이터가 없다면 데이터부터 생성해야 합니다. {Environment.NewLine}"
            + $"--------------------------------------------";

        //메뉴 넘버링용
        int nMenuCount = 0;

        #region 메뉴 - 기본 검색
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}. 기본 검색",
            Action = (MenuModel menuThis) =>
            {
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //부모 1개 추출
                    ForeignKeyTest1_Blog iq1Blog = db1.ForeignKeyTest1_Blog.First();
                    //소속된 자식 추출
                    List<ForeignKeyTest1_Post> list1Post = iq1Blog.Posts.ToList();

                    Console.WriteLine($"Include 없는 기본 검색 : 부모({iq1Blog.idTest1Blog}, {iq1Blog.Name}), 자식({list1Post.Count})");
                    Console.WriteLine($"delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");


                    dtNow = DateTime.Now;
                    //(Include)부모 1개 추출
                    ForeignKeyTest1_Blog iq1Blog2 = db1.ForeignKeyTest1_Blog.Include(x => x.Posts).First();
                    //소속된 자식 추출
                    List<ForeignKeyTest1_Post> list1Post2 = iq1Blog2.Posts.ToList();

                    Console.WriteLine($"Include 있는 기본 검색 : 부모({iq1Blog2.idTest1Blog}, {iq1Blog2.Name}), 자식({list1Post2.Count})");
                    Console.WriteLine($"delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");



                }

                using (ModelsDbContextTable db2 = new ModelsDbContextTable())
                {
                    Console.WriteLine("");

                    dtNow = DateTime.Now;

                    //자식 1개 추출
                    ForeignKeyTest1_Post iq1Post_child1
                    = db2.ForeignKeyTest1_Post
                        .Where(w => w.idTest1Blog == 1)
                        .Include(inc => inc.Blog)
                        .First();

                    //부모 찾기
                    ForeignKeyTest1_Blog iq1Blog_child1 = iq1Post_child1.Blog!;

                    Console.WriteLine($"자식이 부모 찾기 : 자식({iq1Post_child1.Str}), 부모({iq1Blog_child1.idTest1Blog}, {iq1Blog_child1.Name}) ");
                    Console.WriteLine($"delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    dtNow = DateTime.Now;
                    Console.WriteLine($"자식이 찾은 부모의 자식들 : {iq1Blog_child1.Posts.Count} ");
                    Console.WriteLine($"delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                Console.WriteLine("");
                return true;
            }
        });
        #endregion

        #region 메뉴 - 인쿨루드 생략 가능한 경우
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}. 인쿨루드 생략 가능한 경우",
            Action = (MenuModel menuThis) =>
            {
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {

                    dtNow = DateTime.Now;
                    //(Include)부모 1개 추출
                    ForeignKeyTest1_Blog iq1Blog2 = db1.ForeignKeyTest1_Blog.Include(x => x.Posts).First();
                    //소속된 자식 추출
                    List<ForeignKeyTest1_Post> list1Post2 = iq1Blog2.Posts.ToList();

                    Console.WriteLine($"Include 있는 기본 검색 : 부모({iq1Blog2.idTest1Blog}, {iq1Blog2.Name}), 자식({list1Post2.Count})");
                    Console.WriteLine($"delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");


                    //부모 1개 추출
                    ForeignKeyTest1_Blog iq1Blog = db1.ForeignKeyTest1_Blog.First();
                    //소속된 자식 추출
                    List<ForeignKeyTest1_Post> list1Post = iq1Blog.Posts.ToList();

                    Console.WriteLine($"Include 없는 기본 검색 : 부모({iq1Blog.idTest1Blog}, {iq1Blog.Name}), 자식({list1Post.Count})");
                    Console.WriteLine($"delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                Console.WriteLine("");

                using (ModelsDbContextTable db2 = new ModelsDbContextTable())
                {
                    ForeignKeyTest1_Post find1Post
                        = db2.ForeignKeyTest1_Post
                            .Where(w => w.idTest1Blog == 1)
                            .First();

                    //부모 1개 추출
                    ForeignKeyTest1_Blog iq1Blog = db2.ForeignKeyTest1_Blog.First();
                    //소속된 자식 추출
                    List<ForeignKeyTest1_Post> list1Post = iq1Blog.Posts.ToList();

                    Console.WriteLine($"자식이 먼저 조회된 경우 : 부모({iq1Blog.idTest1Blog}, {iq1Blog.Name}), 자식({list1Post.Count})");
                    Console.WriteLine($"delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                Console.WriteLine("");

                using (ModelsDbContextTable db3 = new ModelsDbContextTable())
                {

                    dtNow = DateTime.Now;
                    ForeignKeyTest1_Blog iq1Blog1 = db3.ForeignKeyTest1_Blog.Include(x => x.Posts).First();
                    List<ForeignKeyTest1_Post> list1Post1 = iq1Blog1.Posts.ToList();
                    Console.WriteLine($"Include 반복1 : delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    dtNow = DateTime.Now;
                    ForeignKeyTest1_Blog iq1Blog2 = db3.ForeignKeyTest1_Blog.Include(x => x.Posts).First();
                    List<ForeignKeyTest1_Post> list1Post2 = iq1Blog2.Posts.ToList();
                    Console.WriteLine($"Include 반복2 : delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    dtNow = DateTime.Now;
                    ForeignKeyTest1_Blog iq1Blog3 = db3.ForeignKeyTest1_Blog.Include(x => x.Posts).First();
                    List<ForeignKeyTest1_Post> list1Post3 = iq1Blog3.Posts.ToList();
                    Console.WriteLine($"Include 반복3 : delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                Console.WriteLine("");
                return true;
            }
        });
        #endregion


        #region 메뉴 - FK에 연결된 검색 테스트
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}. FK에 연결된 검색 테스트",
            Action = (MenuModel menuThis) =>
            {
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    ForeignKeyTest1_Blog iqTO = db1.ForeignKeyTest1_Blog.Include(x => x.Posts).First();

                    List<ForeignKeyTest1_Post> listTO = new List<ForeignKeyTest1_Post>();

                    ForeignKeyTest1_Post t1pTemp = db1.ForeignKeyTest1_Post.First();
                    ForeignKeyTest1_Blog? t1bTemp = t1pTemp.Blog;

                    Console.WriteLine($"iqTO : {iqTO.Name}, listTO count : {listTO.Count}");
                    if (null == t1bTemp)
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

        #region 메뉴 - elect List Speed Test(리스트 검색 속도 테스트)
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}. Select List Speed Test(리스트 검색 속도 테스트)",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine("");

                Console.WriteLine("****** select list ******");
                Console.WriteLine(" start select fk list --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<ForeignKeyTest1_Blog> iqTO = db1.ForeignKeyTest1_Blog;
                    List<ForeignKeyTest1_Blog> listTO = iqTO.ToList();

                    Console.WriteLine($"count : {listTO.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                Console.WriteLine(" start select non fk list --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<ForeignKeyTest2_Blog> iqTO = db1.ForeignKeyTest2_Blog;

                    List<ForeignKeyTest2_Blog> listTO = iqTO.ToList();

                    Console.WriteLine($"count : {listTO.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }


                Console.WriteLine(" ");
                Console.WriteLine("****** select take(non Include) child ******");
                Console.WriteLine(" start select fk list --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    List<ForeignKeyTest1_Select> listTo
                        = (from t1b in db1.ForeignKeyTest1_Blog.Take(1)
                           select new ForeignKeyTest1_Select()
                           {
                               idTest1Blog = t1b.idTest1Blog,
                               Name = t1b.Name,
                               Posts = t1b.Posts.ToList(),
                           })
                           .ToList();

                    Console.WriteLine($"count : {listTo.Count}, post:{listTo[0].Posts!.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                Console.WriteLine(" start select non fk list --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    List<ForeignKeyTest2_Select> listTo
                        = (from t2b in db1.ForeignKeyTest2_Blog.Take(1)
                           select new ForeignKeyTest2_Select()
                           {
                               idTest2Blog = t2b.idTest2Blog,
                               Name = t2b.Name,
                               Posts = db1.ForeignKeyTest2_Post.Where(w => w.idTest2Blog == t2b.idTest2Blog).ToList(),
                           })
                           .ToList();

                    Console.WriteLine($"count : {listTo.Count}, post:{listTo[0].Posts!.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                Console.WriteLine("");
                return true;
            }
        });
        #endregion

        #region 메뉴 - select take child Test(1개 추출 검색 속도 테스트)
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}. select take child Test(1개 추출 검색 속도 테스트)",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine("****** select take child ******");
                Console.WriteLine(" start select fk list --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<ForeignKeyTest1_Select> list
                        = (from t1b in db1.ForeignKeyTest1_Blog.Take(1).Include(i => i.Posts)
                           select new ForeignKeyTest1_Select()
                           {
                               idTest1Blog = t1b.idTest1Blog,
                               Name = t1b.Name,
                               Posts = t1b.Posts.ToList(),
                           });

                    List<ForeignKeyTest1_Select> listTo = list.ToList();

                    Console.WriteLine($"count : {listTo.Count}, post:{listTo[0].Posts!.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    //Console.WriteLine("query : ");
                    //Console.WriteLine(list.ToQueryString());
                }

                Console.WriteLine(" start select non fk list --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<ForeignKeyTest2_Select> list
                        = (from t2b in db1.ForeignKeyTest2_Blog.Take(1)
                           select new ForeignKeyTest2_Select()
                           {
                               idTest2Blog = t2b.idTest2Blog,
                               Name = t2b.Name,
                               Posts = db1.ForeignKeyTest2_Post.Where(w => w.idTest2Blog == t2b.idTest2Blog).ToList(),
                           });

                    List<ForeignKeyTest2_Select> listTo = list.ToList();
                    Console.WriteLine($"count : {listTo.Count}, post:{listTo[0].Posts!.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    //Console.WriteLine("query : ");
                    //Console.WriteLine(list.ToQueryString());
                }

                return true;
            }
        });
        #endregion

        #region 메뉴 - select where child(조건 검색 속도 테스트)
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}. select where child(조건 검색 속도 테스트)",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine("****** select where child ******");
                Console.WriteLine(" start select fk list --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<ForeignKeyTest1_Select> list
                        = (from t1b in db1.ForeignKeyTest1_Blog.Where(w => w.idTest1Blog == 1)
                           select new ForeignKeyTest1_Select()
                           {
                               idTest1Blog = t1b.idTest1Blog,
                               Name = t1b.Name,
                               Posts = t1b.Posts.ToList(),
                           });

                    List<ForeignKeyTest1_Select> listTo = list.ToList();

                    Console.WriteLine($"count : {listTo.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    //Console.WriteLine("query : ");
                    //Console.WriteLine(list.ToQueryString());
                }

                Console.WriteLine(" start select non fk list --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<ForeignKeyTest2_Select> list
                        = (from t2b in db1.ForeignKeyTest2_Blog.Where(w => w.idTest2Blog == 1)
                           select new ForeignKeyTest2_Select()
                           {
                               idTest2Blog = t2b.idTest2Blog,
                               Name = t2b.Name,
                               Posts = db1.ForeignKeyTest2_Post.Where(w => w.idTest2Blog == t2b.idTest2Blog).ToList(),
                           });

                    List<ForeignKeyTest2_Select> listTo = list.ToList();
                    Console.WriteLine($"count : {listTo.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    //Console.WriteLine("query : ");
                    //Console.WriteLine(list.ToQueryString());
                }

                return true;
            }
        });
        #endregion

        #region 메뉴 - select where child 30(조건 검색 30개 속도 테스트)
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}. select where child 30(조건 검색 30개 속도 테스트)",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine("****** select where child 30 ******");
                Console.WriteLine(" start select fk list --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<ForeignKeyTest1_Select> list
                        = (from t1b in db1.ForeignKeyTest1_Blog.Where(w => 1 <= w.idTest1Blog && w.idTest1Blog <= 30)
                           select new ForeignKeyTest1_Select()
                           {
                               idTest1Blog = t1b.idTest1Blog,
                               Name = t1b.Name,
                               Posts = t1b.Posts.ToList(),
                           });

                    List<ForeignKeyTest1_Select> listTo = list.ToList();

                    Console.WriteLine($"count : {listTo.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    //Console.WriteLine("query : ");
                    //Console.WriteLine(list.ToQueryString());
                }

                Console.WriteLine(" start select non fk list --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    IQueryable<ForeignKeyTest2_Select> list
                        = (from t2b in db1.ForeignKeyTest2_Blog.Where(w => 1 <= w.idTest2Blog && w.idTest2Blog <= 30)
                           select new ForeignKeyTest2_Select()
                           {
                               idTest2Blog = t2b.idTest2Blog,
                               Name = t2b.Name,
                               Posts = db1.ForeignKeyTest2_Post.Where(w => w.idTest2Blog == t2b.idTest2Blog).ToList(),
                           });

                    List<ForeignKeyTest2_Select> listTo = list.ToList();
                    Console.WriteLine($"count : {listTo.Count}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    //Console.WriteLine("query : ");
                    //Console.WriteLine(list.ToQueryString());
                }

                return true;
            }
        });
        #endregion

        #region 메뉴 - select child list(검색 후 자식 리스트 속도 테스트)
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}. select child list(검색 후 자식 리스트 속도 테스트)",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine("****** select child list ******");
                Console.WriteLine(" start select fk list --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    List<ForeignKeyTest1_Select> list
                        = (from t1b in db1.ForeignKeyTest1_Blog.Where(w => 1 <= w.idTest1Blog && w.idTest1Blog <= 10)
                           select new ForeignKeyTest1_Select()
                           {
                               idTest1Blog = t1b.idTest1Blog,
                               Name = t1b.Name,
                               Posts = t1b.Posts.ToList(),
                           })
                          .ToList();

                    int c = 0;
                    foreach (ForeignKeyTest1_Select t in list)
                    {
                        if (null != t.Posts)
                        {
                            c += t.Posts.Count;
                        }
                    }

                    Console.WriteLine($"count : {list.Count}, post:{c}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                Console.WriteLine(" start select non fk list --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    List<ForeignKeyTest2_Select> list
                        = (from t2b in db1.ForeignKeyTest2_Blog.Where(w => 1 <= w.idTest2Blog && w.idTest2Blog <= 10)
                           select new ForeignKeyTest2_Select()
                           {
                               idTest2Blog = t2b.idTest2Blog,
                               Name = t2b.Name,
                               Posts = db1.ForeignKeyTest2_Post.Where(w => w.idTest2Blog == t2b.idTest2Blog).ToList(),
                           })
                          .ToList();

                    int c = 0;
                    foreach (ForeignKeyTest2_Select t in list)
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

        #region 메뉴 - item to parent list(아이템의 부모 리스트 조회)
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}.  item to parent list(아이템의 부모 리스트 조회)",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine("****** item to parent list ******");
                Console.WriteLine(" start select fk list --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    ForeignKeyTest1_Post iqTO = db1.ForeignKeyTest1_Post.Include(i => i.Blog).First();
                    Console.WriteLine($"item select, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    ForeignKeyTest1_Blog? t1b = iqTO.Blog;
                    string sName = string.Empty;
                    if (null != t1b)
                    {
                        sName = t1b.Name;
                    }
                    Console.WriteLine($"blog : {sName}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                Console.WriteLine(" start select non fk list --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    ForeignKeyTest2_Post iqTO = db1.ForeignKeyTest2_Post.First();
                    Console.WriteLine($"item select, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");


                    ForeignKeyTest2_Blog t2b
                        = db1.ForeignKeyTest2_Blog
                            .Where(w => w.idTest2Blog == iqTO.idTest2Blog)
                            .First();
                    Console.WriteLine($"blog : {t2b.Name}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                return true;
            }
        });
        #endregion

        #region 메뉴 - item to parent list (non Include)(아이템의 부모 리스트 조회(인클루드 없이))
        newCA.MenuList.Add(new MenuModel()
        {
            Index = ++nMenuCount,
            TextFormat = "{0}.  item to parent list (non Include)(아이템의 부모 리스트 조회(인클루드 없이))",
            Action = (MenuModel menuThis) =>
            {
                Console.WriteLine("****** item to parent list ******");
                Console.WriteLine(" start select fk list --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    ForeignKeyTest1_Post iqTO = db1.ForeignKeyTest1_Post.Include(i => i.Blog).First();
                    Console.WriteLine($"item select, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");

                    ForeignKeyTest1_Blog? t1b = iqTO.Blog;
                    string sName = string.Empty;
                    if (null != t1b)
                    {
                        sName = t1b.Name;
                    }
                    Console.WriteLine($"blog : {sName}, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");
                }

                Console.WriteLine(" start select non fk list --------------");
                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {
                    dtNow = DateTime.Now;

                    //리스트를 받고
                    ForeignKeyTest2_Post iqTO = db1.ForeignKeyTest2_Post.First();
                    Console.WriteLine($"item select, delay : {(DateTime.Now.Ticks - dtNow.Ticks)}");


                    ForeignKeyTest2_Blog t2b
                        = db1.ForeignKeyTest2_Blog
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

                using (ModelsDbContextTable db1 = new ModelsDbContextTable())
                {

                    //블로그는 순차 생성
                    for (int i = 1; i < 100; ++i)
                    {
                        ForeignKeyTest1_Blog newT1B = new ForeignKeyTest1_Blog();
                        newT1B.Name = $"Test1Blog {i}";
                        db1.ForeignKeyTest1_Blog.Add(newT1B);

                        ForeignKeyTest2_Blog newT2B = new ForeignKeyTest2_Blog();
                        newT2B.Name = $"Test2Blog {i}";
                        db1.ForeignKeyTest2_Blog.Add(newT2B);
                    }

                    db1.SaveChanges();

                    Db_DataAdd_One(new Random(), db1);
                    db1.SaveChanges();

                    Console.WriteLine($"DB Data complete. Total Count: {db1.ForeignKeyTest1_Blog.Count()}(Test1Blog), {db1.ForeignKeyTest2_Blog.Count()}(Test2Blog)");
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

        using (ModelsDbContextTable db1 = new ModelsDbContextTable())
        {
            Console.WriteLine("DB data add start1");

            //블로그는 순차 생성
            for (int i = 1; i < 10000; ++i)
            {
                ForeignKeyTest1_Blog newT1B = new ForeignKeyTest1_Blog();
                newT1B.Name = $"Test1Blog {i}";
                db1.ForeignKeyTest1_Blog.Add(newT1B);

                ForeignKeyTest2_Blog newT2B = new ForeignKeyTest2_Blog();
                newT2B.Name = $"Test2Blog {i}";
                db1.ForeignKeyTest2_Blog.Add(newT2B);
            }

            db1.SaveChanges();
        }

        using (ModelsDbContextTable db2 = new ModelsDbContextTable())
        {
            Console.WriteLine("DB data add start1-1 : FK child");
            Db_DataAdd_FK1_10(rand);

            Console.WriteLine("DB data add start2");
            for (int i = 1; i <= 1; ++i)
            {
                Db_DataAdd_100000(i, rand);
            }

            Console.WriteLine("DB data add End");
        }

    }

    /// <summary>
    /// index1번에 연결된 자식 10개를 추가한다.
    /// </summary>
    static void Db_DataAdd_FK1_10(Random rand)
    {
        using (ModelsDbContextTable db1 = new ModelsDbContextTable())
        {
            for (int i = 0; i < 10; ++i)
            {
                int Int = rand.Next(0, 100000);
                string Str = Guid.NewGuid().ToString();
                DateTime Date = new DateTime(rand.Next(0, 1000000));

                long idFK = 1;

                ForeignKeyTest1_Post newT1P = new ForeignKeyTest1_Post();
                newT1P.Int = Int;
                newT1P.Str = Str;
                newT1P.Date = Date;
                //외래키 연결 랜덤하게 
                newT1P.idTest1Blog = idFK;
                db1.ForeignKeyTest1_Post.Add(newT1P);

                ForeignKeyTest2_Post newT2P = new ForeignKeyTest2_Post();
                newT2P.Int = Int;
                newT2P.Str = Str;
                newT2P.Date = Date;
                //외래키 연결 랜덤하게 
                newT2P.idTest2Blog = idFK;
                db1.ForeignKeyTest2_Post.Add(newT2P);
            }

            db1.SaveChanges();
        }
    }

    /// <summary>
    /// 10만번씩 끊어서 실행
    /// </summary>
    /// <param name="nCount"></param>
    /// <param name="rand"></param>
    static void Db_DataAdd_100000(
        int nCount
        , Random rand)
    {
        using (ModelsDbContextTable db1 = new ModelsDbContextTable())
        {
            Console.WriteLine("DB data add start2-" + nCount);
            for (int i = 1; i < 100000; ++i)
            {
                Db_DataAdd_One(rand, db1);
            }

            db1.SaveChanges();
        }
    }

    /// <summary>
    /// 1개를 넣는다.
    /// </summary>
    /// <param name="rand"></param>
    /// <param name="db1"></param>
    static void Db_DataAdd_One(
        Random rand
        , ModelsDbContextTable db1)
    {
        int Int = rand.Next(0, 100000);
        string Str = Guid.NewGuid().ToString();
        DateTime Date = new DateTime(rand.Next(0, 1000000));
        long idFK = rand.Next(1, 10000);
        //long idFK = rand.Next(0, 100);

        ForeignKeyTest1_Post newT1P = new ForeignKeyTest1_Post();
        newT1P.Int = Int;
        newT1P.Str = Str;
        newT1P.Date = Date;
        //외래키 연결 랜덤하게 
        newT1P.idTest1Blog = idFK;
        db1.ForeignKeyTest1_Post.Add(newT1P);


        ForeignKeyTest2_Post newT2P = new ForeignKeyTest2_Post();
        newT2P.Int = Int;
        newT2P.Str = Str;
        newT2P.Date = Date;
        //외래키 연결 랜덤하게 
        newT2P.idTest2Blog = idFK;
        db1.ForeignKeyTest2_Post.Add(newT2P);
    }

}
