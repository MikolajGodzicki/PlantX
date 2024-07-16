using PlantX.Data;
using PlantX.Locale;
using PlantX.MVVM.Models.Pesticides;
using PlantX.MVVM.Models.Plants;
using PlantX.MVVM.Models.Raports;
using PlantX.MVVM.Views.Plants;
using PlantX.Notifications;
using PlantX.PDF;
using PlantX.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

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

		public ICollectionView RaportsView { get; set; }


		private Raport selectedRaport;

		public Raport SelectedRaport {
			get => selectedRaport;
			set {
				selectedRaport = value;
				if (selectedRaport is not null) {
					UpdateRaportPesticides(selectedRaport.Pesticides);
				}
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

		public ObservableCollection<Month> Months { get => PlantX_API.Months; }

		private Month selectedMonth;

		public Month SelectedMonth {
			get => selectedMonth;
			set {
				selectedMonth = value;
				OnPropertyChanged();
				CollectionViewSource.GetDefaultView(AvailableRaports).Refresh();
			}
		}

		public RelayCommand RemoveRaportCommand { get; set; }
		public RelayCommand CreatePDFCommand { get; set; }

		private PDFCreator pDFCreator;

		public ShowRaportsViewModel() {
			AvailableRaports = PlantX_API.Raports;
			SelectedMonth = Months.First();

			pDFCreator = new PDFCreator();

			RemoveRaportCommand = new RelayCommand(e => {
				RemoveRaport();
			});

			CreatePDFCommand = new RelayCommand(e => {
				CreatePDF();
			});


			RaportsView = CollectionViewSource.GetDefaultView(AvailableRaports);
			RaportsView.Filter = FilterRaports;
		}

		private bool FilterRaports(object obj) {
			if (obj is Raport raport && SelectedMonth is not null) {
				if (SelectedMonth.Number == 0) {
					return true;
				}
				return raport.CreationDate.Month == SelectedMonth.Number;
			}
			return false;
		}

		private void UpdateRaportPesticides(ObservableCollection<PesticideAreaRelation> pesticides) {
			Pesticides = pesticides;
		}

		private void RemoveRaport() {
			if (!AvailableRaports.Contains(SelectedRaport)) {
				NotificationsManager.ShowError(Locale_PL.Raport_WrongIndex);
				return;
			}

			AvailableRaports.Remove(SelectedRaport);
			Pesticides = null;

			NotificationsManager.ShowSuccess(Locale_PL.Raport_Removed);
		}

		private void CreatePDF() {
			if (SelectedRaport is null) {
				NotificationsManager.ShowError(Locale_PL.Raport_WrongIndex);
				return;
			}

			pDFCreator.CreatePdfFromRaport(SelectedRaport);
			NotificationsManager.ShowSuccess(Locale_PL.Raport_PDFCreated);
		}
	}
}
