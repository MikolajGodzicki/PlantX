using System.Text.RegularExpressions;
using System.Windows.Input;

namespace PlantX.Controls {
	class FormNumberInputControl : FormInputControl {
		public FormNumberInputControl() : base() {
			PreviewTextInput += OnPreviewTextInput;
			PreviewKeyDown += OnPreviewKeyDown;
		}

		private void OnPreviewTextInput(object sender, TextCompositionEventArgs e) {
			e.Handled = !IsTextNumeric(e.Text);
		}

		private void OnPreviewKeyDown(object sender, KeyEventArgs e) {
			if (e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab) {
				e.Handled = false;
			}
		}

		private static bool IsTextNumeric(string text) {
			Regex regex = new Regex("[^0-9]+");
			return !regex.IsMatch(text);
		}
	}
}
