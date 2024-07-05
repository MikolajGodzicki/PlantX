using PlantX.Data;
using PlantX.MVVM.Models.Fields;
using PlantX.MVVM.Models.Pesticides;
using PlantX.MVVM.Models.Plants;
using PlantX.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.ViewModels.Raports {
	class RaportCreatorViewModel : NotifyPropertyBase {
		public ObservableCollection<Field> Fields { get => PlantX_API.AvailableFields; }
		public ObservableCollection<Plant> Plants { get => PlantX_API.AvailablePlants; }

		private ObservableCollection<PesticideAreaRelation> pesticides;
		public ObservableCollection<PesticideAreaRelation> Pesticides {
			get => pesticides;
			set {
				pesticides = value;
				OnPropertyChanged();
			}
		}

		public ObservableCollection<Pesticide> AvailablePesticides { get => PlantX_API.AvailablePesticides; }

		private Pesticide selectedAddPesticide;

		public Pesticide SelectedAddPesticide {
			get => selectedAddPesticide;
			set {
				selectedAddPesticide = value;
				OnPropertyChanged();
				AddPesticide(selectedAddPesticide);
			}
		}

		private Field selectedField;

		public Field SelectedField {
			get => selectedField;
			set {
				selectedField = value;
				OnPropertyChanged();
				RefreshDataGrid();
			}
		}

		public RaportCreatorViewModel() {
			Pesticides = new ObservableCollection<PesticideAreaRelation>();
		}

		private void AddPesticide(Pesticide selectedPesticide) {
			var convertedPesticide = new PesticideAreaRelation {
				Pesticide = selectedPesticide,
				Field = SelectedField
			};
			Pesticides.Add(convertedPesticide);
		}

		private void RefreshDataGrid() {
			var updatedPesticides = Pesticides.Select(e => 
			{ 
				e.Field = SelectedField; 
				return e; 
			});
			Pesticides = new ObservableCollection<PesticideAreaRelation>(updatedPesticides);
		}
	}
}
