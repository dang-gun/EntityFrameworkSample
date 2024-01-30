using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiMigrationsSample.Models;

/// <summary>
/// 대상 DB 타입
/// </summary>
public enum TargetDbType
{
	None = 0,

	/// <summary>
	/// Sqlite
	/// </summary>
	Sqlite,

	/// <summary>
	/// MS Sql
	/// </summary>
	Mssql,
}
