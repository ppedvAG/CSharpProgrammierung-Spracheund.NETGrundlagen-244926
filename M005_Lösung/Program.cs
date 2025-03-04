while(true)
{
    double zahl1 = ZahlEingabe("\nGib eine Zahl ein: ");
    double zahl2 = ZahlEingabe("Gib eine weitere Zahl ein: ");

    foreach(Rechenoperation operation in Enum.GetValues<Rechenoperation>())
    {
        Console.WriteLine($"{(int) operation}: {operation}");
    }
    Rechenoperation op = RechenOperationsEingabe();

    double ergebnis = Berechne(zahl1 ,zahl2, op);

    Console.WriteLine("Wiederholen (Y/N)");
    if (Console.ReadKey().Key == ConsoleKey.N)
        break;
}


double Berechne(double zahl1, double zahl2, Rechenoperation op)
{
    switch(op)
    {
        case Rechenoperation.Addition:
            Console.WriteLine($"{zahl1} + {zahl2} = {zahl1 + zahl2}");
            return zahl1 + zahl2;
        case Rechenoperation.Subtraktion:
            Console.WriteLine($"{zahl1} - {zahl2} = {zahl1 - zahl2}");
            return zahl1 - zahl2;
        case Rechenoperation.Multiplikation:
            Console.WriteLine($"{zahl1} * {zahl2} = {zahl1 * zahl2}");
            return zahl1 * zahl2;
        case Rechenoperation.Division:
            if (zahl2 == 0) 
                return double.NaN;

            Console.WriteLine($"{zahl1} / {zahl2} = {zahl1 / zahl2}");
            return zahl1 / zahl2;
        default:
            Console.WriteLine("Fehler");
            return double.NaN;
    }
}

double ZahlEingabe(string text)
{
    while (true)
    {
        Console.WriteLine(text);
        bool funktioniert = double.TryParse(Console.ReadLine(), out double ergebnis);
        if (funktioniert)
        {
            return ergebnis;
        }
        else
        {
            Console.WriteLine("Keine Zahl eingegeben");
        }
    }
}

Rechenoperation RechenOperationsEingabe()
{
    while(true)
    {
        double ergebnis = ZahlEingabe("Gib eine Rechenoperation ein: ");
        Rechenoperation op = (Rechenoperation)ergebnis;
        if (Enum.IsDefined(op))
            return op;
        else
            Console.WriteLine("Keine gültige Rechenoperation eingegeben");
    }
}

enum Rechenoperation
{
    Addition = 1,
    Subtraktion,
    Multiplikation,
    Division
}