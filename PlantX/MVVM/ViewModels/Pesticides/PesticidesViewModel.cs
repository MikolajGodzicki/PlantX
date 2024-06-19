using PlantX.MVVM.ViewModels.Plants;
using PlantX.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.ViewModels.Pesticides
{
    class PesticidesViewModel : NotifyPropertyBase {
		private PesticidesCreatorViewModel creatorVM { get; set; }
		private PesticidesEditorViewModel editorVM { get; set; }

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

		public PesticidesViewModel() {
			InitializeViewModels();

			InitializeCommands();
		}

		private void InitializeViewModels() {
			creatorVM = new PesticidesCreatorViewModel();
			editorVM = new PesticidesEditorViewModel();

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
