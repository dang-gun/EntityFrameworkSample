using Global.DB;
using System.Text.Json.Serialization;

namespace ModelsDB.MultiMigrations;

/// <summary>
/// 역직열화에 사용할 모델
/// </summary>
/// <remarks>
/// 인터페이스를 그대로 역직열화 하면 오류가 발생하므로 모델로 사용하기위한 개체이다.
/// </remarks>
public class DbContextDefaultInfo_Temp : DbContextDefaultInfoInterface
{
    /// <inheritdoc />
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public UseDbType DBType { get; set; } = UseDbType.None;
    /// <inheritdoc />
    public string DBString { get; set; } = string.Empty;

    /// <summary>
    /// 문자열로 DBType을 입력하는 경우
    /// </summary>
    public string DBTypeString
    { 
        get
        {
            return this.DBType.ToString();
        }
        set
        {
            int nType = 0;

            if (true == int.TryParse(value, out nType))
            {//숫자형으로 들어왔다.
                this.DBType = (UseDbType)nType;
            }
            else
            {
                switch (value.ToLower())
                {
                    case "inmemory":
                        this.DBType = UseDbType.InMemory;
                        break;
                    case "sqlite":
                        this.DBType = UseDbType.SQLite;
                        break;
                    case "mssql":
                        this.DBType = UseDbType.MSSQL;
                        break;
                    case "postgresql":
                        this.DBType = UseDbType.PostgreSQL;
                        break;

                    case "none":
                    default:
                        this.DBType = UseDbType.None;
                        break;
                }//end switch
            }
        }
    }
}
