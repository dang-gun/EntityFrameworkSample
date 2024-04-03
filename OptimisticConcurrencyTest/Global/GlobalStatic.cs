using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using EfTestModel;
using EntityFrameworkSample.DB.Models;
using System.Diagnostics;



namespace OptimisticConcurrency.Global;

/// <summary>
/// Static으로 선언된 적역 변수들
/// </summary>
public static class GlobalStatic
{
    /// <summary>
    /// 낙관적 동시성 공통화를 위한 개체
    /// </summary>
    public static OptimisticConcurrencyUtil OC_Util
        = new OptimisticConcurrencyUtil();

    /// <summary>
    /// 동시성 에러가 났을때 표시할 로그
    /// </summary>
    /// <param name="ex"></param>
    public static void Log(DbUpdateConcurrencyException ex)
    {
        //수정하려다 실패한 개체
        //DbUpdateConcurrencyException는 실패한 첫 개체를 준다.
        EntityEntry dataFail = ex.Entries.Single();

        //에러난 개체를 찾는다.(로그용)
        StringBuilder sb = new StringBuilder();
        sb.Append($"SaveChanges_UpdateConcurrencyCheck Exception : \n");
        if(true == dataFail.Entity is TestOC2)
        {
            TestOC2? tempItem = dataFail.Entity as TestOC2;
            if (null != tempItem)
            {
                sb.Append($"    {tempItem.idTestOC2}: {tempItem.Int}, {tempItem.Str}\n");
            }
        }
        else
        {

        }
        
        Debug.WriteLine(sb.ToString());
    }
}
