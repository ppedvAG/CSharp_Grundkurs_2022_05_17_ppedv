using static M009.Vererbung;

public class Program
{
	static void Main(string[] args)
	{
		Lebewesen lw = new Mensch("Max", 32); //Lebewesen Variable, Mensch Objekt
		Console.WriteLine(lw.GetType().Name); //Mensch
		Console.WriteLine(typeof(Mensch).Name);

		Mensch castMensch = (Mensch) lw; //Lebewesen -> Mensch braucht einen Cast

		#region Laufzeittypvergleich
		if (lw.GetType() == typeof(Mensch)) //true
		{
			Console.WriteLine("lw ist Mensch");
		}

		if (lw.GetType() == typeof(Lebewesen)) //false, da Laufzeittypvergleich
		{
			Console.WriteLine("lw ist Lebewesen");
		}
		#endregion

		#region Variablentypvergleich
		if (lw is Mensch)
		{
			//true
		}

		if (lw is Lebewesen)
		{
			//true
		}
		#endregion

		#region Virtual Override
		Mensch m = new Mensch("Max", 34);
		m.WasBinIch(); //Ich in ein Mensch

		Lebewesen l = m;
		l.WasBinIch(); //Ich in ein Mensch
		#endregion

		#region New
		Mensch m2 = new Mensch("Max", 34);
		m2.PrintName(); //Max, 34

		Lebewesen l2 = m2;
		l2.PrintName(); //Max
		#endregion

		//LebewesenAbstract la = new LebewesenAbstract(""); //nicht möglich, da abstract

		List<Lebewesen> list = new List<Lebewesen>(); //Liste von Lebewesen
		list.Add(new Mensch("Max", 34)); //Alle Klassen die von Lebewesen erben können hinzugefügt werden
		list.Add(new Kind("Max", 12));
		list.Add(new Lebewesen("Max"));

		foreach (Lebewesen leb in list)
		{
			leb.WasBinIch(); //Hier Methode aus den Unterklassen aufrufen
		}
	}
}