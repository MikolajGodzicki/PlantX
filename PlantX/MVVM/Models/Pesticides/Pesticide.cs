using PlantX.MVVM.ViewModels;

namespace PlantX.MVVM.Models.Pesticides {
	public class Pesticide : NotifyPropertyBase {

		public Guid Id { get; set; }

		private string name;
		public string Name {
			get => name;
			set {
				name = value;
				OnPropertyChanged();
			}
		}

		private decimal weight;
		public decimal Weight {
			get => weight;
			set {
				weight = value;
				OnPropertyChanged();
			}
		}

		private WeightType weightType;
		public WeightType WeightType {
			get => weightType;
			set {
				weightType = value;
				OnPropertyChanged();
			}
		}

		public Pesticide(string name, decimal weight, WeightType weightType) {
			Id = Guid.NewGuid();
			Name = name;
			Weight = weight;
			WeightType = WeightType;
		}
	}
}
