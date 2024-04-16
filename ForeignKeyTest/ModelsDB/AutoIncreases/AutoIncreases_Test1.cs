using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ForeignKeyTest.TableModels;

/// <summary>
/// FK키가 자동으로 증가되는 오류 재연용1
/// </summary>
public class AutoIncreases_Test1
{
    /// <summary>
    /// 고유키
    /// </summary>
    [Key]
    public long idAutoIncreases_Test1 { get; set; }

    /// <summary>
    /// 표시 데이터
    /// </summary>
    public string Name { get; set; } = string.Empty;


    /// <summary>
    /// 외래키에 연결된 리스트
    /// </summary>
    [ForeignKey("idAutoIncreases_Test1")]
    public ICollection<AutoIncreases_Test2> Test2 { get; set; } = new List<AutoIncreases_Test2>();

    /// <summary>
    /// 외래키에 연결된 리스트
    /// </summary>
    [ForeignKey("idAutoIncreases_Test1")]
    public ICollection<AutoIncreases_Test3> Test3 { get; set; } = new List<AutoIncreases_Test3>();
}
