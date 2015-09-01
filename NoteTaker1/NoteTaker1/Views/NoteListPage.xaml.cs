using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NoteTaker1
{
	public partial class NoteListPage : ContentPage
	{
		public NoteListPage ()
		{
			InitializeComponent ();

			var noteList = new List<Notes> ();
			noteList.Add (new Notes ("FirstNote"){ TimeStamp = "Now", ActionRequiredFlag = "N" });
			noteList.Add (new Notes ("SecondNote"){ TimeStamp = "Yesterday", ActionRequiredFlag = "Y" });
			noteList.Add (new Notes ("ThirdNote"){ TimeStamp = "theDaybefore", ActionRequiredFlag = "N" });
			NoteListView.ItemsSource = noteList;

		}

		protected void ButtonClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync (new NoteDetailsPage ());
		}
	}
}

