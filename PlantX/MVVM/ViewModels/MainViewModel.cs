using PlantX.Data;
using PlantX.MVVM.ViewModels.Fields;
using PlantX.MVVM.ViewModels.Pesticides;
using PlantX.MVVM.ViewModels.Plants;
using PlantX.MVVM.ViewModels.Raports;
using PlantX.Utils;

namespace PlantX.MVVM.ViewModels {
	internal class MainViewModel : NotifyPropertyBase {
		private PlantsViewModel plantsVM { get; set; }
		private FieldsViewModel fieldsVM { get; set; }
		private PesticidesViewModel pesticidesVM { get; set; }
		private RaportCreatorViewModel raportCreatorVM { get; set; }
		private ShowRaportsViewModel showRaportsVM { get; set; }

		public RelayCommand PlantsCommand { get; set; }
		public RelayCommand FieldsCommand { get; set; }
		public RelayCommand PesticidesCommand { get; set; }

		public RelayCommand RaportCreatorCommand { get; set; }
		public RelayCommand ShowRaportsCommand { get; set; }

		private object currentView;

		public object CurrentView {
			get => currentView;
			set {
				currentView = value;
				OnPropertyChanged();
			}
		}

		public MainViewModel() {
			PlantX_API.Initialize();

			InitializeViewModels();

			InitializeCommands();
		}

		private void InitializeViewModels() {
			plantsVM = new PlantsViewModel();
			fieldsVM = new FieldsViewModel();
			pesticidesVM = new PesticidesViewModel();
			raportCreatorVM = new RaportCreatorViewModel();
			showRaportsVM = new ShowRaportsViewModel();

			SetCurrentViewModel(plantsVM);
		}

		private void InitializeCommands() {
			PlantsCommand = new RelayCommand(e => {
				SetCurrentViewModel(plantsVM);
			});

			FieldsCommand = new RelayCommand(e => {
				SetCurrentViewModel(fieldsVM);
			});

			PesticidesCommand = new RelayCommand(e => {
				SetCurrentViewModel(pesticidesVM);
			});



			RaportCreatorCommand = new RelayCommand(e => {
				SetCurrentViewModel(raportCreatorVM);
			});

			ShowRaportsCommand = new RelayCommand(e => {
				SetCurrentViewModel(showRaportsVM);
			});
		}


		private void SetCurrentViewModel(object viewModel) {
			CurrentView = viewModel;
		}

	}
}
