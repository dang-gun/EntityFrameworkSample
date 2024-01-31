using System.Text;

using Microsoft.EntityFrameworkCore;

using Global.DB;
using ModelsDB;


namespace MultiMigrations_Test
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

            this.radioInMemory_CheckedChanged(null, null);
        }

        #region DB ����
        /// <summary>
        /// �� �����ڵ忡���� �� �Լ��� ȣ��Ǹ� �θ޸� DB�� ���� ���� �����ȴٴ� �ǹ��̴�.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioInMemory_CheckedChanged(object? sender, EventArgs? e)
        {

            if (true == this.radioInMemory.Checked)
            {
                GlobalDb.DBType = UseDbType.InMemory;

                GlobalDb.DBString = "TestDb";

                //�θ޸𸮴� ���̱׷��̼� ������ ����.
                //�׷��� ModelsDbContext.OnConfiguring�� ȣ����� �ʾ� �⺻ �����͸� ���� �� ����.
                //�������� �־��ش�.
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    db1.Test1Model.Add(
                        new Test1Model()
                        {
                            idTest1Model = 1,
                            Int = 1,
                            Str = "Test",
                            Date = DateTime.Now,
                        });
                    db1.SaveChanges();

                    db1.Test2Model.Add(
                        new Test2Model()
                        {
                            idTest2Model = 1,
                            idTest1Model = 1,
                        });
                    db1.SaveChanges();
                }
            }
        }

        private void radioSqlite_CheckedChanged(object sender, EventArgs e)
        {
            if (true == this.radioSqlite.Checked)
            {
                GlobalDb.DBType = UseDbType.Sqlite;

                GlobalDb.DBString = "Data Source=Test.db";

                using (ModelsDbContext_Sqlite db1 = new ModelsDbContext_Sqlite())
                {
                    db1.Database.Migrate();
                }
            }
        }

        private void radioMssql_CheckedChanged(object sender, EventArgs e)
        {
            if (true == this.radioMssql.Checked)
            {
                GlobalDb.DBType = UseDbType.Mssql;

                GlobalDb.DBString
                    = GlobalDb.DbStringLoad(
                        "SettingInfo_gitignore.json"
                        , UseDbType.Mssql);

                using (ModelsDbContext_Mssql db1 = new ModelsDbContext_Mssql())
                {
                    db1.Database.Migrate();
                }
            }
        }
        #endregion


        /// <summary>
        /// ��ü ����Ʈ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object? sender, EventArgs? e)
        {
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
                this.txtDbData1Model_Log.Text = sbTemp.ToString();

            }
        }

        /// <summary>
        /// �θ� �߰�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDbData1Model_Add_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                Test1Model newTest1 = new Test1Model();

                newTest1.Int = rand.Next(0, 100000);
                newTest1.Str = Guid.NewGuid().ToString(); ;
                newTest1.Date = new DateTime(rand.Next(0, 1000000));

                db1.Test1Model.Add(newTest1);
                db1.SaveChanges();
            }

            this.btnSelectAll_Click(null, null);
        }

        private void btnDbData2Model_Add_Click(object sender, EventArgs e)
        {
            int nIdx = 0;
            int.TryParse(txtDbData2Model_Index.Text, out nIdx);


            if (0 < nIdx)
            {
                using (ModelsDbContext db1 = new ModelsDbContext())
                {
                    Test2Model newTest2 = new Test2Model();

                    newTest2.idTest1Model = nIdx;

                    try
                    {
                        db1.Test2Model.Add(newTest2);
                        db1.SaveChanges();

                        this.btnSelectAll_Click(null, null);
                    }
                    catch (Exception ex)
                    {
                        this.txtDbData1Model_Log.Text = ex.ToString();
                    }
                }
            }
            else
            {
                this.txtDbData1Model_Log.Text = "0���� ū ���ڸ� �־��ּ���.";
            }
        }
    }
}
