﻿namespace M011_Linq;

public static class ExtensionMethods //Klasse muss statisch sein
{
	public static int Quersumme(this int zahl) //mit this angeben auf welchen Typen sich diese Methode bezieht
	{
		return zahl.ToString().ToCharArray().Sum(e => (int) char.GetNumericValue(e));
	}
}
