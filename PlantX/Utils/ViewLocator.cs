using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PlantX.Utils {
    internal static class ViewLocator {
        public static Page CreateViewForViewModel(object viewModel) {
            var viewModelName = viewModel.GetType().FullName;
            var viewName = viewModelName.Replace("ViewModel", "View");
            var viewType = Type.GetType(viewName);
            var page = (Page)Activator.CreateInstance(viewType);
            page.DataContext = viewModel;
            return page;
        }
    }
}
