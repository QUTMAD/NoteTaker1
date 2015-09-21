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
		/// <summary>
		/// Initializes a new instance of the <see cref="NoteTaker1.Data.NoteDatabase"/> class.
		/// </summary>
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

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns>The all.</returns>
		public List<Note> GetAll(){
			var items = database.Table<Note> ().ToList<Note>();

			return items;
		}

		/// <summary>
		/// Inserts the or update note.
		/// </summary>
		/// <returns>The or update note.</returns>
		/// <param name="note">Note.</param>
		public int InsertOrUpdateNote(Note note){
			return database.Table<Note> ().Where (x => x.NoteId == note.NoteId).Any() 
				? database.Update (note) : database.Insert (note);
		}

		/// <summary>
		/// Gets the note.
		/// </summary>
		/// <returns>The note.</returns>
		/// <param name="key">Key.</param>
		public Note GetNote(int key){
			return database.Table<Note> ().First (t => t.NoteId == key); 
		}

		/// <summary>
		/// Searches the title.
		/// </summary>
		/// <returns>List of notes containing the search term in the title</returns>
		/// <param name="searchTerm">Search term.</param>
		public List<Note> SearchTitle(string searchTerm){
			return database.Table<Note> ().Where (x => x.titleText.Contains (searchTerm)).ToList ();
			//return database.Query<Note> ("Select * from Note where titleText like *?*", searchTerm).ToList();
		}
		/// <summary>
		/// Searches the title.
		/// </summary>
		/// <returns>List of notes containing the search term in the title</returns>
		/// <param name="searchTerm">Search term.</param>
		public List<Note> SearchDetail(string searchTerm){
			return database.Table<Note> ().Where (x => x.NoteDetail.Contains (searchTerm)).ToList ();
			//return database.Query<Note> ("Select * from Note where NoteDetail like *?*", searchTerm).ToList();
		}

		/// <summary>
		/// Searches the note database
		/// </summary>
		/// <returns>List of notes containing the search term in the title or detail</returns>
		/// <param name="searchTerm">Search term.</param>
		public List<Note> SearchTitleDetail(string searchTerm){
			//Basic LINQ
			var value =  database.Table<Note> ().Where (x => x.titleText.Contains (searchTerm) || x.NoteDetail.Contains (searchTerm)).ToList ();

			//Basic Query
			value = database.Query<Note> ("Select * from Note where NoteDetail like ? OR titleText like ?", searchTerm).ToList();

			//LINQ
			var valueList = 
				from note in database.Table<Note> ()
				where note.titleText.Contains (searchTerm) || note.NoteDetail.Contains (searchTerm)
				select note;
			value = valueList.ToList ();
			return value;
		}

		/// <summary>
		/// Counts the notes by week day.
		/// </summary>
		/// <returns>The notes by week day.</returns>
		public List<IGrouping<DayOfWeek,Note>> CountNotesByWeekDay(){
			var value = 
				from note in database.Table<Note> ()
					group note by note.TimeStamp.DayOfWeek;
			return value.ToList ();
		}


	}
}

