using PlantX.Data;
using PlantX.Locale;
using PlantX.MVVM.Models.Pesticides;
using PlantX.Notifications;
using PlantX.Utils;

namespace PlantX.MVVM.ViewModels.Pesticides {
	class PesticidesCreatorViewModel : NotifyPropertyBase {
		private string weightTypeText;

		public string WeightTypeText {
			get { return weightTypeText; }
			set {
				weightTypeText = value;
				OnPropertyChanged();
			}
		}

		private WeightType selectedPesticideType;

		public WeightType SelectedPesticideType {
			get { return selectedPesticideType; }
			set {
				selectedPesticideType = value;
				SetWeightType(SelectedPesticideType);
				OnPropertyChanged();
			}
		}

		private decimal currentPesticideWeight;

		public decimal CurrentPesticideWeight {
			get { return currentPesticideWeight; }
			set {
				currentPesticideWeight = value;
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
			SelectedPesticideType = WeightType.Liter;

			AddPesticideCommand = new RelayCommand(e => {
				AddPesticide();
			});
		}

		private void SetWeightType(WeightType pesticideType) {
			switch (pesticideType) {
				case WeightType.Liter:
					WeightTypeText = "Litrów";
					break;
				case WeightType.Kilogram:
					WeightTypeText = "Kilogramów";
					break;
				default:
					WeightTypeText = "Nieznany";
					break;
			}
		}

		private void AddPesticide() {
			if (string.IsNullOrEmpty(CurrentPesticideName)) {
				NotificationsManager.ShowError(Locale_PL.Pesticide_NameRequired);
				return;
			}

			if (CurrentPesticideWeight <= 0) {
				NotificationsManager.ShowError(Locale_PL.Pesticide_WeightGreaterThanZero);
				return;
			}

			if (PlantX_API.AvailablePesticides.Any(e => e.Name == CurrentPesticideName)) {
				NotificationsManager.ShowError(Locale_PL.Pesticide_Exists);
				return;
			}

			Pesticide pesticide = new Pesticide(CurrentPesticideName, CurrentPesticideWeight, SelectedPesticideType);
			PlantX_API.AvailablePesticides.Add(pesticide);

			CurrentPesticideName = string.Empty;
			CurrentPesticideWeight = default;

			NotificationsManager.ShowSuccess(Locale_PL.Pesticide_Created);
		}
	}
}
