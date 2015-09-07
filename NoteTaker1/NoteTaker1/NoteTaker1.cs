using System;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;
using NoteTaker1.Data.ViewModel;
using NoteTaker1.Data;

namespace NoteTaker1
{
	public class App : Application
	{
		private static ViewModelLocator _locator;
		private static NavigationService nav;
		public static ViewModelLocator Locator
		{
			get
			{
				return _locator ?? (_locator = new ViewModelLocator());
			}
		}

		public App ()
		{
			
			// The root page of your application
			MainPage = GetMainPage();

		}

		public Page GetMainPage()
		{
			nav = new NavigationService ();
			nav.Configure (ViewModelLocator.NoteListPageKey, typeof(NoteListPage));
			nav.Configure (ViewModelLocator.NoteDetailPageKey, typeof(NoteDetailsPage));
			SimpleIoc.Default.Register<IMyNavigationService> (()=> nav, true);
			var navPage = new NavigationPage (new NoteListPage ());
			nav.Initialize (navPage);
			return navPage;
		}
		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

