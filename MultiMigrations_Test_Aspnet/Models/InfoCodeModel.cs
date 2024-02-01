using Microsoft.AspNetCore.Mvc;


namespace MultiMigrations_Test_Aspnet.Models;

/// <summary>
/// 정보 코드 모델
/// </summary>
public class InfoCodeModel: InfoCodeInterface
{
    /// <inheritdoc/>
    public string InfoCode { get; set; } = string.Empty;

    /// <inheritdoc/>
    public string Message { get; set; } = string.Empty;


    /// <summary>
    /// 컨트롤러베이스의 기능을 쓰기위한 개체
    /// </summary>
    private ControllerBase ThisCB { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cbThis">컨트롤러 기능을 사용하기위한 인스턴스</param>
    public InfoCodeModel(ControllerBase cbThis)
    {
        this.ThisCB = cbThis;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ObjectResult ToResult()
    {
        return this.ThisCB.StatusCode(
                    StatusCodes.Status200OK
                    , (InfoCodeInterface)this);
    }
}