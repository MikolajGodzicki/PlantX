using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PlantX.Converters
{
	public class StringConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
			if (value == null || parameter == null)
				return false;

			return value.ToString().Equals(parameter.ToString());
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
			if (value is bool && (bool)value) {
				return parameter.ToString();
			}
			return Binding.DoNothing;
		}
	}
}
