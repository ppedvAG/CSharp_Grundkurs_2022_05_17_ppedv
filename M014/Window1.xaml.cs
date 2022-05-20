using System.Windows;

namespace M014;

public partial class Window1 : Window
{
	public Window1()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		DialogResult = true;
		Close();
	}
}
