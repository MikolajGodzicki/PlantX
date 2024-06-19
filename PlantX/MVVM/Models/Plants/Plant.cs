using PlantX.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.Models.Plants {
	class Plant : NotifyPropertyBase {
		public Guid Id { get; set; }


		private string name;
		public string Name {
			get => name; 
			set {
				name = value;
				OnPropertyChanged();
			}
		}

		public Plant(string name) {
			Id = Guid.NewGuid();
			Name = name;
		}
	}
}
