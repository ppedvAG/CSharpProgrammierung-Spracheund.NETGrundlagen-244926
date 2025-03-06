using System.Diagnostics;

namespace M012_Linq_Lamba;

internal class Program
{
    static void Main(string[] args)
    {
        #region Einfaches Linq
        // IEnumerable
        // Anleitung zur Erstellung von Beispiel Daten
        // Daten werden erzeugt wenn die Anleitung ausgeführt wird
        IEnumerable<int> zahlen = Enumerable.Range(0, 1_000_000);

        List<int> ints = Enumerable.Range(1, 20000).ToList();

        Console.WriteLine(ints.Average());
        Console.WriteLine(ints.Min());
        Console.WriteLine(ints.Max());
        Console.WriteLine(ints.Sum());

        Console.WriteLine(ints.First());
        Console.WriteLine(ints.Last());

        // Wichtig!: Jede Linq-Funktion fängt mit e => an
        // Sucht das erste Element, welches durch 50 Teilbar ist
        Console.WriteLine(ints.FirstOrDefault(e => e % 50 == 0));
        #endregion

        // Linq mit Objekten
        #region Linq mit Objekten
        List<Fahrzeug> fahrzeuge = new List<Fahrzeug>()
        {
            new Fahrzeug(250, FahrzeugMarke.BMW),
            new Fahrzeug(175, FahrzeugMarke.VW),
            new Fahrzeug(195, FahrzeugMarke.BMW),
            new Fahrzeug(162, FahrzeugMarke.BMW),
            new Fahrzeug(186, FahrzeugMarke.Audi),
            new Fahrzeug(284, FahrzeugMarke.VW),
            new Fahrzeug(301, FahrzeugMarke.VW),
            new Fahrzeug(174, FahrzeugMarke.Audi),
        };

        // Alle VWs finden
        List<Fahrzeug> vws = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW).ToList();

        // Ausgeben aller VMs
        foreach (var item in vws)
        {
            Console.WriteLine($"MaxGeschwindigkeit: {item.MaxV}, FahrzeugMarke: {item.Marke}");
        }

        // Alle VWs finden, welche mind. 220km/h fahren können
        fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW && e.MaxV >= 220);

        fahrzeuge
            .Where(e => e.Marke == FahrzeugMarke.VW)
            .Where(e => e.MaxV >= 220);

        // OrderBy, OrderByDescending
        // Alle Fahrzeuge nach der Marke sortieren
        fahrzeuge.OrderBy(e => e.Marke);
        fahrzeuge.OrderByDescending(e => e.Marke);


        // Alle Fahrzeuge nach Marke, MaxV sortieren
        fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV);
        fahrzeuge.OrderByDescending(e => e.Marke).ThenByDescending(e => e.MaxV);

        // Count(): Wieviele Fahrzeuge mit MaxV > 200 haben wir?
        fahrzeuge.Count(e => e.MaxV > 200);

        // All
        // Prüft ob alle/mind. ein Element(e) einer Bedingung entsprechen
        // Wird generell mit einer if abgefragt
        if (fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).All(e => e.MaxV >= 200))
        {
            // ...
        }

        // Any
        fahrzeuge.Any(); // Prüft, ob die Liste elemente hat
                         // fahrzeuge.Count > 0


        // Distinct
        // Welche Marken haben wir
        List<FahrzeugMarke> marken = fahrzeuge.Select(e => e.Marke).ToList();
        //foreach (var marke in marken)
        //    Console.WriteLine($"Diese Marken gibt es: {marke}");
        marken.Distinct().ToList(); // Nur noch 3 ELemente drinnen: Audi, BMW, VW jeweils 1x mal

        fahrzeuge.Select(e => e.Marke).Distinct();

        // Group By
        // Anhand des kriteriums die Daten in gruppen aufteilen
        // Beispiel: Nach Marke gruppieren
        // Drei Gruppen: Audi-Gruppe, BMW-Gruppe, VW-Gruppe
        fahrzeuge.GroupBy(e => e.Marke);
        #endregion
    }
}

public class Fahrzeug
{
    public int MaxV;
    public FahrzeugMarke Marke;
    public Fahrzeug(int maxV, FahrzeugMarke marke)
    {
        MaxV = maxV;
        Marke = marke;
    }
}

public enum FahrzeugMarke
{
    Audi, BMW, VW
}