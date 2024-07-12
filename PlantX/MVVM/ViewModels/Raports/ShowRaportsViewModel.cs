using PlantX.Data;
using PlantX.Locale;
using PlantX.MVVM.Models.Pesticides;
using PlantX.MVVM.Models.Raports;
using PlantX.Notifications;
using PlantX.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.ViewModels.Raports {
	class ShowRaportsViewModel : NotifyPropertyBase {
		private ObservableCollection<Raport> availableRaports;
		public ObservableCollection<Raport> AvailableRaports {
			get => availableRaports;
			set {
				availableRaports = value;
				OnPropertyChanged();
			}
		}

		private Raport selectedRaport;

		public Raport SelectedRaport {
			get => selectedRaport;
			set {
				selectedRaport = value;
				UpdateRaportPesticides(selectedRaport.Pesticides);
				OnPropertyChanged();
			}
		}

		private ObservableCollection<PesticideAreaRelation> pesticides;
		public ObservableCollection<PesticideAreaRelation> Pesticides {
			get => pesticides;
			set {
				pesticides = value;
				OnPropertyChanged();
			}
		}

		public RelayCommand RemoveRaportCommand { get; set; }

		public ShowRaportsViewModel() {
			AvailableRaports = PlantX_API.Raports;

			RemoveRaportCommand = new RelayCommand(e => {
				RemoveRaport();
			});
		}

		private void UpdateRaportPesticides(ObservableCollection<PesticideAreaRelation> pesticides) {
			Pesticides = pesticides;
		}

		private void RemoveRaport() {
			if (!AvailableRaports.Contains(selectedRaport)) {
				NotificationsManager.ShowError(Locale_PL.Raport_NotExists);
				return;
			}

			AvailableRaports.Remove(SelectedRaport);
			NotificationsManager.ShowSuccess(Locale_PL.Raport_Removed);
		}
	}
}
