using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PlantX.Controls {
	public class MenuButtonControl : RadioButton {
		static MenuButtonControl() {
			DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuButtonControl), new FrameworkPropertyMetadata(typeof(MenuButtonControl)));
		}

		public static readonly DependencyProperty IconSourceProperty =
			DependencyProperty.Register("IconSource", typeof(ImageSource), typeof(MenuButtonControl), new PropertyMetadata(default(ImageSource)));

		public ImageSource IconSource {
			get { return (ImageSource)GetValue(IconSourceProperty); }
			set { SetValue(IconSourceProperty, value); }
		}
	}
}
