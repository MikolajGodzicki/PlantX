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

			if (value is Pesticide pesticide) {
				return WeightConverter.GetConvertedWeight(pesticide, pesticide.Weight) + "/Ha";
			}

			return string.Empty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}
	}
}
