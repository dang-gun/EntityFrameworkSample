namespace Utility.AsontuDynamicOrderBy;

/// <summary>
/// EF 정렬의 확장 오버로드
/// </summary>
public static class OrderByExtensions
{
    /// <summary>
    /// 오름차순 정렬(1 → 2 → 3 → 4)
    /// </summary>
    /// <remarks>
    /// https://asontu.github.io/2020/04/02/a-better-way-to-do-dynamic-orderby-in-c-sharp.html
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="orderBy">실행식 개체</param>
    /// <returns></returns>
    public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, IOrderBy orderBy)
    {
        return Queryable.OrderBy(source, orderBy.Expression);
    }

    /// <summary>
    /// 내림차순 정렬(4 → 3 → 2 → 1)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="orderBy">실행식 개체</param>
    /// <returns></returns>
    public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, IOrderBy orderBy)
    {
        return Queryable.OrderByDescending(source, orderBy.Expression);
    }

    /// <summary>
    /// 오름차순 정렬(1 → 2 → 3 → 4)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="orderBy">실행식 개체</param>
    /// <returns></returns>
    public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, IOrderBy orderBy)
    {
        return Queryable.ThenBy(source, orderBy.Expression);
    }

    /// <summary>
    /// 내림차순 정렬(4 → 3 → 2 → 1)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="orderBy">실행식 개체</param>
    /// <returns></returns>
    public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, IOrderBy orderBy)
    {
        return Queryable.ThenByDescending(source, orderBy.Expression);
    }
}
