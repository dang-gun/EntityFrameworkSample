using CCF_Mssql.Global;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelDB
{
    public class CoreCodeFirstContext : DbContext
    {
        /// <summary>
        /// DB 컨택스트 생성
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //mssql
            options.UseSqlServer(GlobalStatic.DBString);
        }

        public DbSet<TestUser> TestUser { get; set; }
        public DbSet<TestUserInfo> TestUserInfo { get; set; }
        public DbSet<TestIgnore> TestIgnore { get; set; }

        /// <summary>
        /// 테이블이 생성될때 동작
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //제외
            modelBuilder.Ignore<TestIgnore>();


            //'TestUser'에 기본 정보 추가
            modelBuilder.Entity<TestUser>().HasData(new TestUser 
            { 
                idTestUser = 1
                , Email = "test01@test.com"
                , Password = "1111"
                , JoinType = UserJoinType.VVIP
                , JoinDate = new DateTime(2019, 10, 10)
                , Money = 10.1
            }
            , new TestUser 
            { 
                idTestUser = 2
                , Email = "test02@test.com"
                , Password = "1111"
                , JoinType = UserJoinType.Normal
                , JoinDate = new DateTime(2019, 12, 10)
                , Money = 1000.22
            });
        }
    }
}
