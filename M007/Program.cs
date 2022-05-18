using M007;

public class Program
{
	static void Main(string[] args)
	{
		for (int i = 0; i < 1000; i++)
		{
			Person p = new Person();
			Person.ZaehlePerson(); //statische Methode aufrufen ohne Objekt (über Klassenname)
		}

		GC.Collect(); //Hier GC erzwingen
		GC.WaitForPendingFinalizers(); //Warte auf alle Destruktoren

		//Wertetyp
		int original = 5;
		int x = original;
		original = 10;

		//Referenztyp
		Person p1 = new Person();
		Person p2 = p1;
		p1.Name = "Max";

		//Wertetyp
		string s1 = "Test";
		string s2 = s1;
		s1 = "Neuer Test";


		int anzahl = 0;
		Addiere(4, 2, ref anzahl);
		Addiere(4, 3, ref anzahl);
		Addiere(4, 4, ref anzahl);
	}

	public static void Addiere(int z1, int z2, ref int anz) //Referenz zur Variable
	{
		Console.WriteLine(z1 + z2);
		anz++; //Anzahl Variable ansprechen und Wert erhöhen
	}
}