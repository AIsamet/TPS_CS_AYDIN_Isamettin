using System;

namespace TP03

{
    public class Dart : Spaceship
    {
        public Dart()
        {
            Name = "Dart";
            Structure = 10;
            Shield = 3;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            Weapons.Add(new Weapon("Rayon laser", 2, 3, Weapon.EWeaponType.Direct, 2));
        }

        public Dart(string name)
        {
            Name = name;
            Structure = 10;
            Shield = 3;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            Weapons.Add(new Weapon("Rayon laser", 2, 3, Weapon.EWeaponType.Direct, 2));
        }

        public override void ShootTarget(Spaceship target)
        {
            Random random = new Random();
            DisplayAttackerProfile();

            if (Weapons.Count() != 0)
            {
                int randomWeapon = random.Next(0, Weapons.Count());

                //ne tient pas compte du temps de chargement si de type direct
                if (Weapons[randomWeapon].Type == Weapon.EWeaponType.Direct)
                {
                    Weapons[randomWeapon].TimeBeforReload = 1;
                }

                double degatsAttaque = Weapons[randomWeapon].Shoot();
                target.TakeDamages(degatsAttaque);

            }
            else { Console.WriteLine("Tu n'a pas d'arme mon ami\n"); }
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------\n");
        }

    }
}
