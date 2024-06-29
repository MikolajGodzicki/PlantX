using PlantX.MVVM.Models.Pesticides;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace PlantX.Converters {
	public class EnumToSelectedStringConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value == null)
				return string.Empty;

			if (value is WeightType enumValue) {
				switch (enumValue) {
					case WeightType.Kilogram:
						return "Kg/Ha";
					case WeightType.Liter:
						return "L/Ha";
					default:
						return string.Empty;
				}
			}

			return string.Empty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value == null)
				return WeightType.Liter;

			var stringValue = value as string;

			if (stringValue == "Kg/Ha")
				return WeightType.Kilogram;
			else if (stringValue == "L/Ha")
				return WeightType.Liter;

			return WeightType.Liter;
		}
	}
}
