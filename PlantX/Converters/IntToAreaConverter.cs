using PlantX.MVVM.Models.Pesticides;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PlantX.Converters {
	public class IntToAreaConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value == null)
				return string.Empty;

			if (value is int area) {
				if (area >= 100) {
					return $"{(decimal)area / 100} Ha";
				} else {
					return $"{area} A";
				}
			}

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}
	}
}
