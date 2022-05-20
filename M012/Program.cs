public class Program
{
	static void Main(string[] args)
	{
		AppDomain.CurrentDomain.UnhandledException += UnhandledException; //Unhandled Exception in ein File loggen
		throw new TestException("Zahl darf nicht 0 sein", "parse"); //mit throw Exception werfen

		try
		{
			string eingabe = Console.ReadLine();
			int parse = int.Parse(eingabe);
			if (parse == 0)
				throw new TestException("Zahl darf nicht 0 sein", "parse"); //mit throw Exception werfen
		}
		catch (FormatException e) //Keine Zahl
		{
			Console.WriteLine("Keine Zahl eingegeben");
			Console.WriteLine(e.StackTrace);
		}
		catch (OverflowException e) //Zu große Zahl
		{
			Console.WriteLine("Zahl zu groß");
			Console.WriteLine(e.Message);
		}
		catch (TestException e) //Eigene Exception abfangen
		{
			Console.WriteLine(e.Name);
			e.Test();
		}
		catch (Exception e) //Alle anderen Fehler abhandeln
		{
			Console.WriteLine($"Anderer Fehler: {e.Message}");
			if (e is ArithmeticException) //Exception Oberklassen abfangen
			{
				Console.WriteLine("Es ist eine ArithmeticException aufgetreten");
			}
			throw; //Programmabsturz verursachen (wenn Fataler Fehler)
		}
		finally //Wird immer ausgeführt, auch wenn keine Exception auftritt
		{
			Console.WriteLine("Finally ausgeführt");
		}
	}

	private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		Exception ex = e.ExceptionObject as Exception;
		File.WriteAllText(@"C:\Users\lk3\Desktop\Exception.txt", ex.Message + "\n" + ex.StackTrace);
	}
}

public class TestException : Exception //Basisklasse aller Exceptions
{
	public string Name { get; set; }

	public TestException(string? message, string name) : base(message)
	{
		Name = name;
		Console.WriteLine("Nachricht");
	}

	public void Test()
	{
		//Datenbankverbindung trennen
	}
}