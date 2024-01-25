using ModelsDB;
using System;
using System.Linq.Expressions;

namespace Utility.AsontuDynamicOrderBy;

/// <summary>
/// EF의 동적 정렬을 위한 실행식 개체
/// </summary>
/// <remarks>
/// https://asontu.github.io/2020/04/02/a-better-way-to-do-dynamic-orderby-in-c-sharp.html
/// </remarks>
/// <typeparam name="TToOrder">정렬에 사용할 테이블 형식</typeparam>
/// <typeparam name="TBy">정렬에 사용할 컬럼의 형식</typeparam>
public class OrderBy<TToOrder, TBy> : IOrderBy
{
    /// <summary>
    /// 실행시킬 실행식 개체
    /// </summary>
    private readonly Expression<Func<TToOrder, TBy>> expression;

    /// <summary>
    /// 실행식 실행
    /// </summary>
    public dynamic Expression => this.expression;

    /// <summary>
    /// 실행식을 전달받아 저장한다.
    /// </summary>
    /// <param name="expression">실행식</param>
    public OrderBy(Expression<Func<TToOrder, TBy>> expression)
    {
        this.expression = expression;
    }
}



