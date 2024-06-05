using PlantX.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlantX.ViewModel {
    internal class AddNewPesticideViewModel {
        public ICommand NavigateCommand { get; }

        public AddNewPesticideViewModel()
        {
            NavigateCommand = new RelayCommand(Navigate);
        }

        private void Navigate() {
            NavigationServiceProvider.Navigate(new PesticideListViewModel());
        }
    }
}
