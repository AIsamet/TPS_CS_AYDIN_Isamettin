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
            Structure = 10;
            Shield = 15;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            //Weapons = new List<Weapon>();
            //2.d.1.c
            Weapons.Add(new Weapon("Mitrailleuse", 2, 3, Weapon.EWeaponType.Direct, 1));
            Weapons.Add(new Weapon("EMG", 1, 7, Weapon.EWeaponType.Explosive, 1.5));
            Weapons.Add(new Weapon("Missile", 4, 100, Weapon.EWeaponType.Guided, 4));
        }

        public ViperMKII(string name)
        {
            Name = name;
            Structure = 10;
            Shield = 15;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            //Weapons = new List<Weapon>();
            //2.d.1.c
            Weapons.Add(new Weapon("Mitrailleuse", 2, 3, Weapon.EWeaponType.Direct, 1));
            Weapons.Add(new Weapon("EMG", 1, 7, Weapon.EWeaponType.Explosive, 1.5));
            Weapons.Add(new Weapon("Missile", 4, 100, Weapon.EWeaponType.Guided, 4));
        }

        //2.d.2
        public override void ShootTarget(Spaceship target)
        {
            Random random = new Random();
            Console.WriteLine("Vous passez a l'attaque ! ");

            if (Weapons.Count() != 0)
            {
                int randomWeapon = random.Next(0, Weapons.Count());
                if (target is Rocinante)
                {
                    target.TakeDamagesRocinante(Weapons[randomWeapon]);
                }
                else
                {
                    target.TakeDamages(Weapons[randomWeapon].Shoot());
                }
            }
            else { Console.WriteLine("Tu n'a pas d'arme mon ami\n"); }
        }

    }
}
