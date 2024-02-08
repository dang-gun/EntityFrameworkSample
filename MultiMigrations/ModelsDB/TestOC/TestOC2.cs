using System.ComponentModel.DataAnnotations;

namespace ModelsDB
{
    /// <summary>
    /// 테스트용 테이블 - SQL 서버 관리 토큰
    /// </summary>
    public class TestOC2
    {
        /// <summary>
        /// 고유키
        /// </summary>
        [Key]
        public int idTestOC2 { get; set; }

        /// <summary>
        /// 숫자형
        /// </summary>
        public int Int { get; set; }

        /// <summary>
        /// 문자형
        /// </summary>
        [MaxLength(32)]
        public string Str { get; set; } = string.Empty;


        /// <summary>
        /// SQL 서버 관리 토큰
        /// </summary>
        /// <remarks>
        /// 서버에서 관리하는 토큰은 SQL서버에 따라 지원하지 않는 경우가 있다.
        /// (SQLite는 지원하지 않음)
        /// </remarks>
        [Timestamp]
        public byte[]? Version { get; set; }

    }
}
