using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.AsontuDynamicOrderBy;

/// <summary>
/// EF의 동적 정렬을 위한 실행 식 인터페이스
/// </summary>
/// <remarks>
/// https://asontu.github.io/2020/04/02/a-better-way-to-do-dynamic-orderby-in-c-sharp.html
/// </remarks>
public interface IOrderBy
{
    /// <summary>
    /// 사용할 실행식
    /// </summary>
    dynamic Expression { get; }
}
