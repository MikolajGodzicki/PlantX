using PlantX.Data;
using PlantX.MVVM.Models.Fields;
using PlantX.MVVM.Models.Plants;
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

		private string currentFieldArea;

		public string CurrentFieldArea {
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
			if (string.IsNullOrEmpty(CurrentFieldName) || string.IsNullOrEmpty(CurrentFieldArea)) {
				return;
			}

			if (PlantX_API.AvailableFields.Any(e => e.Name == CurrentFieldName)) {
				return;
			}

			Field field = new Field(CurrentFieldName, Convert.ToInt32(CurrentFieldArea));
			PlantX_API.AvailableFields.Add(field);
		}
	}
}
