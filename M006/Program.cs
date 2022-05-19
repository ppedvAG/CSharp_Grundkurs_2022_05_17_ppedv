using M006_AndererNamespace; //Using: Namespace importieren

namespace M006 //Definition von M006 Namespace
{
	public class Program //M006.Program
	{
		/// <summary>
		/// Der Einstiegspunkt
		/// </summary>
		/// <param name="args"></param>
		/// <returns>Den Wert 0</returns>
		static int Main(string[] args) //svm + Tab + Tab -> Main-Methode
		{
			AndererNamespaceProgram p; //kann nicht gefunden werden
			M006_AndererNamespace.Program prog; //Ohne Namespace: Program hier, mit Namespace.Program: Program unten
			Unternamespace.Program uProgram; //M006 kann weggelassen werden da wir im M006 bereits sind

			Person m = new Person("Mustermann", "Max"); //Strg + R, R: Feld umbenennen und alle anderen Felder die genauso heißen
			m.Vorname = "Max";
			m.ToString();
			Console.WriteLine(m.Vorname);

			//m.Gehalt = 1234; //Nicht möglich, da privater Setter
			Console.WriteLine(m.Gehalt);
			return 0;
		}
	}

	namespace Unternamespace //M006.Unternamespace
	{
		public class Program { }
	}
}

namespace M006.UnternamespaceAusserhalb { }

namespace M006_AndererNamespace
{
	public class AndererNamespaceProgram { }

	public class Program { } //2 Klassen mit gleichen Namen, weil anderer Namespace nicht sichtbar
}