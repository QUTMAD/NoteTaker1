using System;
using SQLite.Net;

namespace NoteTaker1.Data
{
	public interface ISqlite
	{
		SQLiteConnection GetConnection();
	}
}

