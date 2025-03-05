using System.Runtime.ConstrainedExecution;

namespace M007_GC_Static;

internal class Program
{
    static void Main(string[] args)
    {
        // Static Methoden
        // Eine Methode als Static deklarieren, dann kann ich sie OHNE ein Objekt der Klasse aufrufen
        int summe = Mathe.Addiere(3, 5);
        Console.WriteLine(summe);

        // Statische Variable
        // Eine static-Variable wird von allen Objekten geteilt
        new Auto();
        new Auto();
        new Auto();
        Auto.AnzahlAutos += 1;
        Console.WriteLine(Auto.AnzahlAutos);


        // Statische Klasse
        // eine Static-Klasse kann nicht instanziiert werden (kein new möglich)
        // Eine Sammlung von statischen Methoden
        Helfer.ZeigeText();

        // Null
        // Die variable ist leer
        Person p1 = null; // In p1 ist kein Wert enthalten

        // p1.Vorname = "Max" // Wenn die Person nicht existiert => kann keinen Namen bekommen WEIL, p1 = null

        if(p1 != null)
        {
            p1.Vorname = "Max";
            Console.WriteLine(p1.Vorname);
        }

        // Arbeiten mit Datumswerten
        // Zwei Klassen: DateTime, TimeSpan
        // Datetime: Bestimmter Punkt mit Datum + Zeit
        // TimeSpan: Zeitspanne
        DateTime dt = new DateTime(2025, 03, 05, 13, 29, 30);
        dt += TimeSpan.FromHours(3);
        Console.WriteLine(dt);
    }
}

class Mathe
{
    public static int Addiere(int a, int b)
    {
        return a + b;
    } 
}

class Auto
{
    public static int AnzahlAutos = 0;

    public Auto()
    {
        AnzahlAutos++; // Wird bei jedem neuen Auto erhöht
    }
}

static class Helfer
{
    public static void ZeigeText()
    {
        Console.WriteLine("Hallo!");
    }
}

public class Person
{
    public string Vorname { get; set; }
}