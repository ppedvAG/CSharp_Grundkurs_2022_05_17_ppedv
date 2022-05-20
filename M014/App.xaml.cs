using System;
using System.IO;
using System.Windows;

namespace M014;

public partial class App : Application
{
	private void Application_Startup(object sender, StartupEventArgs e) //Hier Startup Event im App.xaml gesetzt
	{
		AppDomain.CurrentDomain.UnhandledException += UnhandledException;
	}

	private void UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		Exception ex = e.ExceptionObject as Exception;
		File.WriteAllText(@"C:\Users\lk3\Desktop\Exception.txt", ex.Message + "\n" + ex.StackTrace);
	}
}
