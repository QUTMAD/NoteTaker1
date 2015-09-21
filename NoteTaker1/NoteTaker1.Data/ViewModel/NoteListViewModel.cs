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
		private ObservableCollection<Note> noteList{ get; set;}
		public ObservableCollection<Note> NoteList {
			get {return noteList;}
			set{ noteList = value; 
				RaisePropertyChanged (() => NoteList);
			}
		}


		public ICommand NewNoteCommand { get; private set; }

		public ICommand NoteListCommand {get; private set;}

		public ICommand ClearSearchCommand { get; private set; }

		private string searchTerm { get; set; }

		public string SearchTerm{
			get { return searchTerm; }
			set { 
				if (value!= null) {
					searchTerm = value;
					RaisePropertyChanged (() => SearchTerm);
				}
			}
		}
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
		public NoteListViewModel(IMyNavigationService navigationService)
        {
			this.navigationService = navigationService;
			var database = new NoteDatabase ();

			NewNoteCommand = new Command (() => this.navigationService.NavigateTo (ViewModelLocator.NoteDetailPageKey));
			NoteListCommand = new Command(() => {
				NoteList = new ObservableCollection<Note>(database.SearchTitleDetail(SearchTerm));
			});
			ClearSearchCommand = new Command (() => {
				NoteList = new ObservableCollection<Note> (database.GetAll ());
				SearchTerm = string.Empty;
			});
        }

		public void OnAppearing(){
			var database = new NoteDatabase ();
			NoteList = new ObservableCollection<Note> (database.GetAll ());
		}

    }
}