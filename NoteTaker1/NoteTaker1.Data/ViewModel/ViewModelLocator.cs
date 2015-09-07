/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:NoteTaker1.Data"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace NoteTaker1.Data.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
		public const string NoteListPageKey = "NoteListPage";
		public const string NoteDetailPageKey = "NoteDetailPage";
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

			SimpleIoc.Default.Register<NoteListViewModel>(() => 
				{
					return new NoteListViewModel(
						SimpleIoc.Default.GetInstance<IMyNavigationService>()
					);
				});
			SimpleIoc.Default.Register<NoteDetailViewModel>(() => 
				{
					return new NoteDetailViewModel(
						SimpleIoc.Default.GetInstance<IMyNavigationService>()
					);
				});
        }

        public NoteListViewModel NoteList
        {
            get
            {
				return ServiceLocator.Current.GetInstance<NoteListViewModel>();
            }
        }
        
		public NoteDetailViewModel NoteDetail
		{
			get
			{
				return ServiceLocator.Current.GetInstance<NoteDetailViewModel> ();
			}
		}
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}