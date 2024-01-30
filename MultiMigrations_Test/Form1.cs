using Microsoft.EntityFrameworkCore;

using Global.DB;
using ModelsDB;

namespace MultiMigrations_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region DB º±≈√
        private void radioSqlite_CheckedChanged(object sender, EventArgs e)
        {
            GlobalDb.DBType = UseDbType.Sqlite;

            GlobalDb.DBString = "Data Source=Test.db";

            using (ModelsDbContext db1 = new ModelsDbContext())
            {
                db1.Database.Migrate();
            }
        }

        private void radioMssql_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
