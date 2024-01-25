using Microsoft.EntityFrameworkCore;

using Utility.AsontuDynamicOrderBy;

using Global.DB;
using ModelsDB;

namespace DynamicOrderBy;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Entity Framework Dynamic OrderBy!");
        
        //DB에 데이터 추가할지 여부
        bool bDataAdd = false;

        #region 전달된 옵션 확인
        for (int i = 0; i < args.Length; ++i)
        {
            string sCmd = args[i].ToLower();
            if ("-dataadd" == sCmd)
            {//여러개 실행 허용
                bDataAdd = true;
            }
        }
        #endregion

        Console.WriteLine("DB Setting....");
        GlobalDb.DBType = UseDbType.Sqlite;
        GlobalDb.DBString = "Data Source=Test.db";

        //db 마이그레이션 적용
        switch (GlobalDb.DBType)
        {
            case UseDbType.Sqlite:
                using (ModelsDbContext_Sqlite db1 = new ModelsDbContext_Sqlite())
                {
                    //db1.Database.EnsureCreated();
                    db1.Database.Migrate();
                }
                break;
            //case UseDbType.Mssql:
            //    using (ModelsDbContext_Mssql db1 = new ModelsDbContext_Mssql())
            //    {
            //        //db1.Database.EnsureCreated();
            //        db1.Database.Migrate();
            //    }
            //    break;

            default://기본
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    //db1.Database.EnsureCreated();
                    db1.Database.Migrate();
                }
                break;
        }


        if(true == bDataAdd)
        {
            //딱 한번만 호출해야 한다.
            Db_DataAdd();
        }
        

        DateTime dtNow = DateTime.Now;

        Console.WriteLine("------ start order EF --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            //리스트 초기화
            //리스트를 받고
            IQueryable<TestOrderBy> iqTO = db1.TestOrderBy;

            iqTO = iqTO.OrderBy(ob => ob.idTestOrderBy);
            List<TestOrderBy> listTO = iqTO.ToList();
        }
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<TestOrderBy> iqTO = db1.TestOrderBy;

            iqTO = iqTO.OrderByDescending(ob => ob.Int);
            List<TestOrderBy> listTO = iqTO.ToList();

            Console.WriteLine("Int : " + (DateTime.Now.Ticks - dtNow.Ticks));
        }
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<TestOrderBy> iqTO = db1.TestOrderBy;

            iqTO = iqTO.OrderBy(ob => ob.Str);
            List<TestOrderBy> listTO = iqTO.ToList();

            Console.WriteLine("Str : " + (DateTime.Now.Ticks - dtNow.Ticks));
        }
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<TestOrderBy> iqTO = db1.TestOrderBy;

            iqTO = iqTO.OrderByDescending(ob => ob.Date);
            List<TestOrderBy> listTO = iqTO.ToList();

            Console.WriteLine("Date : " + (DateTime.Now.Ticks - dtNow.Ticks));
        }


        Console.WriteLine(" ");
        //https://asontu.github.io/2020/04/02/a-better-way-to-do-dynamic-orderby-in-c-sharp.html
        Console.WriteLine("------ start order Asontu --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
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
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<TestOrderBy> iqTO = db1.TestOrderBy;

            iqTO = iqTO.OrderByDescending(OrderFunctions.OrderFunctionList["Int"]);
            List<TestOrderBy> listTO = iqTO.ToList();

            Console.WriteLine("Int : " + (DateTime.Now.Ticks - dtNow.Ticks));
        }
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<TestOrderBy> iqTO = db1.TestOrderBy;

            iqTO = iqTO.OrderBy(OrderFunctions.OrderFunctionList["Str"]);
            List<TestOrderBy> listTO = iqTO.ToList();

            Console.WriteLine("Str : " + (DateTime.Now.Ticks - dtNow.Ticks));
        }
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<TestOrderBy> iqTO = db1.TestOrderBy;

            iqTO = iqTO.OrderByDescending(OrderFunctions.OrderFunctionList["Date"]);
            List<TestOrderBy> listTO = iqTO.ToList();

            Console.WriteLine("Date : " + (DateTime.Now.Ticks - dtNow.Ticks));
        }



        Console.WriteLine(" ");

        Console.WriteLine("------ start order EF - Big --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            //리스트 초기화
            //리스트를 받고
            IQueryable<TestOrderBy_Big> iqTO = db1.TestOrderBy_Big;

            iqTO = iqTO.OrderBy(ob => ob.idTestOrderBy);
            List<TestOrderBy_Big> listTO = iqTO.ToList();
        }
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<TestOrderBy_Big> iqTO = db1.TestOrderBy_Big;

            iqTO = iqTO.OrderByDescending(ob => ob.Int);
            List<TestOrderBy_Big> listTO = iqTO.ToList();

            Console.WriteLine("Int : " + (DateTime.Now.Ticks - dtNow.Ticks));
        }
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<TestOrderBy_Big> iqTO = db1.TestOrderBy_Big;

            iqTO = iqTO.OrderBy(ob => ob.Str);
            List<TestOrderBy_Big> listTO = iqTO.ToList();

            Console.WriteLine("Str : " + (DateTime.Now.Ticks - dtNow.Ticks));
        }
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<TestOrderBy_Big> iqTO = db1.TestOrderBy_Big;

            iqTO = iqTO.OrderByDescending(ob => ob.Date);
            List<TestOrderBy_Big> listTO = iqTO.ToList();

            Console.WriteLine("Date : " + (DateTime.Now.Ticks - dtNow.Ticks));
        }


        Console.WriteLine(" ");

        Console.WriteLine("------ start order Asontu - Big --------------");
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            //리스트 초기화
            //리스트를 받고
            IQueryable<TestOrderBy_Big> iqTO = db1.TestOrderBy_Big;

            iqTO = iqTO.OrderBy(ob => ob.idTestOrderBy);
            List<TestOrderBy_Big> listTO = iqTO.ToList();
        }
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<TestOrderBy_Big> iqTO = db1.TestOrderBy_Big;

            iqTO = iqTO.OrderByDescending(OrderFunctions.OrderFunctionList_Big["Int"]);
            List<TestOrderBy_Big> listTO = iqTO.ToList();

            Console.WriteLine("Int : " + (DateTime.Now.Ticks - dtNow.Ticks));
        }
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<TestOrderBy_Big> iqTO = db1.TestOrderBy_Big;

            iqTO = iqTO.OrderBy(OrderFunctions.OrderFunctionList_Big["Str"]);
            List<TestOrderBy_Big> listTO = iqTO.ToList();

            Console.WriteLine("Str : " + (DateTime.Now.Ticks - dtNow.Ticks));
        }
        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            dtNow = DateTime.Now;

            //리스트를 받고
            IQueryable<TestOrderBy_Big> iqTO = db1.TestOrderBy_Big;

            iqTO = iqTO.OrderByDescending(OrderFunctions.OrderFunctionList_Big["Date"]);
            List<TestOrderBy_Big> listTO = iqTO.ToList();

            Console.WriteLine("Date : " + (DateTime.Now.Ticks - dtNow.Ticks));
        }



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

        using (ModelsDbContext db2 = new ModelsDbContext())
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