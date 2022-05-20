public class Program
{
	//Speichert Referenzen zu anderen Methoden, können zur Laufzeit hinzugefügt oder weggenommen werden
	public delegate void Vorstellungen(string name);

	static void Main2(string[] args)
	{
		Vorstellungen vorstellung; //Variablendeklaration
		vorstellung = new Vorstellungen(VorstellungDE); //delegate erstellen
		vorstellung -= new Vorstellungen(VorstellungEN); //Methode abziehen macht nichts wenn die Methode nicht dranhängt
		vorstellung += new Vorstellungen(VorstellungEN); //weitere Methode dranhängen

		vorstellung("Max");
		//Hallo mein Name ist Max
		//Hello my name is Max

		foreach (Delegate dg in vorstellung.GetInvocationList()) //Alle Methoden die dranhängen iterieren
		{
			Console.WriteLine(dg.Method.Name); //Methodennamen mit .Name holen
		}

		vorstellung -= VorstellungEN; //Methode entfernen
		vorstellung("Max");

		vorstellung = null; //Alle Methoden entfernen
	}

	public static void VorstellungDE(string name)
	{
		Console.WriteLine($"Hallo mein Name ist {name}");
	}

	public static void VorstellungEN(string name)
	{
		Console.WriteLine($"Hello my name is {name}");
	}
}