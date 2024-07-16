using PlantX.Data;
using PlantX.Locale;
using PlantX.MVVM.Models.Plants;
using PlantX.Notifications;
using PlantX.Utils;
using System.Collections.ObjectModel;

namespace PlantX.MVVM.ViewModels.Plants {
	class PlantsEditorViewModel : NotifyPropertyBase {
		private ObservableCollection<Plant> availablePlants;
		public ObservableCollection<Plant> AvailablePlants {
			get => availablePlants;
			set {
				availablePlants = value;
				OnPropertyChanged();
			}
		}

		private Plant selectedPlant;
		public Plant SelectedPlant {
			get => selectedPlant;
			set {
				selectedPlant = value;
				UpdateEditForm();
				OnPropertyChanged();
			}
		}

		private string currentPlantName;

		public string CurrentPlantName {
			get => currentPlantName;
			set {
				currentPlantName = value;
				OnPropertyChanged();
			}
		}

		public RelayCommand ChangePlantCommand { get; set; }

		public PlantsEditorViewModel() {
			AvailablePlants = PlantX_API.AvailablePlants;

			ChangePlantCommand = new RelayCommand(e => {
				ChangePlant();
			});

		}

		private void UpdateEditForm() {
			CurrentPlantName = SelectedPlant.Name;
		}

		private void ChangePlant() {
			if (SelectedPlant is null) {
				NotificationsManager.ShowError(Locale_PL.Plant_WrongIndex);
				return;
			}

			Plant? plantToEdit = PlantX_API.GetPlantById(SelectedPlant.Id);

			if (plantToEdit is null) {
				NotificationsManager.ShowError(Locale_PL.Plant_NotExists);
				return;
			}

			if (string.IsNullOrEmpty(CurrentPlantName)) {
				NotificationsManager.ShowError(Locale_PL.Plant_NameRequired);
				return;
			}

			if (PlantX_API.AvailablePlants.Any(e => e.Name == CurrentPlantName && e.Id != plantToEdit.Id)) {
				NotificationsManager.ShowError(Locale_PL.Plant_Exists);
				return;
			}

			plantToEdit.Name = CurrentPlantName;
			NotificationsManager.ShowSuccess(Locale_PL.Plant_Edited);
		}
	}
}
