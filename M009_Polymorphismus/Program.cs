namespace M009_Polymorphismus;

internal class Program
{
    static void Main(string[] args)
    {
        // Polymorphismus
        // -> Typkompatibilität
        // Welche Typen passen mit welchen anderen Typen zusammen

        // Jeder Typ ist immer mit seinen Oberklassen kompatibel
        Lebewesen lw = new Mensch(30, "Max");
        lw.Bewegen(50);

        // Lebewesen kann nicht in ein Mensch umgewandelt werden
        // Mensch m = new Lebewesen(30);

        if (lw.GetType() == typeof(Mensch))
        {
            Console.WriteLine("True\n");
        }

        if (lw.GetType() == typeof(Lebewesen))
        {
            Console.WriteLine("False");
        }

        Lebewesen lebewesen = new Lebewesen(20);
        Mensch mensch = new Mensch(20, "Peter");

        if(lebewesen is Lebewesen)
            Console.WriteLine("True");
        if(lebewesen is Mensch)
            Console.WriteLine("True");
        if(mensch is Lebewesen)
            Console.WriteLine("True");
        if(mensch is Mensch)
            Console.WriteLine("True");
        if (mensch is object)
            Console.WriteLine("Ture");

        // GetType()
        // Gibt den Typen hinter einem Objekt zurück (welches an der Variablen hängt)
        // GetType() kann bei jedem beliebigen Objekt verwendet werden
        lebewesen.GetType();
        Console.WriteLine(lebewesen.GetType()); // M009_Polymorphismus.Lebewesen

        //typeof()
        // Gibt den Typen hinter einem Namen zurück (Klassenname, Structname, Enumname ...)
        // Funktioniert nicht bei variablennamen
        Type ltype = typeof(Lebewesen);
        Console.WriteLine(ltype);

    }
}