using PlantX.MVVM.Models.Fields;
using PlantX.MVVM.Models.Pesticides;
using PlantX.MVVM.Models.Plants;
using PlantX.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.Models.Raports {
	public class Raport : NotifyPropertyBase {

		private string title;

		public string Title {
			get { return title; }
			set {
				title = value;
				OnPropertyChanged();
			}
		}

		private Field field;

		public Field Field {
			get { return field; }
			set {
				field = value;
				OnPropertyChanged();
			}
		}

		private Plant plant;

		public Plant Plant {
			get { return plant; }
			set {
				plant = value;
				OnPropertyChanged();
			}
		}

		private DateOnly creationDate;

		public DateOnly CreationDate {
			get { return creationDate; }
			set {
				creationDate = value;
				OnPropertyChanged();
			}
		}

		private ObservableCollection<Pesticide> pesticides;

		public ObservableCollection<Pesticide> Pesticides {
			get { return pesticides; }
			set {
				pesticides = value;
				OnPropertyChanged();
			}
		}
	}
}
