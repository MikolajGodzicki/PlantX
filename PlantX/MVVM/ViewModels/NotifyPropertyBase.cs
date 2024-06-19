using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PlantX.MVVM.ViewModels {
	public class NotifyPropertyBase : INotifyPropertyChanged {
		public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
