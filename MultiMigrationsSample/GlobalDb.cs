using MultiMigrationsSample.Models;


namespace MultiMigrationsSample;

/// <summary>
/// Static으로 선언된 적역 변수들
/// </summary>
public static class GlobalDb
{
    /// <summary>
    /// 대상 DB 타입
    /// </summary>
    public static TargetDbType DbType = TargetDbType.None;
    /// <summary>
    /// 사용할 커낵트 스트링
    /// </summary>
    public static string DbConnectString = string.Empty;

}
