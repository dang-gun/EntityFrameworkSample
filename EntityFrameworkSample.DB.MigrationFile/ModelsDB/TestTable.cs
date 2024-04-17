using System.ComponentModel.DataAnnotations;


namespace ModelsDB.TableModels;

/// <summary>
/// MigrationFile 테스트 전용
/// </summary>
public class TestTable
{
    /// <summary>
    /// 고유키
    /// </summary>
    [Key]
    public int idTestTable { get; set; }

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
