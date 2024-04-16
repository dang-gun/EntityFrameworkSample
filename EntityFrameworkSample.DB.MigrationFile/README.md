# Entity framework Sample DB Migration(EntityFrameworkSample.DB.MigrationFile)

이 솔루션(EntityFrameworkSample)에서 테스트용으로 사용될 여러 DB를 관리하기위한 마이그레이션을 어떻게 관리하는지 보여주기위한 샘플입니다.

다른 솔루션에서의 사용을 가정하지 않고 만들어진 프로젝트입니다.

_방법을 찾을때까지 이 프로젝트의 소스 파일을 복사하여 사용하세요_


## 사용 방법

### 프로젝트 복사 및 초기 설정

1. 'EntityFrameworkSample.DB'를 참조에 추가합니다.

1. 새로 생성한 프로젝트에 'ModelsDB'폴더를 복사하여 넣습니다.

1. ModelsDB > DbContexts 
   의 내용 중 사용하지 않는 DB엔진의 파일은 지워줍니다.

1. ModelsDB > DbContexts > ModelsDbContextTable
   를 열어 테이블로 사용할 DbSet을 작성합니다.


### 마이그레이션 생성 방법
1. 'ModelsDbContext_[DB이름]'파일을 열면 주석에 마이그레이션 명령어가 정리되어 있습니다.

1. '패키지 관리자 콘솔'을 열고 기본프로젝트를 'DbContext'가있는 프로젝트로 지정합니다.
   '솔루션 탐색기'에서 빌드에 사용할 프로젝트를 '시작 프로젝트'로 지정합니다.

1. 마이그레이션 명령을 사용하여 마이그레이션을 생성합니다.

### 사용하기

_Program.cs를 참고하여 사용합니다._

'GlobalDb.DBType'과 'GlobalDb.DBString'에 값이 들어가 있으면 'ModelsDbContextTable'만 인스턴스를 생성하여 사용할 수 있습니다.

```
using (ModelsDbContextTable db1 = new ModelsDbContextTable())
{
    TestTable temp = db1.TestTable.ToList();
}
```

- 'EntityFrameworkSample.DB'에서 설정한 기본 값을 불러오고 싶으면 'GlobalDb.DbStringReload'를 사용합니다.
- 이미 입력된 정보가 있더라도 기본정보를 사용하고 싶으면 'GlobalDb.DbStringReload(false);'를 호출하면 됩니다.


