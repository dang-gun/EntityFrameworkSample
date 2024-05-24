﻿using System.ComponentModel.DataAnnotations;


namespace TableModels;

/// <summary>
/// 테스트용 테이블2
/// </summary>
public class TestTable2
{
    /// <summary>
    /// 고유키
    /// </summary>
    [Key]
    public int idTestTable2 { get; set; }

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
