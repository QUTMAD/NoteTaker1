using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using GalaSoft.MvvmLight.Ioc;
using NoteTaker1.Data;


namespace NoteTaker1.Droid
{
	[Activity (Label = "NoteTaker1.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		public static MobileServiceClient MobileService = new MobileServiceClient(
			"https://qutmad.azure-mobile.net/",
			"lLPKiDOkWSFwlpYkKWvcHQxxhqUUpj89"
		);
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			//TODO show IOC vs Dependency injection
//			SimpleIoc.Default.Register<ISqlite> (new SqliteDroid ());
			LoadApplication (new App ());

		}
	}
}

