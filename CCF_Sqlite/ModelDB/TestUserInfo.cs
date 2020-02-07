using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ModelDB
{
    /// <summary>
    /// 유저 상세 정보
    /// </summary>
    public class TestUserInfo
    {
        /// <summary>
        /// 고유키
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idTestUserInfo { get; set; }

        /// <summary>
        /// TestUser FK
        /// </summary>
        [ForeignKey("idTestUserForeignKey")]
        public TestUser idTestUser { get; set; }

        /// <summary>
        /// 래벨.
        /// 필수값
        /// </summary>
        [Required]
        public int Lv { get; set; }

        /// <summary>
        /// 닉네임
        /// 10자리
        /// </summary>
        [MaxLength(10)]
        public string NickName { get; set; }

        /// <summary>
        /// 보유금
        /// </summary>
        public double Money { get; set; }
    }
}
