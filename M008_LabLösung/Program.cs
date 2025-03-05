﻿namespace Fahrzeugpark
{
    public class Fahrzeug
    {
        // Properties
        public string Name { get; set; }
        public int MaxGeschwindigkeit { get; set; }
        public int AktGeschwindigkeit { get; set; }
        public double Preis { get; set; }
        public bool MotorLauft { get; set; }

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
                this.MotorLauft = false;
                Console.WriteLine($"Der Motor von {this.Name} wurde gestoppt");
            }
        }

        public void Beschleunige(int a)
        {
            if (this.MotorLauft)
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

            // Instanzieren zuerst
            PKW pkw = new PKW("VW", 150, 10000, 5);
            Schiff schiff = new Schiff("Titanic", 40, 2500000, 2000);
            Flugzeug flugzeug = new Flugzeug("Boeing", 350, 90000000, 17000);

            // Ausgabe
            Console.WriteLine(pkw.Info());
            Console.WriteLine(schiff.Info());
            Console.WriteLine(flugzeug.Info());
        }
    }
    public class PKW : Fahrzeug
    {
        public int Sitzplaetze { get; set; }

        public PKW(string name, int maxGeschwindigkeit, double preis, int sitzplaetze) : base(name, maxGeschwindigkeit, preis)
        {
            Sitzplaetze = sitzplaetze;
        }

        public string Info()
        {
            return "Der PKW " + base.Info() + $" Er hat {this.Sitzplaetze} Türen.";
        }


    }

    public class Schiff : Fahrzeug
    {
        public double Tiefgang { get; set; }
        public Schiff(string name, int maxGeschwindigkeit, double preis, double tiefgang) : base(name, maxGeschwindigkeit, preis)
        {
            this.Tiefgang = tiefgang;
        }

        public string Info()
        {
            return "Das Schiff " + base.Info() + $" Es taucht in {this.Tiefgang}m Tiefe";
        }
    }

    public class Flugzeug : Fahrzeug
    {
        public int MaxFlughoehe { get; set; }
        public Flugzeug(string name, int maxGeschwindigkeit, double preis, int maxFlughoehe) : base(name, maxGeschwindigkeit, preis)
        {
            this.MaxFlughoehe = maxFlughoehe;
        }
        public string Info()
        {
            return "Das Flugzeug " + base.Info() + $" Es kann bis auf {this.MaxFlughoehe}m aufsteigen";
        }

    }
}