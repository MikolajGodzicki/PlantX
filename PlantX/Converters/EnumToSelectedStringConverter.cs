using PlantX.MVVM.Models.Pesticides;
using System.Globalization;
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
