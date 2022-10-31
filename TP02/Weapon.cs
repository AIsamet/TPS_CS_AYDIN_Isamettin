using System;
namespace Aydin_Isamettin_Tp1
{
    public class Weapon
    {
        public EWeaponType weaponType;

        public string name { get; private set; }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }

        //1.1 temps de rechargement qui se calculera en nombre de tour
        public int ReloadTime { get; private set; }
        //1.2 compteur de tours, il permettra de savoir si l’arme est utilisable ou si elle est entrain de recharger
        public int TimeBeforReload { get; private set; }




        public Weapon(string nom, int minDamage, int maxDamage, EWeaponType type, int reloadTime)
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
            return (name + " : dommages mini : " + MinDamage + ", dommages maxi : " + MaxDamage + ", type d'arme : " + weaponType);
        }

        public int Shoot()
        {
            //3.a
            TimeBeforReload -= 1;

            //3.c         
            if (TimeBeforReload == 0)
            {
                Random random = new Random();
                int degats = random.Next(MinDamage, MaxDamage);

                //3.d.1    
                if (weaponType == EWeaponType.Direct)
                {
                    int chance = random.Next(1, 10);
                    if (chance == 1)
                    {
                        degats = 0;
                        Console.WriteLine("l'arme " + name + " a raté sa cible degats = " + degats);
                        return degats;
                    }
                    else
                    {
                        Console.WriteLine("l'arme " + name + " a touché sa cible degats = " + degats);
                        return degats;
                    }
                    TimeBeforReload = ReloadTime;
                }

                //3.d.2
                if (weaponType == EWeaponType.Explosive)
                {
                    int chance = random.Next(1, 4);
                    if (chance == 1)
                    {
                        degats = 0;
                        Console.WriteLine("l'arme " + name + " a raté sa cible degats = " + degats);
                        return degats;
                    }
                    else
                    {
                        degats = degats * 2;
                        Console.WriteLine("l'arme " + name + " a touché sa cible degats = " + degats);
                        return degats;
                    }
                    TimeBeforReload = ReloadTime * 2;
                }

                //3.d.3
                if (weaponType == EWeaponType.Guided)
                {
                    degats = MinDamage;
                    Console.WriteLine("l'arme " + name + " a touché sa cible degats = " + degats);
                    return degats;

                    TimeBeforReload = ReloadTime * 3;
                }
            }

            //3.b
            Console.WriteLine("L'arme " + name + " est entrain de recharger : degats = 0 ");
            return 0;

        }
    }
}
