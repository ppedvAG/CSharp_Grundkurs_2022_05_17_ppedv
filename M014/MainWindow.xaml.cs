using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace M014;

public partial class MainWindow : Window
{
	public int Counter;

	public MainWindow()
	{
		InitializeComponent();
		CBox.ItemsSource = new List<string>() { "Eins", "Zwei", "Drei" }; //Collection als Items setzen
		CBox.SelectedIndex = 0; //Standardelement auswählen

		LBox.ItemsSource = new List<string>() { "Eins", "Zwei", "Drei" };
		LBox.SelectedIndex = 1;

		CB1.IsChecked = true;

		//MessageBoxResult mbr = MessageBox.Show("Hallo", "Titel", MessageBoxButton.YesNo, MessageBoxImage.Information); //Programm bleibt stehen während MessageBox am Bildschirm ist
		//if (mbr == MessageBoxResult.Yes)
		//{
		//	//yes
		//}
		//else
		//{
		//	//no
		//}
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Counter++;
		Text.Text = $"Button wurde {Counter} geklickt";

		Window1 w1 = new Window1();
		//w1.Show(); //Fenster öffnen und alleine lassen
		if (w1.ShowDialog() == true)
		{

		}
		else
		{

		}
	}

	private void CBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
	{
		Text.Text = CBox.SelectedItem.ToString();
	}

	private void CB1_Checked(object sender, RoutedEventArgs e)
	{
		//CheckBox cb = (sender as CheckBox); -> sender casten
		//Checked oder Unchecked
	}
}
