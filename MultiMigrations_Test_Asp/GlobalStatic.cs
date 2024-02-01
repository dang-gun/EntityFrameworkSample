using Microsoft.EntityFrameworkCore;

using Global.DB;
using ModelsDB;

namespace MultiMigrations_Test_Asp;

public class GlobalStatic
{
    /// <summary>
    /// DB를 선택하고 마이그레이션을 시도한다.
    /// </summary>
    public static void DbSelectAndMigrate()
    {
        Console.WriteLine($"DbSelectAndMigrate : {GlobalDb.DBType}");

        switch (GlobalDb.DBType)
        {
            case UseDbType.InMemory:
                {
                    GlobalDb.DBType = UseDbType.InMemory;

                    GlobalDb.DBString = "TestDb";

                    //인메모리는 마이그레이션 개념이 없다.
                    //그러니 ModelsDbContext.OnConfiguring가 호출되지 않아 기본 데이터를 넣을 수 없다.
                    //수동으로 넣어준다.
                    using (ModelsDbContext db1 = new ModelsDbContext())
                    {
                        try
                        {
                            db1.Test1Model.Add(
                            new Test1Model()
                            {
                                idTest1Model = 1,
                                Int = 1,
                                Str = "Test",
                                Date = DateTime.Now,
                            });
                            db1.SaveChanges();

                            db1.Test2Model.Add(
                                new Test2Model()
                                {
                                    idTest2Model = 1,
                                    idTest1Model = 1,
                                });
                            db1.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            //인메모리가 살아있는지 아닌지 확인이 안되서 이렇게 처리한다.
                            Console.WriteLine(ex.ToString());
                        }
                    }//end using db1
                }
                break;

            case UseDbType.SQLite:
                {
                    GlobalDb.DBType = UseDbType.SQLite;

                    GlobalDb.DBString = "Data Source=Test.db";

                    using (ModelsDbContext_Sqlite db1 = new ModelsDbContext_Sqlite())
                    {
                        db1.Database.Migrate();
                    }
                }
                break;

            case UseDbType.MSSQL:
                {
                    GlobalDb.DBType = UseDbType.MSSQL;

                    GlobalDb.DBString
                        = GlobalDb.DbStringLoad(
                            "SettingInfo_gitignore.json"
                            , GlobalDb.DBType);

                    using (ModelsDbContext_Mssql db1 = new ModelsDbContext_Mssql())
                    {
                        db1.Database.Migrate();
                    }
                }
                break;

            case UseDbType.PostgreSQL:
                {
                    GlobalDb.DBType = UseDbType.PostgreSQL;

                    GlobalDb.DBString
                        = GlobalDb.DbStringLoad(
                            "SettingInfo_gitignore.json"
                            , GlobalDb.DBType);

                    using (ModelsDbContext_Postgresql db1 = new ModelsDbContext_Postgresql())
                    {
                        db1.Database.Migrate();
                    }
                }
                break;

            case UseDbType.MariaDB:
                {
                    GlobalDb.DBType = UseDbType.MariaDB;

                    GlobalDb.DBString
                        = GlobalDb.DbStringLoad(
                            "SettingInfo_gitignore.json"
                            , GlobalDb.DBType);

                    using (ModelsDbContext_Mariadb db1 = new ModelsDbContext_Mariadb())
                    {
                        db1.Database.Migrate();
                    }
                }
                break;

            case UseDbType.None:
            default:
                break;

        }
    }
}
