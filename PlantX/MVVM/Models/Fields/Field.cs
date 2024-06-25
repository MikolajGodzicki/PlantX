using PlantX.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.Models.Fields {
	public class Field : NotifyPropertyBase {
		public Guid Id { get; set; }

		private string name;
		public string Name {
			get => name;
			set {
				name = value;
				OnPropertyChanged();
			}
		}

		private int area;
		public int Area {
			get => area;
			set {
				area = value;
				OnPropertyChanged();
			}
		}

		public Field(string name, int area) {
			Id = Guid.NewGuid();
			Name = name;
			Area = area;
		}
	}
}
