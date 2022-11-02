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
            Structure = 10;
            Shield = 3;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            //Weapons = new List<Weapon>();
            Weapons.Add(new Weapon("Rayon laser", 2, 3, Weapon.EWeaponType.Direct, 2));
        }

        public Dart(string name)
        {
            Name = name;
            Structure = 10;
            Shield = 3;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            //Weapons = new List<Weapon>();
            Weapons.Add(new Weapon("Rayon laser", 2, 3, Weapon.EWeaponType.Direct, 2));
        }

        //2.a.2
        public override void ShootTarget(Spaceship target)
        {
            Random random = new Random();
            Console.WriteLine("Vous passez a l'attaque ! ");

            if (Weapons.Count() != 0)
            {
                int randomWeapon = random.Next(0, Weapons.Count());

                if (Weapons[randomWeapon].Type == Weapon.EWeaponType.Direct)
                {
                    Weapons[randomWeapon].TimeBeforReload = 1;
                }

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
