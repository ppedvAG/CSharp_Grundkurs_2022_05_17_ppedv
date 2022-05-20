namespace M013
{
	internal class ActionFuncPredicate
	{
		static void Main2(string[] args)
		{
			Action<int, int> action = Addiere; //Action: Methode mit void und bis zu 16 Parametern
			action += Subtrahiere; //Methode dranhängen wie bei delegate
			action += Subtrahiere; //Methode mehrmals dranhängen
			if (action != null) //Null-Check vor Aufruf
				action(2, 3);
			action?.Invoke(3, 4); //Null-Check mit ? Operator

			DoSomethingWithNumber(3, 4, Addiere); //Methode mit Action als Parameter aufrufen
			DoSomethingWithNumber(3, 4, Subtrahiere);

			Predicate<int> checkForZero = CheckForZero; //Predicate: Methode mit bool als return Wert und genau ein Parameter
			checkForZero?.Invoke(0);

			CheckSomething(0, CheckForZero);
			CheckSomething(1, CheckForOne);

			Func<int, int, int> func = Multipliziere; //Func: Methode mit Rückgabewert, letzter Generic ist der Rückgabewert (hier int), bis zu 16 Parameter
			func?.Invoke(3, 4);

			PrintErgebnis(3, 4, Multipliziere);
			PrintErgebnis(3, 5, Dividiere);

			func += delegate (int x, int y) { return x * y; }; //Anonyme Methode (älteste Form)
			func += (x, y) => { return x * y; }; //Anonyme Methode (kürzer)
			func += (x, y) => x * y; //Neueste Methode (kürzeste)

			func(3, 4); //Alle Anonymen Funktion werden hier ausgeführt
		}

		static void Addiere(int x, int y) => Console.WriteLine(x + y);

		static void Subtrahiere(int x, int y) => Console.WriteLine(x - y);

		static int Multipliziere(int x, int y) => x * y;

		static int Dividiere(int x, int y) => x / y;

		static bool CheckForZero(int num) => num == 0;

		static bool CheckForOne(int num) => num == 1;

		//Action als Parameter bei Methode
		static void DoSomethingWithNumber(int z1, int z2, Action<int, int> act) => act?.Invoke(z1, z2);

		static void CheckSomething(int num, Predicate<int> p) => Console.WriteLine(p.Invoke(num));

		static void PrintErgebnis(int z1, int z2, Func<int, int, int> func) => Console.WriteLine(func?.Invoke(z1, z2));
	}
}
