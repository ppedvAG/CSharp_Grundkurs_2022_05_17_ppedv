namespace M013;

public class Events
{
	static event EventHandler Event; //Event mit generisch EventArgs

	static event EventHandler<TestEventArgs> TestEvent; //Event mit eigenen EventArgs

	static void Main2(string[] args)
	{
		Event += Events_Event; //Ähnlich wie Delegate nur muss hier kein new verwendet werden
		Event(null, EventArgs.Empty); //Aufruf

		TestEvent += Events_TestEvent;
		TestEvent?.Invoke(null, new TestEventArgs() { Status = "Test" }); //Aufruf mit ? und Invoke
	}

	private static void Events_TestEvent(object? sender, TestEventArgs e)
	{
		Console.WriteLine(e.Status);
	}

	private static void Events_Event(object? sender, EventArgs e)
	{
		Console.WriteLine("Event wurde aufgerufen");
	}
}

public class TestEventArgs : EventArgs
{
	public string Status { get; set; }
}
