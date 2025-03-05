namespace M006_OOP_Klassen_Objekte.Data;

// - Vorname - string
// - Nachname - string
// - Größe - double
// - Alter - int
public class Person
{
    #region Feld
    // Feld
    // Dieses Feld hält einen Wert (hier Vorname)
    // Felder sollten nur indirekt angegriffen werden können
    // Durch den private Modifier kann das Feld nicht von außerhalb der Klasse angegriffen werden
    // Beispiel: Verhindern, dass der User hier beliebige Texte eintragen kann (z. B Zahlen)
    private string vorname;

    // Die Get-Methode wird verwendet, um den Wert aus einem Feld auszulesen
    public string GetVorname()
    {
        return vorname;
    }

    // Die Set-Methode wird verwendet, um neue Werte in das Feld einzutragen
    // this.vorname bezieht sich auf das Feld weiter oben (in Z. 15)
    // vorname bezieht sich auf dne Parameter innerhalb dieser Methode
    public void SetVorname(string vorname)
    {
        // this: Wird verwendet, um gleichnamige Variablen voneinander zu unterscheiden
        this.vorname = vorname;
    }
    #endregion

    #region Eigenschaften

    // Eigenschaft (Property)
    // Vereinfachung von dem alten Get-/Setmethoden Schema
    
    private string nachname { get; set; }
    public int Alter {  get; set; } 

    // Full Property
    // Das Full Property ist ein Property mit einem privaten Feld + einem public Property mit get und set Accessoren
    public string Nachname
    {
        get
        {
            return nachname;
        }
        set
        {
            nachname = value;
        }
    }

    #endregion

    #region Konstruktor

    // Konstruktor
    // "Main Methode" von der Klasse
    // Wird beim Erstellen von einem Objekt ausgeführt
    // Der Standardkonstruktor existiert immer, wenn kein andere Konstruktor definiert ist

    public Person()
    {
        Console.WriteLine("Person erstellt");
    }

    // Hier können jetzt Standardwerte bei Initialisierung übergeben werden
    public Person(string vorname, string nachname) : this() // this() bezieht sich auf Person()
    {
        this.vorname = vorname;
        this.nachname = nachname;
    }

    // Verkettung von Konstruktoren
    // Mithilfe von this(...) können Konstruktoren miteinander verkettet werden
    // D.h wenn dieser Konstruktor ausgeführt wird, wird auch der Kosntruktor in der Kette darüber ausgeführt
    public Person(string vorname, string nachname, int alter) : this(vorname, nachname) // -> bezieht sich auf Person darüber
    {
        Alter = alter;
    }


    #endregion
}
