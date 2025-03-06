namespace M011_Generic;

// Generischer Datentyp (Generic)

// Platzhalter für ein konkreten Typ
// Platzhalter wird generell als "T" bezeichnet
// Wenn hier ein konkretet Typ eingesetzt wird, werden alle Vorkommnisse von T mit diesem Typ ausgetauscht

internal class Program
{
    static void Main(string[] args)
    {
        // List
        // Kann eine beliebige Menge an Daten halten
        // Flexibler als Array
        // Der generische Datentyp, in der spitzen Klammer, gibt den Datentyp, welcher in der Liste gespeichert werden soll
        List<int> list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);

        // Liste iterieren (rüber gehen) wie ein Array
        foreach (int i in list)
        {
            Console.WriteLine($"Listelement: {i}");
        }

        // Index wie bei Array
        Console.WriteLine(list[1]);

        if (list.Contains(3))
        {
            Console.WriteLine("Es enthält die 3");
        }

        // String Liste
        List<string> strList = new List<string>();
        strList.Add("A");
        strList.Add("B");
        strList.Add("C");
        strList.Add("D");
        strList.Add("E");

        foreach (string str in strList)
            Console.WriteLine($"StringListe: {str}");

        // Dictionary
        // Liste von Schlüssel-Wert-Paaren
        // Jeder Schlüssel hat einen angehängten Wert
        // Das Dictionary hat zwei Generics (1: Schlüssel, 2. Wert)
        Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();

        keyValuePairs.Add(1, "Wien");
        keyValuePairs.Add(2, "Berlin");
        keyValuePairs.Add(3, "Paris");

        // WICHTIG!: Schlüssel müssen eindeutig sein
        // Dürfen keine doppelten Keys beinhalten

        // Gibt es in dem Dictionary einen Key mit "1", wenn Ja, dann hol mir den Wert davon raus
        if (keyValuePairs.ContainsKey(1))
            Console.WriteLine(keyValuePairs[1]); // Wert hinter Schlüssel entnehmen

        // Wie ich mithilfe eines Foreach, alles Key,Value paare mir rausgeben?
        foreach (KeyValuePair<int, string> pair in keyValuePairs)
        {
            Console.WriteLine($"Die Nummer {pair.Key} hat als Wert {pair.Value}.");
        }

        if(keyValuePairs.ContainsValue("Wien"))
            Console.WriteLine(keyValuePairs[1]);

        // Stack
        Stack<string> stacking = new Stack<string>();
        stacking.Push("Element 1"); // Element eintragen
        stacking.Peek(); // oberstes ausgeben
        stacking.Pop(); // oberstes ausgeben & löschen

        Queue<string> queue = new Queue<string>();
        queue.Enqueue("A"); // Element hinzufügen
        queue.Peek(); // ältestes Element ausgeben
        queue.Dequeue(); // ältestes Element ausgeben & löschen
    }
}