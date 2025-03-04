// Funktionen
// Code in Blöcken ablegen und diese Später mehrmals verwenden

// Aufbaue:
// <Modifier> <Rückgabewert> <Namen>(<Par1>, <Par2>, ...) { Anweisung }

// Modifier:
// Verschiedene Keywords, welche die Funktion beeinflussen
// Beispiele: Acces Modifier (public, private, internal), static, async, ref, extern, sealed, abstract, ....

// Rückgabewert:
// Jede Funktion kann ein Ergebnis haben, dieses wird per return am Ende der Funktion übergeben
// Das Ergebnis kann im Anschliss in einer Variablen gefangen werden und weiterverwendet werden
// void: Kein Return

// Name
// Über den Namen können wir die Funktion aufrufen
// Funktionen in C# werden groß geschrieben

// Parameter
// Gibt vor, welche Daten die Funktion erwartet, wenn sie ausgeführt werden soll
// Wenn eine Funktion ausgeführt wird, muss jeder Parameter mit einem Wert befüllt sein
// Jeder Parameter benötigt immer einen Typen und einen Namen (wie variablen)

// Body
// Der Code den die Funktion ausführen soll
// Kann auf die Parameter zugreifen
// Kann ein ergebnis per return-Keyword zurückgeben


internal class Program
{
    private static void Main(string[] args)
    {
        int s = PrintAddiere(4, 6);
        Console.WriteLine($"Die Summe ist: {s}");

        double d = PrintAddiere(4.0, 6.0);
        Console.WriteLine($"Die Summe ist: {d}");

        int drei = PrintAddiere(3, 6, 9);
        Console.WriteLine($"Die Summe ist: {drei}");

        Addiere(1, 2);
        Addiere(4, 8, 16);
        int g = Addiere(4, 8, 16, 2, 7, 3, 1);
        Console.WriteLine(g); // 41
        Addiere();

        int[] zahlen = [2, 8, 10];
        Addiere(zahlen);

        /////////////////////////////////
        Subtrahiere();
        Subtrahiere(4, 9); // c bleibt 0
        Subtrahiere(c: 10, a: 2); // b überspringen, b bleibt 0

        /////////////////////////////////

        // TryParse gibt einen bool zurück, dieser sagt aus, ob das Parsen funktioniert hat oder nicht
        int ergebnis; // Hier oben muss eine variable definiert werden, welche über das Ergebnis (bei Erolg) einfängt
        bool funktioniert = int.TryParse("123", out ergebnis); // Über out ergebnis wird der Parameter mit der Variable verbunden
        if( funktioniert )
        {
            Console.WriteLine($"Zahl: {ergebnis}");
        } else
        {
            Console.WriteLine("Parsen hat nicht funktioniert");
        }



    }

    // Aufgabe: Funktion, welche zwei Zahlen empfängt und diese Addiert + die Gleichung ausgibt (in der Konsole)
    static int PrintAddiere(int z1, int z2)
    {
        int summe = z1 + z2;
        Console.WriteLine($"{z1} + {z2} = {summe}");
        return summe;
    }

    // Überladung
    // Denselben Funktionsnamen mehrmals verwenden
    // Hierbei müssen sich die parameter unterscheiden (Datentyp oder Parameteranzahl)
    static double PrintAddiere(double z1, double z2)
    {
        double summe = z1 + z2;
        Console.WriteLine($"{z1} + {z2} = {summe}");
        return summe;
    }

    static int PrintAddiere(int z1, int z2, int z3)
    {
        int summe = z1 + z2 + z3;
        Console.WriteLine($"{z1} + {z2} + {z3} = {summe}");
        return summe;
    }


    // params
    // Ermöglicht, beliebig viele Parameter an die Funktion zu geben
    // Innerhalb der Funktion ist der params-Parameter ein Array
    // Jede Funktion kann nur einen params-parameter haben
    static int Addiere(params int[] zahlen)
    {
        return zahlen.Sum();
    }

    // optionale Parameter
    // Parameter mit einer Vorbelegung, diese kann überschrieben
    static void Subtrahiere(int a = 0, int b = 0, int c = 0)
    {
        int summe = a - b - c;
        Console.WriteLine(summe);
        return summe;
    }
}