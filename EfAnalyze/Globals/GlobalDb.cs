using Global.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ModelsDB;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;
using System.Text;


namespace EfAnalyze.Globals;


/// <summary>
/// Static으로 선언된 적역 변수들
/// </summary>
public static class GlobalDb
{

    //public static UseDbType DBType = UseDbType.Sqlite;
    //public static string DBString = "Data Source=Test.db";

    public static UseDbType DBType = UseDbType.Mssql;
    public static string DBString = "Server=192.168.0.222;DataBase=LocalTest;UId=LocalTest_Login;pwd=asdf1234@";


}
