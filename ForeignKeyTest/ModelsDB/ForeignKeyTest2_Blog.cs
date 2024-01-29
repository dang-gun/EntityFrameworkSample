using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDB;

/// <summary>
/// 블로그에는 외래키 리스트 연결안함
/// </summary>
public class ForeignKeyTest2_Blog
{
    /// <summary>
    /// 고유키
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long idTest2Blog { get; set; }

    /// <summary>
    /// 블로그 이름
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 외래키에 연결된 리스트
    /// </summary>
    public ICollection<ForeignKeyTest2_Post> Posts { get; } = new List<ForeignKeyTest2_Post>();
}
