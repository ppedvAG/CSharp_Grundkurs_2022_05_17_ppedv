public class Program
{
	static void Main(string[] args)
	{
		int x = Addiere(5, 10); //Methodenaufruf
		double y = Addiere(50.5, 1); //Hier double Methode, da ein Parameter double
		int z = Addiere(1, 2, 3, 4, 5, 6, 7, 8); //3. Overload, params Addiere Methode

		int sub1 = Subtrahiere(4, 2);
		int sub2 = Subtrahiere(4, 2, 1);

		//int ergebnisSub;
		int ergebnisAdd = AddiereUndSubtrahiere(10, 5, out int ergebnisSub); //Ergebnis von Subtraktion wird in Variable geschrieben
		Console.WriteLine(ergebnisAdd);
		Console.WriteLine(ergebnisSub);

		(int, int) ergebnisse = AddiereUndSubtrahiere(10, 5); //Tupel speichern
		Console.WriteLine(ergebnisse.Item1);
		Console.WriteLine(ergebnisse.Item2);

		(int add, int sub) = AddiereUndSubtrahiere(10, 3, false); //Tupel zerteilen
		Console.WriteLine(add);
		Console.WriteLine(sub);

		if (int.TryParse(Console.ReadLine(), out int parsed))
		{
			Console.WriteLine("Parsen hat funktioniert: " + parsed);
		}
		else
		{
			Console.WriteLine("Keine Zahl");
		}

		PrintZahl(4);
	}

	static int Addiere(int zahl1, int zahl2) //Struktur: Rückgabedatentyp (int) Name (Parameter1, Parameter2, ...)
	{
		return zahl1 + zahl2; //return: Wert zurückgeben
	}

	static double Addiere(double zahl1, double zahl2) //Parameterliste muss sich unterscheiden
	{
		return zahl1 + zahl2;
	}

	static int Addiere(params int[] zahlen) //params: beliebig viele Parameter, muss letzter Parameter sein
	{
		return zahlen.Sum();
	}

	static int Subtrahiere(int z1, int z2, int z3 = 0, int z4 = 0) //Optionale Parameter, beliebig viele, müssen nach alles erforderlichen Parametern sein
	{
		return z1 - z2 - z3;
	}

	static int AddiereUndSubtrahiere(int z1, int z2, out int sub)
	{
		sub = z1 - z2;
		return z1 + z2;
	}

	static (int, int) AddiereUndSubtrahiere(int z1, int z2) //Zwei return Werte mit Tupel
	{
		return (z1 + z2, z1 - z2);
	}

	static (int add, int sub) AddiereUndSubtrahiere(int z1, int z2, bool b = false) //Zwei return Werte mit benamten Tupel
	{
		return (z1 + z2, z1 - z2);
	}

	static void PrintZahl(int zahl) //void: kein Rückgabewert
	{
		Console.WriteLine(zahl);
		return; //beendet die Funktion
		Console.WriteLine(zahl); //kann nicht erreicht werden
	}

	static string PrintEnum(Wochentag tag) //Enumwert als Parameter
	{
		switch (tag)
		{
			case Wochentag.Mo: return "Montag";
			case Wochentag.Di: return "Dienstag";
			case Wochentag.Mi: return "Mittwoch";
			case Wochentag.Do: return "Donnerstag";
			case Wochentag.Fr: return "Freitag";
			case Wochentag.Sa: return "Samstag";
			case Wochentag.So: return "Sonntag";
			default: return "Kein Wochentag";
		}

		//return tag switch
		//{
		//	Wochentag.Mo => "Montag",
		//	Wochentag.Di => "Dienstag",
		//	Wochentag.Mi => "Mittwoch",
		//	Wochentag.Do => "Donnerstag",
		//	Wochentag.Fr => "Freitag",
		//	Wochentag.Sa => "Samstag",
		//	Wochentag.So => "Sonntag",
		//	_ => "Kein Wochentag",
		//};
	}
}

enum Wochentag
{
	Mo,
	Di,
	Mi,
	Do,
	Fr,
	Sa,
	So
}