using System;

namespace NoteTaker1
{
	public class Notes
	{
		private string titleText;
		public string TimeStamp;
		public string ActionRequiredFlag;

		/// <summary>
		/// Initializes a new instance of the <see cref="NoteTaker1.Notes"/> class.
		/// </summary>
		/// <param name="titleText">Title text.</param>
		/// <param name="timeStamp">Time stamp.</param>
		/// <param name="actionRequiredFlag">Action required flag.</param>
		public Notes (string titleText, string timeStamp = "", string actionRequiredFlag = "")
		{
			titleText = titleText;
			TimeStamp = timeStamp;
			ActionRequiredFlag = actionRequiredFlag;
		}
	}
}

