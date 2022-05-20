namespace M013;

public class Component
{
	static void Main(string[] args)
	{
		ComponentWithEvent cwe = new ComponentWithEvent();
		cwe.ValueChanged += counter => Console.WriteLine(counter); //Action mit einem Parameter: counter
		cwe.ProcessCompleted += () => Console.WriteLine("Fertig"); //Action ohne Parameter mit ()
		cwe.StartProcess();
	}
}

public class ComponentWithEvent
{
	//Verhalten des Prozesses anpassen mit Events
	public event Action ProcessCompleted;
	public event Action<int> ValueChanged;

	public void StartProcess()
	{
		for(int i = 0; i < 100; i++)
		{
			//Daten holen, verarbeiten, ...
			ValueChanged(i);
		}
		ProcessCompleted?.Invoke();
	}
}