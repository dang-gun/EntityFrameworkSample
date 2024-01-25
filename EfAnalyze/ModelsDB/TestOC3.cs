using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDB
{
    /// <summary>
    /// 테스트용 테이블 - 관리토큰 없음
    /// </summary>
    public class TestOC3
    {
        /// <summary>
        /// 고유키
        /// </summary>
        [Key]
        public int idTestOC3 { get; set; }

        /// <summary>
        /// 숫자형
        /// </summary>
        public int Int { get; set; }

        /// <summary>
        /// 문자형
        /// </summary>
        [MaxLength(32)]
        public string Str { get; set; } = string.Empty;


    }
}
