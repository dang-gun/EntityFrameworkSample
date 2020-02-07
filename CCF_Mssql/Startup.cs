using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCF_Mssql.Global;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ModelDB;

namespace CCF_Mssql
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

            app.UseMvc();
        }
    }
}
