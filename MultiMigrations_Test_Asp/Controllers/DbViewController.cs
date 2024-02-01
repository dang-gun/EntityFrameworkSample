using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ModelsDB;
using MultiMigrations_Test_Aspnet.Models;


namespace MultiMigrations_Test_Aspnet.Controllers;

/// <summary>
/// DB 보기용 컨트롤러
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public class DbViewController : Controller
{
    /// <summary>
    /// 전체 리스트
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<InfoCodeInterface> SelectAll()
    {
        InfoCodeModel resultInfoCode = new InfoCodeModel(this);

        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            List<Test1Model> findDbData1ModelList
                = db1.Test1Model
                    .Include(inc => inc.Test2ModelList)
                    .ToList();

            StringBuilder sbTemp = new StringBuilder();
            foreach (Test1Model item in findDbData1ModelList)
            {
                sbTemp.Append($"index = {item.idTest1Model}, Int = {item.Int},  Str = {item.Str},   Date = {item.Date} {Environment.NewLine}");

                sbTemp.Append($" [ {Environment.NewLine}");
                foreach (Test2Model itemChild in item.Test2ModelList)
                {
                    sbTemp.Append($"        {{index = {itemChild.idTest2Model}, Parent = {item.idTest1Model}}} {Environment.NewLine}");
                }
                sbTemp.Append($" ], {Environment.NewLine}");
            }
            
            resultInfoCode.Message = sbTemp.ToString();

        }

        return resultInfoCode.ToResult();
    }
}
