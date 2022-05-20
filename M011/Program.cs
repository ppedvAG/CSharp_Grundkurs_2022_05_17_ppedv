using System.Collections.ObjectModel;
using System.Collections.Specialized;

public class Program
{
	static void Main(string[] args)
	{
		List<string> staedte = new List<string>(); //Erstellung einer Liste mit generischem Typ
		staedte.Add("Hamburg"); //Elemente hinzufügen
		staedte.Add("Wien");
		staedte.Add("Köln");
		staedte.Add("Berlin");

		Console.WriteLine(staedte[1]); //Wien, Elemente angreifen wie bei Array

		Console.WriteLine(staedte.Count); //Count statt Length wie beim Array

		staedte[1] = "Linz"; //Wie beim Array Elemente ändern mit []

		staedte.Remove("Linz"); //Höhere Elemente werden aufgeschoben

		foreach (string s in staedte) //Liste durchgehen
		{
			Console.WriteLine(s);
		}

		staedte.ForEach(s => Console.WriteLine(s)); //Funktion auf gesamte Liste anwenden

		Stack<string> staedteStack = new(); //Target-Typed-new: Typ beim new von der Variable entnehmen
		staedteStack.Push("Hamburg");
		staedteStack.Push("Wien");
		staedteStack.Push("Köln");
		staedteStack.Push("Berlin");

		Console.WriteLine(staedteStack.Peek()); //Berlin

		Console.WriteLine(staedteStack.Pop()); //Berlin hinunternehmen

		var staedteQueue = new Queue<string>();
		staedteQueue.Enqueue("Hamburg");
		staedteQueue.Enqueue("Wien");
		staedteQueue.Enqueue("Köln");
		staedteQueue.Enqueue("Berlin");

		Console.WriteLine(staedteQueue.Peek()); //Hamburg

		Console.WriteLine(staedteQueue.Dequeue()); //Hamburg hinausnehmen

		Dictionary<string, int> einwohnerzahlen = new(); //Dictionary: Liste von Key-Value Paaren
		einwohnerzahlen.Add("Wien", 2_000_000);
		einwohnerzahlen.Add("Berlin", 3_650_000);
		einwohnerzahlen.Add("Paris", 2_160_000);

		if (einwohnerzahlen.ContainsKey("Wien"))
			Console.WriteLine(einwohnerzahlen["Wien"]); //Value holen mit Key (hier string)

		Console.WriteLine(einwohnerzahlen.ContainsValue(2_000_000)); //Gibt es eine Stadt mit 2m Einwohnern?

		foreach (KeyValuePair<string, int> kv in einwohnerzahlen) //Dictionary iterieren (var -> Strg + .)
		{
			Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner");
		}

		SortedDictionary<string, int> einwohnerzahlenSorted = new(); //Wird bei jedem Add direkt sortiert
		einwohnerzahlenSorted.Add("Wien", 2_000_000);
		einwohnerzahlenSorted.Add("Berlin", 3_650_000);
		einwohnerzahlenSorted.Add("Paris", 2_160_000);

		ObservableCollection<string> str = new();
		str.CollectionChanged += Str_CollectionChanged; //Methode dranhängen
		str.Add("X"); //Nach jedem Add wird das Event aufgerufen
		str.Add("Y");
		str.Add("Z");
	}

	private static void Str_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action) //Schauen was passiert ist
		{
			case NotifyCollectionChangedAction.Add:
				Console.WriteLine($"Ein Element wurde hinzugefügt {e.NewItems[0]}"); //Neue Elemente angreifen
				break;
			case NotifyCollectionChangedAction.Remove:
				break;
			case NotifyCollectionChangedAction.Replace:
				break;
			case NotifyCollectionChangedAction.Move:
				break;
			case NotifyCollectionChangedAction.Reset:
				break;
		}
	}
}