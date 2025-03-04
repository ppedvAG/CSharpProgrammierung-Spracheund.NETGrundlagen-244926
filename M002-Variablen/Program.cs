#region Variablen

// Kommentare
// Mit zwei Slashes kann ein Kommentar definiert werden
// Wird vom Compiler ignoriert

/*
    Mehrzeiliger 
    Kommentarblock
*/

// Hotkey Kommentieren = [STRG + K] [STRG + C]
// Hotkey Auskommentieren = [STRG + K] [STRG + U]
// Hallo

// Variable
// Behälter für einen Wert
// Werden in der Programmierung immer benötigt
// In C# müssen (nicht bei der Zuweisung) Variablen aus 3 Teilen bestehen: DATENTYP, Namen, Wert
// Aufbau: <Typ> <Name> = <Wert>

int Zahl = 10;

Console.WriteLine(Zahl); // cw + Tab
Console.WriteLine(Zahl * 2);

// Datentypen
// Geben an, welchen Inhalt eine Variable haben darf

// Ganzzahlinge Typen: int, long, short, byte
int i = 23;
long l = 23;
short s = 23;
byte b = 23;

// Kommazahltypen: double, float, decimal
double kommazahl = 23.65;
Console.WriteLine("Die Kommazahl beträgt: " + kommazahl);

float f = 23.65f; // Jede Kommazahl in C# ist standardmäßig ein Double, mit f am Ende kann eine konvertierung durchgeführt werden


decimal d = 23.65m; // Mit dem M-suffix umwandeln

string str = "Hallo, ich bin ein String"; //Strings werden in doppelten Hochkommas
Console.WriteLine(str);

char c = 'a'; // Char werden in einzelnen Hochkommas angegeben

// Bool : True oder False
bool wahr = true;
bool falsch = false;



#endregion

#region Strings

string ergebnis = "Die Zahl mal zwei ist: " + Zahl * 2;
Console.WriteLine(ergebnis);

Console.WriteLine("Die Zahl mal drei ist " + Zahl * 3 + ", das ist mein Ergebnis!");
// $-Prefix (String-Interpolation)
Console.WriteLine($"Der double ist: {kommazahl * 3}, der float ist: {f * 5}, der decimal ist: {d}");

// Escape-Sequenzen: Untippbare Zeichen in Strings einbetten
// https://learn.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
Console.WriteLine("Zeilenumbruch \n Zeilenumbruch");

Console.WriteLine("Tabulator \t Tabulator");

// Wird häufig 
string pfad = @"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.1\System.Security.AccessControl.dll";
#endregion

#region Eingabe

// Console.ReadLine(): Wartet auf die Eingabe des Benutzers, und speichert diese in die Variable (hier "eingabe")
//Console.WriteLine("\n\n");
//Console.WriteLine("String Eingabe: ");
//string eingabe = Console.ReadLine();
//Console.WriteLine($"Du hast {eingabe} eingegeben");

// Console.ReadKey(): Wartet auf die einzelne Eingabe vom Benutzer
//ConsoleKeyInfo taste = Console.ReadKey();
//Console.WriteLine(taste.Key);

#endregion

#region Konvertierung

// Konvertierung: Umwandlung von einem Typen zu einem anderen Typen
string userEingabe = Console.ReadLine();

// String zu Zahl umwandeln: Parse
int konvertierung = int.Parse(userEingabe); // Die Parse Funktion versucht den Text in eine Zahl umzuwandeln
Console.WriteLine($"Deine Zahl mal zwei ist: {konvertierung * 2}");

// Zahl zu String umwandeln: ToString()
Console.WriteLine(konvertierung.ToString());

// Zahl zu Zahl: Typecast, cast, casting
double grosseZahl = 219391133181.28;
Console.WriteLine(grosseZahl);

int x = (int)grosseZahl;
Console.WriteLine(x);

// Implizite Konvertierung
int y = 21;
double z = y;
Console.WriteLine(z);

#endregion

#region Arithmetik

int zahl1 = 3;
int zahl2 = 7;
int Test = 3 + 10 - 5 / 2;

// Aufgabe: 
// Zahl 2 auf zahl 1 addieren
//zahl1 = zahl1 + zahl2;
zahl1 += zahl2;
Console.WriteLine(zahl1);

int summe = zahl1 * zahl2;
Console.WriteLine(summe); // 70

// Modulo (%): Rest einer Division
Console.WriteLine(8 % 5); // 3R

// ++, --
zahl1++; //71
zahl2--; //6

// Math: Mathematische Funktionen
double gerundet = Math.Round(2.456263214, 2); // Auf X Kommastellen runden
Console.WriteLine(gerundet);

// Divisionsprobleme
Console.WriteLine(8 / 5); // 1, wenn zwei ints dividiert werden, kommt auch int heraus
Console.WriteLine(8 / 5.0); // Wenn eine der Beiden Zahen eine Kommazahl ist, kommt auch eine Kommazahl heraus
Console.WriteLine(8 / 5d);
Console.WriteLine(8f / 5);
Console.WriteLine((double)zahl1 / zahl2);

#endregion