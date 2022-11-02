using System;

namespace TP02
    
{
    //2.b
    public class B_Wings : Spaceship
    {
        //2.b.1
        public B_Wings()
        {
            Name = "Default Name";
            MaxStructure = 30;
            MaxShield = 0;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
            WeaponsList = new List<Weapon>();
            WeaponsList.Add(new Weapon("Hammer", 1, 8, Weapon.EWeaponType.Explosive, 1.5));
        }

        public B_Wings(string name)
        {
            Name = name;
            MaxStructure = 30;
            MaxShield = 0;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
            WeaponsList = new List<Weapon>();
            WeaponsList.Add(new Weapon("Hammer", 1, 8, Weapon.EWeaponType.Explosive, 1.5));
        }

        //2.b.2
        public override void ShootTarget(Spaceship target)
        {
            Random random = new Random();
            Console.WriteLine("Vous passez a l'attaque ! ");

            if (WeaponsList.Count() != 0)
            {
                int randomWeapon = random.Next(0, WeaponsList.Count());

                if (WeaponsList[randomWeapon].weaponType == Weapon.EWeaponType.Explosive)
                {
                    WeaponsList[randomWeapon].TimeBeforReload = 1;
                }
                target.TakeDamages(WeaponsList[randomWeapon].Shoot());
            }
            else { Console.WriteLine("Tu n'a pas d'arme mon ami\n"); }
        }
    }
}
