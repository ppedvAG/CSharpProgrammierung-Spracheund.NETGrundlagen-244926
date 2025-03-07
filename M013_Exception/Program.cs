namespace M013_Exception;

// Fehlerbehandlung

// try-catch
// Wird verwendet um Exceptions (= Fehler -> Abstürze zu verhindern)
// Hintergrund: Plattformunabhängigkeiten
// Wenn im Code ein Fehler auftreten sollte, soll dieser Fehler per Exception veursacht werden
// Wenn eine Exception auftritt, kann der Benutzer des Codes selbst entscheiden, wie diese Exception behandelt wird
// Hier kann jetzt z. B ein Log, auf eine Webseite geleitet.

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            string eingabe = Console.ReadLine();
            int x = int.Parse(eingabe);
        }
        // Wenn ein catch-Block ausgeführt wird, stürzt das Programm nicht mehr ab
        catch (FormatException ex) // Hier kann ein spezifischer Fehler behandelt werden (hier Buchstaben)
        {
            // über ex kann auf den Fehler zugegriffen werden
            Console.WriteLine("Die Eingabe ist keine Zahl");
            Console.WriteLine(ex.Message); // Die C# interne Fehlermeldung
            Console.WriteLine(ex.StackTrace); // Rückverfolgung, wo der Fehler passiert ist
        }

        catch (OverflowException ex)
        {
            Console.WriteLine("Die Eingabe ist zu groß/klein");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
        catch (Exception) // Alle anderen Fehler
        {
            Console.WriteLine("Anderer Fehler");
        }
        finally // Wird immer ausgeführt (egal ob Fehler oder nicht)
        {
            Console.WriteLine("Parsen fertig");
        }
    }
}