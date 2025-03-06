using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M009_Polymorphismus;

public class Lebewesen
{
    public int Alter {  get; set; } 
    public Lebewesen(int alter) 
    {
        Alter = alter;
    }

    public virtual void Bewegen(int distanz)
    {
        Console.WriteLine($"Lebewesen bewegt sich um {distanz}m");
    }
}
