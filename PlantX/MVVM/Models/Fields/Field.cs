using PlantX.MVVM.ViewModels;

namespace PlantX.MVVM.Models.Fields {
	public class Field : NotifyPropertyBase {
		public Guid Id { get; set; }

		private string name;
		public string Name {
			get => name;
			set {
				name = value;
				OnPropertyChanged();
			}
		}

		private int area;
		public int Area {
			get => area;
			set {
				area = value;
				OnPropertyChanged();
			}
		}

		public Field(string name, int area) {
			Id = Guid.NewGuid();
			Name = name;
			Area = area;
		}
	}
}
