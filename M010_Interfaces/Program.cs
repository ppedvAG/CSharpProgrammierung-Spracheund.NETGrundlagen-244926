namespace M010_Interfaces;

internal class Program
{
    static void Main(string[] args)
    {
        Smartphone s = new Smartphone();
        Weltkarte w = new Weltkarte();

        IAufladbar[] aufladbars = [s, w];

        aufladbars[0].Maximum = 100;
        aufladbars[0].Aufladen(50);
        aufladbars[0].PrintLadezustand();

        aufladbars[1].Maximum = 100;
        aufladbars[1].Aufladen(85);
        aufladbars[1].PrintLadezustand();

        // Wie kann ich prüfen, ob eine Klasse ein Interface hat
        if (s is IAufladbar)
        {
            // Typvergleich mit is
        }

    }
}

public interface IAufladbar
{
    int Ladezustand { get; set; }
    int Maximum {  get; set; }
    public void Aufladen(int x);
    public void PrintLadezustand();
    public double MaxProzent();
}

public class Smartphone : IAufladbar
{
    public int Ladezustand { get; set; }
    public int Maximum { get; set; }
    public void Aufladen(int x)
    {
        if (Ladezustand + x > Maximum || Ladezustand + x < 0)
            return;
        Ladezustand += x;
    }
    public void PrintLadezustand()
    {
        Console.WriteLine($"Das Smartphone ist zu {MaxProzent() * 100}% geladen");
    }
    public double MaxProzent()
    {
        return (double)Ladezustand / Maximum;
    }
}

public class Weltkarte : Smartphone, IAufladbar
{
    public int Ladezustand { get; set; }
    public int Maximum { get; set; }
    public void Aufladen(int x)
    {
        if (Ladezustand + x > Maximum || Ladezustand + x < 0)
            return;
        Ladezustand += x;
    }
    public void PrintLadezustand()
    {
        Console.WriteLine($"Das Smartphone ist zu {MaxProzent() * 100}% geladen");
    }
    public double MaxProzent()
    {
        return (double)Ladezustand / Maximum;
    }
}