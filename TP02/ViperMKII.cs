using System;

namespace TP02
    
{
    //2.d
    public class ViperMKII : Spaceship
    {
        //2.d.1
        public ViperMKII()
        {
            Name = "Default Name";
            MaxStructure = 10;
            MaxShield = 15;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
            WeaponsList = new List<Weapon>();
            //2.d.1.c
            WeaponsList.Add(new Weapon("Mitrailleuse", 2, 3, Weapon.EWeaponType.Direct, 1));
            WeaponsList.Add(new Weapon("EMG", 1, 7, Weapon.EWeaponType.Explosive, 1.5));
            WeaponsList.Add(new Weapon("Missile", 4, 100, Weapon.EWeaponType.Guided, 4));
        }

        public ViperMKII(string name)
        {
            Name = name;
            MaxStructure = 10;
            MaxShield = 15;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
            WeaponsList = new List<Weapon>();
            //2.d.1.c
            WeaponsList.Add(new Weapon("Mitrailleuse", 2, 3, Weapon.EWeaponType.Direct, 1));
            WeaponsList.Add(new Weapon("EMG", 1, 7, Weapon.EWeaponType.Explosive, 1.5));
            WeaponsList.Add(new Weapon("Missile", 4, 100, Weapon.EWeaponType.Guided, 4));
        }

        //2.d.2
        public override void ShootTarget(Spaceship target)
        {
            Random random = new Random();
            Console.WriteLine("Vous passez a l'attaque ! ");

            if (WeaponsList.Count() != 0)
            {
                int randomWeapon = random.Next(0, WeaponsList.Count());
                target.TakeDamages(WeaponsList[randomWeapon].Shoot());
            }
            else { Console.WriteLine("Tu n'a pas d'arme mon ami\n"); }

        }

    }
}
