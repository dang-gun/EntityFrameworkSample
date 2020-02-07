using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ModelDB
{
    /// <summary>
    /// 유저 가입 타입
    /// </summary>
    public enum UserJoinType
    {
        None = 0,

        Normal,
        VIP,
        VVIP,
    }

    /// <summary>
    /// 테스트용 유저 정보 모델
    /// </summary>
    public class TestUser
    {
        /// <summary>
        /// 고유키
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idTestUser { get; set; }

        /// <summary>
        /// 사인인에 사용하는 이메일
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 비밀번호
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 가입 날짜
        /// </summary>
        public DateTime JoinDate { get; set; }
        /// <summary>
        /// 가입 형태
        /// </summary>
        public UserJoinType JoinType { get; set; }

        /// <summary>
        /// 보유 금액
        /// </summary>
        public double Money { get; set; }

    }
}
