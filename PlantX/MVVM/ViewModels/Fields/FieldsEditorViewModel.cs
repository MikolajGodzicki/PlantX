using PlantX.Data;
using PlantX.Locale;
using PlantX.MVVM.Models.Fields;
using PlantX.MVVM.Models.Plants;
using PlantX.Notifications;
using PlantX.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.ViewModels.Fields {
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

		private int currentFieldArea;

		public int CurrentFieldArea {
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
			CurrentFieldArea = SelectedField.Area;
		}

		private void ChangeField() {
			Field? fieldToEdit = PlantX_API.GetFieldById(SelectedField.Id);

			if (fieldToEdit is null) {
				NotificationsManager.ShowError(Locale_PL.Field_NotExists);
				return;
			}

			if (string.IsNullOrEmpty(CurrentFieldName)) {
				NotificationsManager.ShowError(Locale_PL.Field_NameRequired);
				return;
			}

			if (CurrentFieldArea <= 0) {
				NotificationsManager.ShowError(Locale_PL.Field_AreaGreaterThanZero);
				return;
			}

			if (PlantX_API.AvailableFields.Any(e => e.Name == CurrentFieldName && e.Id != fieldToEdit.Id)) {
				NotificationsManager.ShowError(Locale_PL.Field_Exists);
				return;
			}

			fieldToEdit.Name = CurrentFieldName;
			fieldToEdit.Area = CurrentFieldArea;

			NotificationsManager.ShowSuccess(Locale_PL.Field_Edited);
		}
	}
}
