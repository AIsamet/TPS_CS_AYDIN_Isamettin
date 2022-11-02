using System;

namespace TP02

{
    public class Weapon : IWeapon
    {
        public string Name { get; set; }
        public EWeaponType Type { get; set; }
        public double MinDamage { get; set; }
        public double MaxDamage { get; set; }
        public double AverageDamage
        {
            get
            {
                return ((MinDamage + MaxDamage) / 2);
            }
        }

        //1.1 temps de rechargement qui se calculera en nombre de tour
        public double ReloadTime { get; set; }
        //1.2 compteur de tours, il permettra de savoir si l’arme est utilisable ou si elle est entrain de recharger
        public double TimeBeforReload { get; set; }
        public bool IsReload { get; }




        public Weapon(string nom, double minDamage, double maxDamage, EWeaponType type, double reloadTime)
        {
            Name = nom;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Type = type;
            //1.2
            ReloadTime = reloadTime;
            TimeBeforReload = ReloadTime;
        }

        public enum EWeaponType
        {
            Direct,
            Explosive,
            Guided
        }

        public override string ToString()
        {
            return (Name + " : dommages mini : " + MinDamage + ", dommages maxi : " + MaxDamage + ", type d'arme : " + Type + ", temps de rechargement : " + ReloadTime + ", tours avant rechargement : " + TimeBeforReload);
        }

        public double Shoot()
        {

            //1.3.a
            TimeBeforReload -= 1;
            if (TimeBeforReload < 0) { TimeBeforReload = 0; }

            //1.3.c         
            if (TimeBeforReload == 0)
            {
                Random random = new Random();
                double degats = (random.NextDouble() * (MaxDamage - MinDamage) + MinDamage);

                //1.3.d.1    
                if (Type == EWeaponType.Direct)
                {
                    int chance = random.Next(1, 11); // creates a number between 1 and 11
                    if (chance == 1)
                    {
                        degats = 0;
                        Console.WriteLine("l'arme " + Name + " a raté sa cible\n");
                        TimeBeforReload = ReloadTime;
                        return degats;
                    }
                    else
                    {
                        Console.WriteLine("l'arme " + Name + " tire sur sa cible (degats estimés = " + degats + ")\n");
                        TimeBeforReload = ReloadTime;
                        return degats;
                    }
                }

                //1.3.d.2
                if (Type == EWeaponType.Explosive)
                {
                    int chance = random.Next(1, 5); // creates a number between 1 and 4
                    if (chance == 1)
                    {
                        degats = 0;
                        Console.WriteLine("l'arme " + Name + " a raté sa cible\n");
                        TimeBeforReload = ReloadTime * 2;
                        return degats;
                    }
                    else
                    {
                        degats = degats * 2;
                        Console.WriteLine("l'arme " + Name + " tire sur sa cible (degats estimés = " + degats + ")\n");
                        TimeBeforReload = ReloadTime * 2;
                        return degats;
                    }
                }

                //1.3.d.3
                if (Type == EWeaponType.Guided)
                {
                    degats = MinDamage;
                    Console.WriteLine("l'arme " + Name + " tire sur sa cible (degats estimés = " + degats + ")\n");
                    TimeBeforReload = ReloadTime;
                    return degats;
                }
            }

            //1.3.b
            Console.WriteLine("L'arme " + Name + " est entrain de recharger\nTours avant rechargement : " + TimeBeforReload + "\n");
            return 0;

        }
    }
}
