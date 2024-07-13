using System.Globalization;
using System.Windows.Data;

namespace PlantX.Converters {
	public class StringToIntConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value == null)
				return string.Empty;

			if (value is int intValue)
				return intValue.ToString();

			return string.Empty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			if (string.IsNullOrEmpty(value as string))
				return 0;

			if (int.TryParse(value as string, out int result))
				return result;

			return 0; // Wartość domyślna, jeśli konwersja się nie powiodła
		}
	}
}
