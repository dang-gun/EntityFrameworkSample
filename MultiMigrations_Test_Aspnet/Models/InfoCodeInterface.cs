namespace MultiMigrations_Test_Aspnet.Models;

/// <summary>
/// 정보 코드 인터페이스
/// </summary>
public interface InfoCodeInterface
{
    /// <summary>
    /// 실패시 전달한 코드
    /// <para>0 : 성공.</para>
    /// <para>다른 값은 각 API별로 처리</para>
    /// </summary>
    public string InfoCode { get; set; }

    /// <summary>
    /// 전달할 메시지
    /// </summary>
    /// <remarks>
    /// 개발자를 위해 전달하는 메시지이다.
    /// <para>개발용으로만 사용되어야 한다.</para>
    /// </remarks>
    public string Message { get; set; }
}
