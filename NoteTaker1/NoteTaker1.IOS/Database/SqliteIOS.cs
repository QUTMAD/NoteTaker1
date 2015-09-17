using System;
using NoteTaker1.Data;
using SQLite.Net;
using System.IO;
using Xamarin.Forms;
using NoteTaker1.IOS;

//TODO show IOC vs Dependency Injection
[assembly: Dependency (typeof (SqliteIOS))]

namespace NoteTaker1.IOS
{
	public class SqliteIOS : ISqlite
	{
		public SqliteIOS(){
		}
		#region ISqlite implementation

		public SQLiteConnection GetConnection ()
		{
			const string sqliteFilename = "database.db3";
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var path = Path.Combine (documentsPath, sqliteFilename);
			var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS ();
			//Create the connection
			var conn = new SQLiteConnection(plat,path);

			return conn;
		}

		#endregion


	}
}

