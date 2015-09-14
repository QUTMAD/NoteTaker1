using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace NoteTaker1.Data.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class NoteListViewModel : ViewModelBase
    {
		private IMyNavigationService navigationService;

		public ObservableCollection<Note> NoteList {
			get {
				var database = new NoteDatabase ();
				var x = database.GetAll ();
				return new ObservableCollection<Note> (x);
			}
		}


		public ICommand NewNoteCommand { get; private set; }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
		public NoteListViewModel(IMyNavigationService navigationService)
        {
			this.navigationService = navigationService;
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

			NewNoteCommand = new Command (() => this.navigationService.NavigateTo (ViewModelLocator.NoteDetailPageKey));
        }

		public void OnAppearing(){
			RaisePropertyChanged (() => NoteList);
		}

    }
}