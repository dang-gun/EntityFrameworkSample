using Global.DB;
using Microsoft.AspNetCore.Mvc;
using ModelsDB;
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


        return resultInfoCode.ToResult();
    }
}
