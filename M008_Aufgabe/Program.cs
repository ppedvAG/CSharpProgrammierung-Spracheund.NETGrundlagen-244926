// 1. Erstelle eine Basisklasse Fahrzeug, die folgende Eigenschaften hat:
// Modell(string) → Name des Fahrzeugs
// Preis (double) → Preis des Fahrzeugs
// Typ (Enum FahrzeugTyp) → Auto oder Motorrad
// Eine virtuelle Methode Info(), die die Fahrzeug-Details ausgibt

// 2️. Erstelle zwei abgeleitete Klassen:
// Auto: Hat zusätzlich die Eigenschaft Türen (Anzahl der Türen)
// Motorrad: Hat zusätzlich die Eigenschaft HatBeiwagen (bool, ob das Motorrad einen Beiwagen hat)

// 3️. Nutze das override-Schlüsselwort, um die Info()-Methode in den abgeleiteten Klassen individuell anzupassen.

// 4️. Erstelle ein Enum FahrzeugTyp, das zwei Werte enthält: Auto und Motorrad.

// 5️. Speichere mehrere Fahrzeuge in einem Array und gib ihre Informationen mit einer Schleife aus.

namespace Autohaus
{
    enum FahrzeugTyp
    {
        Auto,
        Motorrad
    }

    // Basisklasse erstellen
    class Fahrzeug
    {

        public string Modell { get; set; }
        public double Preis { get; set; }   
        public FahrzeugTyp Typ { get; set; }   // Enum hinzugefügt

        public Fahrzeug(string modell, double preis, FahrzeugTyp typ) 
        {
            Modell = modell;
            Preis = preis;
            Typ = typ;
        }

        // virtuelle Methode Info()
        public virtual string Info()
        {
            return $"Fahrzeugtyp: {Typ}, Modell: {Modell}, Preis: {Preis}€";
        }
    }

    // Abgeleitete Klasse Auto
    class Auto : Fahrzeug
    {
        public int Türen { get; set; }

        public Auto(string modell, double preis, FahrzeugTyp typ, int türen) : base(modell, preis, typ)
        {
            Türen = türen;
        }

        // Überschreiben von Info()
        public override string Info() 
        {
            return $"{base.Info()}, Türen: {Türen}";
        }
    }

    // Abgeleitete Klasse Motorrad
    class Motorrad : Fahrzeug
    {
        public bool HatBeiwagen { get; set; }
        public Motorrad(string modell, double preis, FahrzeugTyp typ, bool hatBeiwagen) : base(modell, preis, typ)
        {
            HatBeiwagen = hatBeiwagen;
        }

        // Überschreiben der Info()-Methode
        public override string Info()
        {
            string beiwagenText = HatBeiwagen ? "Ja" : "Nein";
            return $"{base.Info()}, Beiwagen: {beiwagenText}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Array mit verschiedenen Fahrzeugen
            Fahrzeug[] fahrzeuge = new Fahrzeug[]
            {
                new Auto("BMW 3er", 35000, FahrzeugTyp.Auto, 4),
                new Auto("VW Golf", 17500, FahrzeugTyp.Auto, 4),
                new Auto("Audi A4", 20000, FahrzeugTyp.Auto, 4),
                new Motorrad("Yamaha", 17000, FahrzeugTyp.Motorrad, false),
                new Motorrad("Harley", 40000, FahrzeugTyp.Motorrad, true),
            };

            // Ausgabe
            foreach (Fahrzeug f in fahrzeuge)
            {
                Console.WriteLine(f.Info());
            }
        }
    }
}