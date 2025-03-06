using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M009_Polymorphismus;

public class Mensch : Lebewesen
{
    public string Name { get; set; }
    public Mensch(int alter, string name) : base(alter)
    {
        Name = name;
    }

    public override void Bewegen(int distanz)
    {
        Console.WriteLine($"{Name} bewegt sich um {distanz}m");
    }
}
