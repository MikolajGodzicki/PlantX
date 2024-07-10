using PlantX.Data;
using PlantX.Locale;
using PlantX.MVVM.Models.Fields;
using PlantX.MVVM.Models.Pesticides;
using PlantX.Notifications;
using PlantX.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.ViewModels.Pesticides {
	class PesticidesEditorViewModel : NotifyPropertyBase {
		private ObservableCollection<Pesticide> availablePesticides;
		public ObservableCollection<Pesticide> AvailablePesticides {
			get => availablePesticides;
			set {
				availablePesticides = value;
				OnPropertyChanged();
			}
		}

		private Pesticide selectedPesticide;
		public Pesticide SelectedPesticide {
			get => selectedPesticide;
			set {
				selectedPesticide = value;
				UpdateEditForm();
				OnPropertyChanged();
			}
		}

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


		public RelayCommand ChangePesticideCommand { get; set; }

		public PesticidesEditorViewModel() {
			AvailablePesticides = PlantX_API.AvailablePesticides;

			SelectedPesticideType = WeightType.Liter;

			ChangePesticideCommand = new RelayCommand(e => {
				ChangePesticide();
			});

		}

		private void ChangePesticide() {
			Pesticide? pesticideToEdit = PlantX_API.GetPesticideById(SelectedPesticide.Id);

			if (pesticideToEdit is null) {
				NotificationsManager.ShowError(Locale_PL.Pesticide_NotExists);
				return;
			}

			if (string.IsNullOrEmpty(CurrentPesticideName)) {
				NotificationsManager.ShowError(Locale_PL.Pesticide_NameRequired);
				return;
			}

			if (CurrentPesticideWeight <= 0) {
				NotificationsManager.ShowError(Locale_PL.Pesticide_WeightGreaterThanZero);
				return;
			}

			if (PlantX_API.AvailablePesticides.Any(e => e.Name == CurrentPesticideName && e.Id != pesticideToEdit.Id)) {
				NotificationsManager.ShowError(Locale_PL.Pesticide_Exists);
				return;
			}

			pesticideToEdit.Name = CurrentPesticideName;
			pesticideToEdit.Weight = CurrentPesticideWeight;
			pesticideToEdit.WeightType = SelectedPesticideType;

			RefreshDataGrid();

			NotificationsManager.ShowSuccess(Locale_PL.Pesticide_Edited);
		}

		private void RefreshDataGrid() {
			AvailablePesticides = new ObservableCollection<Pesticide>(PlantX_API.AvailablePesticides);
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


		private void UpdateEditForm() {
			CurrentPesticideName = SelectedPesticide.Name;
			SelectedPesticideType = SelectedPesticide.WeightType;
			CurrentPesticideWeight = SelectedPesticide.Weight;
		}
	}
}
