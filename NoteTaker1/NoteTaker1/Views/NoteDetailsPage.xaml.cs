using System;
using System.Collections.Generic;

using Xamarin.Forms;
using NoteTaker1.Data.ViewModel;
using NoteTaker1.Data;

namespace NoteTaker1
{
	public partial class NoteDetailsPage : BaseView
	{
		public NoteDetailsPage ()
		{
			BindingContext = App.Locator.NoteDetail;
			InitializeComponent ();
			base.Init ();
			Title = "Details";
		}
	}
}

