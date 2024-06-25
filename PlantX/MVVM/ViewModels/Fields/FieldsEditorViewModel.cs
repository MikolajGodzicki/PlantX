using PlantX.Data;
using PlantX.MVVM.Models.Fields;
using PlantX.MVVM.Models.Plants;
using PlantX.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.ViewModels.Fields
{
    class FieldsEditorViewModel : NotifyPropertyBase {
		private ObservableCollection<Field> availableFields;
		public ObservableCollection<Field> AvailableFields {
			get => availableFields;
			set {
				availableFields = value;
				OnPropertyChanged();
			}
		}

		private Field selectedField;
		public Field SelectedField {
			get => selectedField;
			set {
				selectedField = value;
				UpdateEditForm();
				OnPropertyChanged();
			}
		}

		private string currentFieldName;

		public string CurrentFieldName {
			get => currentFieldName;
			set {
				currentFieldName = value;
				OnPropertyChanged();
			}
		}

		private string currentFieldArea;

		public string CurrentFieldArea {
			get => currentFieldArea;
			set {
				currentFieldArea = value;
				OnPropertyChanged();
			}
		}

		public RelayCommand ChangeFieldCommand { get; set; }

		public FieldsEditorViewModel() {
			AvailableFields = PlantX_API.AvailableFields;

			ChangeFieldCommand = new RelayCommand(e => {
				ChangeField();
			});

		}

		private void UpdateEditForm() {
			CurrentFieldName = SelectedField.Name;
			CurrentFieldArea = SelectedField.Area.ToString();
		}

		private void ChangeField() {
			Field? fieldToEdit = GetFieldById();

			if (fieldToEdit is not null) {
				fieldToEdit.Name = CurrentFieldName;
				fieldToEdit.Area = Convert.ToInt32(CurrentFieldArea);
			}
		}

		private Field? GetFieldById() {
			if (SelectedField is not null) {
				return AvailableFields.First(e => e.Id == SelectedField.Id);
			}

			return null;
		}
	}
}
