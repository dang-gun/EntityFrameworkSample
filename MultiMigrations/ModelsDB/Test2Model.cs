using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ModelsDB;

/// <summary>
/// 테스트용 모델
/// </summary>
public class Test2Model
{
    /// <summary>
    /// 고유키
    /// </summary>
    [Key]
    public long idTest2Model { get; set; }

    /// <summary>
    /// FK 부모
    /// </summary>
    [ForeignKey("idTest1Model")]
    public long idTest1Model { get; set; }

    /// <summary>
    /// 연결된 외래키
    /// </summary>
    /// <summary>
    /// 외래키에 연결된 대상
    /// </summary>
    public Test1Model? Test1Model { get; set; }
}
