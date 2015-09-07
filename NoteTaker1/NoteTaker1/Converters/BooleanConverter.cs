using System;

namespace NoteTaker1.Converters
{
	public class BooleanConverter : ValueConverterBase<object,bool>
	{
		protected override bool ConvertValue(object input, object parameter){
			if (input.ToString().ToLower() == "true")
				return true;
			else
				return false;
		}

		protected override object ConvertValueBack (bool output, object parameter)
		{
			return output.ToString ();
		}
	}
}

