using System;
using System.Collections.Generic;
using Xamarin.Forms;
using NoteTaker1.Data.ViewModel;

namespace NoteTaker1
{
	public partial class NoteListPage : BaseView
	{
		public NoteListPage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.NoteList;


		}

		protected void ButtonClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync (new NoteDetailsPage ());
		}

	}
}

