using System.Windows.Input;

namespace PlantX.Utils {
	public class RelayCommand : ICommand {
		private readonly Action<object> execute;
		private readonly Func<bool> canExecute;

		public RelayCommand(Action<object> execute, Func<bool> canExecute = null) {
			this.execute = execute;
			this.canExecute = canExecute;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter) => canExecute == null || canExecute();

		public void Execute(object parameter) => execute(parameter);
	}
}
