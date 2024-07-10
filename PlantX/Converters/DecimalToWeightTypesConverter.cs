using PlantX.MVVM.Models.Pesticides;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PlantX.Converters {
	public class DecimalToWeightTypesConverter : IValueConverter{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value == null)
				return string.Empty;


			if (value is PesticideAreaRelation item) {
				Pesticide pesticide = item.Pesticide;
				decimal weight = item.CalculatedWeight;
				switch (pesticide.WeightType) {
					case WeightType.Liter:
						if (weight >= 1) {
							return $"{weight} L";
						} else {
							return $"{weight * 1000} ml";
						}

					case WeightType.Kilogram:
						if (weight >= 1) {
							return $"{weight} kg";
						} else {
							return $"{weight * 1000} g";
						}

					default:
						return weight.ToString();
				}
			}

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}
	}
}
