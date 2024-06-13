using System.ComponentModel;

namespace PlantX.MVVM.ViewModels {
	internal class ViewModelBase : INotifyPropertyChanged {
		public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged(string propertyName) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
