using PlantX.Data;
using PlantX.MVVM.Models.Pesticides;
using PlantX.MVVM.Models.Plants;
using PlantX.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.ViewModels.Pesticides {
	class PesticidesCreatorViewModel : NotifyPropertyBase {
		private string weightType;

		public string WeightType {
			get { return weightType; }
			set {
				weightType = value;
				OnPropertyChanged();
			}
		}

		private string selectedPesticideType;

		public string SelectedPesticideType {
			get { return selectedPesticideType; }
			set {
				selectedPesticideType = value;
				SetWeightType(SelectedPesticideType);
				OnPropertyChanged();
			}
		}

		private string currentPesticideName;

		public string CurrentPesticideName {
			get { return currentPesticideName; }
			set {
				currentPesticideName = value;
				OnPropertyChanged();
			}
		}


		public RelayCommand AddPesticideCommand { get; set; }

		public PesticidesCreatorViewModel() {
			SelectedPesticideType = "LitersPerHectar";

			AddPesticideCommand = new RelayCommand(e => {
				AddPesticide();
			});
		}

		private void SetWeightType(string pesticideType) {
			switch (pesticideType) {
				case "LitersPerHectar":
					WeightType = "Litrów";
					break;
				case "KilogramsPerHectar":
					WeightType = "Kilogramów";
					break;
				default:
					WeightType = "Nieznany";
					break;
			}
		}

		private void AddPesticide() {
			if (string.IsNullOrEmpty(CurrentPesticideName)) {
				return;
			}

			if (PlantX_API.AvailablePesticides.Any(e => e.Name == CurrentPesticideName)) {
				return;
			}

			Pesticide pesticide = new Pesticide(CurrentPesticideName);
			PlantX_API.AvailablePesticides.Add(pesticide);
		}
	}
}
