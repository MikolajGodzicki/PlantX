using PlantX.Data;
using PlantX.MVVM.Models.Plants;
using PlantX.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public PlantsCreatorViewModel()
        {
			AddPlantCommand = new RelayCommand(e => {
				AddPlant();
			});
        }

        private void AddPlant() {
			if (String.IsNullOrEmpty(CurrentPlantName)) {
				return;
			}

			Plant plant = new Plant(CurrentPlantName);
			PlantX_API.AvailablePlants.Add(plant);
        }
    }
}
