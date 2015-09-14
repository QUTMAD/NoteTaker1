using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using NoteTaker1.Data.ViewModel;
using Microsoft.Practices.ServiceLocation;

namespace NoteTaker1.Data
{
	public class NoteDetailViewModel :ViewModelBase
	{
		public ICommand SaveNoteCommand { get; private set;}
        private String noteTitle;

        public String NoteTitle
        {
            get { return noteTitle; }
			set { noteTitle = value;
				RaisePropertyChanged(() => NoteTitle); }
        }

        private string noteDetail;

        public string NoteDetail
        {
            get { return noteDetail; }
            set { noteDetail = value;
				RaisePropertyChanged(() => NoteDetail); }
        }

        private bool noteActionFlag;

        public bool NoteActionFlag
        {
            get { return noteActionFlag; }
            set { noteActionFlag = value;
				RaisePropertyChanged(() => NoteActionFlag); }
        }


		public NoteDetailViewModel (IMyNavigationService navigationService)
		{
			var database = new NoteDatabase();
			SaveNoteCommand = new Command (() => {
				database.InsertOrUpdateNote(new Note(NoteTitle,DateTime.Now.ToString(),NoteActionFlag.ToString(),NoteDetail));
				navigationService.GoBack();
			});
		}


	}
}

