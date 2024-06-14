using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.MVVM.ViewModels {
	internal class MainViewModel : ViewModelBase {
		private PlantsCreatorViewModel _plantsCreatorVM { get; set; }

		private object _currentView;

		public object CurrentView {
			get { return _currentView; }
			set { _currentView = value;
				OnPropertyChanged();
			}
		}


		public MainViewModel()
        {
			_plantsCreatorVM = new PlantsCreatorViewModel();
			CurrentView = _plantsCreatorVM;
		}
    }
}
