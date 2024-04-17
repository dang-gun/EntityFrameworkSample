# Entity Framework Sample
Entity Framework용 샘플을 모아둔 솔류션입니다.


## 구성요소
샘플 프로젝트가 참조하고 있는 프로젝트나 라이브러리는 아래와 같은 용도로 참조 되고 있습니다.

### 필수 구성 요소
DB처리 공통화를 위해 'Reference'폴더의 프로젝트를 참조해야 할 수 있습니다.

 - EntityFrameworkSample.DB
   DB 처리 공통화를 위한 프로젝트
   대부분의 프로젝트가 참조하고 있습니다.
 
 - EntityFrameworkSample.Console
   콘솔 프로젝트의 경우 DB 처리시 공통적으로 사용하는 UI를 구현한 프로젝트입니다.
   대부분의 콘솔 프로젝트가 참조하고 있습니다.
 
 - EntityFrameworkSample.DB.MigrationFile
   'EntityFrameworkSample.DB'와 'EntityFrameworkSample.Console'프로젝트를 참조하하여 만들어진 셈플 프로젝트입니다.
   이 프로젝트 참고하여 'ModelsDB'폴더를 복사하고 코드를 수정하여 테스트 프로젝트를 추가로 만들 수 있습니다.
 
 ### 외부 참조
 'OutLibrary'폴더에 이 프로젝트에 소속되지 않은 유틸리티가 포함되어 있습니다.

  - DGU_ConsoleAssist : 콘솔 관련 기능을 지원하는 유틸(여기서는 메뉴기능만 사용합니다.)
    [dang-gun/DGUtility_DotNet/DGU_ConsoleAssist](https://github.com/dang-gun/DGUtility_DotNet/tree/main/DGU_ConsoleAssist)
    



## 테스트 방법
MSSQL과 같이 중요한 정보가 필요한 DB엔진의 경우 정보를 별도의 파일로 관리하여 github에 업로드 하지 않도록 해야합니다.

그래서 이 솔류선에서는 'EntityFrameworkSample.DB' 프로젝트에 'SettingInfo_gitignore.json'파일을 사용하도록 구성이 되어 있습니다.
이 파일은 git예외 파일에 등록되어있어 git에 올라가지 않습니다.


'SettingInfo_gitignore.json'파일의 내용은 아래와 같습니다.(파일은 직접 생성해야 합니다.)
```
//깃에는 올리면 안되는 정보
[
  {
    "DBTypeString": "MSSQL",
    "DBString": "[DB 연결 문자열]"
  },
  {
    "DBTypeString": "PostgreSQL",
    "DBString": "[DB 연결 문자열]"
  },
  {
    "DBTypeString": "Mariadb",
    "DBString": "[DB 연결 문자열]"
  }
]
```

프로젝트가 빌드되면 'SettingInfo_gitignore.json'파일이 출력되도록 속성을 변경합니다.

'SettingInfo_gitignore.json'에서 오른쪽 클릭 > 속성  
'출력 디렉토리로 복사'를 '항상 복사' 혹은 '새 버전이면 복사'로 변경



## 소속 프로젝트 자세한 설명


### 프로젝트 시작 관련(Project Start Related)

#### CoreCodeFirst
[[.NET Core 2] EF(Entity Framework) 코어(Core) 코드 퍼스트(Code First)](https://blog.danggun.net/7682)
<br />
<br />

#### DBFirst
[[.NET Core 2] EF(Entity Framework) 코어(Core) DB 퍼스트(DB First)](https://blog.danggun.net/7909)
<br />
<br />

#### SqliteEF_CCF

<br />
<br />