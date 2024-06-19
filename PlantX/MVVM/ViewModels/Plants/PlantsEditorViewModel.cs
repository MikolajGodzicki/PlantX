using PlantX.Data;
using PlantX.MVVM.Models.Plants;
using PlantX.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.ViewModels.Plants
{
    class PlantsEditorViewModel : NotifyPropertyBase
    {
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

		public RelayCommand ChangePlantNameCommand { get; set; }

		public PlantsEditorViewModel() {
			AvailablePlants = PlantX_API.AvailablePlants;

			ChangePlantNameCommand = new RelayCommand(e => {
				ChangePlantName();
			});

		}

		private void UpdateEditForm() {
			CurrentPlantName = SelectedPlant.Name;
		}

		private void ChangePlantName() {
			Plant? plantToEdit = GetPlantById();
			if (plantToEdit is not null) {
				plantToEdit.Name = CurrentPlantName;
			}
		}

		private Plant? GetPlantById() {
			if (SelectedPlant is not null) {
				return AvailablePlants.First(e => e.Id == SelectedPlant.Id);
			}

			return null;
		}
	}
}
