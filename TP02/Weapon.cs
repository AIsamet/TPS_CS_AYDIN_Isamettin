using System;

namespace TP02
    
{
    public class Weapon
    {
        public EWeaponType weaponType;

        public string name { get; private set; }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }

        //1.1 temps de rechargement qui se calculera en nombre de tour
        public double ReloadTime { get; private set; }
        //1.2 compteur de tours, il permettra de savoir si l’arme est utilisable ou si elle est entrain de recharger
        public double TimeBeforReload { get; set; }




        public Weapon(string nom, int minDamage, int maxDamage, EWeaponType type, double reloadTime)
        {
            name = nom;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            weaponType = type;
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
            return (name + " : dommages mini : " + MinDamage + ", dommages maxi : " + MaxDamage + ", type d'arme : " + weaponType + ", temps de rechargement : " + ReloadTime + ", tours avant rechargement : " + TimeBeforReload);
        }

        public int Shoot()
        {
            //3.a
            TimeBeforReload -= 1;
            if (TimeBeforReload < 0) { TimeBeforReload = 0; }

            //3.c         
            if (TimeBeforReload == 0)
            {
                Random random = new Random();
                int degats = random.Next(MinDamage, MaxDamage);

                //3.d.1    
                if (weaponType == EWeaponType.Direct)
                {
                    int chance = random.Next(1, 11); // creates a number between 1 and 11
                    if (chance == 1)
                    {
                        degats = 0;
                        Console.WriteLine("l'arme " + name + " a raté sa cible\n");
                        TimeBeforReload = ReloadTime;
                        return degats;
                    }
                    else
                    {
                        Console.WriteLine("l'arme " + name + " tire sur sa cible (degats estimés = " + degats + ")\n");
                        TimeBeforReload = ReloadTime;
                        return degats;
                    }
                }

                //3.d.2
                if (weaponType == EWeaponType.Explosive)
                {
                    int chance = random.Next(1, 5); // creates a number between 1 and 4
                    if (chance == 1)
                    {
                        degats = 0;
                        Console.WriteLine("l'arme " + name + " a raté sa cible\n");
                        TimeBeforReload = ReloadTime * 2;
                        return degats;
                    }
                    else
                    {
                        degats = degats * 2;
                        Console.WriteLine("l'arme " + name + " tire sur sa cible (degats estimés = " + degats + ")\n");
                        TimeBeforReload = ReloadTime * 2;
                        return degats;
                    }
                }

                //3.d.3
                if (weaponType == EWeaponType.Guided)
                {
                    degats = MinDamage;
                    Console.WriteLine("l'arme " + name + " tire sur sa cible (degats estimés = " + degats + ")\n");
                    TimeBeforReload = ReloadTime;
                    return degats;
                }
            }

            //3.b
            Console.WriteLine("L'arme " + name + " est entrain de recharger\nTours avant rechargement : " + TimeBeforReload + "\n");
            return 0;

        }
    }
}
