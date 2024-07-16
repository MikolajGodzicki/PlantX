using PlantX.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.Utils {
	public class Month : NotifyPropertyBase {
        private string name;

		public string Name {
            get => name;
            set {
                name = value;
                OnPropertyChanged();
            }
        }

        private int number;

		public int Number {
            get => number;
            set {
                number = value;
                OnPropertyChanged();
            }
        }

        public Month(string _name, int _number)
        {
            Name = _name;
            Number = _number;
        }
    }
}
