namespace PlantX.MVVM.Models.Pesticides {
	[Serializable]
	public class Pesticide {
		/// <summary>
		/// Defines name of pesticide used in farming
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Defines the power of pesticide, ex. 10 Liters per 100 Ares
		/// </summary>
		public PesticidePower Power { get; set; }

		public Pesticide(string name) {
			Name = name;
		}
	}
}
