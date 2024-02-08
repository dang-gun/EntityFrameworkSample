
using System.Text.Json;
using System.Text.RegularExpressions;
using EfTestModel;
using EntityFrameworkSample.DB;
using EntityFrameworkSample.DB.MultiMigrations;


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
}
