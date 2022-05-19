public class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch();
		((IArbeit) m).Lohnauszahlung(); //Cast zu einem bestimmten Interface um Methode anzugreifen
		(m as ITeilzeitArbeit).Lohnauszahlung(); //as-cast: funktioniert nur wenn Typ (Mensch) null sein kann

		Console.WriteLine(IArbeit.Wochenstunden); //Statische Variable angreifen

		IArbeit a = m;
		a.Lohnauszahlung();

		ITeilzeitArbeit ta = m;
		ta.Lohnauszahlung();

		int wochenlohn = a.Gehalt / 160 * IArbeit.Wochenstunden;
	}
}

public interface IArbeit //Interfaces fangen mit I an (Konvention)
{
	static int Wochenstunden => 40; //Statische Variable

	int Gehalt { get; set; }

	string Job { get; set; }

	void Lohnauszahlung(); //Methode wie bei Abstrakter Klasse

	public void Methode()
	{
		//Bad Practice
	}
}

public interface ITeilzeitArbeit : IArbeit //Interfaces vererben
{
	static new int Wochenstunden => 20; //Hier mit new Felder von oben überschreiben

	new void Lohnauszahlung();
}

public abstract class Lebewesen { }

public class Mensch : Lebewesen, IArbeit, ITeilzeitArbeit //Alle Member aus beiden Interfaces implementieren
{
	public int Gehalt { get; set; } = 2000;

	public string Job { get; set; } = "Softwareentwickler";

	void IArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mensch hat ein Gehalt von {Gehalt} für den Job {Job} bekommen");
	}

	void ITeilzeitArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mensch hat ein Gehalt von {Gehalt / 2} für den Job {Job} bekommen");
	}
}