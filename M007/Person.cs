namespace M007
{
	public class Person
	{
		public string Name { get; set; }

		public Person()
		{
			ZaehlePerson(); //statische Methode ist hier sichtbar da wir in der selben Klasse sind
		}

		~Person() //Destruktor: wird aufgerufen wenn der Garbage Collector das Objekt einsammelt
		{
			Console.WriteLine("Person eingesammelt");
		}

		public static int Zaehler = 0;

		public static void ZaehlePerson()
		{
			Zaehler++;
			//Name = "Max"; Nicht möglich da wir in einer statische Methode sind
		}
	}
}
