using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ModelsDB;

/// <summary>
/// 테스트용 모델
/// </summary>
public class Test1Model
{
    /// <summary>
    /// 고유키
    /// </summary>
    [Key]
    public long idTest1Model { get; set; }

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

    /// <summary>
    /// 외래키에 연결된 리스트
    /// </summary>
    [ForeignKey("idTest1Model")]
    public ICollection<Test2Model> Test2ModelList { get; set; }
        = new List<Test2Model>();
}
