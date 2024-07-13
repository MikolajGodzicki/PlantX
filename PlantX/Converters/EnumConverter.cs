using System.Globalization;
using System.Windows.Data;

namespace PlantX.Converters {
	public class EnumConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (parameter == null)
				return false;

			if (value == null)
				return false;

			string enumString = parameter.ToString();
			if (!Enum.IsDefined(value.GetType(), value))
				return false;

			object enumValue = Enum.Parse(value.GetType(), enumString);

			return enumValue.Equals(value);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			if (parameter == null)
				return Binding.DoNothing;

			if (!(value is bool))
				return Binding.DoNothing;

			if ((bool)value) {
				string enumString = parameter.ToString();
				return Enum.Parse(targetType, enumString);
			}

			return Binding.DoNothing;
		}
	}
}
