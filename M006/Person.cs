namespace M006; //Namespace für die ganze Datei definieren

/// <summary>
/// Eine Klasse die eine Person repräsentiert
/// </summary>
class Person
{
	#region Variable
	private string name; //Variable/Feld

	public void SetName(string name)
	{
		if (name.Length >= 2 && name.Length <= 15) //Sicherheit erhöhen durch Set Methode mit Überprüfung davor
			this.name = name;
	}

	public string GetName()
	{ 
		return name;
	}
	#endregion

	#region Properties
	private string vorname; //Privates Feld im Hintergrund

	public string Vorname
	{
		//get
		//{
		//	return vorname;
		//}
		get => vorname;
		set
		{
			if (name.Length >= 2 && name.Length <= 15)
				vorname = value; //value: Wert beim setzen der Variable mit =
		}
	}

	private int gehalt;

	/// <summary>
	/// Das Gehalt der Person
	/// </summary>
	public int Gehalt
	{
		get => gehalt;
		private set => gehalt = value; //Set-Methode von aussen verstecken
	}

	private string lieblingsfarbe;

	public string Lieblingsfarbe => lieblingsfarbe; //{ get => lieblingsfarbe; }, Get-Only Property

	public string Lieblingsnahrung { get; private set; } = "Apfel"; //Werte direkt setzen wie bei einer Variable

	public string Auto { get; init; } = "VW"; //init: kann nur hier oder im Konstruktor gesetzt werden
	#endregion

	//public Member() { } Leeren Standardkonstruktor überschreiben mit eigenem Konstruktor

	/// <summary>
	/// Ein Konstruktor
	/// </summary>
	/// <param name="name">Der Nachname der Person</param>
	/// <param name="vorname">Der Vorname der Person</param>
	public Person(string name, string vorname) //Konstruktor: wird aufgerufen bei new Member(), wird verwendet um Standardwerte zu initiieren
	{
		this.name = name; //this: Variable in der Klasse selbst ansprechen
		this.vorname = vorname;
	}

	public Person(string name, string vorname, string lieblingsfarbe) : this(name, vorname) //Verkettung nach oben
	{
		//this.name = name; Über Verkettung werden die Werte gesetzt -> this(..., ...)
		//this.vorname = vorname;
		this.lieblingsfarbe = lieblingsfarbe;
	}
	
	//ctor + Tab + Tab: Leeren Konstruktor erzeugen
	public Person()
	{

	}
}