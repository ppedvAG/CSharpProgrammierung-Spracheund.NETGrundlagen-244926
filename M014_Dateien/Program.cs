using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace M014_Dateien;

internal class Program
{
    static void Main(string[] args)
    {
        // Grundlegende Klassen
        // Path, Directory, File

        // Aufgabe: Ordner erstellen, und in dieser Datei möchte ich "Hallo Welt" reinschreiben

        // 1. Pfad + Ordner erstellen
        // Pfade werden als Strings dargestellt
        string folderPath = "Test"; 
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // 2. Pfad zur Datei + Datei erstellen
        string filePath = Path.Combine(folderPath, "Test.Txt"); // Combine ist Plattformunabhängig (\ oder /)
        File.WriteAllText(filePath, "Hallo Welt");

        // Stream
        // Pipe zu einer externen Ressource
        // Byte für Byte Daten schreiben/lesen
        // Basis für alle Kommunikation mit externen Ressourcen

        // Streamwriter
        // Vereinfachung für den Basic Stream, welcher schreiben kann
        StreamWriter writer = new StreamWriter(filePath);
        writer.WriteLine("Hallo");
        writer.WriteLine("Welt");

        // Streams sind Pipes, diese haben einen Buffer
        // Dieser Buffer muss niedergeschrieben werden
        writer.Flush(); // Flush() schreibt den Buffer in das File
        writer.Close(); // Die Close() Methode gibt den Zugriff auf das File wieder frei

        // StreamReader
        // Vereinfachung für den Basic Stream, welcher lesen kann
        StreamReader sr = new StreamReader(filePath);
        List<string> zeilen = new List<string>();
        while(!sr.EndOfStream)
        {
            zeilen.Add(sr.ReadLine());
        }
        sr.Close();

        // using-Block
        // Am Ende des Blocks wird der Stream automatisch geschlossen
        // Bei alles Klassen, welche mit externen Ressourcen interagieren, kann der Using-Block verwenet werden
        // Beispiele: StreamWriter/Reader, HttpClient, DbConnection, ...
        using(StreamWriter sw = new StreamWriter(filePath))
        {
            sw.WriteLine("Hallo2");
            sw.WriteLine("Welt2");
        }

        // using-Block
        // Funktioniert wie der using-Block darüber, wird aber erst am Ende der Methode geschlossen
        using StreamWriter sw2 = new StreamWriter(filePath);
        sw2.WriteLine("Hallo2");
        sw2.WriteLine("Welt2");


        // JSON & XML
        // Serialisierungsformate um Objekte aus dem Program zu bewegen (speichern, senden, ...)
        // Wird zw. mehreren Geräten/Anwendungen verwendet, damit diese kommunizieren können

        // JSON
        // In C# gibt es 2 große JSON Frameworks
        // System.Text.JSON (intern)
        // Newtonsoft.Json (extern)

        // System.Text.Json
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

        // Pfad öffnen, datei erstellen
        string jsonPath = Path.Combine(folderPath, "Test.json");

        JsonSerializerSettings options = new JsonSerializerSettings(); // Optionen setzen, beim schreiben/lesen von JSOn
        options.Formatting = Newtonsoft.Json.Formatting.Indented; // JSON Schön schreiben

        // Schreibe mir die Fahrzeugliste mit den Optionen in das JSON mit dem Json-Path
        string json = JsonConvert.SerializeObject(fahrzeuge, options); // Wichtig: Hier options mitgeben
        File.WriteAllText(jsonPath, json);

        string readJson = File.ReadAllText(jsonPath);
        Fahrzeug[] readFzg = JsonConvert.DeserializeObject<Fahrzeug[]>(readJson);

        // Xml
        string xmlPath = Path.Combine(folderPath, "Test.xml");
        
        XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType());
        //Console.WriteLine(fahrzeuge.GetType());
        using(StreamWriter xmlWriter = new StreamWriter(xmlPath))
        {
            xml.Serialize(xmlWriter, fahrzeuge);
        }

        // Read
        using (StreamReader xmlReader = new StreamReader(xmlPath))
        {
			List<Fahrzeug> readFzg2 = xml.Deserialize<List<Fahrzeug>>(xmlReader); //(List<Fahrzeug>) xml.Deserialize(xmlReader);
        }
    }
}
[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
    public int MaxV { get; set; }
    public FahrzeugMarke Marke { get; set;}
    public Fahrzeug(int maxV, FahrzeugMarke marke)
    {
        MaxV = maxV;
        Marke = marke;
    }
    public Fahrzeug() { }
}

public enum FahrzeugMarke
{
    Audi, BMW, VW
}

public static class XmlExtensions
{
    public static T Deserialize<T>(this XmlSerializer xml, TextReader s)
    {
        return (T)xml.Deserialize(s);
    }
}