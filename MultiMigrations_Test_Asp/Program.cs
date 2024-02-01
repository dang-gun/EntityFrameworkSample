using Global.DB;

namespace MultiMigrations_Test_Asp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region DB 정보 불러오기
        GlobalDb.DBType = UseDbType.InMemory;
        GlobalDb.DBString
            = GlobalDb.DbStringLoad("SettingInfo_gitignore.json"
                                    , GlobalDb.DBType);


        //마이그레이션 적용
        GlobalStatic.DbSelectAndMigrate();
        #endregion


        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
