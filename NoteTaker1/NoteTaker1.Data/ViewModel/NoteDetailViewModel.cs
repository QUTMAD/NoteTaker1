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
            set { noteTitle = value; }
        }

        private string noteDetail;

        public string NoteDetail
        {
            get { return noteDetail; }
            set { noteDetail = value; }
        }

        private bool noteActionFlag;

        public bool NoteActionFlag
        {
            get { return noteActionFlag; }
            set { noteActionFlag = value; }
        }


		public NoteDetailViewModel (IMyNavigationService navigationService)
		{
			SaveNoteCommand = new Command (() => {
				var notelistVM = ServiceLocator.Current.GetInstance<NoteListViewModel>();

				notelistVM.NoteList.Add(new Note(NoteTitle, DateTime.Now.ToString(),NoteActionFlag.ToString(),NoteDetail));
				navigationService.GoBack();
			});
		}
	}
}

