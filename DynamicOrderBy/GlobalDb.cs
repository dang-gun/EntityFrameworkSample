using System.Security.Cryptography;
using System.Text;

namespace Global.DB;

    /// <summary>
    /// Static으로 선언된 적역 변수들
    /// </summary>
    public static class GlobalDb
    {
	/// <summary>
	/// DB 타입
	/// </summary>
	public static UseDbType DBType = UseDbType.Memory;
	/// <summary>
	/// DB 컨낵션 스트링 저장
	/// </summary>
	public static string DBString = "";

	/// <summary>
	/// 문자열로 저장된 배열(혹은 리스트)의 데이터를 구분할때 사용하는 구분자
	/// </summary>
	/// <remarks>
	/// 이 값을 중간에 바꾸면 기존의 데이터를 재대로 못읽을 수 있다.
	/// </remarks>
	public static char DbArrayDiv = '▒';

}
