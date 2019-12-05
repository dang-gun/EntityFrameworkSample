using CoreCodeFirst.ModelDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeFirst.Global
{
    public class DB_CoreCodeFirst
    {
        private DbContextOptionsBuilder<CoreCodeFirstContext> OptionsBuilder_Last = null;

        private CoreCodeFirstContext Context_Last = null;

        /// <summary>
        /// 마지막으로 사용한 컨택스트옵션빌드를 다시 받아온다.
        /// 마지막으로 사용한 컨택스트옵션빌드가 없으면 
        /// GlobalStatic.DB_GameServe를 기준으로 다시 생성한다.
        /// </summary>
        /// <returns></returns>
        public DbContextOptionsBuilder<CoreCodeFirstContext> DbContext()
        {
            if (null == this.OptionsBuilder_Last)
            {//생성된게 없다.
                //새로 생성해서 준다,
                this.OptionsBuilder_Last = new DbContextOptionsBuilder<CoreCodeFirstContext>();
            }

            if (null == this.Context_Last)
            {//생성된게 없다.
                //새로 생성해서 준다.
                //MSSql
                this.OptionsBuilder_Last.UseSqlServer(GlobalStatic.DBString);
                //MySql
                //this.OptionsBuilder_Last.UseMySQL(GlobalStatic.DBString);
            }

            return this.OptionsBuilder_Last;
        }
    }
}
