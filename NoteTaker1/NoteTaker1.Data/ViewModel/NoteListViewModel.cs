using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System;

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
        private List<Note> noteList = new List<Note>();
		public List<Note> NoteList {
			get { return noteList; }
			set {
				if (value != null && value != noteList) {
					noteList = value;
					RaisePropertyChanged (() => NoteList);
				}
			}
		}
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public NoteListViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
			var firstNoate = new Note ("FirstNote", DateTime.Now.ToString());
			firstNoate.ActionRequiredFlag = "N";
			NoteList.Add (firstNoate);
			NoteList.Add (new Note ("FirstNote"){ TimeStamp = "Nowish", ActionRequiredFlag = "N" });
			NoteList.Add (new Note ("SecondNote"){ TimeStamp = "Yesterday", ActionRequiredFlag = "Y" });
			NoteList.Add (new Note ("ThirdNote"){ TimeStamp = "theDaybefore", ActionRequiredFlag = "N" });
        }
    }
}