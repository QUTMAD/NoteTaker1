using System;
using NoteTaker1.Data;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;
using System.Reflection;

namespace NoteTaker1
{
	public class NavigationService : IMyNavigationService
	{
		private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
		private NavigationPage _navigation;

		bool wasModal;

		public bool IsModal
		{
			get
			{
				return wasModal;
			}
		}

		public Page CurrentPage {
			get {

				if (_navigation.CurrentPage == null)
				{
					return null;
				}

				return _navigation.CurrentPage;
			}
		}

		public string CurrentPageKey
		{
			get
			{
				lock (_pagesByKey)
				{
					if (_navigation.CurrentPage == null)
					{
						return null;
					}

					var pageType = _navigation.CurrentPage.GetType();

					return _pagesByKey.ContainsValue(pageType)
						? _pagesByKey.First(p => p.Value == pageType).Key
							: null;
				}
			}

		}

		public async void GoBack()
		{

			if (wasModal) {
				var p = await _navigation.Navigation.PopModalAsync ();

			}
			else
				_navigation.PopAsync();

		}

		public void NavigateTo(string pageKey)
		{
			NavigateToInternal(pageKey, null, false);
		}

		public void NavigateTo(string pageKey, object parameter)
		{
			NavigateToInternal (pageKey, parameter, false);
		}

		private void NavigateToInternal(string pageKey, object parameter, bool modal = false)
		{
			try
			{

				lock (_pagesByKey)
				{
					if (_pagesByKey.ContainsKey(pageKey))
					{
						var type = _pagesByKey[pageKey];
						ConstructorInfo constructor = null;
						object[] parameters = null;

						if (parameter == null)
						{
							constructor = type.GetTypeInfo()
								.DeclaredConstructors
								.FirstOrDefault(c => !c.GetParameters().Any());

							parameters = new object[] {

							};
						}
						else
						{
							constructor = type.GetTypeInfo()
								.DeclaredConstructors
								.FirstOrDefault(
									c =>
									{
										var p = c.GetParameters();
										return p.Count() == 1
											&& p[0].ParameterType == parameter.GetType();
									});
							parameters = new[] {
								parameter
							};
						}

						if (constructor == null)
						{
							throw new InvalidOperationException(
								"No suitable constructor found for page " + pageKey);
						}

						var page = constructor.Invoke(parameters) as Page;
						if (modal)
						{
							wasModal = true;
							_navigation.Navigation.PushModalAsync(page);
							NavigationPage.SetHasNavigationBar(_navigation, true);
						}
						else
						{
							wasModal = false;
							_navigation.Navigation.PushAsync(page);
						}
					}
					else
					{
						throw new ArgumentException(
							string.Format(
								"No such page: {0}. Did you forget to call NavigationService.Configure?",
								pageKey),
							"pageKey");
					}
				}
			}
			catch (Exception e)
			{

				throw e;
			}
		}

		public void Configure(string pageKey, Type pageType)
		{
			lock (_pagesByKey)
			{
				if (_pagesByKey.ContainsKey(pageKey))
				{
					_pagesByKey[pageKey] = pageType;
				}
				else
				{
					_pagesByKey.Add(pageKey, pageType);
				}
			}
		}

		public void Initialize(NavigationPage navigation)
		{
			_navigation = navigation;

			_navigation.Popped += (object sender, NavigationEventArgs e) => {

				Debug.WriteLine(e);
			};
		}

		public void ClearHistory (string pageKey)
		{

			lock (_pagesByKey)
			{
				if (_pagesByKey.ContainsKey (pageKey)) {
					var type = _pagesByKey [pageKey];
					ConstructorInfo constructor = null;
					object[] parameters = null;


					constructor = type.GetTypeInfo ()
						.DeclaredConstructors
						.FirstOrDefault (c => !c.GetParameters ().Any ());

					parameters = new object[] {

					};


					if (constructor == null) {
						throw new InvalidOperationException (
							"No suitable constructor found for page " + pageKey);
					}

					var page = constructor.Invoke (parameters) as Page;

					_navigation = new NavigationPage (page);


				}
				else
				{
					throw new ArgumentException(
						string.Format(
							"No such page: {0}. Did you forget to call NavigationService.Configure?",
							pageKey),
						"pageKey");
				}
			}

		}


		public void NavigateToModal (string pageKey)
		{
			NavigateToInternal(pageKey, null, true);
		}

		public void NavigateToModal (string pageKey, object parameter)
		{
			NavigateToInternal(pageKey, parameter, true);

		}

		public void SetNavigationBarVisibility (bool visible)
		{
			NavigationPage.SetHasNavigationBar (CurrentPage, visible);

		}
	}
}

