using PlantX.Data;
using PlantX.Locale;
using PlantX.MVVM.Models.Plants;
using PlantX.Notifications;
using PlantX.Utils;

namespace PlantX.MVVM.ViewModels.Plants {
	class PlantsCreatorViewModel : NotifyPropertyBase {
		private string currentPlantName;

		public string CurrentPlantName {
			get => currentPlantName;
			set {
				currentPlantName = value;
				OnPropertyChanged();
			}
		}

		public RelayCommand AddPlantCommand { get; set; }

		public PlantsCreatorViewModel() {
			AddPlantCommand = new RelayCommand(e => {
				AddPlant();
			});
		}

		private void AddPlant() {
			if (string.IsNullOrEmpty(CurrentPlantName)) {
				NotificationsManager.ShowError(Locale_PL.Plant_NameRequired);
				return;
			}

			if (PlantX_API.AvailablePlants.Any(e => e.Name == CurrentPlantName)) {
				NotificationsManager.ShowError(Locale_PL.Plant_Exists);
				return;
			}

			Plant plant = new Plant(CurrentPlantName);
			PlantX_API.AvailablePlants.Add(plant);

			CurrentPlantName = string.Empty;

			NotificationsManager.ShowSuccess(Locale_PL.Plant_Created);
		}
	}
}
