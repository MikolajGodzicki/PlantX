using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace PlantX.Controls {
	class FormComboboxControl : ComboBox {
		static FormComboboxControl() {
			DefaultStyleKeyProperty.OverrideMetadata(typeof(FormComboboxControl), new FrameworkPropertyMetadata(typeof(FormComboboxControl)));
		}

		public static readonly DependencyProperty PlaceholderProperty =
			DependencyProperty.Register("Placeholder", typeof(string), typeof(FormComboboxControl), new PropertyMetadata(default(string)));

		public string Placeholder {
			get { return (string)GetValue(PlaceholderProperty); }
			set { SetValue(PlaceholderProperty, value); }
		}
	}
}
