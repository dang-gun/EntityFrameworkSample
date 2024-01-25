using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDB
{
    /// <summary>
    /// 테스트용 테이블 - 많은 데이터용
    /// </summary>
    public class TestOrderBy_Big
    {
        /// <summary>
        /// 고유키
        /// </summary>
        [Key]
        public int idTestOrderBy { get; set; }

        /// <summary>
        /// 숫자형
        /// </summary>
        public int Int { get; set; }
        
        /// <summary>
        /// 문자형
        /// </summary>
        public string Str { get; set; } = string.Empty;

        /// <summary>
        /// 날짜형
        /// </summary>
        public DateTime Date { get; set; }
    }
}
