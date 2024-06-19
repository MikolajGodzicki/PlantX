using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Diagnostics;

namespace PlantX.Controls
{
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
