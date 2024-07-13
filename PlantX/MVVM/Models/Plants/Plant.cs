using PlantX.MVVM.ViewModels;

namespace PlantX.MVVM.Models.Plants {
	public class Plant : NotifyPropertyBase {
		public Guid Id { get; set; }


		private string name;
		public string Name {
			get => name;
			set {
				name = value;
				OnPropertyChanged();
			}
		}

		public Plant(string name) {
			Id = Guid.NewGuid();
			Name = name;
		}
	}
}
