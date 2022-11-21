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

        public double ReloadTime { get; set; }
        
        public double TimeBeforReload { get; set; }
        
        public bool IsReload
        {
            get
            {
                if (TimeBeforReload == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }




        public Weapon(string nom, double minDamage, double maxDamage, EWeaponType type, double reloadTime)
        {
            Name = nom;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Type = type;
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

            TimeBeforReload -= 1;
            if (TimeBeforReload < 0) { TimeBeforReload = 0; }

            if (IsReload)
            {
                Random random = new Random();
                double degats = Math.Round((random.NextDouble() * (MaxDamage - MinDamage) + MinDamage),1);

                if (Type == EWeaponType.Direct)
                {
                    int chance = random.Next(1, 11); //crée un nombre entre 1 et 10
                    if (chance == 1) //cas du 1/10 chance de rater
                    {
                        degats = 0;
                        Console.WriteLine("L'arme " + Name + " a raté sa cible\n");
                        TimeBeforReload = ReloadTime;
                        return degats;
                    }
                    else
                    {
                        //degats 'estimés' car il peuvent etre evités notament dans le cas de Rocinante
                        Console.WriteLine("L'arme " + Name + " tire sur sa cible (degats estimés = " + degats + ")\n");
                        TimeBeforReload = ReloadTime;
                        return degats;
                    }
                }

                else if (Type == EWeaponType.Explosive)
                {
                    int chance = random.Next(1, 5); //crée un nombre entre 1 et 4
                    if (chance == 1) //cas du 1/4 chance de rater
                    {
                        degats = 0;
                        Console.WriteLine("L'arme " + Name + " a raté sa cible\n");
                        TimeBeforReload = ReloadTime * 2;
                        return degats;
                    }
                    else
                    {
                        degats = degats * 2;
                        Console.WriteLine("L'arme " + Name + " tire sur sa cible (degats estimés = " + degats + ")\n");
                        TimeBeforReload = ReloadTime * 2;
                        return degats;
                    }
                }

                else if (Type == EWeaponType.Guided)
                {
                    degats = MinDamage;
                    Console.WriteLine("L'arme " + Name + " tire sur sa cible (degats estimés = " + degats + ")\n");
                    TimeBeforReload = ReloadTime;
                    return degats;
                }
            }

            Console.WriteLine("L'arme " + Name + " est entrain de recharger (tours avant rechargement : " + TimeBeforReload + ")\n");
            return 0;

        }
    }
}
