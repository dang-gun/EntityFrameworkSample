using System.Diagnostics;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using EntityFrameworkSample.DB.Models;

using OptimisticConcurrency.Global;
using OptimisticConcurrencyTest.TableModels;

namespace EfTestModel;



public class OptimisticConcurrencyUtil
{
    /// <summary>
    /// 낙관적 동시성 - 여러줄 업데이트시 개체별 콜백함수
    /// </summary>
    /// <returns>false이면 낙관적 동시성 시도를 포기한다.</returns>
    public delegate bool MultiUpdateConcurrencyItemFuncDelegate<T>(T item);


    #region 낙관적 동시성 - 한 줄처리
    /// <summary>
    /// 낙관적 동시성 적용
    /// </summary>
    /// <remarks>
    /// <para>낙관적 동시성이 체크가 성공하면 저장한다.</para>
    /// <para>지정된 실행식을 지정된 횟수만큼 반복한다.</para>
    /// <para>추적중인 데이터가 모두 다시 로드 되므로 가급적 Context를 짧게 만들어야
    /// 부하도 적고 속도도 빨라진다.</para>
    /// </remarks>
    /// <param name="db1"></param>
    /// <param name="nMaxLoop">최대 반복수. 마이너스 값이면 무한반복한다.</param>
    /// <param name="callback">반복해서 동작시킬 실행식.</param>
    /// <returns>업데이트 성공 여부</returns>
    public bool SaveChanges_UpdateConcurrency(
        ModelsDbContext db1
        , int nMaxLoop
        , Func<bool> callback)
    {
        //반복수
        int nLoopCount = 0;

        //저장 성공 여부
        bool bSaveSuccess = false;
        while (false == bSaveSuccess)
        {//낙관적 동시성 처리

            ++nLoopCount;
            if (0 < nMaxLoop
                && nLoopCount > nMaxLoop)
            {//마이너스값이 아니고
                //지정한 횟수(nMaxLoop)를 넘어섰다.

                //낙관적 동시성 종료
                break;
            }

            //동작 재실행
            bool bCallReturn = callback();
            if (false == bCallReturn)
            {//결과가 거짓이다.

                //낙관적 동시성 종료
                break;
            }

            bSaveSuccess = SaveChanges_UpdateConcurrencyCheck_Reload(db1);
        }//end while (false == bSaveSuccess)


        return bSaveSuccess;
    }

    

    #endregion

    #region 낙관적 동시성 여러줄 처리 - 각자 컨택스트 생성하여 처리함(순차 처리 - 동기)

    /// <summary>
    /// 낙관적 동시성 여러줄 처리 - 각자 컨택스트 생성하여 처리함(순차 처리 동기)
    /// </summary>
    /// <remarks>
    /// 전달받은 리스트의 아이템마다 DbContext를 만들어 처리한다.
    /// <para>낙관적 동시성이 실패했을대 롤백 기준이 트랙잭션 기준이라 
    /// DbContext를 따로 만들지 않으면 기존 처리된 것까지 모두 초기화 되는 문제가 있다.</para>
    /// <para>그래서 아이템 별로 DbContext를 생성하여 처리한다.</para>
    /// <para>비동기로 처리해도 트랜젝션은 한개라 전체가 롤백된다.<br />
    /// 동기로 처리하면 각 컨택스트가 별도의 트랙젝션 처리가 되어 하나씩 처리된다.<br />
    /// </para>
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// <param name="nMaxLoop"></param>
    /// <param name="listLeft"></param>
    /// <param name="callbackItem"></param>
    /// <param name="nDelay"></param>
    public void SaveChanges_Update_MultiDbContext<T>(
        int nMaxLoop
        , ref List<T> listLeft
        , MultiUpdateConcurrencyItemFuncDelegate<T> callbackItem
        , int nDelay)
    {

        for (int i = 0; i < listLeft.Count; ++i)
        {
            T item = listLeft[i];

            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                db1.Update(item!);

                bool bSaveSTemp
                    = SaveChanges_UpdateConcurrency(
                        db1
                        , nMaxLoop
                        , callbackItem
                        , item
                        , nDelay);
            }//end using db1

        }//end for i

    }

    /// <summary>
    /// 낙관적 동시성 저장 시도 - 제네릭 방식
    /// </summary>
    /// <typeparam name="T">낙관적 동시성 저장을 시도할 개체 모델</typeparam>
    /// <param name="db1">추적중인 컨택스트</param>
    /// <param name="nMaxLoop">최대 반복수. 마이너스 값이면 무한반복한다.</param>
    /// <param name="callbackItem">저장이 실패한 아이템을 반복해서 동작시킬 실행식.</param>
    /// <param name="tItem">주적중인 아이템 개체</param>
    /// <param name="nDelay">저장전 대기시간</param>
    /// <returns>업데이트 성공 여부</returns>
    public bool SaveChanges_UpdateConcurrency<T>(
        ModelsDbContext db1
        , int nMaxLoop
        , MultiUpdateConcurrencyItemFuncDelegate<T> callbackItem
        , T tItem
        , int nDelay)
    {
        //반복수
        int nLoopCount = 0;

        //저장 성공 여부
        bool bSaveSuccess = false;
        while (false == bSaveSuccess)
        {//낙관적 동시성 처리

            ++nLoopCount;
            if (0 < nMaxLoop
                && nLoopCount > nMaxLoop)
            {//마이너스값이 아니고
                //지정한 횟수(nMaxLoop)를 넘어섰다.

                //낙관적 동시성 종료
                break;
            }

            //동작 재실행
            bool bCallReturn = callbackItem(tItem);
            if (false == bCallReturn)
            {//결과가 거짓이다.

                //낙관적 동시성 종료
                break;
            }


            Thread.Sleep(nDelay);
            bSaveSuccess = SaveChanges_UpdateConcurrencyCheck_Reload(db1);
        }//end while (false == bSaveSuccess)


        return bSaveSuccess;
    }

    #endregion

    #region 낙관적 동시성 여러줄 처리 - 각자 컨택스트 생성하여 처리함(실패 따로 처리 - 동기)

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="nMaxLoop"></param>
    /// <param name="listLeft"></param>
    /// <param name="callbackItem"></param>
    /// <param name="nDelay"></param>
    public void SaveChanges_Update_MultiDbContext_FailWait<T>(
        int nMaxLoop
        , ref List<T> listLeft
        , MultiUpdateConcurrencyItemFuncDelegate<T> callbackItem
        , int nDelay)
    {

        List<T> listTarget = listLeft;
        List<T> listFailWait;

        //첫 체크가 끝났는지 여부
        //첫 체크는 데이터를 로드할 필요가 없다. 
        bool bFirstCheckEnd = false;

        //각 개체가 저장되었는지 여부
        bool bOC_Temp = false;

        Queue<T> qTarget = new Queue<T>(listLeft);
        

        do
        {
            listFailWait = listTarget;

            for (int i = 0; i < listFailWait.Count; ++i)
            {
                T item = listLeft[i];


                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    if (false == bFirstCheckEnd)
                    {//첫 체크가 끝났다.

                        //검색된 내용을 다시 검색한다.
                        db1.Update(item!);
                    }

                    //동작 재실행
                    bool bCallReturn = callbackItem(item);

                    //낙관적 동시성 저장 시도
                    bOC_Temp = this.SaveChanges_UpdateConcurrencyCheck_NotLoad(db1);
                    if (true == bOC_Temp)
                    {//저장 성공

                        //리스트에서 
                        listTarget.Remove(item);
                    }
                }

                //첫 체크를 완료했는지 여부를 체크
                bFirstCheckEnd = true;
            }
        } while (0 == listTarget.Count());

    }

    //public bool SaveChanges_Update_MultiDbContext_FailWait_OneItem<T>(
    //    ModelsDbContext db1
    //    , int nMaxLoop
    //    , MultiUpdateConcurrencyItemFuncDelegate<T> callbackItem
    //    , T tItem
    //    , int nDelay)
    //{

    //}

    #endregion

    #region 낙관적 동시성 여러줄 처리 - 테스트 중
    /// <summary>
    /// 낙관적 동시성 여러행 적용
    /// </summary>
    /// <remarks>
    /// 낙관적 동시성이 체크가 성공하면 저장한다.<br />
    /// 지정된 실행식을 지정된 횟수만큼 반복한다.<br />
    /// 추적중인 데이터가 모두 다시 로드 되므로 가급적 Context를 짧게 만들어야 
    /// 부하도 적고 속도도 빨라진다.
    /// </remarks>
    /// <param name="db1"></param>
    /// <param name="nMaxLoop">최대 반복수. 마이너스 값이면 무한반복한다.</param>
    /// <param name="listLeft"><para>업데이트가 되지않고 남은 리스트</para>
    /// <para>이 리스트는 업데이트가 성공하면 비워진다.</para>
    /// <para>성공하지 못한 개체는 계속 남아있는다.</para>
    /// <para>리턴이 true가 되면 이 리스트의 아이템은 0개가 된다.</para>
    /// <para>리스트의 순서는 바뀔 수 있다.</para></param>
    /// <param name="callbackItem">저장이 실패한 아이템을 반복해서 동작시킬 실행식.</param>
    /// <param name="nDelay">저장전 대기시간</param>
    /// <returns>업데이트 성공 여부</returns>
    public bool SaveChanges_MultiUpdateConcurrency<T>(
        ModelsDbContext db1
        , int nMaxLoop
        , ref List<T> listLeft
        , MultiUpdateConcurrencyItemFuncDelegate<T> callbackItem
        , int nDelay)
    {
        //반복수
        int nLoopCount = 0;

        //저장 성공 여부
        bool bSaveSuccess = false;

        //첫 동작 여부
        bool bFirstLoop = true;

        //에러 인덱스
        //-1이면 에러가 없다는 의미다.
        int nErrorIdx = 0;

        while (nErrorIdx != -1)
        {//낙관적 동시성 처리

            ++nLoopCount;
            if (0 < nMaxLoop
                && nLoopCount > nMaxLoop)
            {//마이너스값이 아니고
                //지정한 횟수(nMaxLoop)를 넘어섰다.

                //낙관적 동시성 종료
                break;
            }

            //동작 재실행
            bool bCallReturn = false;

            if (true == bFirstLoop)
            {//첫 루프에서만 동작

                bFirstLoop = false;
                foreach (T tData in listLeft)
                {
                    bCallReturn = callbackItem(tData);
                    if (false == bCallReturn)
                    {//동시성 포기다.
                        break;
                    }
                }
            }
            else
            {//두번째 루프다.

                //에러난 개체만 갱신한다.
                //(맨 처음 개체가 에러난 개체다.)
                bCallReturn = callbackItem(listLeft[0]);
            }


            if (false == bCallReturn)
            {//결과가 거짓이다.

                //낙관적 동시성 종료
                break;
            }

            Thread.Sleep(nDelay);

            nErrorIdx = SaveChanges_MultiUpdateConcurrencyCheck(db1, ref listLeft);
            if (-1 == nErrorIdx)
            {
                bSaveSuccess = true;
                listLeft.Clear();
            }
        }//end while (false == bSaveSuccess)


        return bSaveSuccess;
    }

    /// <summary>
    /// 낙관적 동시성 저장 시도
    /// </summary>
    /// <remarks>
    /// <para>실패하면 해당 개체의 리스트상 인덱스가 리턴된다.</para>
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// <param name="db1"></param>
    /// <param name="listLeft">기준이 되는 리스트</param>
    /// <returns>성공하면 -1, 실패한 개체의 리스트상 인덱스</returns>
    public int SaveChanges_MultiUpdateConcurrencyCheck<T>(
        ModelsDbContext db1
        , ref List<T> listLeft)
    {
        int bReturn = -1;

        try
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"SaveChanges : {listLeft.Count}, \n");
            foreach (T tData in listLeft)
            {
                TestOC2? tempItem = tData as TestOC2;
                if(null != tempItem)
                {
                    sb.Append($"    {tempItem.Str}\n");
                }
            }
            Debug.WriteLine(sb.ToString());
            db1.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            //Debug.WriteLine($"DbUpdateConcurrencyException : {listLeft.Count} ");

            //수정하려다 실패한 개체
            //DbUpdateConcurrencyException는 실패한 첫 개체를 준다.
            EntityEntry dataFail = ex.Entries.Single();
            // 수정하려던 요소를 다시 로드 한다.
            // 수정하려던 값이 초기화 되므로 넣으려는 값을 다시 계산해야 한다.
            dataFail.Reload();


            //에러난 개체를 찾는다.
            bReturn = listLeft.IndexOf((T)dataFail.Entity);


            if (-1 != bReturn)
            {//업데이트에 실패한 개체가 있다.

                //업데이트에 성공한 개체 추적 중지 시키기 *********
                List<T> Temp = listLeft.Take(bReturn).ToList();
                foreach (T item in Temp)
                {
                    if(null !=  item)
                    {
                        var entry = db1.Entry(item);

                        if (entry.State != EntityState.Detached)
                        {
                            entry.State = EntityState.Detached;
                        }
                    }
                }

                //인덱스 전까지 있는 개체를 지워준다.
                listLeft.RemoveRange(0, bReturn);


                //Debug.WriteLine($"DbUpdateConcurrencyException 2 : {listLeft.Count} ");
            }
        }

        return bReturn;
    }

    #endregion


    /// <summary>
    /// 낙관적 동시성 저장 시도(실패시 동작 없음)
    /// </summary>
    /// <remarks>
    /// 낙관적 동시성 체크가 성공면 저장하고 true가 리턴되고
    /// 실패하면 false가 리턴된다.
    /// </remarks>
    /// <param name="db1"></param>
    /// <returns></returns>
    public bool SaveChanges_UpdateConcurrencyCheck_NotLoad(ModelsDbContext db1)
    {
        bool bReturn = false;

        try
        {
            db1.SaveChanges();
            bReturn = true;
        }
        catch (DbUpdateConcurrencyException ex)
        {//개체가 변경되어 저장이 실패함
            GlobalStatic.Log(ex);
        }

        return bReturn;
    }

    /// <summary>
    /// 낙관적 동시성 저장 시도(실패시 다시 불러옴)
    /// </summary>
    /// <remarks>
    /// 낙관적 동시성 체크가 성공면 저장하고 true가 리턴되고
    /// 실패하면 false가 리턴된다.
    /// <para>실패시 실패한 대상을 다시 로드한다.<br /> 
    /// 테스트를 해보면 컨택스트 자체가 롤백되는 것으로 보인다.(확인 필요)</para>
    /// </remarks>
    /// <param name="db1"></param>
    /// <returns></returns>
    public bool SaveChanges_UpdateConcurrencyCheck_Reload(ModelsDbContext db1)
    {
        bool bReturn = false;

        try
        {
            db1.SaveChanges();
            bReturn = true;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            // Update the values of the entity that failed to save from the store
            // 수정하려던 요소를 다시 로드 한다.
            // 수정하려던 값이 초기화 되므로 넣으려는 값을 다시 계산해야 한다.
            //ex.Entries.Single().Reload();

            //수정하려다 실패한 개체
            //DbUpdateConcurrencyException는 실패한 첫 개체를 준다.
            EntityEntry dataFail = ex.Entries.Single();
            // 수정하려던 요소를 다시 로드 한다.
            // 수정하려던 값이 초기화 되므로 넣으려는 값을 다시 계산해야 한다.
            dataFail.Reload();

            GlobalStatic.Log(ex);
        }

        return bReturn;
    }
}
