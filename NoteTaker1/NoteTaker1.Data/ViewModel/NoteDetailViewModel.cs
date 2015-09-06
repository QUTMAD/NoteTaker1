using System;
using GalaSoft.MvvmLight;

namespace NoteTaker1.Data
{
	public class NoteDetailViewModel :ViewModelBase
	{

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


        public NoteDetailViewModel ()
		{
		}
	}
}

