using PlantX.Data;
using PlantX.Locale;
using PlantX.MVVM.Models.Fields;
using PlantX.MVVM.Models.Pesticides;
using PlantX.MVVM.Models.Plants;
using PlantX.MVVM.Models.Raports;
using PlantX.Notifications;
using PlantX.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

		private string title;

		public string Title {
			get => title; 
			set {
				title = value;
				OnPropertyChanged();
			}
		}

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

		private Plant selectedPlant;

		public Plant SelectedPlant {
			get => selectedPlant;
			set {
				selectedPlant = value;
				OnPropertyChanged();
			}
		}

		private PesticideAreaRelation selectedPesticide;
		public PesticideAreaRelation SelectedPesticide {
			get => selectedPesticide;
			set {
				selectedPesticide = value;
				OnPropertyChanged();
			}
		}

		private DateTime selectedDate;

		public DateTime SelectedDate {
			get => selectedDate;
			set {
				selectedDate = value;
				OnPropertyChanged();
			}
		}

		public RelayCommand RemovePesticideCommand { get; set; }
		public RelayCommand CreateRaportCommand { get; set; }

		public RaportCreatorViewModel() {
			Pesticides = new ObservableCollection<PesticideAreaRelation>();

			SelectedDate = DateTime.Now;

			RemovePesticideCommand = new RelayCommand(e => {
				RemovePesticide(SelectedPesticide);
			});

			CreateRaportCommand = new RelayCommand(e => {
				CreateRaport();
			});
		}

		private void AddPesticide(Pesticide selectedPesticide) {
			if (Pesticides.Any(e => e.Pesticide.Id == selectedPesticide.Id)) {
				NotificationsManager.ShowError(Locale_PL.Raport_PesticideExists);
				return;
			}

			var convertedPesticide = new PesticideAreaRelation {
				Pesticide = selectedPesticide,
				Field = SelectedField
			};

			Pesticides.Add(convertedPesticide);
			NotificationsManager.ShowSuccess(Locale_PL.Raport_PesticideAdded);
		}

		private void RemovePesticide(PesticideAreaRelation pesticide) {
			if (!Pesticides.Contains(pesticide)) {
				NotificationsManager.ShowError(Locale_PL.Raport_PesticideNotExists);
				return;
			}

			Pesticides.Remove(pesticide);
			NotificationsManager.ShowSuccess(Locale_PL.Raport_PesticideRemoved);
		}

		private void RefreshDataGrid() {
			var updatedPesticides = Pesticides.Select(e => {
				e.Field = SelectedField;
				return e;
			});
			Pesticides = new ObservableCollection<PesticideAreaRelation>(updatedPesticides);
		}

		private void CreateRaport() {
			if (string.IsNullOrEmpty(Title)) {
				NotificationsManager.ShowError(Locale_PL.Raport_WrongTitle);
				return;
			}

			if (SelectedField is null) {
				NotificationsManager.ShowError(Locale_PL.Raport_FieldNotSelected);
				return;
			}

			if (SelectedPlant is null) {
				NotificationsManager.ShowError(Locale_PL.Raport_PlantNotSelected);
				return;
			}

			if (Pesticides.Count() <= 0) {
				NotificationsManager.ShowError(Locale_PL.Raport_PesticideBelowOne);
				return;
			}

			Raport raport = new Raport() {
				Title = Title,
				CreationDate = DateOnly.FromDateTime(SelectedDate),
				Field = SelectedField,
				Pesticides = Pesticides,
				Plant = SelectedPlant
			};

			Pesticides = new ObservableCollection<PesticideAreaRelation>();
			SelectedField = null;
			SelectedPlant = null;

			PlantX_API.Raports.Add(raport);
			NotificationsManager.ShowSuccess(Locale_PL.Raport_Created);
		}
	}
}
