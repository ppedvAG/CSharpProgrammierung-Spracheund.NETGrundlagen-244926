using M006_OOP_Klassen_Objekte.Data;

namespace M006_OOP_Klassen_Objekte;

/// <summary>
/// 
/// Klassen und Objekte
/// 
/// Objekte sind Datenstrukturen, welche Daten halten
/// Jedes Objekt kommt von einer Klasse
/// Die Klasse hinter den Objekten gibt den Aufbau der Objekte vor
/// 
/// Um komplexere Datentypen darzustellen (u.a Person) benötigen wir Klassen
/// Die Klasse ist ein Bauplan für Objekte. In der Klasse werden nur Definitionen angelegt
/// 
/// WICHTIG: In der Klasse selber werden keine konkreten Werte definiert
/// Aus der Klasse können beliebig viele Objekte definiert werden
/// Die konkreten Werte werden in den Objekten definiert
/// Objekt p1: [25J, Max, Mustermann]
/// Objekt p2: [20J, Udo, Mustermann]
/// </summary>

internal class Program
{
    static void Main(string[] args)
    {
        // Objekt erstellen mithilfe des new-Keywords
        Person p1 = new Person();
        Person p2 = new Person();

        p2.SetVorname("Udo");
        p2.Nachname = "Mustermann";
        p2.Alter = 20;

        // Hier konkrete Werte der Person zuweisen
        p1.SetVorname("Max");
        p1.Nachname = "Mustermann";
        p1.Alter = 25;

        Console.WriteLine($"{p1.GetVorname()} {p1.Nachname} ist {p1.Alter}");

        Schulung s = new Schulung(p1, "Burghausen", Schulungstyp.Hybrid, 4, "C# Grundkurs", p1, p2 );
        s.NeueTeilnehmerHinzufuegen(new Person());
        Console.WriteLine($"Der Trainer: {s.Trainer.GetVorname()} {s.Trainer.Nachname}, der Ort: {s.Standort}, die Teilnehmer: {s.Teilnehmer[1].GetVorname()} {s.Teilnehmer[1].Nachname}");

        foreach(Person teilnehmer in s.Teilnehmer)
        {
            Console.WriteLine($"{teilnehmer.GetVorname()} {teilnehmer.Nachname}");
        }
    }
}