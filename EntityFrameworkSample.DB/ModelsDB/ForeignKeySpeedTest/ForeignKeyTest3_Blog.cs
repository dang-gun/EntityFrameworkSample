using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSample.DB.Models.ForeignKeySpeedTest;

/// <summary>
/// 테스트용 테이블
/// </summary>
public class ForeignKeyTest3_Blog
{
    /// <summary>
    /// 고유키
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long idTest3Blog { get; set; }

    /// <summary>
    /// 블로그 이름
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 매장의 자주쓰는 정보
    /// </summary>
    public ICollection<ForeignKeyTest3_Post> Test3Post { get; set; } = new List<ForeignKeyTest3_Post>();
}
