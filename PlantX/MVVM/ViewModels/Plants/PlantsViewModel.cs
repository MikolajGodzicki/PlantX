using PlantX.Utils;

namespace PlantX.MVVM.ViewModels.Plants {
	class PlantsViewModel : NotifyPropertyBase {
		private PlantsCreatorViewModel creatorVM { get; set; }
		private PlantsEditorViewModel editorVM { get; set; }

		private string selectedOption;

		public string SelectedOption {
			get { return selectedOption; }
			set {
				selectedOption = value;
				OnPropertyChanged();
			}
		}

		private object currentView;

		public object CurrentView {
			get => currentView;
			set {
				currentView = value;
				OnPropertyChanged();
			}
		}

		public RelayCommand CreatorCommand { get; set; }
		public RelayCommand EditorCommand { get; set; }

		public PlantsViewModel() {
			InitializeViewModels();

			InitializeCommands();
		}

		private void InitializeViewModels() {
			creatorVM = new PlantsCreatorViewModel();
			editorVM = new PlantsEditorViewModel();

			SelectedOption = "Creator";
			SetCurrentViewModel(creatorVM);
		}

		private void InitializeCommands() {
			CreatorCommand = new RelayCommand(e => {
				SetCurrentViewModel(creatorVM);
			});

			EditorCommand = new RelayCommand(e => {
				SetCurrentViewModel(editorVM);
			});
		}

		private void SetCurrentViewModel(object viewModel) {
			CurrentView = viewModel;
		}
	}
}
