using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using static System.Environment;

public class Program
{
	static void Main(string[] args)
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Desktop: C:\Users\lk3\Desktop

		string folderPath = Path.Combine(desktop, "M015"); //Path Klasse für Pfadoperationen

		if (!Directory.Exists(folderPath)) //Directory Klasse für Ordneroperationen
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt");

		//StreamWriterTest();

		//StreamReaderTest();


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

		#region JSON
		//string json = JsonConvert.SerializeObject(fahrzeuge);
		//File.WriteAllText(filePath, json);

		//string read = File.ReadAllText(filePath);
		//List<Fahrzeug> fzg = JsonConvert.DeserializeObject<List<Fahrzeug>>(read); //In spitzer Klammer Typ zu dem konvertiert werden soll
		#endregion

		#region XML
		//XmlSerializer xml = new XmlSerializer(typeof(List<Fahrzeug>));
		//using Stream s = new FileStream(filePath, FileMode.Create);
		//xml.Serialize(s, fahrzeuge);

		//Stream readStream = new FileStream(filePath, FileMode.Open);
		//List<Fahrzeug> readFahrzeuge = xml.Deserialize(readStream) as List<Fahrzeug>;
		#endregion

		#region CSV
		//File.WriteAllText(filePath, fahrzeuge.Aggregate("", (agg, fzg) => agg + $"{fzg.MaxGeschwindigkeit};{fzg.Marke}\n"));

		//TextFieldParser tfp = new TextFieldParser(filePath);
		//tfp.SetDelimiters(";");

		//List<Fahrzeug> readFahrzeuge = new();
		//while (!tfp.EndOfData)
		//{
		//	string[] fields = tfp.ReadFields(); //Derzeitige Zeile einlesen
		//	Fahrzeug f = new Fahrzeug(int.Parse(fields[0]), Enum.Parse<FahrzeugMarke>(fields[1]));
		//	readFahrzeuge.Add(f);
		//}
		#endregion

		#region BinaryFormatter
		BinaryFormatter formatter = new BinaryFormatter(); //Daten unleserlich schreiben
		using Stream str = new FileStream(filePath, FileMode.Create);
		formatter.Serialize(str, fahrzeuge);

		str.Position = 0;
		List<Fahrzeug> fzg = formatter.Deserialize(str) as List<Fahrzeug>;
		#endregion
	}

	static void StreamWriterTest()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Desktop: C:\Users\lk3\Desktop

		string folderPath = Path.Combine(desktop, "M015"); //Path Klasse für Pfadoperationen

		if (!Directory.Exists(folderPath)) //Directory Klasse für Ordneroperationen
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt");

		StreamWriter sw = new StreamWriter(filePath); //Überschreibt File
		sw.WriteLine("1"); //In den Buffer schreiben
		sw.WriteLine("2");
		sw.WriteLine("3");
		sw.Flush(); //Auf die Festplatte schreiben
		sw.Dispose(); //Resourcen frei machen und StreamWriter schließen

		//using-Block: Disposed automatisch am Ende des Blocks
		//AutoFlush: Automatisch nach jeder Eingabe in den Buffer auf die Festplatte schreiben
		using (StreamWriter sw2 = new StreamWriter(filePath, append: true) { AutoFlush = true }) //append: Anhängen
		{
			sw2.WriteLine("4");
			sw2.WriteLine("5");
			sw2.WriteLine("6");
		}

		using StreamWriter sw3 = new(filePath, append: true) { AutoFlush = true };
		sw3.WriteLine("9");
		sw3.WriteLine("10");
		sw3.WriteLine("11");
	}

	static void StreamReaderTest()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Desktop: C:\Users\lk3\Desktop

		string folderPath = Path.Combine(desktop, "M015"); //Path Klasse für Pfadoperationen

		if (!Directory.Exists(folderPath)) //Directory Klasse für Ordneroperationen
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt");

		//StreamWriterTest();

		using StreamReader sr = new StreamReader(filePath);
		string readFile = sr.ReadToEnd(); //ließt alles in einen string
		string[] split = readFile.Split(NewLine, StringSplitOptions.RemoveEmptyEntries); //Eingelesenen string aufteilen in Zeilen, leere Zeilen entfernen

		sr.BaseStream.Position = 0; //Hier Stream zurücksetzen auf den Anfang

		List<string> readLines = new();
		string read = sr.ReadLine();
		while (!sr.EndOfStream)
		{
			readLines.Add(read);
			read = sr.ReadLine();
		}
	}
}

//Record: Generiert Klasse darunter
//Wertetyp statt Referenztyp
//== und != vergleichen Werte statt den HashCodes

[Serializable] //Serializable für der BinaryFormatter
public record Fahrzeug(int MaxGeschwindigkeit, FahrzeugMarke Marke);

//public class Fahrzeug
//{
//	public int MaxGeschwindigkeit;

//	public FahrzeugMarke Marke;

//	public Fahrzeug(int v, FahrzeugMarke fm)
//	{
//		MaxGeschwindigkeit = v;
//		Marke = fm;
//	}

//	public Fahrzeug() { }
//}

public enum FahrzeugMarke
{
	BMW,
	Audi,
	VW
}