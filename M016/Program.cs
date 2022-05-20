using System.Collections;
using System.Diagnostics;

public class Program
{
	static void Main(string[] args)
	{
		Zug z = new();

		Wagon w1 = new();
		Wagon w2 = new();
		if (w1 == w2)
		{
			//Eigene Implementation verwenden
		}

		z += w1;

		foreach (Wagon w in z) //Zug direkt foreach-en durch Enumerator
		{

		}

		Wagon zw = z["1"]; //Zug direkt mit [] ansprechen
		Wagon zw2 = z[1];
		//z[0] = w1; Nicht möglich da kein set

		Stopwatch sw = Stopwatch.StartNew();
		Stopwatch sw1 = new Stopwatch();
		sw1.Start();
		//...
		sw.Stop();
		Console.WriteLine(sw.ElapsedMilliseconds);
	}
}

public class Zug : IEnumerable
{
	private List<Wagon> wagons = new List<Wagon>();

	public IEnumerator GetEnumerator()
	{
		foreach (Wagon w in wagons)
			yield return w;
	}

	public Wagon this[string s]
	{
		get
		{
			int x = int.Parse(s);
			return wagons[x];
		}
	}

	public Wagon this[int x]
	{
		get => wagons[x];
	}

	public static Zug operator +(Zug z, Wagon w)
	{
		z.wagons.Add(w);
		return z;
	}
}

public class Wagon
{
	public int Sitzplätze;

	public string Farbe;

	public static bool operator ==(Wagon w1, Wagon w2)
	{
		return w1.Sitzplätze == w2.Sitzplätze && w1.Farbe == w2.Farbe;
	}

	public static bool operator !=(Wagon w1, Wagon w2)
	{
		return w1.Sitzplätze != w2.Sitzplätze || w1.Farbe != w2.Farbe;
	}
}