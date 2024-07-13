using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace PlantX.Controls {
	class FormFloatNumberInputControl : FormInputControl {
		public FormFloatNumberInputControl() : base() {
			this.PreviewTextInput += OnPreviewTextInput;
			this.PreviewKeyDown += OnPreviewKeyDown;
		}

		private void OnPreviewTextInput(object sender, TextCompositionEventArgs e) {
			e.Handled = !IsTextAllowed(e.Text);
		}

		private void OnPreviewKeyDown(object sender, KeyEventArgs e) {
			if (e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab || e.Key == Key.Left || e.Key == Key.Right) {
				e.Handled = false;
			}
		}

		private static bool IsTextAllowed(string text) {
			// Regex allowing only digits, one decimal point, and one negative sign at the start
			Regex regex = new Regex(@"^[-]?[0-9]*(\.|,)?[0-9]*$");
			return regex.IsMatch(text);
		}

		protected override void OnTextChanged(TextChangedEventArgs e) {
			base.OnTextChanged(e);

			// Additional validation to ensure only one decimal separator is present
			string text = this.Text;
			int dotCount = text.Count(c => c == '.' || c == ',');
			int minusCount = text.Count(c => c == '-');

			if (dotCount > 1 || minusCount > 1 || (minusCount == 1 && !text.StartsWith("-"))) {
				this.Text = text.Remove(text.Length - 1);
				this.CaretIndex = this.Text.Length;
			}
		}
	}
}
