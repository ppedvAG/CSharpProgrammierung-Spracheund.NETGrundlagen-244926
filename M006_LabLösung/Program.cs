namespace Fahrzeugpark
{
    public class Fahrzeug
    {
        // Properties
        private string Name { get; set; }
        private int MaxGeschwindigkeit {  get; set; }  
        private int AktGeschwindigkeit { get; set; }
        private double Preis {  get; set; } 
        private bool MotorLauft {  get; set; }

        public Fahrzeug(string name, int maxGeschwindigkeit, double preis)
        {
            Name = name;
            MaxGeschwindigkeit = maxGeschwindigkeit;
            AktGeschwindigkeit = 0;
            Preis = preis;
            MotorLauft = false;
        }

        public string Info()
        {
            if (this.MotorLauft)
            {
                return $"{this.Name} kostet {this.Preis} und fährt momentan mit {this.AktGeschwindigkeit} von maximal {this.MaxGeschwindigkeit}km/h";
            }
            else
            {
                return $"{this.Name} kostet {this.Preis} und könnte maximal {this.MaxGeschwindigkeit}km/h fahren";
            }
        }

        public void StarteMotor()
        {
            if (this.MotorLauft)
            {
                Console.WriteLine($"Der Motor von {this.Name} läuft bereits");
            }
            else
            {
                this.MotorLauft = true;
                Console.WriteLine($"Der motor von {this.Name} wurde gestartet");
            }
        }

        public void StoppeMotor()
        {
            if (!this.MotorLauft)
            {
                Console.WriteLine($"Der Motor von {this.Name} ist bereits gestoppt");
            } 
            else if (this.AktGeschwindigkeit > 0)
                Console.WriteLine($"Der Motor kann nicht gestoppt werden, da sich {this.Name} noch bewegt");
            else
            {
                this.MotorLauft= false;
                Console.WriteLine($"Der Motor von {this.Name} wurde gestoppt");
            }
        }

        public void Beschleunige(int a)
        {
            if(this.MotorLauft)
            {
                if (this.AktGeschwindigkeit + a > this.MaxGeschwindigkeit)
                    this.AktGeschwindigkeit = this.MaxGeschwindigkeit;
                else if (this.AktGeschwindigkeit + a < 0)
                    this.AktGeschwindigkeit = 0;
                else 
                    this.AktGeschwindigkeit += a;

                Console.WriteLine($"{this.Name} bewegt sich jetzt mit {this.AktGeschwindigkeit}km/h");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fahrzeug fz1 = new Fahrzeug("BMW", 240, 50000);
            Console.WriteLine(fz1.Info() + "\n");

            fz1.StarteMotor();
            fz1.Beschleunige(120);
            Console.WriteLine(fz1.Info() + "\n");

            fz1.Beschleunige(300);
            Console.WriteLine(fz1.Info() + "\n");

            fz1.StoppeMotor();
            Console.WriteLine(fz1.Info() + "\n");

            fz1.Beschleunige(-500);
            fz1.StoppeMotor();
            Console.WriteLine(fz1.Info() + "\n");
        }
    }
}