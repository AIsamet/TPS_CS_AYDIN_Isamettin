using System;

namespace TP03

{
    public class B_Wings : Spaceship
    {
        public B_Wings()
        {
            Name = "B_Wings";
            Structure = 30;
            Shield = 0;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            Weapons.Add(new Weapon("Hammer", 1, 8, Weapon.EWeaponType.Explosive, 1.5));
        }

        public B_Wings(string name)
        {
            Name = name;
            Structure = 30;
            Shield = 0;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            Weapons.Add(new Weapon("Hammer", 1, 8, Weapon.EWeaponType.Explosive, 1.5));
        }

        public override void ShootTarget(Spaceship target)
        {
            Random random = new Random();
            DisplayAttackerProfile();

            if (Weapons.Count() != 0)
            {
                int randomWeapon = random.Next(0, Weapons.Count());

                //ne tient pas compte du temps de chargement si de type explosive
                if (Weapons[randomWeapon].Type == Weapon.EWeaponType.Explosive)
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
