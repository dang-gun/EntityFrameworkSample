using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDB;

/// <summary>
/// 테스트용 테이블
/// </summary>
public class Test2Select
{
    /// <summary>
    /// 고유키
    /// </summary>
    public long idTest2Blog { get; set; }

    /// <summary>
    /// 블로그 이름
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 외래키에 연결된 리스트
    /// </summary>
    public List<Test2Post>? Posts { get; set; }
}
