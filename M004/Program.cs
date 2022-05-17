#region Schleifen
int a = 0;
int b = 10;
while (a < b) //läuft während die Bedingung true ist
{
	Console.WriteLine("while: " + a);
	if (a == 5)
		break; //break: beendet die Schleife
	a++;
}

int c = 0;
int d = 10;
do //läuft während die Bedingung true ist und mindestens einmal
{
	c++;
	if (c == 5)
		continue; //springt zum Kopf/Fuß zurück
	Console.WriteLine("do-while: " + c);
}
while (c < d);

while (true) //Endlosschleife
{
	if (d == b)
		break; //break beendet hier die Endlosschleife
}

for (int i = 0; i < 10; i++) //läuft während Bedingung true ist und hat einen Zähler integriert
{
	Console.WriteLine("for: " + i);
}

for (int i = 10 - 1; i >= 0; i--) //Schleife die nach unten zählt
{
	Console.WriteLine("forr: " + i);
}

for (int i = 0, j = 0; i == j && i != 10 && j != 10; i += 2, j *= 5) //Mehrere Zähler, mehrere Bedingungen, mehrere Inkrementierungen
{
	break;
}

int[] zahlen = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
for (int i = 0; i < zahlen.Length; i++) //Array mit for-Schleife durchgehen
{
	Console.WriteLine(zahlen[i]);
}

foreach (int z in zahlen) //Array mit foreach durchgehen, kann nicht daneben greifen
{
	Console.WriteLine(z);
}
#endregion

#region Enums
Wochentag wt = Wochentag.Di; //Wochentag Variable

if (wt == Wochentag.Di) //Überprüfung mit Enum
{
	Console.WriteLine("Es ist Dienstag");
}

int x = 2;
Wochentag castTag = (Wochentag) x; //Mittwoch

for (int i = 0; i < 7; i++)
{
	Console.WriteLine((Wochentag) i); //Alle Wochentage printen
}

string input = Console.ReadLine();
Wochentag inputTag = (Wochentag) int.Parse(input); //int Input zu Wochentag
Console.WriteLine(inputTag);

Wochentag stringInputTag = (Wochentag) Enum.Parse(typeof(Wochentag), input); //int oder string Input zu Wochentag
Console.WriteLine(stringInputTag);

Wochentag inputGeneric = Enum.Parse<Wochentag>(input); //Obere Methode nur wesentlich kürzer
Console.WriteLine(inputGeneric);
#endregion

#region Switch
Wochentag tag = Wochentag.Di;
if (tag == Wochentag.Mo) //Negativbeispiel
	Console.WriteLine("Wochenanfang");
else if (tag == Wochentag.Di || tag == Wochentag.Mi || tag == Wochentag.Do)
	Console.WriteLine("Wochenmitte");
else if (tag == Wochentag.Fr || tag == Wochentag.Sa || tag == Wochentag.So)
	Console.WriteLine("Wochenende");

switch (tag)
{
	case Wochentag.Mo:
		Console.WriteLine("Wochenanfang");
		break; //break am Ende aller Cases, außer wenn kein Code drinnen steht
	case Wochentag.Di: //Di, Mi, Do als eine Einheit
	case Wochentag.Mi:
	case Wochentag.Do:
		Console.WriteLine("Wochenmitte");
		break;
	case Wochentag.Fr:
	case Wochentag.Sa:
	case Wochentag.So:
		Console.WriteLine("Wochenende");
		break;
	default: //Wenn kein Case erreicht
		Console.WriteLine("Etwas ist schiefgelaufen");
		break;
}


switch (tag) //switch mit boolscher Logik
{
	case >= Wochentag.Mo and <= Wochentag.Fr:
		Console.WriteLine("Wochentag");
		break;
	case Wochentag.Sa or Wochentag.So:
		Console.WriteLine("Wochenende");
		break;
}
#endregion

enum Wochentag
{
	Mo, 
	Di, 
	Mi, 
	Do, 
	Fr, 
	Sa, 
	So
}