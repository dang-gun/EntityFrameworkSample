# EntityFrameworkSample
EF 관련 셈플 프로젝트


## 테스트 방법
MSSQL과 같이 중요한 정보가 필요한 DB엔진의 경우 정보를 별도의 파일로 관리하여 github에 업로드 하지 않도록 해야합니다.

그래서 이 솔류선에서는 'EntityFrameworkSample.DB' 프로젝트에 'SettingInfo_gitignore.json'파일을 생성해야 합니다.

'SettingInfo_gitignore.json'파일의 내용은 아래와 같습니다.
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