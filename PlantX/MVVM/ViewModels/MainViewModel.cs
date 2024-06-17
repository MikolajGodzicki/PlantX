using PlantX.MVVM.ViewModels.Fields;
using PlantX.MVVM.ViewModels.Pesticides;
using PlantX.MVVM.ViewModels.Plants;
using PlantX.MVVM.ViewModels.Raports;
using PlantX.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.ViewModels {
	internal class MainViewModel : ViewModelBase {
		private PlantsCreatorViewModel plantsCreatorVM { get; set; }
		private PlantsEditorViewModel plantsEditorVM { get; set; }
		private FieldsCreatorViewModel fieldsCreatorVM { get; set; }
		private FieldsEditorViewModel fieldsEditorVM { get; set; }
		private PesticidesCreatorViewModel pesticidesCreatorVM { get; set; }
		private PesticidesEditorViewModel pesticidesEditorVM { get; set; }
		private RaportCreatorViewModel raportCreatorVM { get; set; }
		private ShowRaportsViewModel showRaportsVM { get; set; }

		public RelayCommand PlantsCommand { get; set; }
		public RelayCommand FieldsCommand { get; set; }
		public RelayCommand PesticidesCommand { get; set; }

		public RelayCommand RaportCreatorCommand { get; set; }
		public RelayCommand ShowRaportsCommand { get; set; }


		private object currentView;

		public object CurrentView {
			get { return currentView; }
			set { currentView = value;
				OnPropertyChanged();
			}
		}


		public MainViewModel()
        {
			InitializeViewModels();

			InitializeCommands();
		}

		private void InitializeViewModels() {
			plantsCreatorVM = new PlantsCreatorViewModel();
			plantsEditorVM = new PlantsEditorViewModel();
			fieldsCreatorVM = new FieldsCreatorViewModel();
			fieldsEditorVM = new FieldsEditorViewModel();
			pesticidesCreatorVM = new PesticidesCreatorViewModel();
			pesticidesEditorVM = new PesticidesEditorViewModel();
			raportCreatorVM = new RaportCreatorViewModel();
			showRaportsVM = new ShowRaportsViewModel();

			CurrentView = plantsCreatorVM;
		}
		
		private void InitializeCommands() {
			PlantsCommand = new RelayCommand(e => {
				CurrentView = plantsCreatorVM;
			});

			FieldsCommand = new RelayCommand(e => {
				CurrentView = fieldsCreatorVM;
			});

			PesticidesCommand = new RelayCommand(e => {
				CurrentView = pesticidesCreatorVM;
			});


			RaportCreatorCommand = new RelayCommand(e => {
				CurrentView = raportCreatorVM;
			});

			ShowRaportsCommand = new RelayCommand(e => {
				CurrentView = showRaportsVM;
			});
		}
    }
}
