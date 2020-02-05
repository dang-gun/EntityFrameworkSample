using DBFirst.Global;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBFirst.ModelDB
{
    public partial class CcfTestContext : DbContext
    {
        /// <summary>
        /// DB 컨택스트 생성
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            switch (GlobalStatic.DBType)
            {
                case "sqlite":
                    options.UseSqlite(GlobalStatic.DBString);
                    break;
                case "mysql":
                    //options.UseSqlite(GlobalStatic.DBString);
                    break;

                case "mssql":
                default:
                    options.UseSqlServer(GlobalStatic.DBString);
                    break;
            }
        }
    }
}
