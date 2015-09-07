using System;

namespace NoteTaker1.Data
{
	public interface IPageLifeCycleEvents
	{
		void OnAppearing();
		void OnDisappearing();
		void OnLayoutChanged();
	}
}

