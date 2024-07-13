using System.Windows;
using System.Windows.Controls;

namespace PlantX.Controls {
	class FormInputControl : TextBox {
		static FormInputControl() {
			DefaultStyleKeyProperty.OverrideMetadata(typeof(FormInputControl), new FrameworkPropertyMetadata(typeof(FormInputControl)));
		}

		public static readonly DependencyProperty PlaceholderProperty =
			DependencyProperty.Register("Placeholder", typeof(string), typeof(FormInputControl), new PropertyMetadata(default(string)));

		public string Placeholder {
			get { return (string)GetValue(PlaceholderProperty); }
			set { SetValue(PlaceholderProperty, value); }
		}
	}
}
