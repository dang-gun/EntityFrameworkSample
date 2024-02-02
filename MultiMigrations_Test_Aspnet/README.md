# Entity framework Multi Migrations - Test ASP.NET Core 6

'MultiMigrations'프로젝트를 테스트하기위한 프로젝입니다.
(참고 : github - [Entity framework Multi Migrations](https://github.com/dang-gun/EntityFrameworkSample/tree/master/MultiMigrations))

'ASP.NET Core 6'으로 개발되었습니다.

## 사용 방법

![테스트 스웨커 이미지](https://raw.githubusercontent.com/dang-gun/EntityFrameworkSample/master/MultiMigrations_Test_Aspnet/ProjectFiles/EfMultiMigrations_005.png "테스트 스웨커 이미지")

1. 'MultiMigrations'를 이용하여 마이그레이션을 합니다.

1. 프로젝트를 실행(Run)시킵니다.
	(스웨거(Swagger) 창이 열립니다.)

1. 'DB Select' 컨트롤러에서 사용할 DB를 선택하는 API를 호출해줍니다.

1. 'DbView > Select All'을 호출하면 해당 DB의 'Test1Model'리스트를 기준으로 FK가 연결된 자식까지 텍스트(Text)로 리턴 됩니다.


#### 데이터 추가하기
- 'DbView > Test1Model_Add'를 호출하면 선택된 DB에 랜덤한 값을 가지고 있는 'Test1Model'데이터를 추가합니다.
- 'DbView > Test2Model_Add'를 호출할때 'nParentIndex'에 'Test1Model'의 고유번호를 전달하면 'Test1Model'을 찾아 자식 데이터를 추가합니다.


<br />
<br />