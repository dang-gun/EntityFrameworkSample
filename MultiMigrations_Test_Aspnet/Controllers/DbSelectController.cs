using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using Global.DB;

using ModelsDB;
using MultiMigrations_Test_Aspnet;
using MultiMigrations_Test_Aspnet.Models;
using System.Diagnostics;

namespace MultiMigrations_Test_Aspnet.Controllers;

/// <summary>
/// 사용할 DB를 선택/변경 하는 컨트롤러
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public class DbSelectController : Controller
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPatch]
    public ActionResult<InfoCodeInterface> InMemory()
    {
        InfoCodeModel resultInfoCode = new InfoCodeModel(this);

        GlobalDb.DBType = UseDbType.InMemory;
        //마이그레이션 적용
        GlobalStatic.DbSelectAndMigrate();


        return resultInfoCode.ToResult();
    }

    /// <summary>
    /// SQLite 선택
    /// </summary>
    /// <returns></returns>
    [HttpPatch]
    public ActionResult<InfoCodeInterface> SQLite()
    {
        InfoCodeModel resultInfoCode = new InfoCodeModel(this);
        //마이그레이션 적용
        GlobalStatic.DbSelectAndMigrate();

        return resultInfoCode.ToResult();
    }

    /// <summary>
    /// MSSQL 선택
    /// </summary>
    /// <returns></returns>
    [HttpPatch]
    public ActionResult<InfoCodeInterface> MSSQL()
    {
        InfoCodeModel resultInfoCode = new InfoCodeModel(this);

        GlobalDb.DBType = UseDbType.MSSQL;
        //마이그레이션 적용
        GlobalStatic.DbSelectAndMigrate();

        return resultInfoCode.ToResult();
    }

    /// <summary>
    /// PostgreSQL 선택
    /// </summary>
    /// <returns></returns>
    [HttpPatch]
    public ActionResult<InfoCodeInterface> PostgreSQL()
    {
        InfoCodeModel resultInfoCode = new InfoCodeModel(this);

        GlobalDb.DBType = UseDbType.PostgreSQL;
        //마이그레이션 적용
        GlobalStatic.DbSelectAndMigrate();

        return resultInfoCode.ToResult();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPatch]
    public ActionResult<InfoCodeInterface> Mariadb()
    {
        InfoCodeModel resultInfoCode = new InfoCodeModel(this);

        return resultInfoCode.ToResult();
    }
}
