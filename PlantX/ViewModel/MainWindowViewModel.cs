using PlantX.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantX.ViewModel {
    internal class MainWindowViewModel {
        public MainWindowViewModel()
        {
            NavigationServiceProvider.Navigate(new PesticideListViewModel());
        }
    }
}
