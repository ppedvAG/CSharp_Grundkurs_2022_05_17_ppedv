#region Variablen
////Variable: Typ Name;
int zahl; //Definition
zahl = 5; //Zuweisung
Console.WriteLine(zahl); //cw + Tab + Tab: Console.WriteLine();

//int zahlMitZuweisung = 5; //Definition mit Zuweisung
//Console.WriteLine(zahlMitZuweisung);

//string stadt = "Wien"; //Text mit Doppeltem Hochkomma
//Console.WriteLine(stadt);

///*
// * Mehrzeiliger
// * Kommentar
// */

//char zeichen = 'S'; //Einzelnes Zeichen mit einzelnen Hochkomma
//Console.WriteLine(zeichen);

//double kommazahl = 33.88; //Kommazahl mit Punkt
//Console.WriteLine(kommazahl);

//float kommaFloat = 55.44f; //Float mit f
//Console.WriteLine(kommaFloat);

//decimal geld = 333_598_72_49_85.44m; //Decimal mit m, Trennzeichen mit _
//Console.WriteLine(geld);

//bool wahrFalsch = true; //true oder false
//Console.WriteLine(wahrFalsch);

//string ausgabe = "Ich wohne in " + stadt + " und bin " + zahl + " Jahre alt"; //Strings mit + verbinden
//Console.WriteLine(ausgabe);

//string stadtAusgabe = $"Ich wohne in {stadt} und bin {zahl} Jahre alt"; //String Interpolation mit $ vor dem String
//Console.WriteLine(stadtAusgabe);

//Console.WriteLine("Ich wohne in {0} und bin {1} Jahre alt", stadt, zahl); //Mehrere Argumente bei cw

////https://docs.microsoft.com/en-us/dotnet/standard/base-types/character-escapes-in-regular-expressions

//string umbruch = "Hallo ich bin \n ein string"; //\n: Zeilenumbruch
//Console.WriteLine(umbruch);

//string tab = "Hallo ich bin \t ein string"; //\t: Tabulator
//Console.WriteLine(tab);

//string verbatim = @"Hallo	 ich bin
//ein string";
//Console.WriteLine(verbatim); //Verbatim-String: wird genau so interpretiert wie im Code geschrieben

//string pfad = @"C:\Users\User"; //statt C:\\Users\\User
#endregion

#region Eingabe
//string eingabe = Console.ReadLine(); //Eingabe mit Console.ReadLine(), wartet bis Enter
//Console.WriteLine(eingabe);

//char eingabeReadKey = Console.ReadKey().KeyChar; //Zeicheneingabe (ohne Enter)
//Console.WriteLine(eingabeReadKey);

//int umwandlung = int.Parse(eingabe); //Umwandlung von String zu Zahl
//Console.WriteLine(umwandlung);

//int convert = Convert.ToInt32(eingabe); //Umwandlung von String zu Zahl (alte Methode)
//Console.WriteLine(convert);
#endregion

//Console.WriteLine("Test"); Strg + K, C: Alle markierten Zeilen auskommentieren
//Console.WriteLine("Test"); Strg + K, U: Alle markierten Zeilen einkommentieren

#region Typecasting
string intZuStringToString = zahl.ToString(); //int zu string

string intZuString = "Wert von Zahl: " + zahl; //int zu string

double doubleZahl = 50.4;
int intZahl = (int) doubleZahl; //Umwandlung erzwingen, da Kommastelle

int implizit = 50; //Kein erzwingen Notwendig, da keine Kommastelle
double implizitDouble = implizit;
#endregion

#region Mathematik
int zahl1 = 7;
int zahl2 = 3;
Console.WriteLine(zahl1 + zahl2);
Console.WriteLine(zahl1 - zahl2);
Console.WriteLine(zahl1 * zahl2);
Console.WriteLine(zahl1 / zahl2); //Zwei ganze Zahlen dividieren, schneidet Kommastellen weg
Console.WriteLine(zahl1 / (double) zahl2); //Kommadivision erzwingen
Console.WriteLine(zahl1 % zahl2); //Gibt Rest der Division zurück

zahl1++; //Erhöhe Zahl um 1
zahl1--; //Verringere Zahl um 1

zahl1 = zahl1 + 1; //zahl1 um 1 erhöhen und zuweisen, zahl1++ nur länger
zahl1 %= zahl2; //Schreibe Ergebnis von Modulo-Operation in Zahl1 rein

double round = 2.6;
Math.Round(round); //Abrunden auf 2
Math.Round(round, 2); //Auf Zwei Stellen runden
Math.Floor(round); //Immer abrunden
Math.Ceiling(round); //Immer aufrunden
Math.Pow(4, 3); //Potenzieren: 4^3
Math.Sqrt(16); //Wurzel von 16
#endregion