using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NoteTaker1
{
	public partial class NoteListPage : NavigationPage
	{
		public NoteListPage ()
		{
			InitializeComponent ();

//			var noteList = new List<Notes> ();
//			noteList.Add (new Notes ("FirstNote"){ TimeStamp = "Now", ActionRequiredFlag = "N" });
//			noteList.Add (new Notes ("SecondNote"){ TimeStamp = "Yesterday", ActionRequiredFlag = "Y" });
//			noteList.Add (new Notes ("ThirdNote"){ TimeStamp = "theDaybefore", ActionRequiredFlag = "N" });
//			NoteListView.ItemTemplate = new DataTemplate (typeof(Notes));
//			NoteListView.ItemsSource = noteList;
		}

		public static void ButtonClicked (EventArgs e){
//			Navigation.PushAsync (new NoteDetailsPage());
		}
	}
}

