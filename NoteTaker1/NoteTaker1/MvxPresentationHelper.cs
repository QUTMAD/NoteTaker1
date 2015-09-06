using System;
using Xamarin.Forms;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;

namespace NoteTaker1
{
	public class MvxPresentationHelper
	{
		public static ContentPage CreatePage(MvxViewModelRequest request)
		{
			var viewModelName = request.ViewModelType.Name;
			var pageName = viewModelName.Replace("ViewModel", "Page");
			Type pageType = Type.GetType(App.PageNamespace + "." + pageName);

			if (pageType == null)
			{
				Mvx.Trace("Page not found for {0}", pageName);
				return null;
			}

			var page = Mvx.Resolve(pageType) as ContentPage;

			if (page == null)
			{
				Mvx.Error("Failed to create ContentPage {0}", pageName);
			}
			return page;
		}

	}
}

