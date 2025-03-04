do
{
    // EIngabe und Parsing der Zahlen
    Console.WriteLine("\nGib eine Zahl ein: ");
    double zahl1 = double.Parse(Console.ReadLine());

    Console.WriteLine("Gib eine weitere Zahl ein: ");
    double zahl2 = double.Parse(Console.ReadLine());

    // Anzeigen der Rechenoperation
    Console.WriteLine("\nWähle eine Rechenoperation");
    foreach (Rechenoperation op in Enum.GetValues<Rechenoperation>())
    {
        Console.WriteLine($"{(int)op}: {op}");
    }

    Console.WriteLine("Auswahl: ");
    Rechenoperation operation = (Rechenoperation)int.Parse(Console.ReadLine());

    // Ergebnisvariable
    double ergebnis = 0.0;

    switch (operation)
    {
        case Rechenoperation.Addition:
            ergebnis = zahl1 + zahl2;
            break;
        case Rechenoperation.Subtraktion:
            ergebnis = zahl1 - zahl2;
            break;
        case Rechenoperation.Multiplikation:
            ergebnis = zahl1 * zahl2;
            break;
        case Rechenoperation.Division:
            if (zahl2 == 0)
            {
                Console.WriteLine("\nEine Division durch 0 ist nicht erlaubt");
                Console.WriteLine("Wiederholen? (Y/N)");
                //continue;
            }
            ergebnis = zahl1 / zahl2;
            break;
        default:
            Console.WriteLine("Fehlerhafte Eingabe bei Auswahl der Rechenoperation");
            Console.WriteLine("Wiederholen (Y/N)");
            //continue;
            break;

    }

    Console.WriteLine($"\n Ergebnis: {ergebnis}");

    // Frage nach der Wiederholung des Programs
    Console.WriteLine("Wiederholen (Y/N)");

} while (Console.ReadKey().Key == ConsoleKey.Y);


enum Rechenoperation
{
    Addition = 1,
    Subtraktion,
    Multiplikation,
    Division
}