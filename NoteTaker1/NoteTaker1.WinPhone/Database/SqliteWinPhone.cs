using System;
using NoteTaker1.Data;
using SQLite.Net;
using System.IO;
[assembly: Dependency(typeof(SqliteWinPhone))]

namespace NoteTaker1.Droid
{
	public class SqliteWinPhone : ISqlite
	{
		public SqliteWinPhone(){
		}
		#region ISqlite implementation

		public SQLiteConnection GetConnection ()
		{
			const string sqliteFilename = "database.db3";
			var path = Path.Combine (ApplicationData.Current.LocalFolder.Path, sqliteFilename);

			var conn = new SQLiteConnection(SQLite.Net.Platform.XamarinAndroid,path);

			return conn;
		}

		#endregion


	}
}

