using System;
using Xamarin.Forms;
using NoteTaker1.Data;

namespace NoteTaker1
{
	public class BaseView : ContentPage
	{
		public BaseView ()
		{
		}

		protected void Init(){
		
			var lifecycleHandler = this.BindingContext as IPageLifeCycleEvents;

			if (lifecycleHandler != null) {
				base.Appearing += (object sender, EventArgs e) => {
					lifecycleHandler.OnAppearing();
				};
				base.Disappearing += (object sender, EventArgs e) => {
					lifecycleHandler.OnDisappearing();
				};
				base.LayoutChanged += (object sender, EventArgs e) => {
					lifecycleHandler.OnLayoutChanged();
				};
			}
		}
	}
}

