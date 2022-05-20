using M011_Linq;

public class Program
{
	static void Main2(string[] args)
	{
		#region Einfaches Linq
		//Erstellt eine Liste von Start mit einer bestimmten Anzahl Elementen
		//(5, 20) -> Start bei 5, 20 Elemente -> 5-24
		List<int> ints = Enumerable.Range(0, 20).ToList();

		Console.WriteLine(ints.Average());
		Console.WriteLine(ints.Min());
		Console.WriteLine(ints.Max());

		Console.WriteLine(ints.Sum());

		Console.WriteLine(ints.First()); //Erstes Element der Liste, Exception wenn Liste leer
		Console.WriteLine(ints.FirstOrDefault()); //null wenn Liste leer

		Console.WriteLine(ints.Last()); //Erstes Element der Liste, Exception wenn Liste leer
		Console.WriteLine(ints.LastOrDefault()); //null wenn Liste leer

		Console.WriteLine(ints.Single(e => e == 2)); //Einziges Element mit Bedingung, Exception wenn leer oder mehr als ein Element
		Console.WriteLine(ints.SingleOrDefault(e => e == 2)); //Einziges Element mit Bedingung, null wenn leer und Exception wenn mehr als ein Element
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq Schreibweisen
		//Alle BMWs mit Foreach
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(f);

		//Standard-Linq: SQL-ähnliche Schreibweise (alt)
		List<Fahrzeug> bmws = (from fzg in fahrzeuge 
							   where fzg.Marke == FahrzeugMarke.BMW
							   select fzg).ToList();

		//Methodenkette
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(fzg => fzg.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		#region Einfaches Linq mit Objektliste
		//Höchste Geschwindigkeit
		Console.WriteLine(fahrzeuge.Max(fzg => fzg.MaxGeschwindigkeit));

		//Liste sortieren (originale Liste wird nicht verändert)
		List<Fahrzeug> ordered = fahrzeuge.OrderBy(fzg => fzg.MaxGeschwindigkeit).ToList();

		//Schnellstes & Langsamstes Auto
		fahrzeuge.OrderBy(fzg => fzg.MaxGeschwindigkeit).First(); //Langsamstes
		fahrzeuge.OrderBy(fzg => fzg.MaxGeschwindigkeit).Last(); //Schnellstes
		fahrzeuge.OrderByDescending(fzg => fzg.MaxGeschwindigkeit).First(); //Schnellstes

		//Originale Liste verändern durch Zuweisung
		//fahrzeuge = fahrzeuge.OrderBy(fzg => fzg.MaxGeschwindigkeit).ToList();

		//Alle Automarken
		List<FahrzeugMarke> alleMarken = fahrzeuge.Select(fzg => fzg.Marke).ToList();

		//Marken einzigartig machen
		List<FahrzeugMarke> distinct = alleMarken.Distinct().ToList();

		//Alle Geschwindigkeiten summieren
		int summeV = fahrzeuge.Sum(fzg => fzg.MaxGeschwindigkeit);

		//Alle VWs aufsummieren mit mindestens 200km/h
		int summeVWs = fahrzeuge.Where(fzg => fzg.Marke == FahrzeugMarke.VW && fzg.MaxGeschwindigkeit >= 200).Sum(fzg => fzg.MaxGeschwindigkeit);

		//Alle Fahrzeuge >= 150
		bool alle150 = fahrzeuge.All(fzg => fzg.MaxGeschwindigkeit >= 150);

		//Ein Fahrzeug >= 150
		bool ein150 = fahrzeuge.Any(fzg => fzg.MaxGeschwindigkeit >= 150);

		//Checkt ob ein Element existiert
		bool einElement = fahrzeuge.Any(); //fahrzeuge.Count > 0

		//Liste aufteilen auf 5er Teile + Rest
		List<Fahrzeug[]> x = fahrzeuge.Chunk(5).ToList();

		//fahrzeuge = fahrzeuge.Concat(...) Zwei Collections verbinden
		//fahrzeuge.Append() und fahrzeuge.Prepend() -> Objekte am Ende/Anfang hinzufügen
		#endregion

		#region Komplexes Linq
		//Fahrzeuge nach Automarken gruppieren (VW-Gruppe, BMW-Gruppe, Audi-Gruppe)
		IEnumerable<IGrouping<FahrzeugMarke, Fahrzeug>> groupedFahrzeuge = fahrzeuge.GroupBy(fzg => fzg.Marke);

		//Einzelne Gruppe holen (hier BMWs)
		IGrouping<FahrzeugMarke, Fahrzeug> bmwGroup = groupedFahrzeuge.First(group => group.Key == FahrzeugMarke.BMW);

		//Fahrzeuge aus Liste heraus holen
		List<Fahrzeug> bmwsAusGroup = bmwGroup.ToList();

		//Group zu Dictionary konvertieren (var schreiben -> Strg + . -> Langer Typ generieren)
		Dictionary<FahrzeugMarke, List<Fahrzeug>> groupDictionary = groupedFahrzeuge.ToDictionary(group => group.Key, fzg => fzg.ToList());

		//Liste schnell ausgeben
		Console.WriteLine(fahrzeuge.Aggregate("", (agg, fzg) => agg + $"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxGeschwindigkeit} fahren.\n"));
		#endregion

		#region Erweiterungsmethoden
		int zahl = 38527;
		zahl.Quersumme();

		Console.WriteLine(385618.Quersumme()); //Erweiterungsmethode benutzen

		fahrzeuge = fahrzeuge.Shuffle().ToList(); //Zuweisen wie immer

		groupDictionary.Shuffle(); //Dictionary hat die Methode auch bekommen
		#endregion
	}
}

public class Fahrzeug
{
	public int MaxGeschwindigkeit;

	public FahrzeugMarke Marke;

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxGeschwindigkeit = v;
		Marke = fm;
	}
}

public enum FahrzeugMarke
{
	BMW,
	Audi,
	VW
}