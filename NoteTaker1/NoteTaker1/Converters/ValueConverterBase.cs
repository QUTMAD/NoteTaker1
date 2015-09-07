using System;
using Xamarin.Forms;
using System.Globalization;

namespace NoteTaker1
{
		/// <summary>
		/// A base class with basic value-conversion functionality.
		/// </summary>
		/// <typeparam name="TInput">The expected input type.</typeparam>
		/// <typeparam name="TOutput">The type of the converted output.</typeparam>
		public abstract class ValueConverterBase<TInput, TOutput> : IValueConverter
		{
			#region Protected Methods

			/// <summary>
			/// Called when an incoming value needs conversion.
			/// </summary>
			/// <param name="input">The incoming value of type <see cref="TInput"/>.</param>
			/// <param name="parameter">The converter parameter, if any.</param>
			/// <returns>The value converted to type <see cref="TOutput"/>.</returns>
			protected abstract TOutput ConvertValue(TInput input, object parameter);

			/// <summary>
			/// Called when an output value needs conversion back to the original input type.
			/// </summary>
			/// <param name="output">The previously converted value.</param>
			/// <param name="parameter">The converter parameter, if any.</param>
			/// <returns>The value converted back to type <see cref="TInput"/>.</returns>
			protected virtual TInput ConvertValueBack(TOutput output, object parameter)
			{
				throw new InvalidOperationException(GetType().Name + " cannot be used in two-way binding.");
			}

			#endregion


			#region Public Methods

			/// <summary>
			/// Modifies the source data before passing it to the target for display in the UI.
			/// </summary>
			/// <returns>
			/// The value to be passed to the target dependency property.
			/// </returns>
			/// <param name="value">The source data being passed to the target.</param>
			/// <param name="targetType">The <see cref="T:System.Type"/> of data expected by the target dependency property.</param>
			/// <param name="parameter">An optional parameter to be used in the converter logic.</param>
			/// <param name="culture">The culture of the conversion.</param>
			public object Convert(object value, Type targetType, object parameter, string language)
			{

				var input = (value is TInput) ? (TInput)value : default(TInput);
				var output = ConvertValue(input, parameter);

				return output;
			}

			/// <summary>
			/// Modifies the target data before passing it to the source object.  This method is called only in <see cref="F:System.Windows.Data.BindingMode.TwoWay"/> bindings.
			/// </summary>
			/// <returns>
			/// The value to be passed to the source object.
			/// </returns>
			/// <param name="value">The target data being passed to the source.</param><param name="targetType">The <see cref="T:System.Type"/> of data expected by the source object.</param><param name="parameter">An optional parameter to be used in the converter logic.</param><param name="culture">The culture of the conversion.</param>
			public object ConvertBack(object value, Type targetType, object parameter, string language)
			{

				var output = (value is TOutput) ? (TOutput)value : default(TOutput);
				var input = ConvertValueBack(output, parameter);

				return input;
			}
			public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
			{

				var output = (value is TOutput) ? (TOutput)value : default(TOutput);
				var input = ConvertValueBack(output, parameter);

				return input;
			}

			public object Convert(object value, Type targetType, object parameter, CultureInfo language)
			{

				var input = (value is TInput) ? (TInput)value : default(TInput);
				var output = ConvertValue(input, parameter);

				return output;
			}
			#endregion

		}
}

