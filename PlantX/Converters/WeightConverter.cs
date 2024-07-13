using PlantX.MVVM.Models.Pesticides;

namespace PlantX.Converters {
	public class WeightConverter {
		public static string GetConvertedWeight(Pesticide pesticide, decimal weight) {
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
					} else if (weight >= 0.01M) {
						return $"{weight * 100} dag";
					} else {
						return $"{weight * 1000} g";
					}

				default:
					return weight.ToString();
			}
		}
	}
}
