using PlantX.Data;
using PlantX.Locale;
using PlantX.MVVM.Models.Fields;
using PlantX.MVVM.Models.Plants;
using PlantX.Notifications;
using PlantX.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.ViewModels.Fields
{
    class FieldsCreatorViewModel : NotifyPropertyBase
    {
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

		public RelayCommand AddFieldCommand { get; set; }

		public FieldsCreatorViewModel() {
			AddFieldCommand = new RelayCommand(e => {
				AddField();
			});
		}

		private void AddField() {
			if (string.IsNullOrEmpty(CurrentFieldName)) {
				NotificationsManager.ShowError(Locale_PL.Field_NameRequired);
				return;
			}

			if (CurrentFieldArea <= 0) {
				NotificationsManager.ShowError(Locale_PL.Field_AreaGreaterThanZero);
				return;
			}

			if (PlantX_API.AvailableFields.Any(e => e.Name == CurrentFieldName)) {
				NotificationsManager.ShowError(Locale_PL.Field_Exists);
				return;
			}

			Field field = new Field(CurrentFieldName, Convert.ToInt32(CurrentFieldArea));
			PlantX_API.AvailableFields.Add(field);

			CurrentFieldName = string.Empty;
			CurrentFieldArea = default;

			NotificationsManager.ShowSuccess(Locale_PL.Field_Created);
		}
	}
}
