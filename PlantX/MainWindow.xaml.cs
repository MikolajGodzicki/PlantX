using PlantX.Data;
using PlantX.MVVM.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace PlantX {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		protected override void OnClosing(CancelEventArgs e) {
			base.OnClosing(e);

			if (DataContext is MainViewModel viewModel) {
				MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz wyjść?", "Potwierdź wyjście", MessageBoxButton.YesNo, MessageBoxImage.Question);

				if (result == MessageBoxResult.No) {
					e.Cancel = true;
					return;
				}

				PlantX_API.Save();
			}
		}
	}
}