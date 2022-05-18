public class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch("Max", 34);
		m.Name = "Max"; //Name wird nach unten weitergegeben

		//Kind k = new Kind("Max", 13);
		//k.Alter = 14;
	}
}

public class Lebewesen //Basisklasse für alle Lebewesen
{
	public string Name { get; set; }

	public Lebewesen(string name)
	{
		Name = name;
	}

	public Lebewesen(string name, string lieblingsfarbe)
	{

	}

	public Lebewesen() { }

	public virtual void WasBinIch()
	{
		Console.WriteLine($"Ich bin ein {GetType().Name} und mein Name ist {Name}");
	}
}

public sealed class Mensch : Lebewesen //Mensch erbt von Lebewesen/Mensch ist ein Lebewesen
{
	//Name von oben vererbt bekommen

	public int Alter { get; set; }

	public Mensch(string name, int alter) : base(name) //base um Konstruktor nach oben zu Verketten
	{
		Alter = alter;
	}

	public Mensch(string name) { } //Verkettet mit leerem Konstruktor

	public Mensch(string name, bool x) : base("", "") { } //Werte nach oben geben statt Parametern

	public sealed override void WasBinIch() //sealed: Überschreiben verhindern
	{
		//base.WasBinIch(); base greift nach oben
		Console.WriteLine($"Mein Name ist {Name} und ich bin {Alter} alt");
	}
}

//public class Kind : Mensch //Mensch ist sealed da keine Vererbung möglich
//{
//	//Name und Alter werden nach unten gegeben

//	public Kind(string name, int alter) : base(name, alter) { }

//	public override void WasBinIch() //Kann nicht überschrieben werden da sealed
//	{
//		base.WasBinIch();
//	}
//}