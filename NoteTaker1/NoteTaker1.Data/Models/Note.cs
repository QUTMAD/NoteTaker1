using System;
using SQLite.Net.Attributes;

namespace NoteTaker1.Data
{
	public class Note
	{
		[PrimaryKey, AutoIncrement]
		public int NoteId { get; set; }
		[NotNull, MaxLength(128)]
		public string titleText { get; set; }
		public DateTime TimeStamp { get; set; }
		public string NoteDetail { get; set; }
		public Boolean ActionRequiredFlag { get; set; }

		public Note(){
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NoteTaker1.Data.Note"/> class.
		/// </summary>
		/// <param name="titleText">Title text.</param>
		/// <param name="timeStamp">Time stamp.</param>
		/// <param name="actionRequiredFlag">Action required flag.</param>
		/// <param name="noteDetail">Note detail.</param>
		public Note (string titleText, DateTime timeStamp, bool actionRequiredFlag = false, string noteDetail = "")
		{
			this.titleText = titleText;
			TimeStamp = timeStamp;
			ActionRequiredFlag = actionRequiredFlag;
			NoteDetail = noteDetail;
		}
	}
}

