# Entity framework Multi Migrations - Test WinForm

'MultiMigrations'프로젝트를 테스트하기위한 프로젝입니다.

'WinForm'으로 개발되었습니다.

## 사용 방법

![테스트 프로그램 이미지](https://raw.githubusercontent.com/dang-gun/EntityFrameworkSample/master/MultiMigrations_Test/ProjectFiles/EfMultiMigrations_003.png "테스트 프로그램 이미지")

1. 'MultiMigrations'를 이용하여 마이그레이션을 합니다.

1. 프로젝트를 실행(Run)시킵니다.

1. 'DB Select' 항목중 사용할 DB를 선택합니다.

1. 'Select All' 버튼을 누르면 해당 DB의 'Test1Model'리스트를 기준으로 FK가 연결된 자식까지 텍스트(Text)로 표시됩니다.


#### 데이터 추가하기
- 'Test1Model Add' 버튼을 누르면 선택된 DB에 랜덤한 값을 가지고 있는 'Test1Model'데이터를 추가합니다.
- 'Parent Index'에 'Test1Model'의 고유번호를 넣고 'Add'버튼을 누르면 인덱스에 해당하는 'Test1Model'을 찾아 자식 데이터를 추가합니다.


<br />
<br />