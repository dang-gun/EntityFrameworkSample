# Entity framework Sample DB

이 솔루션(EntityFrameworkSample)에서 테스트용으로 사용될 여러 DB를 관리하기위한 마이그레이션 라이브러리입니다.

다른 솔루션에서의 사용을 가정하지 않고 만들어진 프로젝트입니다.

_방법을 찾을때까지 이 프로젝트의 소스 파일을 복사하여 사용하세요_

<br />
<br />

### 지원 범위

.NET Core 6
Entity framework 6

<br />

#### 지원하는 DB
- MSSQL
- Sqlite
- InMomey
- PostgreSQL
- MariaDB

<br />

### 자세한 설명
[[Entity Framework 6] 여러 종류 DB대응하기](https://blog.danggun.net/10495)

<br />

## DB의 연결정보 전달 - 마이그레이션

마이그레이션하기전에 아래와 같은 방법으로 사용할 정보를 넣어두어야 합니다.

- 'SettingInfo_gitignore.json'을 만들어 놓는다.
	'SettingInfo_gitignore.json'파일을 작성해두면 이 파일을 읽어 자동으로 DB엔진에 맞는 정보를 사용합니다.
	```
	[
	  {
		"DBTypeString": "[DB 이름]",
		"DBString": "[연결 문자열]"
	  }
	]
	```
	
	- DB 이름(UseDbType 기준) : InMemory, SQLite, MSSQL, PostgreSQL, MariaDB
	
- 미리 GlobalDb.DBType, GlobalDb.DBString에 정보 넣기
	직접 'GlobalDb'에 데이터를 수정하는 방법입니다.
	생성자(static GlobalDb())에서 자동화를 하는 방식으로 사용 가능합니다.


- 'DbContextInfo'파일을 수정
	'ModelsDB > DbContexts > DbContextInfo'의 파일을 직접 수정하여 
    'DbContextInfo'파일은 'GlobalDb.DBString'가 없을때 사용하는 데이터 입니다.
	여기에 사용할 데이터를 미리 넣습니다.
	

### DB별 마이그레이션 방법
1. '패키지 관리자 콘솔'을 열고 '기본 프로젝트'를 'DbContexts'를 가지고 있는 프로젝트로 지정합니다.
(예> MultiMigrations)
![패키지 관리자 콘솔 설정 방법](https://raw.githubusercontent.com/dang-gun/EntityFrameworkSample/master/MultiMigrations/ProjectFiles/EfMultiMigrations_001.png "패키지 관리자 콘솔 설정 방법")



1. '솔루션 탐색기'에서 DB정보를 가지고 있는 프로젝트를 시작 프로젝트로 설정합니다.
('SettingInfo_gitignore.json'파일이 이 프로젝트에 있다면 이 프로젝트를 지정합니다.)

1. DB에 맞는 'DbContext'파일을 열어 주석에 있는 EF명령어를 '패키지 관리자 콘솔' 넣습니다.
 예> SQLite를 마이그레이션 하려면
	```
	Add-Migration InitialCreate -Context ModelsDbContext_Sqlite -OutputDir Migrations/Sqlite
	```


### DB 조회/수정/제거
'ModelsDbContext'를 선언하여 EF에서 연결한 DB에 접근 할 수 있습니다.
예>
```
using (ModelsDbContext db1 = new ModelsDbContext())
{
    List<Test1Model> findDbData1ModelList
        = db1.Test1Model
            .Include(inc => inc.Test2ModelList)
            .ToList();

    StringBuilder sbTemp = new StringBuilder();
    foreach (Test1Model item in findDbData1ModelList)
    {
        sbTemp.Append($"index = {item.idTest1Model}, Int = {item.Int},  Str = {item.Str},   Date = {item.Date} {Environment.NewLine}");

        sbTemp.Append($" [ {Environment.NewLine}");
        foreach (Test2Model itemChild in item.Test2ModelList)
        {
            sbTemp.Append($"        {{index = {itemChild.idTest2Model}, Parent = {item.idTest1Model}}} {Environment.NewLine}");
        }
        sbTemp.Append($" ], {Environment.NewLine}");
    }

    sReturn = sbTemp.ToString();

}//end using db1
```

_참고 : 'DbContext'는 가능한 짧게 유지하는 것이 좋습니다._


## 주의 사항
여러 DB의 프로바인더를 참조하고 있어서 빌드 결과물의 용량이 큽니다.
(약 12mb)

이 프로젝트를 복사하여 자신의 프로젝트에 맞게 필요없는 프로바인더는 제거하여 사용하는 것이 좋습니다.

