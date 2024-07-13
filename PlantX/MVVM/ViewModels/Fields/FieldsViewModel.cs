using PlantX.Utils;

namespace PlantX.MVVM.ViewModels.Fields {
	class FieldsViewModel : NotifyPropertyBase {
		private FieldsCreatorViewModel creatorVM { get; set; }
		private FieldsEditorViewModel editorVM { get; set; }

		private string selectedOption;

		public string SelectedOption {
			get { return selectedOption; }
			set {
				if (selectedOption != value) {
					selectedOption = value;
					OnPropertyChanged();
				}
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

		public FieldsViewModel() {
			InitializeViewModels();

			InitializeCommands();
		}

		private void InitializeViewModels() {
			creatorVM = new FieldsCreatorViewModel();
			editorVM = new FieldsEditorViewModel();

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
