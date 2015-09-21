using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;

namespace NoteTaker1.Data
{
	public class NoteDatabase
	{
		SQLiteConnection database;
		public NoteDatabase ()
		{
			database = DependencyService.Get<ISqlite> ().GetConnection ();
			//TODO show IOC vs Dependency injection
//			database = SimpleIoc.Default.GetInstance<ISqlite> ().GetConnection ();
			if (database.TableMappings.All(t => t.MappedType.Name != typeof(Note).Name)) {
				database.CreateTable<Note> ();
				database.Commit ();
			}
		}

		public List<Note> GetAll(){
			var items = database.Table<Note> ().ToList<Note>();

			return items;
		}

		public int InsertOrUpdateNote(Note note){
			return database.Table<Note> ().Where (x => x.titleText == note.titleText && x.TimeStamp == note.TimeStamp ).Count () > 0 
				? database.Update (note) : database.Insert (note);
		}

		public Note GetNote(string key){
			return database.Table<Note> ().First (t => t.titleText == key); 
		}

	}
}

