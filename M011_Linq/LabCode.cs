public class LabCode
{
	//1. Gib alle Autos mit 6 Sitzplätzen aus.
	//2. Gib die Summe aller Sitzplätze aus.
	//3. Sortiere alle Fahrzeuge nach Automarke, danach nach Höchstgeschwindigkeit.
	//4. Gib alle Autos mit mindestens einem besetzten Sitzplatz aus.
	//5. Gib alle Autos aus die schneller fahren können als der Durchschnitt aller Autos.
	//6. Gib alle Autos aus bei denen mehr als die Hälfte aller Sitzplätze belegt sind.
	//7. Gib pro Automarke das schnellste Auto aus.
	//8. Gib die Höchstgeschwindigkeit pro Anzahl Sitzplätze aus und sortiere nach Sitzanzahl (schnellster 4-, 5- und 6-Sitzer).
	//9. Mische die Liste. Erstelle danach eine Erweiterungsmethode dafür.

	static void Main(string[] args)
	{
		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};
	}
}

public class Fahrzeug
{
	public int MaxGeschwindigkeit;
	public FahrzeugMarke Marke;
	public List<Sitzplatz> Sitze;

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxGeschwindigkeit = v;
		Marke = fm;
		Sitze = new List<Sitzplatz>();
		int sitze = v <= 150 ? 6 : v <= 250 ? 5 : 4;
		for (int i = 0; i < sitze; i++)
			Sitze.Add(new Sitzplatz());
		for (int i = 0; i < v % (sitze + 1); i++)
			Sitze[i].IstBesetzt = true;
	}
}

public class Sitzplatz
{
	public bool IstBesetzt;
}

public enum FahrzeugMarke
{
	BMW,
	Audi,
	VW
}