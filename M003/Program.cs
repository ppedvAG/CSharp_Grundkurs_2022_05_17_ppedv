#region Arrays
int[] zahlen = new int[5]; //Array mit 5 Stellen, Indizes 0-4
zahlen[1] = 5; //Stelle ansprechen (fängt bei 0 an und endet bei 4)
Console.WriteLine(zahlen[1]);

int[] zahlenDirekt = new int[] { 1, 2, 3, 4, 5 }; //Direkte Initialisierung, 5 Stellen

int[] zahlenDirektKurz = new[] { 1, 2, 3, 4, 5 }; //Kurzschreibweise

int[] nochKuerzer = { 1, 2, 3, 4, 5 }; //Direkt 5 Stellen Array erstellen

Console.WriteLine(zahlen.Length); //5

Console.WriteLine(zahlen.Contains(3)); //False, da keine 3 im Array

Console.WriteLine(zahlen.Sum()); //5

int[,] zweiDArray = new int[3, 3]; //Matrix (3x3), beliebig viele Dimensionen mit Beistrichen
zweiDArray[1, 1] = 4;
Console.WriteLine(zweiDArray[1, 1]);
Console.WriteLine(zweiDArray.Length); //Anzahl aller Elemente (9)
Console.WriteLine(zweiDArray.Rank); //Anzahl Dimensionen (2)
Console.WriteLine(zweiDArray.GetLength(1)); //Länge der zweiten Dimension (3)

int[,] zweiDArrayDirekt = //Direkt initialisiert
{
	{ 1, 2, 3 },
	{ 4, 5, 6 },
	{ 7, 8, 9 }
};
#endregion

#region Bedingungen
int zahl1 = 5;
int zahl2 = 7;

bool istGleich = zahl1 == zahl2; //false
bool istUngleich = zahl1 != zahl2; //true

bool kleiner = zahl1 < zahl2;
bool groesser = zahl1 > zahl2;

if (zahl1 == zahl2) //Wenn Bedingung (Zahl1 gleich Zahl2)
{
	Console.WriteLine("Zahlen sind gleich");
}
else //Wenn nicht Bedingung
{
	Console.WriteLine("Zahlen sind ungleich");
}

if (zahl1 != zahl2) //Einzeilige if's und else's ohne Klammern
	Console.WriteLine("Zahlen sind ungleich");
else
	Console.WriteLine("Zahlen sind gleich");


if (zahl1 > zahl2)
{
	//...
}
else if (zahl1 == zahl2)
{
	//...
}
else
{
	//...
}


if (zahl1 > zahl2)
{
	//...
}
else //Else-If ausgeschrieben
{
	if (zahl1 == zahl2)
	{
		//...
	}
	else
	{
		//...
	}
}


bool istMittwoch = false;
bool istRegen = true;

if (istMittwoch && istRegen) //&& -> nur true wenn beide true sind
{
	Console.WriteLine("Es ist Mittwoch und es regnet");
}

if (istMittwoch || istRegen) //|| -> wenn einer von beiden oder beide true sind
{
	Console.WriteLine("Es ist Mittwoch und/oder es regnet");
}

if (!istMittwoch && istRegen) //! -> negiert den nächsten Ausdruck (istMittwoch), kann auch auf eine Klammer angewandt werden
{
	Console.WriteLine("Es ist nicht Mittwoch und es regnet");
}

if (istMittwoch ^ istRegen) //^ -> nur wenn eins von beiden true aber nicht beide
{
	Console.WriteLine("Entweder es ist Mittwoch oder es regnet");
}

if (zahl1 == 5 && zahl2 == 7)
{
	Console.WriteLine("Zahl1 ist 5 und Zahl2 ist 7");
}

//if (zahl1 != zahl2)
//	Console.WriteLine("Zahlen sind ungleich");
//else
//	Console.WriteLine("Zahlen sind gleich");

//Fragezeichen Operator (?, :) ? ist if, : ist else
//Braucht immer ein else
Console.WriteLine(zahl1 != zahl2 ? "Zahlen sind ungleich" : "Zahlen sind gleich");
#endregion