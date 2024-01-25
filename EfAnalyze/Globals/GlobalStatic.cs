
using EfAnalyze.Forms;
using System.Diagnostics;

namespace EfAnalyze.Global;

/// <summary>
/// 
/// </summary>
public static class GlobalStatic
{
    /// <summary>
    /// 최상위 부모 폼
    /// </summary>
    public static ParentForm? frmParent;

    /// <summary>
    /// db 정보 처리 폼
    /// </summary>
    public static DbInfoForm frmDbInfo = new DbInfoForm();

    /// <summary>
    /// DB 저장시 업데이트 순서가 어떻게 되는지 확인하는 폼
    /// </summary>
    public static SaveChangesUpdateOrderForm frmSaveChangesUpdateOrder = new SaveChangesUpdateOrderForm();

    /// <summary>
    /// 낙관적 동시성 테스트 폼
    /// </summary>
    public static OptimisticConcurrencyForm frmOptimisticConcurrency = new OptimisticConcurrencyForm();


    /// <summary>
    /// fromDbInfo에 아이템을 다시 로드하여 보여준다.
    /// </summary>
    public static void DbItemInfoReload()
    {
        if(true == frmParent!.tsmiDbItemInfoReload.Checked)
        {
            frmDbInfo.ReloadDB();
        }
    }

    /// <summary>
    /// 로그 표시
    /// </summary>
    /// <param name="sMsg"></param>
    public static void Log(string sMsg)
    {
        if (true == frmParent!.tsmiLogShow.Checked)
        {
            Debug.WriteLine(
                string.Format("[{0}] {1}"
                    , DateTime.Now.ToString("HH:mm:ss")
                    , sMsg));
        }
            
    }
}
