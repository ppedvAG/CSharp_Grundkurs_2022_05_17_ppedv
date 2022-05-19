namespace M009;

internal class Abstract
{
	public abstract class LebewesenAbstract //Struktur, kein Objekt von dieser Klasse direkt erstellbar
	{
		public string Name { get; set; }

		public LebewesenAbstract(string name)
		{
			Name = name;
		}

		public abstract void PrintStatus();
	}

	public class Mensch2 : LebewesenAbstract
	{
		public Mensch2(string name) : base(name)
		{

		}

		public override void PrintStatus()
		{
			//...
		}
	}
}
