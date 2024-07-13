using PlantX.MVVM.Models.Pesticides;
using System.Globalization;
using System.Windows.Data;

namespace PlantX.Converters {
	public class DecimalToWeightTypesConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value == null)
				return string.Empty;


			if (value is PesticideAreaRelation item) {
				Pesticide pesticide = item.Pesticide;
				decimal weight = item.CalculatedWeight;

				return WeightConverter.GetConvertedWeight(pesticide, weight);
			}

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}
	}
}
