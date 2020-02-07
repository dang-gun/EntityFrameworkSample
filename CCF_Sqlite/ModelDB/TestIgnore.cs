using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDB
{
    /// <summary>
    /// 제외 테스트용 모델
    /// </summary>
    public class TestIgnore
    {
        /// <summary>
        /// 고유키
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long idTestIgnore { get; set; }

        
        [Required]
        public int Count { get; set; }
    }
}
