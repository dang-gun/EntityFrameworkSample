﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCodeFirst.Global;
using ModelDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CoreCodeFirst
{
    public class Startup
    {
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;

        //사용할 DB 정보
        string sConnectStringSelect = "CoreCodeFirst";
        GlobalStatic.DBType = Configuration[sConnectStringSelect + ":DBType"];
        GlobalStatic.DBString = Configuration[sConnectStringSelect + ":ConnectionString"];
    }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //db 컨택스트 연결
            services.AddDbContext<CoreCodeFirstContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //웹사이트 기본파일 읽기 설정
            app.UseDefaultFiles();
            //wwwroot 파일읽기
            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
