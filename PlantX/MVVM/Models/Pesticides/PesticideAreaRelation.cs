using PlantX.MVVM.Models.Fields;

namespace PlantX.MVVM.Models.Pesticides {
	public class PesticideAreaRelation {
		public Pesticide Pesticide { get; set; }
		public Field Field { get; set; }

		public decimal CalculatedWeight {
			get {
				if (Field is null)
					return 0;

				return Pesticide.Weight * ((decimal)Field.Area / 100);
			}
		}

		public string PesticideWeightType {
			get {
				string weightType = Pesticide.WeightType switch {
					WeightType.Kilogram => "Kg",
					WeightType.Liter => "L",
					_ => "Nieznany"
				};

				return weightType;
			}
		}
	}
}
