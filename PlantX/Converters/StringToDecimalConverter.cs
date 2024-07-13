using System.Globalization;
using System.Windows.Data;

namespace PlantX.Converters {
	public class StringToDecimalConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value == null)
				return string.Empty;

			if (value is decimal decValue)
				return decValue.ToString();

			return string.Empty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			if (string.IsNullOrEmpty(value as string))
				return 0;

			string valAsString = value as string;
			valAsString = valAsString.Replace('.', ',');
			if (decimal.TryParse(valAsString, out decimal result))
				return result;

			return 0; // Wartość domyślna, jeśli konwersja się nie powiodła
		}
	}
}
