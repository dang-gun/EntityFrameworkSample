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

        resultInfoCode.Message = this.ShowData();

        return resultInfoCode.ToResult();
    }

    /// <summary>
    /// DbData1Model 추가
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<InfoCodeInterface> DbData1Model_Add()
    {
        InfoCodeModel resultInfoCode = new InfoCodeModel(this);

        Random rand = new Random();

        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            Test1Model newTest1 = new Test1Model();

            newTest1.Int = rand.Next(0, 100000);
            newTest1.Str = Guid.NewGuid().ToString(); ;
            newTest1.Date = new DateTime(rand.NextInt64(100000000, 10000000000000));

            db1.Test1Model.Add(newTest1);
            db1.SaveChanges();
        }

        resultInfoCode.Message = this.ShowData();

        return resultInfoCode.ToResult();
    }

    /// <summary>
    /// DbData1Model 추가
    /// </summary>
    /// <param name="nParentIndex">대상 부모 인덱스</param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<InfoCodeInterface> DbData2Model_Add([FromForm] int nParentIndex)
    {
        InfoCodeModel resultInfoCode = new InfoCodeModel(this);

        using (ModelsDbContext db1 = new ModelsDbContext())
        {
            Test2Model newTest2 = new Test2Model();

            newTest2.idTest1Model = nParentIndex;

            try
            {
                db1.Test2Model.Add(newTest2);
                db1.SaveChanges();

                resultInfoCode.Message = this.ShowData();
            }
            catch (Exception ex)
            {
                resultInfoCode.Message = ex.ToString();
            }
        }

        

        return resultInfoCode.ToResult();
    }

    /// <summary>
    /// 데이터 보기
    /// </summary>
    /// <returns></returns>
    private string ShowData()
    {
        string sReturn = string.Empty;

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

            sReturn = sbTemp.ToString();

        }//end using db1

        return sReturn;
    }
}
