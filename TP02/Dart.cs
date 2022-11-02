using System;

namespace TP02
    
{
    //2.a
    public class Dart : Spaceship
    {
        //2.a.1
        public Dart()
        {
            Name = "Default Name";
            MaxStructure = 10;
            MaxShield = 3;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
            WeaponsList = new List<Weapon>();
            WeaponsList.Add(new Weapon("Rayon laser", 2, 3, Weapon.EWeaponType.Direct, 2));
        }

        public Dart(string name)
        {
            Name = name;
            MaxStructure = 10;
            MaxShield = 3;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
            WeaponsList = new List<Weapon>();
            WeaponsList.Add(new Weapon("Rayon laser", 2, 3, Weapon.EWeaponType.Direct, 2));
        }

        //2.a.2
        public override void ShootTarget(Spaceship target)
        {
            Random random = new Random();
            Console.WriteLine("Vous passez a l'attaque ! ");

            if (WeaponsList.Count() != 0)
            {
                int randomWeapon = random.Next(0, WeaponsList.Count());

                if (WeaponsList[randomWeapon].weaponType == Weapon.EWeaponType.Direct)
                {
                    WeaponsList[randomWeapon].TimeBeforReload = 1;
                }
                target.TakeDamages(WeaponsList[randomWeapon].Shoot());
            }
            else { Console.WriteLine("Tu n'a pas d'arme mon ami\n"); }
        }
    }
}
