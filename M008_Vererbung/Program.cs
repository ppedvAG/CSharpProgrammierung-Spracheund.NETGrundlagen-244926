namespace M008_Vererbung;

internal class Program
{
    static void Main(string[] args)
    {
        Mensch m = new Mensch(30, "Max");
        m.Alter = 30; // Alter wird vererbt
        m.Bewegen(10); // Bewegen wird vererbt
    }
}

public class Lebewesen
{
    public int Alter { get; set; }

    // virtual & override
    // eine mit virtual gekennzeichnete Methode kann in den Unterklassen überschrieben werden
    // Normale Methoden können nicht überschrieben werden
    // Mithilfe des override Keywords kann eine Überschreibung erzeugt werden
    public virtual void Bewegen(int distanz)
    {
        Console.WriteLine($"Lebewesen bewegt sich um {distanz}m");
    }


    // Wenn ein Konstruktor in der Oberklasse definiert ist, muss jede Unterklasse einen verketteten Konstruktor enthalten
    public Lebewesen(int alter)
    {
        this.Alter = alter;
    }   
}

public class Mensch : Lebewesen
{
    public string Name { get; set; }
    // Strg + . => Generate Constructor
    // Wenn dieser Konstruktor weitere Felder enthalten soll, können diese hier einfach hinzugefügt werden
    public Mensch(int alter, string name) : base(alter)
    {
        this.Name = name;
    }

    // override eintippen -> Abstand -> Methode auswählen -> Enter
    public sealed override void Bewegen(int distanz)
    {
        Console.WriteLine($"{Name} bewegt sich um {distanz}m");
    }
}

public class Kind : Mensch
{
    public Kind(int alter, string name) : base(alter, name)
    {
    }

    public override void Bewegen(int distanz)
    {
        Console.WriteLine($"{Name} bewegt sich um {distanz}m");
    }

}