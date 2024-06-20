using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.ViewModels.Pesticides
{
    class PesticidesCreatorViewModel : NotifyPropertyBase {
		private string weightType;

		public string WeightType {
			get { return weightType; }
			set {
				if (weightType != value) {
					weightType = value;
					OnPropertyChanged();
				}
			}
		}


		private string selectedPesticideType;

		public string SelectedPesticideType {
			get { return selectedPesticideType; }
			set {
				if (selectedPesticideType != value) {
					selectedPesticideType = value;
					SetWeightType(SelectedPesticideType);
					OnPropertyChanged();
				}
			}
		}

		public PesticidesCreatorViewModel() {
			SelectedPesticideType = "LitersPerHectar";
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
	}
}
