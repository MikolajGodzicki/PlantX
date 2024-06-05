using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PlantX.Utils {
    internal static class NavigationServiceProvider {
        private static Frame _navFrame;
            
        public static void Init(Frame navFrame) {
            _navFrame = navFrame;
        }

        public static void Navigate(object viewModel) {
            var page = ViewLocator.CreateViewForViewModel(viewModel);
            _navFrame.Navigate(page);
        }
    }
}
