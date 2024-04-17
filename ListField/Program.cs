using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using EfTest.Models;
using ListField.Global;
using ModelsDB;
using EntityFrameworkSample.Console;
using EntityFrameworkSample.DB;
using ListField.TableModels;
using System.Text;

namespace ListField;

internal class Program
{
	/// <summary>
	///  The main entry point for the application.
	/// </summary>
	static void Main(string[] args)
	{
        Console.WriteLine("Hello, Entity Framework List Field!");
        Console.WriteLine("DB������ ���� ������ �ȵǰų� �̻��ϰ� �� �� �ֽ��ϴ�.");

        //db ���� �ޱ�
        DbConsole consoleMenuDb = new DbConsole();
        consoleMenuDb.DbSelectConsole(UseDbType.All);

        #region ���̱׷��̼�
        //���̱׷��̼�
        //���̱׷��̼��� ���̱׷��̼��� �����Ҷ� ����� DbContext�� ����ؾ� ���� �����ϹǷ�
        //���̺귯��ȭ�� �� �� ����.
        System.Console.WriteLine("DB Setting....");

        //DB ������ ������ �⺻ ���� �ҷ�����
        GlobalDb.DbStringReload(true);


        //db ���̱׷��̼� ����
        //DB���� ���ڿ��� ������ �⺻���� ���
        switch (GlobalDb.DBType)
        {
            case UseDbType.SQLite:
                using (ModelsDbContext_Sqlite db1 = new ModelsDbContext_Sqlite())
                {
                    //���̱׷��̼�
                    db1.Database.Migrate();
                }
                break;

            case UseDbType.MSSQL:
                using (ModelsDbContext_Mssql db1 = new ModelsDbContext_Mssql())
                {
                    //���̱׷��̼�
                    db1.Database.Migrate();
                }
                break;

            case UseDbType.PostgreSQL:
                using (ModelsDbContext_Postgresql db1 = new ModelsDbContext_Postgresql())
                {
                    //���̱׷��̼�
                    db1.Database.Migrate();
                }
                break;

            case UseDbType.MariaDB:
                using (ModelsDbContext_Mariadb db1 = new ModelsDbContext_Mariadb())
                {
                    //���̱׷��̼�
                    db1.Database.Migrate();
                }
                break;

            case UseDbType.InMemory://InMomey�� ���̱׷��̼� ������ ����.
            default:
                //���� ����
                break;
        }
        #endregion

        System.Console.WriteLine("DB Setting complete");
        System.Console.WriteLine("");





        //����Ʈ�� �����ϱ�
        Console.WriteLine("List Info : ");
        List<EfList_Test2> efList_Test2s = new List<EfList_Test2>();

        using (ModelsDbContextTable db3 = new ModelsDbContextTable())
        {
            efList_Test2s = db3.EfList_Test2.ToList();
        }

        Console.WriteLine("List count : " + efList_Test2s.Count);
        Console.WriteLine("-----------------------------");

        StringBuilder sbTemp;
        foreach (EfList_Test2 item in efList_Test2s)
        {
            Console.WriteLine(" ");
            Console.WriteLine($"������ item : {item.idEfList_Test2} ������");

            sbTemp = new StringBuilder();
            foreach (string itemListString1 in item.ListString1)
            {
                sbTemp.Append(itemListString1 + ",");
            }
            Console.WriteLine($"ListString1 => {sbTemp.ToString()}");

            sbTemp = new StringBuilder();
            foreach (string itemListString2 in item.ListString2)
            {
                sbTemp.Append(itemListString2 + ",");
            }
            Console.WriteLine($"ListString2 => {sbTemp.ToString()}");

            sbTemp = new StringBuilder();
            foreach (JsonTestModel itemListJson1 in item.ListJson1)
            {
                sbTemp.Append($"{itemListJson1.id}(id):{itemListJson1.Name}(Name):{itemListJson1.Age}(Age) ,");
            }
            Console.WriteLine($"ListJson1 => {sbTemp.ToString()}");
        }
    }
}